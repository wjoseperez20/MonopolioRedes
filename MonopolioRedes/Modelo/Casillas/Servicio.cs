using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo.Casillas
{
    public class Servicio : Propiedad
    {
        private Tipo_Servicio _tipo_servicio;

        public Servicio(string nombre, Tipo_Servicio tipo_servicio, int precio, int hipoteca, int posicion, Tipo_Casilla tipo_casilla, Image imagen)
        {
            Nombre = nombre;
            Precio = precio;
            Hipoteca = hipoteca;
            Propietario = null;
            Tipo = tipo_casilla;
            Posicion = posicion;
            Imagen = imagen;

            this._tipo_servicio = tipo_servicio;
        }

        public Tipo_Servicio Tipo_Servicio
        {
            get { return this._tipo_servicio; }
        }

        public int Obtener_Penitencia(int Valor_Dado, int Jugador_ID)
        {

            if (!Penitencia_Activa())
                return 0;

            if (this.Propietario.Id == Jugador_ID)
                return 0;

            if (Nivel_Penitencia == 1)
                return (Valor_Dado * 4);
            else
                return (Valor_Dado * 10);
            
            
        }
    }
}
