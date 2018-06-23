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
        Jugador Jugador1, Jugador2, Jugador3, Jugador4;
        Jugador Jugador_Principal;

        public Ventana_Juego(Juego _Juego, Form _MainForm, Main _controla)
        {
            controla = _controla;
            Juego_Actual = _Juego;
            //Jugador_Principal = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
            MainForm = _MainForm;
          // AsignarJugadores();
           // InitializeComponent();
           // AsignarNombres();
           // ActualizarDatos();
           // LlenarDataGrid(Jugador_Principal);
           // LlenarData_Colores();
           // enable_cargar();
           // Enable_Turno();
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

        private void bSaltarTurno_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lJugadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
