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
            this.tastoGioca = new System.Windows.Forms.Label();
            this.tastoEsci = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.victoryPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.titoloVittoria = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.Indietro = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
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
            // tastoGioca
            // 
            this.tastoGioca.AutoSize = true;
            this.tastoGioca.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tastoGioca.Location = new System.Drawing.Point(362, 227);
            this.tastoGioca.Name = "tastoGioca";
            this.tastoGioca.Size = new System.Drawing.Size(85, 31);
            this.tastoGioca.TabIndex = 1;
            this.tastoGioca.Text = "Gioca";
            this.tastoGioca.Click += new System.EventHandler(this.tastoGioca_Click);
            // 
            // tastoEsci
            // 
            this.tastoEsci.AutoSize = true;
            this.tastoEsci.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tastoEsci.Location = new System.Drawing.Point(371, 288);
            this.tastoEsci.Name = "tastoEsci";
            this.tastoEsci.Size = new System.Drawing.Size(66, 31);
            this.tastoEsci.TabIndex = 2;
            this.tastoEsci.Text = "Esci";
            this.tastoEsci.Click += new System.EventHandler(this.tastoEsci_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.AutoSize = true;
            this.menuPanel.Controls.Add(this.tastoEsci);
            this.menuPanel.Controls.Add(this.tastoGioca);
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Location = new System.Drawing.Point(282, 5);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 450);
            this.menuPanel.TabIndex = 3;
            // 
            // victoryPanel
            // 
            this.victoryPanel.Controls.Add(this.button1);
            this.victoryPanel.Controls.Add(this.titoloVittoria);
            this.victoryPanel.Location = new System.Drawing.Point(67, 73);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(800, 450);
            this.victoryPanel.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(194, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(382, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Torna Al Menu Principale";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titoloVittoria
            // 
            this.titoloVittoria.AutoSize = true;
            this.titoloVittoria.Font = new System.Drawing.Font("SansSerif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.titoloVittoria.Location = new System.Drawing.Point(114, 91);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(558, 56);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai Completato Il Livello!";
            // 
            // panelGame
            // 
            this.gamePanel.Controls.Add(this.Indietro);
            this.gamePanel.Location = new System.Drawing.Point(154, 27);
            this.gamePanel.Name = "panelGame";
            this.gamePanel.Size = new System.Drawing.Size(800, 450);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // Indietro
            // 
            this.Indietro.Location = new System.Drawing.Point(27, 405);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(95, 23);
            this.Indietro.TabIndex = 0;
            this.Indietro.Text = "Torna al Menu";
            this.Indietro.UseVisualStyleBackColor = true;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.victoryPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.victoryPanel.ResumeLayout(false);
            this.victoryPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tastoGioca;
        private System.Windows.Forms.Label tastoEsci;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button Indietro;
        private System.Windows.Forms.Panel victoryPanel;
        private System.Windows.Forms.Label titoloVittoria;
        private System.Windows.Forms.Button button1;
    }
}

