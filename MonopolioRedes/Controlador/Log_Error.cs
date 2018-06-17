using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolioRedes.Controlador
{
    public class Log_Error
    {
        public static void Escribir_Log(string path, string content)
        {
            try
            {
                FileStream Writer = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                byte[] Msg = Encoding.ASCII.GetBytes(Environment.NewLine + content);
                Writer.Write(Msg, 0, Msg.Length);
                Writer.Dispose();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se puede encontrar el archivo: " + e + ":" + content);
            }
        }
    }
}
