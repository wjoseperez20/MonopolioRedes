using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace TestSerialPorts
{
    class Program
    {
        static string msg_recieve = "";

        static void Main(string[] args)
        {
            string Puerto, msg;
            bool end_conection = false;
            Console.Write("Ingresa el puerto: ");
            Puerto = Console.ReadLine().ToUpper();
            Console.WriteLine();
            SerialPort sp = new SerialPort(Puerto, 9600, Parity.None, 8, StopBits.One);

            Recieve_Message(sp);
            sp.Open();

            while (!end_conection)
            {
                Console.Write("Ingrese el mensaje: ");
                msg = Console.ReadLine();
                if (msg_recieve.ToUpper().Equals("QUIT"))
                    break;
                if (msg.ToUpper().Equals("QUIT"))
                    end_conection = true;
                Send_Message(sp,msg,end_conection);
                Console.WriteLine();
            }

            sp.Close();

            Console.WriteLine("Conexión terminada...");
            Console.ReadLine();
            
            
        }

        static void Send_Message(SerialPort sp, string text, bool closeport)
        {
            try
            {
                sp.WriteLine(text);

            }
            catch (Exception c)
            {
                Console.WriteLine("ERROR: " + c.ToString());
            }
        }

        static void Recieve_Message(SerialPort sp)
        {
            sp.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            msg_recieve = sp.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Mensaje recibido: "+ msg_recieve);
            Console.WriteLine();
        }

    }
}
