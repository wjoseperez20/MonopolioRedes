using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UNORedes.Modelo;

namespace UNORedes.Controladora
{
    class Global_Variables
    {
        public static bool Juego_Iniciado = false;
        public static Penitencia_Jugador Penitencia_Activa = Penitencia_Jugador.Sin_penitencia;
        public const string bandera = "01111110";
        public const string control_cartamano = "0110";
        public const string control_cartamesa = "0111";
        public const string control_cartainicial = "0010";
        public const string control_victoria = "0011";
        public const string control_iniciopartida = "0001";
        public const string color_azul = "00";
        public const string color_verde = "01";
        public const string color_amarillo = "11";
        public const string color_rojo = "10";
        public const string sentido_izq = "10";
        public const string sentido_der = "11";
        public static int id_carta = 1;
    }
}
