namespace UNORedes
{
    partial class Ventana_Inicio
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lInfo = new System.Windows.Forms.Label();
            this.bStartCon = new System.Windows.Forms.Button();
            this.tPuerto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bComenzar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lInfo);
            this.panel1.Controls.Add(this.bStartCon);
            this.panel1.Controls.Add(this.tPuerto);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 134);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Estado:";
            // 
            // lInfo
            // 
            this.lInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfo.Location = new System.Drawing.Point(93, 85);
            this.lInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(297, 28);
            this.lInfo.TabIndex = 11;
            this.lInfo.Text = "Sin conexión";
            this.lInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lInfo.Click += new System.EventHandler(this.lInfo_Click);
            // 
            // bStartCon
            // 
            this.bStartCon.Location = new System.Drawing.Point(260, 43);
            this.bStartCon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bStartCon.Name = "bStartCon";
            this.bStartCon.Size = new System.Drawing.Size(133, 28);
            this.bStartCon.TabIndex = 10;
            this.bStartCon.Text = "Conectar";
            this.bStartCon.UseVisualStyleBackColor = true;
            this.bStartCon.Click += new System.EventHandler(this.bStartCon_Click);
            // 
            // tPuerto
            // 
            this.tPuerto.Location = new System.Drawing.Point(92, 47);
            this.tPuerto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPuerto.Name = "tPuerto";
            this.tPuerto.Size = new System.Drawing.Size(143, 22);
            this.tPuerto.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Puerto:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "INICIO SESION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bComenzar
            // 
            this.bComenzar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bComenzar.Location = new System.Drawing.Point(16, 167);
            this.bComenzar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bComenzar.Name = "bComenzar";
            this.bComenzar.Size = new System.Drawing.Size(419, 43);
            this.bComenzar.TabIndex = 4;
            this.bComenzar.Text = "COMENZAR JUEGO";
            this.bComenzar.UseVisualStyleBackColor = true;
            this.bComenzar.Click += new System.EventHandler(this.bComenzar_Click);
            // 
            // Ventana_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(460, 224);
            this.Controls.Add(this.bComenzar);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ventana_Inicio";
            this.Text = "UNO";
            this.Load += new System.EventHandler(this.Ventana_Juego_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStartCon;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lInfo;
        public System.Windows.Forms.TextBox tPuerto;
        public System.Windows.Forms.Button bComenzar;
        private System.Windows.Forms.Label label3;
    }
}

