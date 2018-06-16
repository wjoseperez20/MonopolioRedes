using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Specialized;
using System.Collections;
using System.Threading;

namespace ChatSerialPort
{
    public partial class Form1 : Form
    {
        SerialPort sp;
        int[] total_flag = new int[255];
        int reading_byte;
        int i = 0;
        string byte_2, byte_3, control, dir_origen,dir_destino,sentido,color_carta,numero_carta;
        bool decimal_base = false;
        int bytes_tosend = 1;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(sp != null)
            {
                sp.Close();
            }
        }



        public Form1()
        {
            InitializeComponent();
            cBytesSend.SelectedIndex = 0;
            cBase.SelectedIndex = 0;
        }

        public delegate void Delegate_Asycn_Task();


        private void cBytesSend_SelectedIndexChanged(object sender, EventArgs e)
        {
            bytes_tosend = Convert.ToInt32(cBytesSend.SelectedItem);
        }

        private void bConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (sp != null)
                    sp.Close();
                string port = tPuerto.Text.ToUpper();
                sp = new SerialPort(port, 2400, Parity.None, 8, StopBits.One);
                sp.Open();
                Recieve_Message(sp);
                MessageBox.Show("Conectado con éxito.");

            }
            catch (Exception c)
            {
                MessageBox.Show("FATAL ERROR: " + c.ToString());
                sp.Close();
            }
        }

        private void tChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void cBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBase.SelectedIndex == 0)
                decimal_base = false;
            else
                decimal_base = true;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (sp != null)
            {
                try
                {
                    byte[] trama_bytes = new byte[bytes_tosend];
                    int j = 0;
                    foreach (byte b in trama_bytes)
                    {
                        if (j == 0)
                        {
                            if (decimal_base)
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData1.Text));
                            else
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData1.Text, 2));
                        }
                        else if (j == 1)
                        {
                            if (decimal_base)
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData2.Text));
                            else
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData2.Text, 2));
                        }
                        else if (j == 2)
                        {
                            if (decimal_base)
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData3.Text));
                            else
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData3.Text, 2));
                        }
                        else if (j == 3)
                        {
                            if (decimal_base)
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData4.Text));
                            else
                                trama_bytes[j] = Convert.ToByte(Convert.ToInt32(tData4.Text, 2));
                        }
                        j++;
                    }
                    tChat.AppendText("Mensaje enviado.");
                    tChat.AppendText(Environment.NewLine);
                    sp.Write(trama_bytes, 0, trama_bytes.Length);
                }
                catch (Exception c)
                {
                    MessageBox.Show("FATAL ERROR: " + c.ToString());
                }
            }
            else
            {
                tChat.AppendText("No se ha establecido una conexión...");
                tChat.AppendText(Environment.NewLine);
            }
        }
        private void Recieve_Message(SerialPort sp)
        {
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        private  void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp_sender = (SerialPort)sender;
                if (!sp_sender.IsOpen || !sp.IsOpen)
                    return;

                sp_sender.DiscardNull = false;
      
                while(sp_sender.BytesToRead > 0)
                {
                    reading_byte = sp_sender.ReadByte();
                    this.Invoke(new Action(() => trama_reading()));
                }
                sp_sender.DiscardInBuffer();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void trama_reading()
        {
            if (i == 0)
            {
                if (reading_byte == 126)
                {
                    total_flag[i] = reading_byte;
                    tChat.AppendText("Recibiendo posible trama...");
                    tChat.AppendText(Environment.NewLine);
                    i++;
                }
                else
                {
                    Trama_incorrecta();
                }
            }
            else
            {
                if (i == 3)
                {
                    if(reading_byte != 126)
                    {
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
                }
            }
        }


        private void Trama_correcta()
        {
            byte_2 = Convert.ToString(total_flag[1], 2).PadLeft(8, '0');
            byte_3 = Convert.ToString(total_flag[2], 2).PadLeft(8, '0');
            tChat.AppendText("Bandera 7E detectada, trama recibida correctamente");
            tChat.AppendText(Environment.NewLine);
            dir_origen = byte_2.Substring(0, 2);
            dir_destino = byte_2.Substring(2, 2);
            control = byte_2.Substring(4, 4);
            tChat.AppendText("Direccion => Origen: " + dir_origen + " Destino: " + dir_destino);
            tChat.AppendText(Environment.NewLine);
            tChat.AppendText("instruccion: " + control);
            tChat.AppendText(Environment.NewLine);

            sentido = byte_3.Substring(0, 2);
            color_carta = byte_3.Substring(2, 2);
            numero_carta = byte_3.Substring(4, 4);
            tChat.AppendText("Sentido: " + sentido);
            tChat.AppendText(Environment.NewLine);
            tChat.AppendText("Color de la carta: " + color_carta);
            tChat.AppendText(Environment.NewLine);
            tChat.AppendText("numero de la carta: " + numero_carta);
            tChat.AppendText(Environment.NewLine);

        }
        private void Trama_incorrecta()
        {
            tChat.AppendText("Trama incorrecta.");
            tChat.AppendText(Environment.NewLine);
        }
    }
}
