using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UNORedes.Controladora;
using UNORedes.Modelo;

namespace UNORedes.Controladora
{
    public class Control_App
    {
        Random rand = new Random();
        public Seria_lPort serial_port;
        public Game JuegoActual;
        public Ventana_Juego Juego_Form;

        public Carta Crear_Carta(int numero, string _color)
        {
            Carta c;
            Color_Carta color = string_to_color(_color, numero);
            c = new Carta(Global_Variables.id_carta, numero);
            c.Color = color;
            switch (color)
            {
                case Color_Carta.Amarillo:
                    {
                        if(numero < 10)
                        {
                            c.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_yellow");
                            c.Tipo = Tipo_Carta.Normal;
                        }
                        else if (numero == 10)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.skip_yellow;
                            c.Tipo = Tipo_Carta.PierdeTurno;
                        }
                        else if (numero == 11)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.change_yellow;
                            c.Tipo = Tipo_Carta.CambioSentido;
                        }
                        else if (numero == 12)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.plus2_yellow;
                            c.Tipo = Tipo_Carta.RobaDos;
                        }
                    }
                    break;
                case Color_Carta.Rojo:
                    {
                        if (numero < 10)
                        {
                            c.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_red");
                            c.Tipo = Tipo_Carta.Normal;
                        }
                        else if (numero == 10)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.skip_red;
                            c.Tipo = Tipo_Carta.PierdeTurno;
                        }
                        else if (numero == 11)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.change_red;
                            c.Tipo = Tipo_Carta.CambioSentido;
                        }
                        else if (numero == 12)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.plus2_red;
                            c.Tipo = Tipo_Carta.RobaDos;
                        }
                    }
                    break;
                case Color_Carta.Azul:
                    {
                        if (numero < 10)
                        {
                            c.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_blue");
                            c.Tipo = Tipo_Carta.Normal;
                        }
                        else if (numero == 10)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.skip_blue;
                            c.Tipo = Tipo_Carta.PierdeTurno;
                        }
                        else if (numero == 11)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.change_blue;
                            c.Tipo = Tipo_Carta.CambioSentido;
                        }
                        else if (numero == 12)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.plus2_blue;
                            c.Tipo = Tipo_Carta.RobaDos;
                        }
                    }
                    break;
                case Color_Carta.Verde:
                    {
                        if (numero < 10)
                        {
                            c.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_green");
                            c.Tipo = Tipo_Carta.Normal;
                        }
                        else if (numero == 10)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.skip_green;
                            c.Tipo = Tipo_Carta.PierdeTurno;
                        }
                        else if (numero == 11)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.change_green;
                            c.Tipo = Tipo_Carta.CambioSentido;
                        }
                        else if (numero == 12)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.plus2_green;
                            c.Tipo = Tipo_Carta.RobaDos;
                        }
                    }
                    break;
                default:
                    {
                        if (numero == 13)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.changecolor;
                            c.Tipo = Tipo_Carta.CambioColor;
                        }
                        else if (numero == 14)
                        {
                            c.Imagen_Carta = UNORedes.Properties.Resources.plus4;
                            c.Tipo = Tipo_Carta.RobaCuatro;
                        }
                    }
                    break;
            }
            Global_Variables.id_carta++;
            return c;
        }
        public List<Carta> CrearMazo()
        {
            List<Carta> Mazo = new List<Carta>();
            Carta _carta;
            int numero = 1;
            for (int i = 1; i < 109; i++)
            {
                if (i == 1)
                {
                    _carta = new Carta(i, 0);
                    _carta.Color = Color_Carta.Amarillo;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_0_yellow");
                    Mazo.Add(_carta);
                }
                else if (i > 1 && i <= 19)
                {
                    if (i == 11)
                        numero = 1;
                    _carta = new Carta(i, numero);
                    _carta.Color = Color_Carta.Amarillo;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_yellow");
                    Mazo.Add(_carta);
                    numero++;
                }
                else if (i == 20)
                {
                    _carta = new Carta(i, 0);
                    _carta.Color = Color_Carta.Azul;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_0_blue");
                    Mazo.Add(_carta);
                    numero = 1;
                }
                else if (i > 20 && i <= 38)
                {
                    if (i == 30)
                        numero = 1;
                    _carta = new Carta(i, numero);
                    _carta.Color = Color_Carta.Azul;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_blue");
                    Mazo.Add(_carta);
                    numero++;
                }
                else if (i == 39)
                {
                    _carta = new Carta(i, 0);
                    _carta.Color = Color_Carta.Rojo;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_0_red");
                    Mazo.Add(_carta);
                    numero = 1;
                }
                else if (i > 39 && i <= 57)
                {
                    if (i == 49)
                        numero = 1;
                    _carta = new Carta(i, numero);
                    _carta.Color = Color_Carta.Rojo;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_red");
                    Mazo.Add(_carta);
                    numero++;
                }
                else if (i == 58)
                {
                    _carta = new Carta(i, 0);
                    _carta.Color = Color_Carta.Verde;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_0_green");
                    Mazo.Add(_carta);
                    numero = 1;
                }
                else if (i > 58 && i <= 76)
                {
                    if (i == 68)
                        numero = 1;
                    _carta = new Carta(i, numero);
                    _carta.Color = Color_Carta.Verde;
                    _carta.Tipo = Tipo_Carta.Normal;
                    _carta.Imagen_Carta = (Image)UNORedes.Properties.Resources.ResourceManager.GetObject("_" + numero.ToString() + "_green");
                    Mazo.Add(_carta);
                    numero++;
                }
                else if (i > 76 && i <= 78)
                {
                    _carta = new Carta(i, 12);
                    _carta.Color = Color_Carta.Amarillo;
                    _carta.Tipo = Tipo_Carta.RobaDos;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.plus2_yellow;
                    Mazo.Add(_carta);
                }
                else if (i > 78 && i <= 80)
                {
                    _carta = new Carta(i, 12);
                    _carta.Color = Color_Carta.Azul;
                    _carta.Tipo = Tipo_Carta.RobaDos;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.plus2_blue;
                    Mazo.Add(_carta);
                }
                else if (i > 80 && i <= 82)
                {
                    _carta = new Carta(i, 12);
                    _carta.Color = Color_Carta.Rojo;
                    _carta.Tipo = Tipo_Carta.RobaDos;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.plus2_red;
                    Mazo.Add(_carta);
                }
                else if (i > 82 && i <= 84)
                {
                    _carta = new Carta(i, 12);
                    _carta.Color = Color_Carta.Verde;
                    _carta.Tipo = Tipo_Carta.RobaDos;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.plus2_green;
                    Mazo.Add(_carta);
                }
                else if (i > 84 && i <= 86)
                {
                    _carta = new Carta(i, 11);
                    _carta.Color = Color_Carta.Amarillo;
                    _carta.Tipo = Tipo_Carta.CambioSentido;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.change_yellow;
                    Mazo.Add(_carta);
                }
                else if (i > 86 && i <= 88)
                {
                    _carta = new Carta(i, 11);
                    _carta.Color = Color_Carta.Azul;
                    _carta.Tipo = Tipo_Carta.CambioSentido;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.change_blue;
                    Mazo.Add(_carta);
                }
                else if (i > 88 && i <= 90)
                {
                    _carta = new Carta(i, 11);
                    _carta.Color = Color_Carta.Rojo;
                    _carta.Tipo = Tipo_Carta.CambioSentido;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.change_red;
                    Mazo.Add(_carta);
                }
                else if (i > 90 && i <= 92)
                {
                    _carta = new Carta(i, 11);
                    _carta.Color = Color_Carta.Verde;
                    _carta.Tipo = Tipo_Carta.CambioSentido;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.change_green;
                    Mazo.Add(_carta);
                }
                else if (i > 92 && i <= 94)
                {
                    _carta = new Carta(i, 10);
                    _carta.Color = Color_Carta.Amarillo;
                    _carta.Tipo = Tipo_Carta.PierdeTurno;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.skip_yellow;
                    Mazo.Add(_carta);
                }
                else if (i > 94 && i <= 96)
                {
                    _carta = new Carta(i, 10);
                    _carta.Color = Color_Carta.Azul;
                    _carta.Tipo = Tipo_Carta.PierdeTurno;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.skip_blue;
                    Mazo.Add(_carta);
                }
                else if (i > 96 && i <= 98)
                {
                    _carta = new Carta(i, 10);
                    _carta.Color = Color_Carta.Rojo;
                    _carta.Tipo = Tipo_Carta.PierdeTurno;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.skip_red;
                    Mazo.Add(_carta);
                }
                else if (i > 98 && i <= 100)
                {
                    _carta = new Carta(i, 10);
                    _carta.Color = Color_Carta.Verde;
                    _carta.Tipo = Tipo_Carta.PierdeTurno;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.skip_green;
                    Mazo.Add(_carta);
                }
                else if (i > 100 && i <= 104)
                {
                    _carta = new Carta(i, 13);
                    _carta.Color = Color_Carta.Ninguno;
                    _carta.Tipo = Tipo_Carta.CambioColor;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.changecolor;
                    Mazo.Add(_carta);
                }
                else if (i > 104 && i <= 108)
                {
                    _carta = new Carta(i, 14);
                    _carta.Color = Color_Carta.Ninguno;
                    _carta.Tipo = Tipo_Carta.RobaCuatro;
                    _carta.Imagen_Carta = UNORedes.Properties.Resources.plus4;
                    Mazo.Add(_carta);
                }
            }
            return Mazo;
        }

        public int get_turno_random()
        {
            int destino = rand.Next(JuegoActual.Jugadores.Count);
            return destino;

        }
        public Jugador Get_jugador_byid(Game Juego_Actual, int id_usuario)
        {
            return Juego_Actual.Jugadores.Find(j => j.ID == id_usuario);
        }
        public Jugador Get_Jugador_Principal(Game Juego_Actual)
        {
            return Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
        }
        public Game Borrar_Carta_Mazo(Game Juego_Actual, Carta _carta)
        {
            Game _Juego = Juego_Actual;
            foreach (Carta c in Juego_Actual.Cartas)
            {
                if (c.Numero == _carta.Numero && c.Tipo == _carta.Tipo && c.Color == _carta.Color)
                {
                    Juego_Actual.Cartas.Remove(c);
                    break;
                }
            }
            return _Juego;
        }
        public void Borrar_Carta_Jugador(Carta _carta, int id_jugador)
        {
            Jugador _player = JuegoActual.Jugadores.Find(j => j.ID == id_jugador);
            foreach(Carta c in _player.Mano)
            {
                if (c.Numero == _carta.Numero && c.Tipo == _carta.Tipo && c.Color == _carta.Color)
                {
                    _player.Mano.Remove(c);
                    break;
                }
            }
            if (_player.Jugador_Principal)
                Juego_Form.LlenarDataGrid(_player);
        }
        public void Actualizar_Form_Juego(Ventana_Juego _form, Game Juego_Actual)
        {
            _form.AsignarJugadores();
            _form.ActualizarDatos();
            _form.Enable_Turno();
            _form.enable_cargar();
        }
        public void Set_SerialPort(Seria_lPort _sp)
        {
            serial_port = _sp;
        }
        public void Procesar_Ventana_Juego(Ventana_Inicio Main_Form, Game Juego_Actual)
        {
            Main_Form.Visible = false;
            Ventana_Juego V_Juego = new Ventana_Juego(Juego_Actual, Main_Form, this);
            serial_port.Set_Juego_Form(V_Juego);
            V_Juego.Visible = true;
            Juego_Form = V_Juego;
            Global_Variables.Juego_Iniciado = true; //activa el hilo de la siguiente ventana
        }
        public int get_id_destino(int id_origen, bool saltaturno)
        {
            int id_destino;
            int max_id = JuegoActual.Jugadores.Count - 1;
            
            if (JuegoActual.Sentido == Sentido_Juego.Izquierda)
            {
                if (id_origen == max_id)
                {
                    if (!saltaturno)
                        id_destino = 0;
                    else
                        id_destino = 1;
                }
                else
                {
                    if (!saltaturno)
                        id_destino = id_origen + 1;
                    else
                    {
                        if (id_origen == 2)
                            id_destino = 0;
                        else
                            id_destino = id_origen + 2;

                    }
                }
            }
            else
            {
                if (id_origen == 0)
                {
                    if (!saltaturno)
                        id_destino = max_id;
                    else
                        id_destino = max_id - 1;
                }
                else
                {
                    if (!saltaturno)
                        id_destino = id_origen - 1;
                    else
                    {
                        if (id_origen == 1)
                            id_destino = 3;
                        else
                            id_destino = id_origen - 2;
                    }
                }
            }
            return id_destino;
        }
        public Game CrearJuego(List<Jugador> Jugadores)
        {
            List<Carta> Mazo_Juego = new List<Carta>();
            Mazo_Juego = CrearMazo();
            Game Juego_Actual = new Game();
            Juego_Actual.Cartas = Mazo_Juego;
            Juego_Actual.Carta_Inicial = true;
            Juego_Actual.Sentido = Sentido_Juego.Izquierda;
            Juego_Actual.Juego_Terminado = false;
            Jugador player;
            player = Jugadores.Find(j => j.Jugador_Principal == true);
            Juego_Actual.Jugadores.Add(player);
            JuegoActual = Juego_Actual;
            if (player.ID == 0)
                player = RepartirMazo(player, Juego_Actual);
            //Juego_Actual.Jugadores.RemoveAt(0);
            //Juego_Actual.Jugadores.Add(player);
            foreach (Jugador j in Jugadores)
            {
                if(!j.Jugador_Principal)
                    Juego_Actual.Jugadores.Add(j);
            }
            return Juego_Actual;
        }
        public Jugador CrearJugador(int id, bool turno_activo, bool jugador_principal)
        {
            Jugador _player = new Jugador(0, id, turno_activo, jugador_principal);
            return _player;
        }
        public Carta Get_Carta_Mazo()
        {
            Carta _carta = null;
            int index = 1;
            if(JuegoActual.Cartas.Count > 0)
            {
                index = rand.Next(JuegoActual.Cartas.Count);
                _carta = JuegoActual.Cartas.ElementAt(index);
                JuegoActual.Cartas.RemoveAt(index);
            }
            return _carta;
        }
        public Carta get_Primera_Carta()
        {
            Carta _carta = null;
            int index = 1;
            bool carta_valida = false;
            while (!carta_valida)
            {
                index = rand.Next(JuegoActual.Cartas.Count);
                _carta = JuegoActual.Cartas.ElementAt(index);
                if (_carta == null)
                    continue;
                if (_carta.Tipo != Tipo_Carta.RobaCuatro)
                    carta_valida = true;
            }
            JuegoActual.Cartas.RemoveAt(index);
            return _carta;
        }
        public Jugador RepartirMazo(Jugador _player, Game Juego_Actual)
        {
            Jugador player;
            Carta _carta;
            player = _player;
            Global_Variables.Penitencia_Activa = Penitencia_Jugador.Siete_Cartas;
            for (int i = 1; i < 8; i++)
            {
                _carta = Get_Carta_Mazo();
                player.Mano.Add(_carta);
                serial_port.Send_bytes(_carta, Juego_Actual, false); //envia la carta para ser eliminada de los otros mazos
            }
            return player;
        }
        public DataTable Mostrar_Cartas(Jugador _player)
        {
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("Numero");
            DataColumn c2 = new DataColumn("Color");
            DataColumn c3 = new DataColumn("Tipo");
            DataColumn c4 = new DataColumn("ID");
            DataColumn c5 = new DataColumn("Carta");
            dt.Columns.Add(c4);
            dt.Columns.Add(c1);
            dt.Columns.Add(c2);
            dt.Columns.Add(c3);
            c5.DataType = System.Type.GetType("System.Byte[]");
            dt.Columns.Add(c5);
            var imageConverter = new ImageConverter();
            foreach (Carta c in _player.Mano)
            {
                DataRow row = dt.NewRow();
                row["ID"] = c.ID;
                if (c.Numero == -1)
                    row["Numero"] = " ";
                else
                    row["Numero"] = c.Numero.ToString();
                if (c.Color == Color_Carta.Ninguno)
                    row["Color"] = "MultiColor";
                else
                    row["Color"] = c.Color.ToString();
                row["Tipo"] = c.Tipo.ToString();
                row["Carta"] = imageConverter.ConvertTo(c.Imagen_Carta, System.Type.GetType("System.Byte[]"));
                dt.Rows.Add(row);
            }
            return dt;
        }
        public DataTable Colors_Grid()
        {
            DataTable dt = new DataTable();
            DataColumn c1 = new DataColumn("COLORES");
            dt.Columns.Add(c1);
            DataRow Row1 = dt.NewRow();
            DataRow Row2 = dt.NewRow();
            DataRow Row3 = dt.NewRow();
            DataRow Row4 = dt.NewRow();
            Row1["COLORES"] = "Amarillo";
            Row2["COLORES"] = "Rojo";
            Row3["COLORES"] = "Azul";
            Row4["COLORES"] = "Verde";
            dt.Rows.Add(Row1);
            dt.Rows.Add(Row2);
            dt.Rows.Add(Row3);
            dt.Rows.Add(Row4);
            return dt;

        }
        public Carta Encontrar_Carta(Game Juego, int Next_Card_id)
        {
            try
            {
                Carta Card;
                Card = Juego.Jugadores.Find(j => j.Jugador_Principal == true).Mano.Find(c => c.ID == Next_Card_id);
                return Card;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Carta_Valida(Game Juego_Actual, Carta Carta_Jugada)
        {
            try
            {
                if (Juego_Actual.Tablero == null)
                    return true;
                if (Juego_Actual.Carta_Inicial && Juego_Actual.Tablero.Tipo == Tipo_Carta.CambioColor)
                    return true;
                if (Carta_Jugada.Tipo == Tipo_Carta.RobaCuatro || Carta_Jugada.Tipo == Tipo_Carta.CambioColor)
                    return true;
                if (Juego_Actual.Tablero.Color == Carta_Jugada.Color || JuegoActual.color_actual == Carta_Jugada.Color)
                    return true;
                if (Juego_Actual.Tablero.Numero < 10 && Carta_Jugada.Numero == Juego_Actual.Tablero.Numero)
                    return true;
                if (Juego_Actual.Tablero.Tipo != Tipo_Carta.Normal && Juego_Actual.Tablero.Tipo == Carta_Jugada.Tipo)
                    return true;
                return false;
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
                return false;
            }

        }
        public bool Enable_Cargar_Carta(Game Juego_Actual)
        {
            Jugador _player = Juego_Actual.Jugadores.Find(j => j.Jugador_Principal == true);
            if (!_player.Turno_Activo)
                return false;
            foreach (Carta c in _player.Mano)
            {
                if (Carta_Valida(Juego_Actual, c))
                    return false;
            }
            return true;
        }
        public void Cargar_Carta(Jugador _player)
        {
            if (JuegoActual.Cartas.Count > 0)
            {
                Carta _carta = Get_Carta_Mazo();
                _player.Mano.Add(_carta);
                Global_Variables.Penitencia_Activa = Penitencia_Jugador.Una_Carta;
                serial_port.Send_bytes(_carta, JuegoActual, false);
                if (!Carta_Valida(JuegoActual, _carta))
                {
                    serial_port.Pasar_Turno(_player.ID);
                    MessageBox.Show("Lo siento, la carta obtenida no puede ser jugada.");
                }
            }
            else
            {
                serial_port.Pasar_Turno(_player.ID);
                MessageBox.Show("¡Se acabaron las cartas del mazo!");
            }
        }
        public void Penitencia_Cargar_Cartas(int cantidad, Jugador _player)
        {
            Carta _carta;
            for(int i = 0; i < cantidad; i++)
            {
                _carta = Get_Carta_Mazo();
                if(_carta != null)
                {
                    _player.Mano.Add(_carta);
                    //JuegoActual.Jugadores.Find(j => j.Jugador_Principal == true).Mano.Add(_carta);
                    serial_port.Send_bytes(_carta, JuegoActual, false);
                }else
                {
                    serial_port.Pasar_Turno(_player.ID);
                }
            }
        }
        public void Actualizar_Sentido(string byte_3)
        {
            string sentido = byte_3.Substring(0, 2);
            if (sentido.Equals(Global_Variables.sentido_izq))
                JuegoActual.Sentido = Sentido_Juego.Izquierda;
            else
                JuegoActual.Sentido = Sentido_Juego.Derecha;
        }


        public void Actualizar_Turno(int id_destino)
        {
            try
            {
                if (JuegoActual.Jugadores.Find(j => j.Turno_Activo == true) != null)
                    JuegoActual.Jugadores.Find(j => j.Turno_Activo == true).Turno_Activo = false;
                JuegoActual.Jugadores.Find(j => j.ID == id_destino).Turno_Activo = true;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al actualizar el turno, id destino: " + id_destino + " EXCEPTION: "+e.ToString());
            }
        }
        public void Jugar_Carta(Carta _carta)
        {
            JuegoActual.Tablero = _carta;
            if (JuegoActual.Tablero.Tipo == Tipo_Carta.CambioColor || JuegoActual.Tablero.Tipo == Tipo_Carta.RobaCuatro)
                Juego_Form.Cambiar_Color();
            else
            {
                JuegoActual.color_actual = JuegoActual.Tablero.Color;
                Juego_Form.Color_Actual();
            } 
            if(JuegoActual.Tablero.Tipo == Tipo_Carta.CambioSentido)
                cambiar_sentido();

            serial_port.Send_bytes(_carta, JuegoActual, true);
            
            Actualizar_Form_Juego(Juego_Form, JuegoActual);
        }

        public int get_direccion(int id_origen, int id_destino)
        {
            string dir_or = Convert.ToString(id_origen, 2).PadLeft(2, '0');
            dir_or = dir_or.PadRight(8, '0');
            string dir_dest = Convert.ToString(id_destino, 2).PadLeft(4, '0');
            dir_dest = dir_dest.PadRight(8, '0');
            int int_diror = Convert.ToInt32(dir_or, 2);
            int int_dirde = Convert.ToInt32(dir_dest, 2);
            return (int_diror + int_dirde);
        }
        public int get_control(string _control)
        {
            int control = Convert.ToInt32(_control.PadLeft(8,'0'), 2);
            return control;
        }
        public int get_destino(string byte_2)
        {
            string dir_de = byte_2.Substring(2, 2);
            int id_destino = Convert.ToInt32(dir_de, 2);
            return id_destino;
        }
        public int get_origen(string byte_2)
        {
            string dir_or = byte_2.Substring(0, 2);
            int id_origen = Convert.ToInt32(dir_or, 2);
            return id_origen;
        }
        public int get_numero(string byte_3)
        {
            int numero = Convert.ToInt32(byte_3.Substring(4, 4), 2);
            return numero;
        }
        public string get_color(string byte_3)
        {
            string color = byte_3.Substring(2, 2);
            return color;
        }
        public string cambiocolor_to_string()
        {
            string _color;
            switch (JuegoActual.color_actual)
            {
                case Color_Carta.Amarillo:
                    {
                        _color = Global_Variables.color_amarillo.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Azul:
                    {
                        _color = Global_Variables.color_azul.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Rojo:
                    {
                        _color = Global_Variables.color_rojo.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Verde:
                    {
                        _color = Global_Variables.color_verde.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                default:
                    {
                        _color = Global_Variables.color_azul.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
            }
            return _color;
        }
        public string color_to_string(Carta _carta)
        {
            string _color;
            switch (_carta.Color)
            {
                case Color_Carta.Amarillo:
                    {
                        _color = Global_Variables.color_amarillo.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Azul:
                    {
                        _color = Global_Variables.color_azul.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Rojo:
                    {
                        _color = Global_Variables.color_rojo.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                case Color_Carta.Verde:
                    {
                        _color = Global_Variables.color_verde.PadRight(6,'0');
                        _color = _color.PadLeft(8, '0');
                    }
                    break;
                default:
                    {
                        _color = Global_Variables.color_azul.PadRight(6, '0');
                        _color = _color.PadLeft(8, '0');
                    }break;
            }
            return _color;
        }
        public Color_Carta string_to_color(string color, int numero)
        {
            if(numero < 13)
            {
                if (color.Equals(Global_Variables.color_amarillo))
                    return Color_Carta.Amarillo;
                if (color.Equals(Global_Variables.color_azul))
                    return Color_Carta.Azul;
                if (color.Equals(Global_Variables.color_rojo))
                    return Color_Carta.Rojo;
                if (color.Equals(Global_Variables.color_verde))
                    return Color_Carta.Verde;
            }
            return Color_Carta.Ninguno;
        }
        public int carta_to_int(Carta _carta)
        {
            string _color = "";
            string _numero = Convert.ToString(_carta.Numero, 2).PadLeft(8, '0');

            if(_carta.Tipo == Tipo_Carta.CambioColor || _carta.Tipo == Tipo_Carta.RobaCuatro)
                _color = cambiocolor_to_string();
            else
                _color = color_to_string(_carta);

            int numero = Convert.ToInt32(_numero, 2);
            int color = Convert.ToInt32(_color, 2);
            return (numero + color);
        }
        public int crear_carta_null()
        {
            string _color;
            _color = cambiocolor_to_string();
            int color = Convert.ToInt32(_color, 2);
            return (15 + color);
        }
        public int sentido_to_int(Game _juego)
        {
            string _sentido;
            int sentido;
            if(_juego.Sentido == Sentido_Juego.Izquierda)
            {
                _sentido = Global_Variables.sentido_izq.PadRight(8, '0');
                sentido = Convert.ToInt32(_sentido, 2);
            }
            else
            {
                _sentido = Global_Variables.sentido_der.PadRight(8, '0');
                sentido = Convert.ToInt32(_sentido, 2);
            }
            return sentido;
        }
        public void cambiar_sentido()
        {
            if (JuegoActual.Sentido == Sentido_Juego.Izquierda)
                JuegoActual.Sentido = Sentido_Juego.Derecha;
            else
                JuegoActual.Sentido = Sentido_Juego.Izquierda;
        }
    }
}
