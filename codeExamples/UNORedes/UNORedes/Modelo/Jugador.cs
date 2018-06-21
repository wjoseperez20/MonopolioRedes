using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNORedes.Modelo
{
    public class Jugador
    {
        private int _id;
        private int cantidad_cartas = 0;
        public List<Carta> Mano = new List<Carta>();
        private bool turno_activo;
        private bool jugador_principal = false;

        public Jugador(int cantidadcartas, int id, bool turno, bool _principal)
        {
            this._id = id;
            this.cantidad_cartas = cantidadcartas;
            this.turno_activo = turno;
            this.jugador_principal = _principal;
        }
        public bool Turno_Activo
        {
            get { return turno_activo; }
            set { turno_activo = value; }
        }
        public int ID
        {
            get { return this._id; }
            set { _id = value; }
        }
        public int Cantidad_Cartas
        {
            get { return cantidad_cartas; }
            set { cantidad_cartas = value; }
        }
        public bool Jugador_Principal
        {
            get { return jugador_principal; }
        }
    }
}
