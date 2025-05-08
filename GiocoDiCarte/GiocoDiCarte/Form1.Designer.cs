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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.victoryPanel = new System.Windows.Forms.Panel();
            this.labelTempoRimasto = new System.Windows.Forms.Label();
            this.labelMosse = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tornaMenu = new System.Windows.Forms.Button();
            this.titoloVittoria = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.labelTempo = new System.Windows.Forms.Label();
            this.labelMosseTxt = new System.Windows.Forms.Label();
            this.label_nMosse = new System.Windows.Forms.Label();
            this.Indietro = new System.Windows.Forms.Button();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.gameoverPanel = new System.Windows.Forms.Panel();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuPanel.Location = new System.Drawing.Point(817, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(80, 50);
            this.menuPanel.TabIndex = 3;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            this.menuPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseClick);
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseMove);
            // 
            // victoryPanel
            // 
            this.victoryPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.victoryPanel.AutoSize = true;
            this.victoryPanel.Controls.Add(this.labelTempoRimasto);
            this.victoryPanel.Controls.Add(this.labelMosse);
            this.victoryPanel.Controls.Add(this.label5);
            this.victoryPanel.Controls.Add(this.label4);
            this.victoryPanel.Controls.Add(this.tornaMenu);
            this.victoryPanel.Controls.Add(this.titoloVittoria);
            this.victoryPanel.Location = new System.Drawing.Point(12, 172);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(583, 326);
            this.victoryPanel.TabIndex = 1;
            // 
            // labelTempoRimasto
            // 
            this.labelTempoRimasto.AutoSize = true;
            this.labelTempoRimasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempoRimasto.Location = new System.Drawing.Point(422, 232);
            this.labelTempoRimasto.Name = "labelTempoRimasto";
            this.labelTempoRimasto.Size = new System.Drawing.Size(70, 25);
            this.labelTempoRimasto.TabIndex = 5;
            this.labelTempoRimasto.Text = "label6";
            // 
            // labelMosse
            // 
            this.labelMosse.AutoSize = true;
            this.labelMosse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMosse.Location = new System.Drawing.Point(422, 207);
            this.labelMosse.Name = "labelMosse";
            this.labelMosse.Size = new System.Drawing.Size(70, 25);
            this.labelMosse.TabIndex = 4;
            this.labelMosse.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(238, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "tempo rimanente:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(243, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "mosse rimanenti:";
            // 
            // tornaMenu
            // 
            this.tornaMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.tornaMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tornaMenu.Location = new System.Drawing.Point(198, 273);
            this.tornaMenu.Name = "tornaMenu";
            this.tornaMenu.Size = new System.Drawing.Size(382, 50);
            this.tornaMenu.TabIndex = 1;
            this.tornaMenu.Text = "Torna Al Menu Principale";
            this.tornaMenu.UseVisualStyleBackColor = false;
            this.tornaMenu.Click += new System.EventHandler(this.tornaMenu_Click);
            // 
            // titoloVittoria
            // 
            this.titoloVittoria.AutoSize = true;
            this.titoloVittoria.Font = new System.Drawing.Font("Microsoft New Tai Lue", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titoloVittoria.Location = new System.Drawing.Point(271, 144);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(230, 63);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai vinto!";
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.AutoSize = true;
            this.gamePanel.Controls.Add(this.labelTempo);
            this.gamePanel.Controls.Add(this.labelMosseTxt);
            this.gamePanel.Controls.Add(this.label_nMosse);
            this.gamePanel.Controls.Add(this.Indietro);
            this.gamePanel.Location = new System.Drawing.Point(59, 520);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(802, 489);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.BackColor = System.Drawing.Color.Transparent;
            this.labelTempo.Location = new System.Drawing.Point(25, 25);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(25, 13);
            this.labelTempo.TabIndex = 4;
            this.labelTempo.Text = "150";
            // 
            // labelMosseTxt
            // 
            this.labelMosseTxt.AutoSize = true;
            this.labelMosseTxt.BackColor = System.Drawing.Color.Transparent;
            this.labelMosseTxt.Location = new System.Drawing.Point(691, 25);
            this.labelMosseTxt.Name = "labelMosseTxt";
            this.labelMosseTxt.Size = new System.Drawing.Size(40, 13);
            this.labelMosseTxt.TabIndex = 2;
            this.labelMosseTxt.Text = "mosse:";
            // 
            // label_nMosse
            // 
            this.label_nMosse.AutoSize = true;
            this.label_nMosse.BackColor = System.Drawing.Color.Transparent;
            this.label_nMosse.Location = new System.Drawing.Point(737, 25);
            this.label_nMosse.Name = "label_nMosse";
            this.label_nMosse.Size = new System.Drawing.Size(35, 13);
            this.label_nMosse.TabIndex = 1;
            this.label_nMosse.Text = "label3";
            // 
            // Indietro
            // 
            this.Indietro.Location = new System.Drawing.Point(28, 463);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(95, 23);
            this.Indietro.TabIndex = 0;
            this.Indietro.Text = "Torna al Menu";
            this.Indietro.UseVisualStyleBackColor = true;
            this.Indietro.Click += new System.EventHandler(this.Indietro_Click);
            // 
            // levelPanel
            // 
            this.levelPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.levelPanel.AutoSize = true;
            this.levelPanel.Location = new System.Drawing.Point(59, 76);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(84, 49);
            this.levelPanel.TabIndex = 3;
            this.levelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.levelPanel_Paint);
            this.levelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseClick);
            this.levelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseMove);
            // 
            // gameoverPanel
            // 
            this.gameoverPanel.Location = new System.Drawing.Point(167, 25);
            this.gameoverPanel.Name = "gameoverPanel";
            this.gameoverPanel.Size = new System.Drawing.Size(271, 113);
            this.gameoverPanel.TabIndex = 5;
            this.gameoverPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gameoverPanel_Paint);
            this.gameoverPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameoverPanel_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.gameoverPanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.victoryPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.victoryPanel.ResumeLayout(false);
            this.victoryPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.Button Indietro;
        private System.Windows.Forms.Panel victoryPanel;
        private System.Windows.Forms.Label titoloVittoria;
        private System.Windows.Forms.Button tornaMenu;
        private System.Windows.Forms.Panel levelPanel;
        private System.Windows.Forms.Label label_nMosse;
        private System.Windows.Forms.Panel gameoverPanel;
        private System.Windows.Forms.Label labelMosseTxt;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.Label labelMosse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTempoRimasto;
    }
}

