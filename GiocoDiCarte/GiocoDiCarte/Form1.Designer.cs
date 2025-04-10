namespace GiocoDiCarte
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panelGame = new System.Windows.Forms.Panel();
            this.Indietro = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.panelGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label1.Location = new System.Drawing.Point(181, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(456, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gioco di Carte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(362, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gioca";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(371, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Esci";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.label3);
            this.menuPanel.Controls.Add(this.label2);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Location = new System.Drawing.Point(1, 1);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 451);
            this.menuPanel.TabIndex = 3;
            // 
            // panelGame
            // 
            this.panelGame.Controls.Add(this.Indietro);
            this.panelGame.Location = new System.Drawing.Point(1, 1);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(800, 451);
            this.panelGame.TabIndex = 3;
            this.panelGame.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            // 
            // Indietro
            // 
            this.Indietro.Location = new System.Drawing.Point(27, 405);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(75, 23);
            this.Indietro.TabIndex = 0;
            this.Indietro.Text = "Indietro";
            this.Indietro.UseVisualStyleBackColor = true;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.panelGame.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Button Indietro;
    }
}

