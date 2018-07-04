using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolioRedes.Modelo
{
    public class Ficha
    {
        private int _id;
        private Label _imagen;
        private string _nombre;
        private Dictionary<int, Point> _coordenadas;

        public Ficha(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;
            _coordenadas = new Dictionary<int, Point>();
        }

        public int Id
        {
            get { return _id; }
        }

        public Label Imagen
        {
            get { return _imagen; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public Dictionary<int, Point> Coordenadas
        {
            get { return _coordenadas; }
            set { _coordenadas = value; }
        }

        public void AsignarLabel(Label label)
        {
            _imagen = label;
        }
        public void AsignarCoordenadaFicha(int Casilla, int x, int y)
        {
            _coordenadas.Add(Casilla, new Point(x, y));
        }

    }
}
