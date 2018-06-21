using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNORedes.Modelo
{
    public class Carta
    {
        private int _id;
        private int _numero = 0;
        public Color_Carta Color;
        public Tipo_Carta Tipo;
        public Image Imagen_Carta;

        public Carta(int _ID, int _Numero)
        {
            this._id = _ID;
            this._numero = _Numero;
       
        }
        public int ID
        {
            get { return this._id; }
        }
        public int Numero
        {
            get { return this._numero; }
        }
    }
}
