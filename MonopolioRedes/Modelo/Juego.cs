using MonopolioRedes.Modelo.Casillas;
using MonopolioRedes.Modelo.Tarjetas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolioRedes.Modelo
{
    public class Juego
    {
        public List<Jugador> JugadoresRegistrados;
        public List<Jugador> JugadoresConectados;
        public List<Casilla> Casillas;
        public List<Tarjeta_Arca> Tarjetas_Arca;
        public List<Tarjeta_Casualidad> Tarjetas_Casualidad;
        public List<Ficha> Fichas;
        public int Fondo_Impuesto;
        public Banco Banco;
        public bool Connected;
        private int _cantidadJugadores;
        public bool Iniciado;
        private Random turnoJugador;

        private static Juego _juego = null;

        private Juego()
        {
            ValoresIniciales();
        }

        public static Juego ObtenerJuego
        {
            get
            {
                if (_juego == null)
                    _juego = new Juego();

                return _juego;
            }

            private set { }
        }

        public void AsignarFichaJugador(Jugador jugador)
        {
            if (jugador.Ficha != null)
                return;

            jugador.Ficha = Fichas.Find(f => f.Id == jugador.Id);
        }


        private void ValoresIniciales()
        {
            Casillas = new List<Casilla>();

            JugadoresRegistrados = new List<Jugador>();
            JugadoresConectados = new List<Jugador>();

            Tarjetas_Arca = new List<Tarjeta_Arca>();

            Tarjetas_Casualidad = new List<Tarjeta_Casualidad>();

            Fichas = new List<Ficha>();

            this.Fondo_Impuesto = 0;

            this.Banco = new Banco();

            Crear_Tablero();
            Crear_Tarjetas_Arca();
            Crear_Tarjetas_Casualidad();
            CrearFichas();
            Connected = false;
            Iniciado = false;

            turnoJugador = new Random();
        }

        public int get_id_destino(int id_origen)
        {
            int max_id = JugadoresConectados.Count - 1;

            int id_destino;
            if (id_origen == max_id)
            {
                id_destino = 0;
            }
            else
            {
                id_destino = id_origen + 1;
            }

            return id_destino;
        }

        public bool IniciarPartida()
        {
            if (JugadoresConectados.Count < CantidadJugadores)
                return false;


            Iniciado = true;

            List<int> OrdenTurno = new List<int>();

            for(int i = 1; i <= JugadoresConectados.Count; i++)
            {
                OrdenTurno.Add(i);
            }

            int index = 0;

            foreach(Jugador jugador in JugadoresConectados)
            {
                index = turnoJugador.Next(0, OrdenTurno.Count);
                jugador.Turno = OrdenTurno.ElementAt(index);
                OrdenTurno.RemoveAt(index);

                if (jugador.Turno == 1)
                    jugador.Turno_Activo = true;
            }

            return true;

        }


        public void ReiniciarJuego()
        {
            ValoresIniciales();
        }


        public void GestionarJugadaJugador(Jugador jugador)
        {
            jugador.Realizar_Jugada();

            return;

            int CasillaId = jugador.Posicion;

            Casilla _casilla = Casillas.Find(c => c.Posicion == CasillaId);

            if (_casilla == null)
                return;

            if (_casilla.Tipo == Tipo_Casilla.Inicio)
            {
                return;
            }

            if (_casilla.Tipo == Tipo_Casilla.Arca_Comunal)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Casualidad)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Detencion)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Parking)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Impuesto)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Propiedad)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Servicio)
            {
                return;
            }

            if(_casilla.Tipo == Tipo_Casilla.Tren)
            {
                return;
            }


        }

        public int CantidadJugadores
        {
            get { return _cantidadJugadores; }
            set { _cantidadJugadores = value; }
        }

        private void Crear_Tablero()
        {
            for (int i = 0; i <= 39; i++)
            {

                Propiedad Propiedad;
                Casilla Casilla;

                if (i == 0)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Inicio;
                    Casilla.Imagen = null; //Imagen

                    this.Casillas.Add(Casilla);
                }
                else if (i == 1)
                {
                    Propiedad = new Avenida("San Luis Norte", Color_Avenida.Morado, 60, 2, 10, 30, 90, 160, 250, 30, 50, 50, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 2 || i == 17 || i == 33)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Arca_Comunal;
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 3)
                {
                    Propiedad = new Avenida("San Luis Sur", Color_Avenida.Morado, 60, 4, 20, 60, 180, 320, 450, 30, 50, 50, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 4 || i == 38)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Impuesto; // 150
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 5)
                {
                    Propiedad = new Tren("Tren Norte", Tipo_Tren.Tren_Norte, 200, 25, 50, 100, 200, 100, i, Tipo_Casilla.Tren, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 6)
                {
                    Propiedad = new Avenida("Formosa Este", Color_Avenida.Azul_claro, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 7 || i == 22 || i == 36)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Casualidad;
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 8)
                {
                    Propiedad = new Avenida("Formosa Norte", Color_Avenida.Azul_claro, 100, 6, 30, 90, 270, 400, 550, 50, 50, 50, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 9)
                {
                    Propiedad = new Avenida("Formosa Sur", Color_Avenida.Azul_claro, 120, 8, 40, 100, 300, 450, 600, 60, 50, 50, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 10)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Carcel;
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 11)
                {
                    Propiedad = new Avenida("San Juan Este", Color_Avenida.Rosado, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 12)
                {
                    Propiedad = new Servicio("Luz", Tipo_Servicio.Servicio_Luz, 150, 75, i, Tipo_Casilla.Servicio, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 13)
                {
                    Propiedad = new Avenida("San Juan Sur", Color_Avenida.Rosado, 140, 10, 50, 150, 450, 625, 750, 70, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 14)
                {
                    Propiedad = new Avenida("San Juan Norte", Color_Avenida.Rosado, 160, 12, 60, 80, 500, 700, 900, 80, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 15)
                {
                    Propiedad = new Tren("Tren Oeste", Tipo_Tren.Tren_Oeste, 200, 25, 50, 100, 200, 100, i, Tipo_Casilla.Tren, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 16)
                {
                    Propiedad = new Avenida("Neuquen Este", Color_Avenida.Naranja, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 18)
                {
                    Propiedad = new Avenida("Neuquen Sur", Color_Avenida.Naranja, 180, 14, 70, 200, 550, 750, 950, 90, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 19)
                {
                    Propiedad = new Avenida("Neuquen Norte", Color_Avenida.Naranja, 200, 16, 80, 220, 600, 800, 1000, 100, 100, 100, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 20)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Parking;
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 21)
                {
                    Propiedad = new Avenida("Mendoza Este", Color_Avenida.Rojo, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 23)
                {
                    Propiedad = new Avenida("Mendoza Sur", Color_Avenida.Rojo, 220, 18, 90, 250, 700, 875, 1050, 110, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 24)
                {
                    Propiedad = new Avenida("Mendoza Norte", Color_Avenida.Rojo, 240, 20, 100, 300, 750, 925, 1100, 120, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 25)
                {
                    Propiedad = new Tren("Tren Este", Tipo_Tren.Tren_Este, 200, 25, 50, 100, 200, 100, i, Tipo_Casilla.Tren, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 26)
                {
                    Propiedad = new Avenida("Santa fe Este", Color_Avenida.Amarillo, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 27)
                {
                    Propiedad = new Avenida("Santa fe Sur", Color_Avenida.Amarillo, 260, 22, 110, 330, 800, 975, 1150, 130, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 28)
                {
                    Propiedad = new Servicio("Agua", Tipo_Servicio.Servicio_Agua, 150, 75, i, Tipo_Casilla.Servicio, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 29)
                {
                    Propiedad = new Avenida("Santa fe Norte", Color_Avenida.Amarillo, 280, 24, 120, 360, 850, 1025, 1200, 140, 150, 150, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 30)
                {
                    Casilla = new Casilla();
                    Casilla.Posicion = i;
                    Casilla.Tipo = Tipo_Casilla.Detencion;
                    Casilla.Imagen = null;

                    this.Casillas.Add(Casilla);
                }
                else if (i == 31)
                {
                    Propiedad = new Avenida("Cordoba Este", Color_Avenida.Verde, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 32)
                {
                    Propiedad = new Avenida("Cordoba Sur", Color_Avenida.Verde, 300, 26, 130, 390, 900, 1100, 1275, 150, 200, 200, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 34)
                {
                    Propiedad = new Avenida("Cordoba Norte", Color_Avenida.Verde, 320, 28, 150, 450, 1000, 1200, 1400, 160, 200, 200, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 35)
                {
                    Propiedad = new Tren("Tren Sur", Tipo_Tren.Tren_Sur, 200, 25, 50, 100, 200, 100, i, Tipo_Casilla.Tren, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 37)
                {
                    Propiedad = new Avenida("Buenos Aires Norte", Color_Avenida.Azul_Oscuro, 350, 35, 175, 500, 1100, 1300, 1500, 175, 200, 200, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
                else if (i == 39)
                {
                    Propiedad = new Avenida("Buenos Aires Sur", Color_Avenida.Azul_Oscuro, 400, 50, 200, 600, 1400, 1700, 2000, 200, 200, 200, i, Tipo_Casilla.Propiedad, null);

                    this.Casillas.Add(Propiedad);
                }
            }
        }

        private void Crear_Tarjetas_Arca()
        {
            Tarjeta_Arca Tarjeta;

            Tarjeta = new Tarjeta_Arca(1, Efecto_Arca.Ir_Carcel, "Secuestraste a Biagio, vas a la cárcel");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(2, Efecto_Arca.Recibir_10, "Primer lugar en concurso de belleza, ganas 10$ de premio");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(3, Efecto_Arca.Recibir_50_Jugador, "Rescaste a Biagio, cada jugador te paga 50$");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(4, Efecto_Arca.Recibir_100, "Tu abuelo murió, heredas 100$");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(5, Efecto_Arca.Recibir_200, "Ganaste 200$ por error del banco");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(6, Efecto_Arca.Recibir_200_Inicio, "Ve hasta el inicio y oobra 200$");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(7, Efecto_Arca.Restar_20, "Dañaste la puerta del laboratorio, paga 20$");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(8, Efecto_Arca.Restar_25_Propiedad, "Paga 25$ por cada propiedad");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(9, Efecto_Arca.Restar_50_Jugador, "Te robaste unos cables del laboratorio, paga 50$ a cada jugador");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(10, Efecto_Arca.Restar_100, "Reprobaste redes, pagas 100$ para pasar");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(11, Efecto_Arca.Restar_150, "Dañaste una computadora de laboratorio, paga 150$");
            Tarjetas_Arca.Add(Tarjeta);

            Tarjeta = new Tarjeta_Arca(12, Efecto_Arca.Salir_Prision, "Pasaste redes, sales de prisión.");
            Tarjetas_Arca.Add(Tarjeta);

        }

        private void Crear_Tarjetas_Casualidad()
        {
            Tarjeta_Casualidad Tarjeta;

            Tarjeta = new Tarjeta_Casualidad(1, Efecto_Casualidad.Dar_25_Jugador, "Das 25$ a cada jugador");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(2, Efecto_Casualidad.Ir_Carcel, "Mataste a Igor, vas a la carcel");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(3, Efecto_Casualidad.Ir_Mendoza_Sur, "Visita a los mendoza, ve a Mendoza Sur");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(4, Efecto_Casualidad.Ir_San_Luis, "Ve hasta San Luis Norte");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(5, Efecto_Casualidad.Recibir_50, "Banco Venezuela te regala 50$");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(6, Efecto_Casualidad.Recibir_100, "Has ganado el concurso de Counter Strike, ganas 100$");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(7, Efecto_Casualidad.Recibir_150, "Le robas 150$ a Biagio");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(8, Efecto_Casualidad.Recibir_200_Inicio, "Ve al inicio y recibes 200$");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(9, Efecto_Casualidad.Restar_3_Pasos, "Se te quedó el celular, vuelve 3 pasos atrás");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(10, Efecto_Casualidad.Restar_25_Propiedad, "Pagas 25$ por cada propiedad.");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(11, Efecto_Casualidad.Restar_50, "Perdiste en Counter Strike, paga 50$");
            Tarjetas_Casualidad.Add(Tarjeta);

            Tarjeta = new Tarjeta_Casualidad(12, Efecto_Casualidad.Salir_Prision, "Pasaste redes, sales de prisión.");
            Tarjetas_Casualidad.Add(Tarjeta);

        }

        private void CrearFichas()
        {
            Ficha ficha;

            ficha = new Ficha(0, "Rojo");
            ficha.AsignarCoordenadaFicha(0, 495, 498);
            ficha.AsignarCoordenadaFicha(1, 447, 510);
            ficha.AsignarCoordenadaFicha(2, 402, 510);
            ficha.AsignarCoordenadaFicha(3, 357, 510);
            ficha.AsignarCoordenadaFicha(4, 311, 510);
            ficha.AsignarCoordenadaFicha(5, 267, 510);
            ficha.AsignarCoordenadaFicha(6, 220, 510);
            ficha.AsignarCoordenadaFicha(7, 175, 510);
            ficha.AsignarCoordenadaFicha(8, 129, 510);
            ficha.AsignarCoordenadaFicha(9, 85, 510);
            ficha.AsignarCoordenadaFicha(10, 16, 510);
            ficha.AsignarCoordenadaFicha(11, 37, 448);
            ficha.AsignarCoordenadaFicha(12, 37, 403);
            ficha.AsignarCoordenadaFicha(13, 37, 258);
            ficha.AsignarCoordenadaFicha(14, 37, 312);
            ficha.AsignarCoordenadaFicha(15, 37, 266);
            ficha.AsignarCoordenadaFicha(16, 37, 220);
            ficha.AsignarCoordenadaFicha(17, 37, 175);
            ficha.AsignarCoordenadaFicha(18, 37, 129);
            ficha.AsignarCoordenadaFicha(19, 37, 83);
            ficha.AsignarCoordenadaFicha(20, 37, 16);
            ficha.AsignarCoordenadaFicha(21, 107, 16);
            ficha.AsignarCoordenadaFicha(22, 152, 16);
            ficha.AsignarCoordenadaFicha(23, 197, 16);
            ficha.AsignarCoordenadaFicha(24, 243, 16);
            ficha.AsignarCoordenadaFicha(25, 289, 16);
            ficha.AsignarCoordenadaFicha(26, 334, 16);
            ficha.AsignarCoordenadaFicha(27, 380, 16);
            ficha.AsignarCoordenadaFicha(28, 425, 16);
            ficha.AsignarCoordenadaFicha(29, 470, 16);
            ficha.AsignarCoordenadaFicha(30, 540, 16);
            ficha.AsignarCoordenadaFicha(31, 540, 84);
            ficha.AsignarCoordenadaFicha(32, 540, 129);
            ficha.AsignarCoordenadaFicha(33, 540, 175);
            ficha.AsignarCoordenadaFicha(34, 540, 220);
            ficha.AsignarCoordenadaFicha(35, 540, 266);
            ficha.AsignarCoordenadaFicha(36, 540, 312);
            ficha.AsignarCoordenadaFicha(37, 540, 358);
            ficha.AsignarCoordenadaFicha(38, 540, 403);
            ficha.AsignarCoordenadaFicha(39, 540, 448);
            Fichas.Add(ficha);

            ficha = new Ficha(1, "Amarillo");
            ficha.AsignarCoordenadaFicha(0, 534, 530);
            ficha.AsignarCoordenadaFicha(1, 468, 542);
            ficha.AsignarCoordenadaFicha(2, 423, 542);
            ficha.AsignarCoordenadaFicha(3, 378, 542);
            ficha.AsignarCoordenadaFicha(4, 332, 542);
            ficha.AsignarCoordenadaFicha(5, 288, 542);
            ficha.AsignarCoordenadaFicha(6, 241, 542);
            ficha.AsignarCoordenadaFicha(7, 196, 542);
            ficha.AsignarCoordenadaFicha(8, 150, 542);
            ficha.AsignarCoordenadaFicha(9, 106, 542);
            ficha.AsignarCoordenadaFicha(10, 37, 542);
            ficha.AsignarCoordenadaFicha(11, 12, 469);
            ficha.AsignarCoordenadaFicha(12, 12, 424);
            ficha.AsignarCoordenadaFicha(13, 12, 379);
            ficha.AsignarCoordenadaFicha(14, 12, 333);
            ficha.AsignarCoordenadaFicha(15, 12, 287);
            ficha.AsignarCoordenadaFicha(16, 12, 241);
            ficha.AsignarCoordenadaFicha(17, 12, 196);
            ficha.AsignarCoordenadaFicha(18, 12, 150);
            ficha.AsignarCoordenadaFicha(19, 12, 104);
            ficha.AsignarCoordenadaFicha(20, 12, 37);
            ficha.AsignarCoordenadaFicha(21, 82, 37);
            ficha.AsignarCoordenadaFicha(22, 127, 37);
            ficha.AsignarCoordenadaFicha(23, 172, 37);
            ficha.AsignarCoordenadaFicha(24, 218, 37);
            ficha.AsignarCoordenadaFicha(25, 264, 37);
            ficha.AsignarCoordenadaFicha(26, 309, 37);
            ficha.AsignarCoordenadaFicha(27, 355, 37);
            ficha.AsignarCoordenadaFicha(28, 400, 37);
            ficha.AsignarCoordenadaFicha(29, 445, 37);
            ficha.AsignarCoordenadaFicha(30, 515, 37);
            ficha.AsignarCoordenadaFicha(31, 515, 105);
            ficha.AsignarCoordenadaFicha(32, 515, 150);
            ficha.AsignarCoordenadaFicha(33, 515, 196);
            ficha.AsignarCoordenadaFicha(34, 515, 241);
            ficha.AsignarCoordenadaFicha(35, 515, 287);
            ficha.AsignarCoordenadaFicha(36, 515, 333);
            ficha.AsignarCoordenadaFicha(37, 515, 379);
            ficha.AsignarCoordenadaFicha(38, 515, 424);
            ficha.AsignarCoordenadaFicha(39, 515, 469);
            Fichas.Add(ficha);

            ficha = new Ficha(2, "Azul");
            ficha.AsignarCoordenadaFicha(0, 495, 530);
            ficha.AsignarCoordenadaFicha(1, 447, 542);
            ficha.AsignarCoordenadaFicha(2, 402, 542);
            ficha.AsignarCoordenadaFicha(3, 357, 542);
            ficha.AsignarCoordenadaFicha(4, 311, 542);
            ficha.AsignarCoordenadaFicha(5, 267, 542);
            ficha.AsignarCoordenadaFicha(6, 220, 542);
            ficha.AsignarCoordenadaFicha(7, 175, 542);
            ficha.AsignarCoordenadaFicha(8, 129, 542);
            ficha.AsignarCoordenadaFicha(9, 85, 542);
            ficha.AsignarCoordenadaFicha(10, 16, 542);
            ficha.AsignarCoordenadaFicha(11, 12, 448);
            ficha.AsignarCoordenadaFicha(12, 12, 403);
            ficha.AsignarCoordenadaFicha(13, 12, 358);
            ficha.AsignarCoordenadaFicha(14, 12, 312);
            ficha.AsignarCoordenadaFicha(15, 12, 266);
            ficha.AsignarCoordenadaFicha(16, 12, 220);
            ficha.AsignarCoordenadaFicha(17, 12, 175);
            ficha.AsignarCoordenadaFicha(18, 12, 129);
            ficha.AsignarCoordenadaFicha(19, 12, 83);
            ficha.AsignarCoordenadaFicha(20, 12, 16);
            ficha.AsignarCoordenadaFicha(21, 82, 16);
            ficha.AsignarCoordenadaFicha(22, 127, 16);
            ficha.AsignarCoordenadaFicha(23, 172, 16);
            ficha.AsignarCoordenadaFicha(24, 218, 16);
            ficha.AsignarCoordenadaFicha(25, 264, 16);
            ficha.AsignarCoordenadaFicha(26, 309, 16);
            ficha.AsignarCoordenadaFicha(27, 355, 16);
            ficha.AsignarCoordenadaFicha(28, 400, 16);
            ficha.AsignarCoordenadaFicha(29, 445, 16);
            ficha.AsignarCoordenadaFicha(30, 515, 16);
            ficha.AsignarCoordenadaFicha(31, 515, 84);
            ficha.AsignarCoordenadaFicha(32, 515, 129);
            ficha.AsignarCoordenadaFicha(33, 515, 175);
            ficha.AsignarCoordenadaFicha(34, 515, 220);
            ficha.AsignarCoordenadaFicha(35, 515, 266);
            ficha.AsignarCoordenadaFicha(36, 515, 312);
            ficha.AsignarCoordenadaFicha(37, 515, 358);
            ficha.AsignarCoordenadaFicha(38, 515, 403);
            ficha.AsignarCoordenadaFicha(39, 515, 448);

            Fichas.Add(ficha);

            ficha = new Ficha(3, "Verde");
            ficha.AsignarCoordenadaFicha(0, 534, 498);
            ficha.AsignarCoordenadaFicha(1, 468, 510);
            ficha.AsignarCoordenadaFicha(2, 423, 510);
            ficha.AsignarCoordenadaFicha(3, 378, 510);
            ficha.AsignarCoordenadaFicha(4, 332, 510);
            ficha.AsignarCoordenadaFicha(5, 288, 510);
            ficha.AsignarCoordenadaFicha(6, 241, 510);
            ficha.AsignarCoordenadaFicha(7, 196, 510);
            ficha.AsignarCoordenadaFicha(8, 150, 510);
            ficha.AsignarCoordenadaFicha(9, 106, 510);
            ficha.AsignarCoordenadaFicha(10, 37, 510);
            ficha.AsignarCoordenadaFicha(11, 37, 469);
            ficha.AsignarCoordenadaFicha(12, 37, 424);
            ficha.AsignarCoordenadaFicha(13, 37, 379);
            ficha.AsignarCoordenadaFicha(14, 37, 333);
            ficha.AsignarCoordenadaFicha(15, 37, 287);
            ficha.AsignarCoordenadaFicha(16, 37, 241);
            ficha.AsignarCoordenadaFicha(17, 37, 196);
            ficha.AsignarCoordenadaFicha(18, 37, 150);
            ficha.AsignarCoordenadaFicha(19, 37, 104);
            ficha.AsignarCoordenadaFicha(20, 37, 37);
            ficha.AsignarCoordenadaFicha(21, 107, 37);
            ficha.AsignarCoordenadaFicha(22, 152, 37);
            ficha.AsignarCoordenadaFicha(23, 197, 37);
            ficha.AsignarCoordenadaFicha(24, 243, 37);
            ficha.AsignarCoordenadaFicha(25, 289, 37);
            ficha.AsignarCoordenadaFicha(26, 334, 37);
            ficha.AsignarCoordenadaFicha(27, 380, 37);
            ficha.AsignarCoordenadaFicha(28, 425, 37);
            ficha.AsignarCoordenadaFicha(29, 470, 37);
            ficha.AsignarCoordenadaFicha(30, 540, 37);
            ficha.AsignarCoordenadaFicha(31, 540, 105);
            ficha.AsignarCoordenadaFicha(32, 540, 150);
            ficha.AsignarCoordenadaFicha(33, 540, 196);
            ficha.AsignarCoordenadaFicha(34, 540, 241);
            ficha.AsignarCoordenadaFicha(35, 540, 287);
            ficha.AsignarCoordenadaFicha(36, 540, 333);
            ficha.AsignarCoordenadaFicha(37, 540, 379);
            ficha.AsignarCoordenadaFicha(38, 540, 424);
            ficha.AsignarCoordenadaFicha(39, 540, 469);
            Fichas.Add(ficha);

        }
    }
}
