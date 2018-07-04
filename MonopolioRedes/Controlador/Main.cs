using System;
using System.IO.Ports;
using MonopolioRedes.Vista;
using System.Windows.Forms;


using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonopolioRedes.Modelo;

namespace MonopolioRedes.Controlador
{
    public class Main
    {
        Random rand = new Random();
        public Connection serial_port;
        public Juego JuegoActual;
        public Ventana_Juego Juego_Form;


        public void Set_SerialPort(Connection _sp)
        {
            serial_port = _sp;
        }

        public Jugador CrearJugador(int i)
        {
            Jugador _player = new Jugador(i);
            return _player;
        }

        public void Procesar_Ventana_Juego(Ventana_Inicio Main_Form, Juego Juego_Actual)
        {
            Main_Form.Visible = false;
            Ventana_Juego V_Juego = new Ventana_Juego(Juego_Actual, Main_Form, this);
            serial_port.Set_Juego_Form(V_Juego);
            V_Juego.Visible = true;
            Juego_Form = V_Juego;
            Global_Variable.Juego_Iniciado = true; //activa el hilo de la siguiente ventana
            Juego_Form.MostrarJugadores();
        }

        public Juego CrearJuego(List<Jugador> Jugadores)
        {
            Juego.ObtenerJuego.JugadoresConectados = Jugadores;
   
            foreach(Jugador jugador in Jugadores)
            {
                Juego.ObtenerJuego.AsignarFichaJugador(jugador);
            }

            return Juego.ObtenerJuego;
        }

        public void LanzarDado(Jugador jugador)
        {
            jugador.Realizar_Jugada();

            Juego_Form.ActualizarFicha(jugador);

            int byte_3 = EnviarDados(); 

            int id_destino = Juego.ObtenerJuego.get_id_destino(jugador.Id);

            int direccion = get_direccion(jugador.Id, id_destino);

            int control = get_control(Global_Variable.control_tirarDados);

            int byte_2 = direccion + control;

            serial_port.Enviar_trama(byte_2, byte_3);

            

        }

        public int get_direccion(int id_origen, int id_destino)
        {
            string dir_or = Convert.ToString(id_origen, 2).PadLeft(2, '0');
            dir_or = dir_or.PadRight(8, '0');
            string dir_dest = Convert.ToString(id_destino, 2).PadLeft(4, '0');
            dir_dest = dir_dest.PadRight(8, '0');
            int int_diror = Convert.ToInt32(dir_or, 2);
            int int_dirde = Convert.ToInt32(dir_dest, 2);
            return (int_diror + int_dirde);
        }

        public int get_control(string _control)
        {
            int control = Convert.ToInt32(_control.PadLeft(8, '0'), 2);
            return control;
        }

        public int get_destino(string byte_2)
        {
            string dir_de = byte_2.Substring(2, 2);
            int id_destino = Convert.ToInt32(dir_de, 2);
            return id_destino;
        }

        public int get_origen(string byte_2)
        {
            string dir_or = byte_2.Substring(0, 2);
            int id_origen = Convert.ToInt32(dir_or, 2);
            return id_origen;
        }

        public int EnviarDados()
        { 

            string dado_1 = Convert.ToString(Dado.Dado_1, 2).PadLeft(5,'0');

            dado_1 = dado_1.PadRight(8, '0');

            string dado_2 = Convert.ToString(Dado.Dado_2, 2).PadLeft(8, '0');

            int byte_3 = 128 + Convert.ToInt32(dado_1, 2) + Convert.ToInt32(dado_2, 2);

            return byte_3;
        }

        public void ActualizarPosicionJugador(int idOrigen, int idDestino, string byte_3)
        {
            string dado_1 = byte_3.Substring(2, 3);
            string dado_2 = byte_3.Substring(5, 3);

            Dado.Dado_1 = Convert.ToInt32(dado_1,2);
            Dado.Dado_2 = Convert.ToInt32(dado_2,2);

            int resultado_dado = Dado.Dado_1 + Dado.Dado_2;

            Jugador _jugador = Juego.ObtenerJuego.JugadoresConectados.Find(x => x.Id == idOrigen);
            Jugador _jugadorDestino = Juego.ObtenerJuego.JugadoresConectados.Find(x => x.Id == idDestino);

            _jugador.Calcular_Posicion(resultado_dado);

            Juego_Form.ActualizarFicha(_jugador);

            _jugador.Turno_Activo = false;
            _jugadorDestino.Turno_Activo = true;

            if(idDestino == Juego_Form._jugadorPrincipal.Id)
            {
                MessageBox.Show("Es tu turno!");
                Juego_Form.HabilitarBotonDado();
            }
            else
            {
                MessageBox.Show("Es el turno del jugador: " + _jugadorDestino.Id);
            }

        }


    }
}