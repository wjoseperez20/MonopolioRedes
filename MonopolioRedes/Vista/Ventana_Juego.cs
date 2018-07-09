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

        public void ActualizarFicha(Jugador jugador)
        {
            jugador.Ficha.Imagen.Invoke(new Action<Jugador>(InvokeActualizarFicha), jugador);
        }

        private void InvokeActualizarFicha(Jugador jugador)
        {
            jugador.Ficha.Imagen.Location = jugador.Ficha.Coordenadas[jugador.Posicion];
        }

        public void HabilitarBotonDado()
        {
            bLanzar.Invoke(new Action(InvokeHabilitarDado));
        }

        private void InvokeHabilitarDado()
        {
            bLanzar.Enabled = true;
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

                if (jugador.Id == 0)
                    jugador.Ficha.AsignarLabel(lrojo);
                else if (jugador.Id == 1)
                    jugador.Ficha.AsignarLabel(lamarillo);
                else if (jugador.Id == 2)
                    jugador.Ficha.AsignarLabel(lazul);
                else
                    jugador.Ficha.AsignarLabel(lverde);

                jugador.Ficha.Imagen.Visible = true;
                jugador.Ficha.Imagen.Location = jugador.Ficha.Coordenadas[0];

                lJugadores.Items.Add(jugador.Id+" "+principal+": Monedero: " + jugador.Cartera + " Propiedades: " + jugador.Propiedades.Count);
            }

        }

 
        private void bLanzar_Click_1(object sender, EventArgs e)
        {
            bLanzar.Enabled = false;
            controla.LanzarDado(_jugadorPrincipal);
        }

        private void lrojo_Click(object sender, EventArgs e)
        {

        }

        private void lazul_Click(object sender, EventArgs e)
        {

        }

        private void lamarillo_Click(object sender, EventArgs e)
        {

        }

        private void lverde_Click(object sender, EventArgs e)
        {

        }
    }
}
