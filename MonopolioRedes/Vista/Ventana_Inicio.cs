using System;
using System.Windows.Forms;
using MonopolioRedes.Controlador;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolioRedes.Modelo;

namespace MonopolioRedes.Vista
{
    public partial class Ventana_Inicio : Form
    {
        Main controla = new Main();
        Connection sp = new Connection();
        Juego Juego_Actual = Juego.ObtenerJuego;

        public Ventana_Inicio()
        {
            InitializeComponent();
        }

        private void Ventana_Juego_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bComenzar_Click(object sender, EventArgs e)
        {
            if(sp.sp != null)
            {
                if (!sp.sp.IsOpen)
                {
                    MessageBox.Show("Conexión no iniciada.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Conexión no iniciada.");
                return;
            }

            Jugador Jugador1;
            Jugador1 = controla.CrearJugador(0);
            Jugador1.Turno_Activo = true;
            Jugador1.Principal = true;
            sp.Enviar_Peticion_InicioPartida(Jugador1);
        }

        private void bStartCon_Click(object sender, EventArgs e)
        {
            sp.Start_Conection(this,controla);
        }

        private void lInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
