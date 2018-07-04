﻿using MonopolioRedes.Modelo.Tarjetas;
using MonopolioRedes.Modelo.Casillas;
using System.Collections.Generic;
using System.Net.Sockets;

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonopolioRedes.Modelo
{
    public class Jugador
    {
        private int _id;
        private string _usuario;
        private string _password;
        private string _nombre;
        private string _apellido;
        private int _cartera;
        private bool _detenido;
        private int _turnos_carcel;
        private int _posicion;
        private bool _turno_activo;
        private bool _principal;

        public List<Tarjeta_Casualidad> Tarjeta_Casualidad = new List<Tarjeta_Casualidad>();
        public List<Tarjeta_Arca> Tarjeta_Arca = new List<Tarjeta_Arca>();
        public List<Propiedad> Propiedades = new List<Propiedad>();

        private TcpClient _cliente;
        public byte[] Lectura;
        public byte[] Escritura;
        private int _turno;
        private Ficha _ficha;

        public Jugador(int id)
        {
            this.Id = id;
            this._cartera = 1500;
            this._detenido = false;
            this._posicion = 0;
            this._turnos_carcel = 0;
            this._turno_activo = false;
            _turno = 0;
            _ficha = null;
            _principal = false;
        }


        public int Id
        {
            get { return this._id; }
            set { _id = value; }
        }

        public string Usuario
        {
            get { return this._usuario; }
            set { this._usuario = value; }
        }

        public bool Detenido
        {
            get { return this._detenido; }
            set { this._detenido = value; }
        }

        public int Posicion
        {
            get { return this._posicion; }
            set { this._posicion = value; }
        }

        public int Cartera
        {
            get { return this._cartera; }
            set { this._cartera = value; }
        }

        public int Turnos_Carcel
        {
            get { return this._turnos_carcel; }
            set { this._turnos_carcel = value; }
        }

        public bool Turno_Activo
        {
            get { return this._turno_activo; }
            set { this._turno_activo = value; }
        }

        public TcpClient Cliente
        {
            get { return this._cliente; }
            set { this._cliente = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public int Turno
        {
            get { return _turno; }
            set { _turno = value; }
        }

        public Ficha Ficha
        {
            get { return _ficha; }
            set { _ficha = value; }
        }

        public bool Principal { get => _principal; set => _principal = value; }

        public void Realizar_Jugada()
        {
            int resultado_dado = Dado.Lanzar_Dado();

            Calcular_Posicion(resultado_dado);
        }

        public void Calcular_Posicion(int resultado_dado)
        {
            int casilla_destino = this._posicion + resultado_dado;

            if (casilla_destino > 39)
            {
                this._posicion = casilla_destino - 40;
            }
            else
            {
                this._posicion = casilla_destino;
            }
        }

        public void AsignarPopiedad(Propiedad propiedad)
        {
            Propiedades.Add(propiedad);
        }

        public void RemoverPropiedad(Propiedad propiedad)
        {
            Propiedades.Remove(propiedad);
        }

        public void RemoverPropiedades()
        {
            foreach (Propiedad p in Propiedades)
            {
                p.Propietario = null;
            }

            Propiedades.Clear();
        }

    }
}
