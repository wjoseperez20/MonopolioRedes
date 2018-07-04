using System;
using System.Windows.Forms;
using MonopolioRedes.Modelo;
using MonopolioRedes.Controlador;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolioRedes.Vista
{
    public partial class Ventana_Juego : Form
    {
        public Juego Juego_Actual;
        Form MainForm;
        Main controla;
        public Jugador _jugadorPrincipal;

        public Ventana_Juego(Juego _Juego, Form _MainForm, Main _controla)
        {
            InitializeComponent();
            controla = _controla;
            Juego_Actual = _Juego;
            _jugadorPrincipal = Juego_Actual.JugadoresConectados.Find(j => j.Principal);
            MainForm = _MainForm;
            bSaltarTurno.Enabled = false;
            bComprarPropiedad.Enabled = false;

            if (_jugadorPrincipal.Id != 0)
                bLanzar.Enabled = false;
        }

        private void Ventana_Juego_Load(object sender, EventArgs e)
        {

        }

        private void bLanzar_Click(object sender, EventArgs e)
        {

        }

        private void lTablero_Click(object sender, EventArgs e)
        {

        }

        private void Ventana_Juego_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void bSaltarTurno_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void MostrarJugadores()
        {
            lJugadores.Invoke(new Action(InvokeMostrarJugadores));
        }

        public void JugadorPrincipal()
        {

        }

        private void InvokeMostrarJugadores()
        {
            lJugadores.Items.Clear();
            string principal = "";

            foreach (Jugador jugador in Juego_Actual.JugadoresConectados.OrderBy(x => x.Id))
            {
                if (jugador.Principal)
                    principal = "(Yo)";
                else
                    principal = "";

                lJugadores.Items.Add(jugador.Id+" "+principal+": Monedero: " + jugador.Cartera + " Propiedades: " + jugador.Propiedades.Count);
            }

        }

        private void bLanzar_Click_1(object sender, EventArgs e)
        {
            controla.LanzarDado(_jugadorPrincipal);
        }
    }
}
