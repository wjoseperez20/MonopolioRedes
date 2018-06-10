using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonopolioRedes.Modelo;
using MonopolioRedes.Modelo.Casillas;

namespace MonopolioRedes.Vista
{
    public partial class Inicio : Form
    {
        Random rand = new Random();
        public Inicio()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bApagar_Click(object sender, EventArgs e)
        {
            Juego Juego = new Juego();

            int Resultado_Dado = Dado.Lanzar_Dado();

            

            MessageBox.Show("Resultado: " + Resultado_Dado + " d1: " + Dado.Dado_1.ToString() + " d2: " + Dado.Dado_2.ToString() + " Doble: " + Dado.Doble.ToString());

            Casilla c_destino = Juego.Casillas.Find(c => c.Posicion == Resultado_Dado);

            Jugador J1 = new Jugador(1, "Wilmer");

            if (c_destino.Tipo == Tipo_Casilla.Propiedad)
            {
                Propiedad p_destino = (Propiedad)c_destino;
                MessageBox.Show(p_destino.Posicion.ToString()+ " - " +p_destino.Tipo.ToString()+" "+p_destino.Color.ToString() +" - "+p_destino.Nombre.ToString() +" Penitencia: " + p_destino.Precio);
            }
            else if (c_destino.Tipo == Tipo_Casilla.Tren)
            {
                Tren t_destino = (Tren)c_destino;
                MessageBox.Show(t_destino.Posicion.ToString() + " - " + t_destino.Tipo.ToString() + " " + t_destino.Tipo_Tren.ToString() + " Penitencia: " +t_destino.Precio);
            }
            else if (c_destino.Tipo == Tipo_Casilla.Servicio)
            {
                Servicio s_destino = (Servicio)c_destino;
                MessageBox.Show(s_destino.Posicion.ToString() + " - " + s_destino.Tipo.ToString() + " " + s_destino.Tipo_Servicio.ToString() + " Penitencia: " + s_destino.Precio);
            }
            else
            {
                MessageBox.Show(c_destino.Posicion.ToString()+ " - " + c_destino.Tipo.ToString());
            }
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
