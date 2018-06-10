using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo.Casillas
{
    public class Propiedad : Casilla
    {
        private int _precio;
        private int _hipoteca;
        private int _nivel_penitencia;
        private Jugador _propietario;
        private string _nombre;

        public int Precio
        {
            get { return this._precio; }
            protected set { _precio = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            protected set { _nombre = value; }
        }

        public int Nivel_Penitencia
        {
            get { return this._nivel_penitencia; }
            set { this._nivel_penitencia = value; }
        }

        public Jugador Propietario
        {
            get { return this._propietario; }
            set { this._propietario = value; }
        }

        public int Hipoteca
        {
            get { return _hipoteca; }
            protected set { _hipoteca = value; }
        }
        public bool Penitencia_Activa()
        {
            if (this.Propietario != null)
                return true;

            return false;
        }

    }
}
