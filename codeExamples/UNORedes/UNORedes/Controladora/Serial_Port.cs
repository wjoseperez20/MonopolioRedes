using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNORedes.Modelo;

namespace UNORedes.Controladora
{

    public class Seria_lPort
    {
        public SerialPort sp;
        private int reading_byte = 0,int_direccion, int_control, int_carta,int_sentido, int_byte3, int_byte2;
        private int i = 0; //contador de bytes por trama
        private int count_cartas = 0;
        private int[] total_flag = new int[10];
        private byte[] bytes_sending = new byte[20];
        private string byte_2 = "", byte_3 = "";
        Ventana_Inicio Inicio_Form;
        Ventana_Juego Juego_Form;
        Jugador Primer_Jugador = null;
        Jugador _Jugador = null;
        Control_App Controla;
        Game Juego_Actual = null;

        public void Start_Conection(Ventana_Inicio main_form, Control_App _control)
        {
            try
            {
                if (sp != null)
                    sp.Close();
                string port = main_form.tPuerto.Text.ToUpper();
                sp = new SerialPort(port, 1200, Parity.None, 8, StopBits.One);
                sp.Open();
                Controla = _control;
                Controla.Set_SerialPort(this);
                Inicio_Form = main_form;
                Inicio_Form.lInfo.Text = "Conexión establecida.";
                sp.DiscardOutBuffer();
                Recieve_Message(sp);
            }
            catch (Exception c)
            {
                MessageBox.Show("FATAL ERROR: " + c.ToString());
                if( sp != null)
                    sp.Close();
                if (main_form != null)
                    main_form.lInfo.Text = "Error de conexión.";
                if (Controla != null)
                    Controla = null;
            }
        }

        public void Set_Juego_Form(Ventana_Juego game_form)
        {
            Juego_Form = game_form;
        }

        public void Enviar_Peticion_InicioPartida(Jugador _jugador_Peticion)
        {
            try
            {
                Primer_Jugador = _jugador_Peticion;
                enviar_trama(Convert.ToInt32("00000001", 2), Convert.ToInt32("10000000", 2));
            }
            catch (Exception e)
            {
                Primer_Jugador = null;
                MessageBox.Show("ERROR: " + e.ToString());
            }
        }

        public void Recieve_Message(SerialPort sp)
        {
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp_sender = (SerialPort)sender;
                if (!sp_sender.IsOpen || !sp.IsOpen)
                    return;

                sp_sender.DiscardNull = false;

                while (sp_sender.BytesToRead > 0)
                {
                    reading_byte = sp_sender.ReadByte();
                    procesar_trama();

                }
                sp_sender.DiscardInBuffer();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void procesar_trama()
        {
            if (!Global_Variables.Juego_Iniciado)
                Inicio_Form.Invoke(new Action(() => trama_reading()));
            else
                Juego_Form.Invoke(new Action(() => trama_reading()));
        }

        private void trama_reading()
        {
            if (i == 0)
            {
                if (reading_byte == 126)
                {
                    total_flag[i] = reading_byte;
                    i++;
                    if (!Global_Variables.Juego_Iniciado)
                        trama_coming();
                }
                else
                {
                    total_flag[i] = reading_byte;
                    Trama_incorrecta();
                }
            }
            else
            {
                if (i == 3)
                {
                    if (reading_byte != 126)
                    {
                        total_flag[i] = reading_byte;
                        i = 0;
                        Trama_incorrecta();
                    }
                    else
                    {
                        total_flag[i] = reading_byte;
                        i = 0;
                        Trama_correcta();
                    }
                }
                else
                {
                    total_flag[i] = reading_byte;
                    i++;
                    if (!Global_Variables.Juego_Iniciado)
                        trama_coming();
                }
            }
        }

        private void trama_coming()
        {
            Inicio_Form.lInfo.Text = "Recibiendo posible trama ("+i.ToString()+"): "+reading_byte.ToString();
            Inicio_Form.bComenzar.Enabled = false;
        }


        private void ChangeStatus(bool trama_valida)
        {
            if (trama_valida)
            {
                int contador = 0, resto = 0;
                string bit_modo = "";
                Inicio_Form.lInfo.Text = "Trama recibida correctamente";
                byte_3 = Convert.ToString(total_flag[2], 2).PadLeft(8, '0');
                resto = Convert.ToInt32(byte_3,2);
                contador = Convert.ToInt32(byte_3.Substring(6, 2).PadLeft(8, '0'),2);
                bit_modo = byte_3.Substring(5, 1);

                if (Primer_Jugador != null)
                {
                    int bit_modo_int = Convert.ToInt32("00000100", 2);

                    enviar_trama(total_flag[1], (resto+bit_modo_int));
                    List<Jugador> Jugadores = new List<Jugador>();
                    Jugadores.Add(Primer_Jugador);
                    for (int i = 1; i <= contador; i++)
                    {
                        Jugador _newPlayer;
                        _newPlayer = Controla.CrearJugador(i, false, false);
                        Jugadores.Add(_newPlayer);
                    }
                    Juego_Actual = Controla.CrearJuego(Jugadores);
                    Controla.Procesar_Ventana_Juego(Inicio_Form, Juego_Actual);
                }
                else
                {
                    if (bit_modo.Equals("0"))
                    {
                        _Jugador = Controla.CrearJugador(contador + 1, false, true);
                        enviar_trama(total_flag[1], (resto + 1));
                    }
                    else
                    {
                        List<Jugador> Jugadores = new List<Jugador>();
                        Jugadores.Add(_Jugador);
                        for(int i = 0; i < _Jugador.ID; i++)
                        {
                            Jugador _newPlayer;
                            if(i == 0)
                                _newPlayer = Controla.CrearJugador(i, false, false); //turno activo jugador id = 0
                            else
                                _newPlayer = Controla.CrearJugador(i, false, false);
                            Jugadores.Add(_newPlayer);
                        }
                        for(int j = contador; j > _Jugador.ID; j--)
                        {
                            Jugador _NewPlayer;
                            _NewPlayer = Controla.CrearJugador(j, false, false);
                            Jugadores.Add(_NewPlayer);
                        }

                        reenviar_trama();
                        Juego_Actual = Controla.CrearJuego(Jugadores);
                        Controla.Procesar_Ventana_Juego(Inicio_Form, Juego_Actual);
                       
                    }
                }
            }
            else
            {
                Inicio_Form.lInfo.Text = "incorrecto (" + i.ToString() + "): " + reading_byte.ToString();
                Inicio_Form.bComenzar.Enabled = true;
            }
        }

    
        private void Carta_ToByte(Carta _carta)
        {

        }

        private void Jugar_Primera_Carta(Carta _carta)
        {
            int destino = Controla.get_turno_random();
            int_direccion = Controla.get_direccion(0, destino);
            int_control = Controla.get_control(Global_Variables.control_cartamesa);
            int_byte2 = int_direccion + int_control;
            int_carta = Controla.carta_to_int(_carta);
            int_sentido = Controla.sentido_to_int(Juego_Actual);
            int_byte3 = int_carta + int_sentido;
            Juego_Actual.Tablero = _carta;

            if(_carta.Tipo != Tipo_Carta.CambioColor)
            {
                Juego_Actual.color_actual = _carta.Color;
                Juego_Form.Color_Actual();
            }


            Juego_Actual.Jugadores.Find(j => j.ID == destino).Turno_Activo = true;

            if (destino != 0)
                Juego_Actual.Carta_Inicial = false;

            enviar_trama(int_byte2, int_byte3);
        }

        public void Pasar_Turno(int _player_id)
        {
            int id_destino;
            Global_Variables.Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
            count_cartas = 0;
            id_destino = Controla.get_id_destino(_player_id, false);
            int_direccion = Controla.get_direccion(_player_id, id_destino);
            int_control = Controla.get_control(Global_Variables.control_cartamesa);
            int_byte2 = int_direccion + int_control;

            int_carta = Controla.crear_carta_null();
            int_sentido = Controla.sentido_to_int(Juego_Actual);
            int_byte3 = int_carta + int_sentido;

            Controla.Actualizar_Turno(id_destino);
            Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);

            enviar_trama(int_byte2, int_byte3);
        }
        private void Jugar_Carta(Carta _carta, Game _Juego) 
        {
            int id_destino;
            Jugador _player = Juego_Actual.Jugadores.Find(J => J.Jugador_Principal == true);
            int id_origen = _player.ID;

            if (_carta.Tipo == Tipo_Carta.PierdeTurno)
                id_destino = Controla.get_id_destino(id_origen, true);
            else
                id_destino = Controla.get_id_destino(id_origen, false);

            int_direccion = Controla.get_direccion(id_origen, id_destino);
            int_control = Controla.get_control(Global_Variables.control_cartamesa);
            int_byte2 = int_direccion + int_control;

            int_carta = Controla.carta_to_int(_carta);
            int_sentido = Controla.sentido_to_int(_Juego);
            int_byte3 = int_carta + int_sentido;

            Controla.Borrar_Carta_Jugador(_carta, id_origen);
            Controla.Actualizar_Turno(id_destino);
            Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);

            enviar_trama(int_byte2, int_byte3);

            Ganar_Juego(_player);
        }
        private void Ganar_Juego(Jugador player)
        {
            if(player.Mano.Count < 1)
            {
                int_direccion = Controla.get_direccion(player.ID, player.ID);
                int_control = Controla.get_control(Global_Variables.control_victoria);
                int_byte2 = int_direccion + int_control;
                int_byte3 = 128;
                Juego_Form.Force_Disable_Turno();
                enviar_trama(int_byte2, int_byte3);
                MessageBox.Show("Felicidades, ¡ganaste la partida!");
            }
        }
        private void Tomar_Carta(Carta _carta, Game _Juego) //tomar carta del mazo
        {
            int_direccion = Controla.get_direccion(_Juego.Jugadores.Find(j => j.Jugador_Principal == true).ID, _Juego.Jugadores.Find(j => j.Jugador_Principal == true).ID);
            int_control = Controla.get_control(Global_Variables.control_cartamano);
            int_byte2 = int_direccion + int_control; //encapsular todo en el byte 2        
            int_carta = Controla.carta_to_int(_carta);
            int_sentido = Controla.sentido_to_int(_Juego);
            int_byte3 = int_carta + int_sentido;

            enviar_trama(int_byte2, int_byte3);

        }
        private void anunciar_cartas_inciales(int id_origen) //envia
        {
            int id_destino = Controla.get_id_destino(id_origen,false);
            int_direccion = Controla.get_direccion(id_origen,id_destino); 
            int_control = Controla.get_control(Global_Variables.control_cartainicial);
            int_byte2 = int_direccion + int_control;
            int_byte3 = Convert.ToInt32("10000000", 2);

            enviar_trama(int_byte2, int_byte3);

        }
        private bool id_equal_jugador(int id)
        {
            return (id == Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true).ID);
        }
        private string byte_to_string(int _byte)
        {
            string byte_string = Convert.ToString(_byte, 2).PadLeft(8, '0');
            return byte_string;
        }
        private void Penitencia_Activa(int id_usuario)
        {
            if (Global_Variables.Penitencia_Activa == Penitencia_Jugador.Siete_Cartas && count_cartas == 7)
            {
                count_cartas = 0;
                Global_Variables.Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
                anunciar_cartas_inciales(id_usuario);
                return;
            }
            if (Global_Variables.Penitencia_Activa == Penitencia_Jugador.Dos_Cartas && count_cartas == 2)
            {
                count_cartas = 0;
                Global_Variables.Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
                Pasar_Turno(id_usuario);
                return;
            }
            if (Global_Variables.Penitencia_Activa == Penitencia_Jugador.Una_Carta && count_cartas == 1)
            {
                count_cartas = 0;
                Global_Variables.Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
                return;
            }
            if (Global_Variables.Penitencia_Activa == Penitencia_Jugador.Cuatro_Cartas && count_cartas == 4)
            {
                count_cartas = 0;
                Global_Variables.Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
                Pasar_Turno(id_usuario);
                return;
            }
        }

        public void reenviar_trama()
        {
            Thread.Sleep(500);
            bytes_sending = new byte[4];
            bytes_sending[0] = Convert.ToByte(Convert.ToInt32(Global_Variables.bandera, 2));
            bytes_sending[1] = Convert.ToByte(total_flag[1]);
            bytes_sending[2] = Convert.ToByte(total_flag[2]);
            bytes_sending[3] = Convert.ToByte(Convert.ToInt32(Global_Variables.bandera, 2));
            sp.Write(bytes_sending, 0, 4);
        }
        public void enviar_trama(int byte_2, int byte_3)
        {
            Thread.Sleep(500);
            bytes_sending = new byte[4];
            bytes_sending[0] = Convert.ToByte(Convert.ToInt32(Global_Variables.bandera, 2));
            bytes_sending[1] = Convert.ToByte(byte_2);
            bytes_sending[2] = Convert.ToByte(byte_3);
            bytes_sending[3] = Convert.ToByte(Convert.ToInt32(Global_Variables.bandera, 2));
            sp.Write(bytes_sending, 0, 4);
        }
        private void Recibir_Carta_Mazo() //recibe
        {

            string  color;
            int numero;
            byte_2 = byte_to_string(total_flag[1]);
            byte_3 = byte_to_string(total_flag[2]);
            int id_usuario = Controla.get_origen(byte_2);

            if (id_equal_jugador(id_usuario))
            {
                count_cartas++;
                Penitencia_Activa(id_usuario);
                return;
            }
            numero = Controla.get_numero(byte_3);
            color = Controla.get_color(byte_3);
            Carta _carta = Controla.Crear_Carta(numero, color);
            Jugador _player = Controla.Get_jugador_byid(Juego_Actual, id_usuario); 
            //Jugador _player = Controla.Get_Jugador_Principal(Juego_Actual);
            Juego_Actual.Jugadores.Remove(_player);
            _player.Mano.Add(_carta);
            Juego_Actual = Controla.Borrar_Carta_Mazo(Juego_Actual, _carta);                     
            Juego_Actual.Jugadores.Add(_player);
            Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);

            reenviar_trama();

        }

        private void RecibirTurno_Repartir_Mazo()
        {
            byte_2 = byte_to_string(total_flag[1]);
            byte_3 = byte_to_string(total_flag[2]);
            int id_usuario = Controla.get_destino(byte_2);
            Jugador _player = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
            if (id_equal_jugador(id_usuario))
            {
                if (_player.ID == 0) //el jugador con id 0 marca el final del reparto y pone carta en la mesa)
                {
                    Carta _carta;
                    Global_Variables.Penitencia_Activa = Penitencia_Jugador.Una_Carta;
                    _carta = Controla.get_Primera_Carta();
                    Send_bytes(_carta, Juego_Actual, false);
                    Jugar_Primera_Carta(_carta);
                    Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);
                    return;
                }
                _player = Controla.RepartirMazo(_player, Juego_Actual);
                Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);
                Juego_Form.LlenarDataGrid(_player);
            }
            else
            {
                reenviar_trama();
            }
        }
        private void Recibir_Carta_Tablero()
        {

            byte_2 = byte_to_string(total_flag[1]);
            byte_3 = byte_to_string(total_flag[2]);

            int id_origen = Controla.get_origen(byte_2);

            if (id_equal_jugador(id_origen))
                return;

            int id_destino = Controla.get_destino(byte_2);
            int numero = Controla.get_numero(byte_3);
            string color = Controla.get_color(byte_3);

            if (numero < 15)
            {

                Controla.Actualizar_Sentido(byte_3);
                Carta _carta = Controla.Crear_Carta(numero, color);
                Juego_Actual.Tablero = _carta;
                Controla.Borrar_Carta_Jugador(_carta, id_origen);

                if (Juego_Actual.Carta_Inicial)
                {
                    if (_carta.Tipo != Tipo_Carta.CambioColor)
                    {
                        Color_Carta color_juego = Controla.string_to_color(color, -1);
                        Juego_Actual.color_actual = color_juego;
                        Juego_Form.Color_Actual();
                    }
                }
                else
                {
                    Color_Carta color_juego = Controla.string_to_color(color, -1);
                    Juego_Actual.color_actual = color_juego;
                    Juego_Form.Color_Actual();
                }


                if (!id_equal_jugador(id_destino) && Juego_Actual.Carta_Inicial)
                    Juego_Actual.Carta_Inicial = false;

                Controla.Actualizar_Turno(id_destino);

                Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);
                reenviar_trama();

                if (id_equal_jugador(id_destino) && !Juego_Actual.Carta_Inicial)
                {
                    Jugador _player = Controla.Get_jugador_byid(Juego_Actual, id_destino);
                    if (_carta.Tipo == Tipo_Carta.RobaDos)
                    {
                        Juego_Form.Force_Disable_Turno();
                        Global_Variables.Penitencia_Activa = Penitencia_Jugador.Dos_Cartas;
                        Controla.Penitencia_Cargar_Cartas(2, _player);
                        Juego_Form.LlenarDataGrid(_player);
                    }
                    else if (_carta.Tipo == Tipo_Carta.RobaCuatro)
                    {
                        Juego_Form.Force_Disable_Turno();
                        Global_Variables.Penitencia_Activa = Penitencia_Jugador.Cuatro_Cartas;
                        Controla.Penitencia_Cargar_Cartas(4, _player);
                        Juego_Form.LlenarDataGrid(_player);
                    }
                    
                }
            }
            else
            {
                Controla.Actualizar_Turno(id_destino);
                Controla.Actualizar_Form_Juego(Juego_Form, Juego_Actual);
                reenviar_trama();
            }


  
        }
        private void Procesar_Victoria()
        {
            byte_2 = byte_to_string(total_flag[1]);

            int id_origen = Controla.get_origen(byte_2);

            if (id_equal_jugador(id_origen))
                return;
            Juego_Form.Force_Disable_Turno();
            reenviar_trama();
            MessageBox.Show("El jugador numero: " + id_origen + " ha ganado la partida.");

        }
        public void Send_bytes(Carta _carta, Game _Juego, bool Visible)
        {
            if (Visible)
                Jugar_Carta(_carta, _Juego);
            else
                Tomar_Carta(_carta, _Juego);
        }
        private void Trama_correcta()
        {

            string control = Convert.ToString(total_flag[1], 2).PadLeft(8,'0').Substring(4,4);
            if (!Global_Variables.Juego_Iniciado && control.Equals(Global_Variables.control_iniciopartida)) //conteo de jugadores (control: 0001)
            {
                ChangeStatus(true);
                return;
            }

            if (control.Equals(Global_Variables.control_cartamano)) //sacar n cartas del mazo (control: 0110) 
            {
                Recibir_Carta_Mazo();
                return;
            }
            if (control.Equals(Global_Variables.control_cartainicial))
            {
                RecibirTurno_Repartir_Mazo();
                return;
            }
            if (control.Equals(Global_Variables.control_cartamesa))
            {
                Recibir_Carta_Tablero();
                return;
            }
            if (control.Equals(Global_Variables.control_victoria))
            {
                Procesar_Victoria();
                return;
            }

        }
        private void Trama_incorrecta()
        {
            if (!Global_Variables.Juego_Iniciado)
            {
                ChangeStatus(false);
                return;
            }
            int id = -1;
            try
            {
                Jugador _player = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
                id = _player.ID;
            }
            catch (Exception)
            {
                id = -1;
            }
            string bytes_data = id.ToString();
            foreach(byte b in total_flag)
            {
                bytes_data += ";" + Convert.ToString(Convert.ToInt32(b),2).PadLeft(8,'0');
            }
            Log_Error.Escribir_Log(@"Logs\tramas_incorrectas.txt", bytes_data + " \n");
        }

    }
}
