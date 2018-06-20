namespace MonopolioRedes.Vista
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
            this.lTablero = new System.Windows.Forms.Label();
            this.bSaltarTurno = new System.Windows.Forms.Button();
            this.bSalirCarcelC = new System.Windows.Forms.Button();
            this.bSalirCarcelA = new System.Windows.Forms.Button();
            this.bComprarHotel = new System.Windows.Forms.Button();
            this.bComprarCasa = new System.Windows.Forms.Button();
            this.bComprarPropiedad = new System.Windows.Forms.Button();
            this.bLanzar = new System.Windows.Forms.Button();
            this.lJugadorPropiedades = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lJugadores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lTablero
            // 
            this.lTablero.BackColor = System.Drawing.Color.Transparent;
            this.lTablero.Image = ((System.Drawing.Image)(resources.GetObject("lTablero.Image")));
            this.lTablero.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lTablero.Location = new System.Drawing.Point(26, 35);
            this.lTablero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lTablero.Name = "lTablero";
            this.lTablero.Size = new System.Drawing.Size(582, 581);
            this.lTablero.TabIndex = 8;
            this.lTablero.Click += new System.EventHandler(this.lTablero_Click);
            // 
            // bSaltarTurno
            // 
            this.bSaltarTurno.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaltarTurno.Location = new System.Drawing.Point(370, 666);
            this.bSaltarTurno.Margin = new System.Windows.Forms.Padding(4);
            this.bSaltarTurno.Name = "bSaltarTurno";
            this.bSaltarTurno.Size = new System.Drawing.Size(264, 49);
            this.bSaltarTurno.TabIndex = 24;
            this.bSaltarTurno.Text = "SALTAR TURNO";
            this.bSaltarTurno.UseVisualStyleBackColor = true;
            this.bSaltarTurno.Click += new System.EventHandler(this.bSaltarTurno_Click);
            // 
            // bSalirCarcelC
            // 
            this.bSalirCarcelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalirCarcelC.Location = new System.Drawing.Point(1006, 547);
            this.bSalirCarcelC.Margin = new System.Windows.Forms.Padding(4);
            this.bSalirCarcelC.Name = "bSalirCarcelC";
            this.bSalirCarcelC.Size = new System.Drawing.Size(264, 34);
            this.bSalirCarcelC.TabIndex = 23;
            this.bSalirCarcelC.Text = "Salir de la Carcel (casualidad)";
            this.bSalirCarcelC.UseVisualStyleBackColor = true;
            // 
            // bSalirCarcelA
            // 
            this.bSalirCarcelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSalirCarcelA.Location = new System.Drawing.Point(661, 547);
            this.bSalirCarcelA.Margin = new System.Windows.Forms.Padding(4);
            this.bSalirCarcelA.Name = "bSalirCarcelA";
            this.bSalirCarcelA.Size = new System.Drawing.Size(264, 34);
            this.bSalirCarcelA.TabIndex = 22;
            this.bSalirCarcelA.Text = "Salir de la Carcel (arca)";
            this.bSalirCarcelA.UseVisualStyleBackColor = true;
            // 
            // bComprarHotel
            // 
            this.bComprarHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bComprarHotel.Location = new System.Drawing.Point(1111, 488);
            this.bComprarHotel.Margin = new System.Windows.Forms.Padding(4);
            this.bComprarHotel.Name = "bComprarHotel";
            this.bComprarHotel.Size = new System.Drawing.Size(158, 34);
            this.bComprarHotel.TabIndex = 21;
            this.bComprarHotel.Text = "Comprar Hotel";
            this.bComprarHotel.UseVisualStyleBackColor = true;
            // 
            // bComprarCasa
            // 
            this.bComprarCasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bComprarCasa.Location = new System.Drawing.Point(886, 488);
            this.bComprarCasa.Margin = new System.Windows.Forms.Padding(4);
            this.bComprarCasa.Name = "bComprarCasa";
            this.bComprarCasa.Size = new System.Drawing.Size(158, 34);
            this.bComprarCasa.TabIndex = 20;
            this.bComprarCasa.Text = "Comprar Casa";
            this.bComprarCasa.UseVisualStyleBackColor = true;
            // 
            // bComprarPropiedad
            // 
            this.bComprarPropiedad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bComprarPropiedad.Location = new System.Drawing.Point(661, 488);
            this.bComprarPropiedad.Margin = new System.Windows.Forms.Padding(4);
            this.bComprarPropiedad.Name = "bComprarPropiedad";
            this.bComprarPropiedad.Size = new System.Drawing.Size(158, 34);
            this.bComprarPropiedad.TabIndex = 19;
            this.bComprarPropiedad.Text = "Comprar Propiedad";
            this.bComprarPropiedad.UseVisualStyleBackColor = true;
            // 
            // bLanzar
            // 
            this.bLanzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLanzar.Location = new System.Drawing.Point(25, 666);
            this.bLanzar.Margin = new System.Windows.Forms.Padding(4);
            this.bLanzar.Name = "bLanzar";
            this.bLanzar.Size = new System.Drawing.Size(264, 49);
            this.bLanzar.TabIndex = 18;
            this.bLanzar.Text = "LANZAR DADO";
            this.bLanzar.UseVisualStyleBackColor = true;
            // 
            // lJugadorPropiedades
            // 
            this.lJugadorPropiedades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJugadorPropiedades.FormattingEnabled = true;
            this.lJugadorPropiedades.ItemHeight = 20;
            this.lJugadorPropiedades.Location = new System.Drawing.Point(661, 237);
            this.lJugadorPropiedades.Margin = new System.Windows.Forms.Padding(4);
            this.lJugadorPropiedades.Name = "lJugadorPropiedades";
            this.lJugadorPropiedades.Size = new System.Drawing.Size(608, 184);
            this.lJugadorPropiedades.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(657, 203);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Tus Propiedades:";
            // 
            // lJugadores
            // 
            this.lJugadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJugadores.FormattingEnabled = true;
            this.lJugadores.ItemHeight = 20;
            this.lJugadores.Location = new System.Drawing.Point(661, 66);
            this.lJugadores.Margin = new System.Windows.Forms.Padding(4);
            this.lJugadores.Name = "lJugadores";
            this.lJugadores.Size = new System.Drawing.Size(608, 84);
            this.lJugadores.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(657, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Jugadores:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(1172, 634);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 99);
            this.label3.TabIndex = 29;
            // 
            // Ventana_Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 742);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lJugadorPropiedades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lJugadores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSaltarTurno);
            this.Controls.Add(this.bSalirCarcelC);
            this.Controls.Add(this.bSalirCarcelA);
            this.Controls.Add(this.bComprarHotel);
            this.Controls.Add(this.bComprarCasa);
            this.Controls.Add(this.bComprarPropiedad);
            this.Controls.Add(this.bLanzar);
            this.Controls.Add(this.lTablero);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ventana_Juego";
            this.Text = "Ventana_Juego";
            this.Load += new System.EventHandler(this.Ventana_Juego_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lTablero;
        private System.Windows.Forms.Button bSaltarTurno;
        private System.Windows.Forms.Button bSalirCarcelC;
        private System.Windows.Forms.Button bSalirCarcelA;
        private System.Windows.Forms.Button bComprarHotel;
        private System.Windows.Forms.Button bComprarCasa;
        private System.Windows.Forms.Button bComprarPropiedad;
        private System.Windows.Forms.Button bLanzar;
        private System.Windows.Forms.ListBox lJugadorPropiedades;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lJugadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}