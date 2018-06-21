using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNORedes.Modelo
{
    public class Game
    {
        private List<Jugador> jugadores = new List<Jugador>();
        private Sentido_Juego sentido;
        private List<Carta> cartas = new List<Carta>();
        private bool _terminado = false;
        private Carta tablero = null;
        private int id_turno = 1;
        public Color_Carta color_actual;
        private bool carta_inicial = true;

        public bool Carta_Inicial
        {
            get { return carta_inicial; }
            set { carta_inicial = value; }
        }
        public int ID_Turno
        {
            get { return id_turno; }
            set { id_turno = value; }
        }
        public bool Juego_Terminado
        {
            get { return this._terminado; }
            set { _terminado = value; }
        }

        public Sentido_Juego Sentido
        {
            get{ return sentido; }
            set { sentido = value; }
        }

        public List<Jugador> Jugadores
        {
            get { return jugadores; }
            set { jugadores = value; }
        }

        public List<Carta> Cartas
        {
            get { return cartas; }
            set { cartas = value; }
        }
        public Carta Tablero
        {
            get { return tablero; }
            set { tablero = value; }
        }
    }
}
