using MonopolioRedes.Modelo.Tarjetas;
using MonopolioRedes.Modelo.Tipos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo
{
    public class Jugador
    {
        private int _id;
        private string _nombre;
        private int _cartera;
        private bool _detenido;
        private int _turnos_carcel;
        private bool _turno_activo;
        private int _posicion;
        public List<Tarjeta_Casualidad> Tarjeta_Casualidad = new List<Tarjeta_Casualidad>();
        public List<Tarjeta_Arca> Tarjeta_Arca = new List<Tarjeta_Arca>();

        public Jugador (int id, string nombre)
        {
            this._id = id;
            this._nombre = nombre;
            this._cartera = 1500;
            this._detenido = false;
            this._turno_activo = false;
            this._posicion = 0;
            this._turnos_carcel = 0;

        }

        public int Id
        {
            get { return this._id; }
        }

        public string Nombre
        {
            get { return this._nombre; }
        }

        public bool Detenido
        {
            get { return this._detenido; }
            set { this._detenido = value; }
        }

        public int Posicion
        {
            get { return this._posicion; }
            set { this._posicion = value; }
        }
        
        public int Cartera
        {
            get { return this._cartera; }
            set { this._cartera = value; }
        }

        public int Turnos_Carcel
        {
            get { return this._turnos_carcel; }
            set { this._turnos_carcel = value; }
        }

        public bool Turno_Activo
        {
            get { return this._turno_activo; }
            set { this._turno_activo = value; }
        }

    }
}
