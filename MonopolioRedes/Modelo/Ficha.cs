using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Modelo
{
    public class Ficha
    {
        private int _id;
        private bool _asignada;

        public Ficha(int id)
        {
            _id = id;
        }

        public int Id
        {
            get { return _id; }
        }

        public bool Asignada
        {
            get { return _asignada; }
            set { _asignada = value; }
        }
    }
}
