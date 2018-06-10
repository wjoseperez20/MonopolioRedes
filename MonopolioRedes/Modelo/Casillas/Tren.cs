using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo.Casillas
{
    public class Tren : Propiedad
    {
        private Tipo_Tren _tipo_tren;
        private int _penitencia_1; // 1 Tren
        private int _penitencia_2; // 2 Trenes
        private int _penitencia_3; // 3 Trenes
        private int _penitencia_4; // 4 Trenes

        public Tren(string nombre, Tipo_Tren tipo_tren, int precio, int penitencia1, int penitencia2, int penitencia3, int penitencia4, int hipoteca, 
            int posicion, Tipo_Casilla tipo_casilla, Image imagen)
        {
            Nombre = nombre;
            Precio = precio;
            Hipoteca = hipoteca;
            Propietario = null;
            Tipo = tipo_casilla;
            Posicion = posicion;
            Imagen = imagen;

            this._tipo_tren = tipo_tren;
            this._penitencia_1 = penitencia1;
            this._penitencia_2 = penitencia2;
            this._penitencia_3 = penitencia3;
            this._penitencia_4 = penitencia4;
        }

        public Tipo_Tren Tipo_Tren
        {
            get { return this._tipo_tren; }
        }

        public int Penitencia_1
        {
            get { return this._penitencia_1; }
        }

        public int Penitencia_2
        {
            get { return this._penitencia_2; }
        }

        public int Penitencia_3
        {
            get { return this._penitencia_3; }
        }

        public int Penitencia_4
        {
            get { return this._penitencia_4; }
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
                Valor_Penitencia = this.Penitencia_1;
            }
            else if (Nivel_Penitencia == 2)
            {
                Valor_Penitencia = this.Penitencia_2;
            }
            else if (Nivel_Penitencia == 3)
            {
                Valor_Penitencia = this.Penitencia_3;
            }
            else if (Nivel_Penitencia == 4)
            {
                Valor_Penitencia = this.Penitencia_4;
            }

            return Valor_Penitencia;
        }
    }
}
