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
    public partial class Ventana_Juego : Form
    {
        public Game Juego_Actual;
        Form MainForm;
        Control_App controla;
        Jugador Jugador1, Jugador2, Jugador3, Jugador4;
        Jugador Jugador_Principal;
        public Ventana_Juego(Game _Juego, Form _MainForm, Control_App _controla)
        {
            controla = _controla;
            Juego_Actual = _Juego;
            Jugador_Principal = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
            MainForm = _MainForm;
            AsignarJugadores();
            InitializeComponent();
            AsignarNombres();
            ActualizarDatos();
            LlenarDataGrid(Jugador_Principal);
            LlenarData_Colores();
            enable_cargar();
            Enable_Turno();
        }
        public void Force_Disable_Turno()
        {
            button1.Enabled = false;
            bPasar.Enabled = false;
        }
        public void Enable_Turno()
        {
            if(Juego_Actual.Jugadores.Find(j => j.Jugador_Principal).Turno_Activo == true) //if (Juego_Actual.Jugadores.Find(j => j.Turno_Activo == true).ID == Jugador_Principal.ID)
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
        public void LlenarData_Colores()
        {
            GirdColors.DataSource = controla.Colors_Grid();
        }
        public void AsignarNombres()
        {
            if (Jugador1 != null)
                lJugador1.Text = Jugador1.ID.ToString();
            if (Jugador2 != null)
                lJugador2.Text = Jugador2.ID.ToString();
            if (Jugador3 != null)
                lJugador3.Text = Jugador3.ID.ToString();
            if (Jugador4 != null)
                lJugador4.Text = Jugador4.ID.ToString();
        }
        public void AsignarJugadores()
        {
            Jugador1 = Juego_Actual.Jugadores.Find(j => j.ID == 0);
            Jugador2 = Juego_Actual.Jugadores.Find(j => j.ID == 1);
            Jugador3 = Juego_Actual.Jugadores.Find(j => j.ID == 2);
            Jugador4 = Juego_Actual.Jugadores.Find(j => j.ID == 3);
        }
        public void ActualizarDatos()
        {
            if(Jugador1 != null)
                tCartas1.Text = Jugador1.Mano.Count.ToString();
            if(Jugador2 != null)
                tCartas2.Text = Jugador2.Mano.Count.ToString();
            if(Jugador3 != null)
                tCartas3.Text = Jugador3.Mano.Count.ToString();
            if(Jugador4 != null)
                tCartas4.Text = Jugador4.Mano.Count.ToString();

            tCartasM.Text = Juego_Actual.Cartas.Count.ToString();

            lTurnoJugador.Text = "CARTAS JUGADOR NÚMERO: " + Jugador_Principal.ID.ToString();
            if (Juego_Actual.Tablero == null)
                lTablero.Text = "TABLERO VACÍO";
            else
            {
                lTablero.Text = "";
                lTablero.Image = Juego_Actual.Tablero.Imagen_Carta;
            }
        }
        public void enable_cargar()
        {
            if (controla.Enable_Cargar_Carta(Juego_Actual))
                bPasar.Enabled = true;
            else
                bPasar.Enabled = false;
        }
        public void LlenarDataGrid(Jugador _player)
        {
            dataGridView1.DataSource = controla.Mostrar_Cartas(_player);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
        }
        public void Cambiar_Color()
        {
            DataGridViewRow row_color = GirdColors.SelectedRows[0];
            int id_row = row_color.Index;
            if (id_row == 0)
                Juego_Actual.color_actual = Color_Carta.Amarillo;
            else if (id_row == 1)
                Juego_Actual.color_actual = Color_Carta.Rojo;
            else if (id_row == 2)
                Juego_Actual.color_actual = Color_Carta.Azul;
            else
                Juego_Actual.color_actual = Color_Carta.Verde;
        }
        public void Color_Actual()
        {
            if (Juego_Actual.color_actual == Color_Carta.Amarillo)
                GirdColors.Rows[0].Selected = true;
            else if (Juego_Actual.color_actual == Color_Carta.Rojo)
                GirdColors.Rows[1].Selected = true;
            else if (Juego_Actual.color_actual == Color_Carta.Azul)
                GirdColors.Rows[2].Selected = true;
            else
                GirdColors.Rows[3].Selected = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            int id_carta = Convert.ToInt32(row.Cells[0].Value); //cambiar algoritmo de busqeuda
            Carta Carta_Jugada = controla.Encontrar_Carta(Juego_Actual, id_carta); //cambiar algoritmo de busqueda.
            if(Carta_Jugada == null)
            {
                MessageBox.Show("Error al encontrar la carta");
                return;
            }
            if (controla.Carta_Valida(Juego_Actual, Carta_Jugada))
            {
                Juego_Actual.Carta_Inicial = false;
                controla.Jugar_Carta(Carta_Jugada);
            }
            else
            {
                MessageBox.Show("Carta no valida para ser jugada.");
            }
        }

        private void lTablero_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string tipo_carta = row.Cells[3].Value.ToString().ToLower();
                if (tipo_carta == "cambiocolor" || tipo_carta == "robacuatro")
                {
                    //MessageBox.Show("Recuerda seleccionar un color antes de jugar la carta!");
                    GirdColors.Enabled = true;
                }
                else
                {
                    GirdColors.Enabled = false;
                }
            }
        }

        private void bPasar_Click(object sender, EventArgs e)
        {
            controla.Cargar_Carta(Jugador_Principal);
            enable_cargar();
            AsignarJugadores();
            ActualizarDatos();
            LlenarDataGrid(Jugador_Principal);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ventana_Juego_Load(object sender, EventArgs e)
        {

        }

        private void Ventana_Juego_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Close();
        }
    }
}
