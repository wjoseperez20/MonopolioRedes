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

        public void Set_SerialPort(Connection _sp)
        {
            serial_port = _sp;
        }

        public Jugador CrearJugador()
        {
            Jugador _player = new Jugador();
            return _player;
        }

    }
}
