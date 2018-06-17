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
    public class Connection
    {
        public SerialPort sp;
        private int reading_byte = 0;
        private int i = 0; //contador de bytes por trama
        private int[] total_flag = new int[10];
        private byte[] bytes_sending = new byte[20];

        Ventana_Inicio Inicio_Form;
        Ventana_Juego Juego_Form;

        Main Controla;
        Jugador Primer_Jugador = null;
        Jugador _Jugador = null;

        public void Start_Conection(Ventana_Inicio main_form, Main _control)
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
                if (sp != null)
                    sp.Close();

                if (main_form != null)
                    main_form.lInfo.Text = "Error de conexión.";

                if (Controla != null)
                    Controla = null;
            }
        }


        public void Enviar_Peticion_InicioPartida(Jugador _jugador_Peticion)
        {
            try
            {
                Primer_Jugador = _jugador_Peticion;
                Enviar_trama(Convert.ToInt32("00000001", 2), Convert.ToInt32("10000000", 2));
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
                    Procesar_trama();

                }
                sp_sender.DiscardInBuffer();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void Procesar_trama()
        {
            if (!Global_Variable.Juego_Iniciado)
                Inicio_Form.Invoke(new Action(() => Trama_reading()));
            else
                Juego_Form.Invoke(new Action(() => Trama_reading()));
        }

        private void Trama_reading()
        {
            if (i == 0)
            {
                if (reading_byte == 126)
                {
                    total_flag[i] = reading_byte;
                    i++;
                    if (!Global_Variable.Juego_Iniciado)
                        Trama_coming();
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
                    if (!Global_Variable.Juego_Iniciado)
                        Trama_coming();
                }
            }
        }

        private void Trama_coming()
        {
            Inicio_Form.lInfo.Text = "Recibiendo posible trama (" + i.ToString() + "): " + reading_byte.ToString();
            Inicio_Form.bComenzar.Enabled = false;
        }

        private void Trama_correcta()
        {
          return;
        }

        private void Trama_incorrecta()
        {
            if (!Global_Variable.Juego_Iniciado)
            {
               // ChangeStatus(false);
                return;
            }
            int id = -1;
            try
            {
            //    Jugador _player = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
              //  id = _player.ID;
            }
            catch (Exception)
            {
                id = -1;
            }
            string bytes_data = id.ToString();
            foreach (byte b in total_flag)
            {
                bytes_data += ";" + Convert.ToString(Convert.ToInt32(b), 2).PadLeft(8, '0');
            }
            Log_Error.Escribir_Log(@"Logs\tramas_incorrectas.txt", bytes_data + " \n");
        }

        public void Reenviar_trama()
        {
            Thread.Sleep(500);
            bytes_sending = new byte[4];
            bytes_sending[0] = Convert.ToByte(Convert.ToInt32(Global_Variable.bandera, 2));
            bytes_sending[1] = Convert.ToByte(total_flag[1]);
            bytes_sending[2] = Convert.ToByte(total_flag[2]);
            bytes_sending[3] = Convert.ToByte(Convert.ToInt32(Global_Variable.bandera, 2));
            sp.Write(bytes_sending, 0, 4);
        }

        public void Enviar_trama(int byte_2, int byte_3)
        {
            Thread.Sleep(500);
            bytes_sending = new byte[4];
            bytes_sending[0] = Convert.ToByte(Convert.ToInt32(Global_Variable.bandera, 2));
            bytes_sending[1] = Convert.ToByte(byte_2);
            bytes_sending[2] = Convert.ToByte(byte_3);
            bytes_sending[3] = Convert.ToByte(Convert.ToInt32(Global_Variable.bandera, 2));
            sp.Write(bytes_sending, 0, 4);
        }
    }
}
