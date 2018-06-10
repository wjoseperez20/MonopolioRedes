using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo.Casillas
{
    public class Avenida : Propiedad
    {
        private Color_Avenida _color;
        private int _penitencia_0; //Alquiler 
        private int _penitencia_1; // 1 casa
        private int _penitencia_2; // 2 casas
        private int _penitencia_3; // 3 casas
        private int _penitencia_4; // 4 casas
        private int _penitencia_5; // Hotel
        private int _precio_casa;
        private int _precio_hotel;

        public Avenida(string nombre, Color_Avenida color, int precio, int penitencia0, int penitencia1, int penitencia2, int penitencia3, int penitencia4,
            int penitencia5, int hipoteca, int precio_casa, int precio_hotel, int posicion, Tipo_Casilla tipo, Image imagen)
        {
            Nombre = nombre;
            Precio = precio;
            Hipoteca = hipoteca;
            Propietario = null;
            Tipo = tipo;
            Posicion = posicion;
            Imagen = imagen;

            _color = color;
            _penitencia_0 = penitencia0;
            _penitencia_1 = penitencia1;
            _penitencia_2 = penitencia2;
            _penitencia_3 = penitencia3;
            _penitencia_4 = penitencia4;
            _penitencia_5 = penitencia5;
            _precio_casa = precio_casa;
            _precio_hotel = precio_hotel;
        }

        public Color_Avenida Color
        {
            get { return _color; }
        }

        public int Obtener_Penitencia(int Jugador_ID)
        {

            if (!Penitencia_Activa())
                return 0;

            if (this.Propietario.Id == Jugador_ID)
                return 0;

            int Valor_Penitencia = 0;

            if (Nivel_Penitencia == 1)
            {
                Valor_Penitencia = this._penitencia_0;
            }
            else if (Nivel_Penitencia == 2)
            {
                Valor_Penitencia = this._penitencia_1;
            }
            else if (Nivel_Penitencia == 3)
            {
                Valor_Penitencia = this._penitencia_2;
            }
            else if (Nivel_Penitencia == 4)
            {
                Valor_Penitencia = this._penitencia_3;
            }
            else if (Nivel_Penitencia == 5)
            {
                Valor_Penitencia = this._penitencia_4;
            }
            else if (Nivel_Penitencia == 6)
            {
                Valor_Penitencia = this._penitencia_5;
            }

            return Valor_Penitencia;
        }
    }
}
