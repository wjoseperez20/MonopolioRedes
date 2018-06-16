namespace ChatSerialPort
{
    partial class Form1
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
            this.tChat = new System.Windows.Forms.TextBox();
            this.tData1 = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.cBytesSend = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tData2 = new System.Windows.Forms.TextBox();
            this.tData3 = new System.Windows.Forms.TextBox();
            this.tData4 = new System.Windows.Forms.TextBox();
            this.cBase = new System.Windows.Forms.ComboBox();
            this.tPuerto = new System.Windows.Forms.TextBox();
            this.bConectar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tChat
            // 
            this.tChat.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tChat.Location = new System.Drawing.Point(16, 15);
            this.tChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tChat.Multiline = true;
            this.tChat.Name = "tChat";
            this.tChat.ReadOnly = true;
            this.tChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tChat.Size = new System.Drawing.Size(628, 210);
            this.tChat.TabIndex = 0;
            this.tChat.TextChanged += new System.EventHandler(this.tChat_TextChanged);
            // 
            // tData1
            // 
            this.tData1.Location = new System.Drawing.Point(16, 247);
            this.tData1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tData1.Name = "tData1";
            this.tData1.Size = new System.Drawing.Size(107, 22);
            this.tData1.TabIndex = 1;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(196, 300);
            this.bSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(100, 28);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Enviar";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // cBytesSend
            // 
            this.cBytesSend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBytesSend.FormattingEnabled = true;
            this.cBytesSend.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cBytesSend.Location = new System.Drawing.Point(136, 302);
            this.cBytesSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBytesSend.Name = "cBytesSend";
            this.cBytesSend.Size = new System.Drawing.Size(51, 24);
            this.cBytesSend.TabIndex = 7;
            this.cBytesSend.SelectedIndexChanged += new System.EventHandler(this.cBytesSend_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 304);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bytes por enviar:";
            // 
            // tData2
            // 
            this.tData2.Location = new System.Drawing.Point(132, 246);
            this.tData2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tData2.Name = "tData2";
            this.tData2.Size = new System.Drawing.Size(107, 22);
            this.tData2.TabIndex = 2;
            // 
            // tData3
            // 
            this.tData3.Location = new System.Drawing.Point(248, 246);
            this.tData3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tData3.Name = "tData3";
            this.tData3.Size = new System.Drawing.Size(107, 22);
            this.tData3.TabIndex = 3;
            // 
            // tData4
            // 
            this.tData4.Location = new System.Drawing.Point(364, 246);
            this.tData4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tData4.Name = "tData4";
            this.tData4.Size = new System.Drawing.Size(107, 22);
            this.tData4.TabIndex = 4;
            // 
            // cBase
            // 
            this.cBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBase.FormattingEnabled = true;
            this.cBase.Items.AddRange(new object[] {
            "Binario",
            "Decimal"});
            this.cBase.Location = new System.Drawing.Point(505, 245);
            this.cBase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cBase.Name = "cBase";
            this.cBase.Size = new System.Drawing.Size(160, 24);
            this.cBase.TabIndex = 9;
            this.cBase.SelectedIndexChanged += new System.EventHandler(this.cBase_SelectedIndexChanged);
            // 
            // tPuerto
            // 
            this.tPuerto.Location = new System.Drawing.Point(81, 346);
            this.tPuerto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tPuerto.Name = "tPuerto";
            this.tPuerto.Size = new System.Drawing.Size(145, 22);
            this.tPuerto.TabIndex = 10;
            // 
            // bConectar
            // 
            this.bConectar.Location = new System.Drawing.Point(236, 343);
            this.bConectar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bConectar.Name = "bConectar";
            this.bConectar.Size = new System.Drawing.Size(100, 28);
            this.bConectar.TabIndex = 11;
            this.bConectar.Text = "Conectar";
            this.bConectar.UseVisualStyleBackColor = true;
            this.bConectar.Click += new System.EventHandler(this.bConectar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 348);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 26);
            this.label2.TabIndex = 12;
            this.label2.Text = "Puerto:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 385);
            this.Controls.Add(this.tPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bConectar);
            this.Controls.Add(this.cBase);
            this.Controls.Add(this.tData4);
            this.Controls.Add(this.tData3);
            this.Controls.Add(this.tData2);
            this.Controls.Add(this.cBytesSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tData1);
            this.Controls.Add(this.tChat);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "SerialPort - Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tChat;
        private System.Windows.Forms.TextBox tData1;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ComboBox cBytesSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tData2;
        private System.Windows.Forms.TextBox tData3;
        private System.Windows.Forms.TextBox tData4;
        private System.Windows.Forms.ComboBox cBase;
        private System.Windows.Forms.TextBox tPuerto;
        private System.Windows.Forms.Button bConectar;
        private System.Windows.Forms.Label label2;
    }
}

