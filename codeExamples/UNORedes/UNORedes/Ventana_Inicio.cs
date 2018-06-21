using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNORedes.Controladora;
using UNORedes.Modelo;

namespace UNORedes
{
    public partial class Ventana_Inicio : Form
    {
        Control_App controla = new Control_App();
        Game Juego_Actual = new Game();
        Seria_lPort sp = new Seria_lPort();

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
            Jugador1 = controla.CrearJugador(00, false, true);
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
