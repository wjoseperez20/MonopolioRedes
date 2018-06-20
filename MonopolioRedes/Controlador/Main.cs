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
        }

        public Juego CrearJuego(List<Jugador> Jugadores)
        {
           
      
            //Juego Juego_Actual =  ObtenerJuego();

         //   return Juego_Actual;
        }
    }
}