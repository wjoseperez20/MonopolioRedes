using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolioRedes.Modelo;

namespace MonopolioRedes.Controlador
{
    class Global_Variable
    {

        public static bool Juego_Iniciado = false;
        public const string bandera = "01111110";

        //Instrucciones
        public const string control_inicioPartida = "0000";
        public const string control_tirarDados = "0001";
        public const string control_subasta = "0010";
        public const string control_respuestaSubasta = "0011";
        public const string control_propiedades = "0100";
        public const string control_tomarTarjeta = "0101";
        public const string control_retirarseJuego = "0110";
        public const string control_victoria = "0111";

        //Propiedades - Cartas
        public static int id_carta = 1;
        public static int id_propiedad = 1;

    }
}
