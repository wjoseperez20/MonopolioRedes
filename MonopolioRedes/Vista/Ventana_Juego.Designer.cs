﻿namespace MonopolioRedes.Vista
{
    partial class Ventana_Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Juego));
            this.bSaltarTurno = new System.Windows.Forms.Button();
            this.bComprarPropiedad = new System.Windows.Forms.Button();
            this.lJugadorPropiedades = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lJugadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lDado = new System.Windows.Forms.Label();
            this.lazul = new System.Windows.Forms.Label();
            this.lamarillo = new System.Windows.Forms.Label();
            this.lverde = new System.Windows.Forms.Label();
            this.lrojo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bLanzar = new System.Windows.Forms.Button();
            this.lTablero = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSaltarTurno
            // 
            this.bSaltarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bSaltarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaltarTurno.Location = new System.Drawing.Point(1076, 535);
            this.bSaltarTurno.Margin = new System.Windows.Forms.Padding(4);
            this.bSaltarTurno.Name = "bSaltarTurno";
            this.bSaltarTurno.Size = new System.Drawing.Size(260, 79);
            this.bSaltarTurno.TabIndex = 24;
            this.bSaltarTurno.Text = "Pasar Turno";
            this.bSaltarTurno.UseVisualStyleBackColor = false;
            this.bSaltarTurno.Click += new System.EventHandler(this.bSaltarTurno_Click);
            // 
            // bComprarPropiedad
            // 
            this.bComprarPropiedad.BackColor = System.Drawing.Color.Lime;
            this.bComprarPropiedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bComprarPropiedad.Location = new System.Drawing.Point(808, 535);
            this.bComprarPropiedad.Margin = new System.Windows.Forms.Padding(4);
            this.bComprarPropiedad.Name = "bComprarPropiedad";
            this.bComprarPropiedad.Size = new System.Drawing.Size(260, 78);
            this.bComprarPropiedad.TabIndex = 19;
            this.bComprarPropiedad.Text = "Comprar Propiedad";
            this.bComprarPropiedad.UseVisualStyleBackColor = false;
            // 
            // lJugadorPropiedades
            // 
            this.lJugadorPropiedades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJugadorPropiedades.FormattingEnabled = true;
            this.lJugadorPropiedades.ItemHeight = 20;
            this.lJugadorPropiedades.Location = new System.Drawing.Point(804, 212);
            this.lJugadorPropiedades.Margin = new System.Windows.Forms.Padding(4);
            this.lJugadorPropiedades.Name = "lJugadorPropiedades";
            this.lJugadorPropiedades.Size = new System.Drawing.Size(531, 184);
            this.lJugadorPropiedades.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(804, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Mis Propiedades:";
            // 
            // lJugadores
            // 
            this.lJugadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJugadores.FormattingEnabled = true;
            this.lJugadores.ItemHeight = 20;
            this.lJugadores.Location = new System.Drawing.Point(796, 46);
            this.lJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.lJugadores.Name = "lJugadores";
            this.lJugadores.Size = new System.Drawing.Size(531, 104);
            this.lJugadores.TabIndex = 26;
            this.lJugadores.SelectedIndexChanged += new System.EventHandler(this.lJugadores_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(804, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Jugadores en la partida:";
            // 
            // lDado
            // 
            this.lDado.AutoSize = true;
            this.lDado.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDado.Location = new System.Drawing.Point(1192, 460);
            this.lDado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lDado.Name = "lDado";
            this.lDado.Size = new System.Drawing.Size(92, 31);
            this.lDado.TabIndex = 30;
            this.lDado.Text = "label4";
            // 
            // lazul
            // 
            this.lazul.BackColor = System.Drawing.Color.Transparent;
            this.lazul.Image = global::MonopolioRedes.Properties.Resources.FichaAzul1;
            this.lazul.Location = new System.Drawing.Point(526, 529);
            this.lazul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lazul.Name = "lazul";
            this.lazul.Size = new System.Drawing.Size(31, 26);
            this.lazul.TabIndex = 34;
            this.lazul.Click += new System.EventHandler(this.lazul_Click);
            // 
            // lamarillo
            // 
            this.lamarillo.BackColor = System.Drawing.Color.Transparent;
            this.lamarillo.Image = global::MonopolioRedes.Properties.Resources.FichaAmarilla1;
            this.lamarillo.Location = new System.Drawing.Point(487, 529);
            this.lamarillo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lamarillo.Name = "lamarillo";
            this.lamarillo.Size = new System.Drawing.Size(31, 26);
            this.lamarillo.TabIndex = 33;
            this.lamarillo.Click += new System.EventHandler(this.lamarillo_Click);
            // 
            // lverde
            // 
            this.lverde.BackColor = System.Drawing.Color.Transparent;
            this.lverde.Image = global::MonopolioRedes.Properties.Resources.FichaVerde;
            this.lverde.Location = new System.Drawing.Point(526, 491);
            this.lverde.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lverde.Name = "lverde";
            this.lverde.Size = new System.Drawing.Size(31, 26);
            this.lverde.TabIndex = 32;
            this.lverde.Click += new System.EventHandler(this.lverde_Click);
            // 
            // lrojo
            // 
            this.lrojo.BackColor = System.Drawing.Color.Transparent;
            this.lrojo.Image = global::MonopolioRedes.Properties.Resources.FichaRoja;
            this.lrojo.Location = new System.Drawing.Point(487, 491);
            this.lrojo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lrojo.Name = "lrojo";
            this.lrojo.Size = new System.Drawing.Size(31, 26);
            this.lrojo.TabIndex = 31;
            this.lrojo.Click += new System.EventHandler(this.lrojo_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(1391, 801);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 98);
            this.label3.TabIndex = 29;
            // 
            // bLanzar
            // 
            this.bLanzar.BackColor = System.Drawing.Color.White;
            this.bLanzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLanzar.Image = global::MonopolioRedes.Properties.Resources.dado;
            this.bLanzar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bLanzar.Location = new System.Drawing.Point(804, 436);
            this.bLanzar.Margin = new System.Windows.Forms.Padding(4);
            this.bLanzar.Name = "bLanzar";
            this.bLanzar.Size = new System.Drawing.Size(361, 80);
            this.bLanzar.TabIndex = 18;
            this.bLanzar.Text = "TIRAR DADO";
            this.bLanzar.UseVisualStyleBackColor = false;
            this.bLanzar.Click += new System.EventHandler(this.bLanzar_Click_1);
            // 
            // lTablero
            // 
            this.lTablero.BackColor = System.Drawing.Color.Transparent;
            this.lTablero.Image = global::MonopolioRedes.Properties.Resources.tablero;
            this.lTablero.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lTablero.Location = new System.Drawing.Point(-1, -1);
            this.lTablero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTablero.Name = "lTablero";
            this.lTablero.Size = new System.Drawing.Size(753, 706);
            this.lTablero.TabIndex = 8;
            this.lTablero.Click += new System.EventHandler(this.lTablero_Click);
            // 
            // Ventana_Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1457, 697);
            this.Controls.Add(this.lazul);
            this.Controls.Add(this.lamarillo);
            this.Controls.Add(this.lverde);
            this.Controls.Add(this.lrojo);
            this.Controls.Add(this.lDado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lJugadorPropiedades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lJugadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSaltarTurno);
            this.Controls.Add(this.bComprarPropiedad);
            this.Controls.Add(this.bLanzar);
            this.Controls.Add(this.lTablero);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Ventana_Juego";
            this.Text = "Ventana_Juego";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ventana_Juego_FormClosed);
            this.Load += new System.EventHandler(this.Ventana_Juego_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lTablero;
        private System.Windows.Forms.Button bSaltarTurno;
        private System.Windows.Forms.Button bComprarPropiedad;
        private System.Windows.Forms.Button bLanzar;
        private System.Windows.Forms.ListBox lJugadorPropiedades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lJugadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lDado;
        private System.Windows.Forms.Label lrojo;
        private System.Windows.Forms.Label lverde;
        private System.Windows.Forms.Label lamarillo;
        private System.Windows.Forms.Label lazul;
    }
}