namespace MonopolioRedes.Vista
{
    partial class Inicio
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
            this.tLogs = new System.Windows.Forms.TextBox();
            this.tLista_Jugadores = new System.Windows.Forms.TextBox();
            this.bApagar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tLogs
            // 
            this.tLogs.Location = new System.Drawing.Point(16, 49);
            this.tLogs.Margin = new System.Windows.Forms.Padding(4);
            this.tLogs.Multiline = true;
            this.tLogs.Name = "tLogs";
            this.tLogs.Size = new System.Drawing.Size(743, 546);
            this.tLogs.TabIndex = 0;
            this.tLogs.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tLista_Jugadores
            // 
            this.tLista_Jugadores.Location = new System.Drawing.Point(781, 49);
            this.tLista_Jugadores.Margin = new System.Windows.Forms.Padding(4);
            this.tLista_Jugadores.Multiline = true;
            this.tLista_Jugadores.Name = "tLista_Jugadores";
            this.tLista_Jugadores.Size = new System.Drawing.Size(419, 377);
            this.tLista_Jugadores.TabIndex = 1;
            // 
            // bApagar
            // 
            this.bApagar.Location = new System.Drawing.Point(781, 567);
            this.bApagar.Margin = new System.Windows.Forms.Padding(4);
            this.bApagar.Name = "bApagar";
            this.bApagar.Size = new System.Drawing.Size(420, 28);
            this.bApagar.TabIndex = 2;
            this.bApagar.Text = "Apagar Sistema";
            this.bApagar.UseVisualStyleBackColor = true;
            this.bApagar.Click += new System.EventHandler(this.bApagar_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 610);
            this.Controls.Add(this.bApagar);
            this.Controls.Add(this.tLista_Jugadores);
            this.Controls.Add(this.tLogs);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Inicio";
            this.Text = "Monopolio | Redes 1";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tLogs;
        private System.Windows.Forms.TextBox tLista_Jugadores;
        private System.Windows.Forms.Button bApagar;
    }
}

