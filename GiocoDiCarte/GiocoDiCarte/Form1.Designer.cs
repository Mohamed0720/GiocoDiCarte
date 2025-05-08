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
            this.tornaMenu = new System.Windows.Forms.Button();
            this.titoloVittoria = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.labelTornaMenu = new System.Windows.Forms.Label();
            this.labelTempo = new System.Windows.Forms.Label();
            this.label_nMosse = new System.Windows.Forms.Label();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.gameoverPanel = new System.Windows.Forms.Panel();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuPanel.Location = new System.Drawing.Point(33, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(128, 89);
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
            this.victoryPanel.Controls.Add(this.tornaMenu);
            this.victoryPanel.Controls.Add(this.titoloVittoria);
            this.victoryPanel.Location = new System.Drawing.Point(12, 68);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(1236, 539);
            this.victoryPanel.TabIndex = 1;
            // 
            // labelTempoRimasto
            // 
            this.labelTempoRimasto.BackColor = System.Drawing.Color.Transparent;
            this.labelTempoRimasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempoRimasto.Location = new System.Drawing.Point(416, 334);
            this.labelTempoRimasto.Name = "labelTempoRimasto";
            this.labelTempoRimasto.Size = new System.Drawing.Size(771, 64);
            this.labelTempoRimasto.TabIndex = 5;
            this.labelTempoRimasto.Text = "label6";
            // 
            // labelMosse
            // 
            this.labelMosse.BackColor = System.Drawing.Color.Transparent;
            this.labelMosse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMosse.Location = new System.Drawing.Point(416, 274);
            this.labelMosse.Name = "labelMosse";
            this.labelMosse.Size = new System.Drawing.Size(817, 70);
            this.labelMosse.TabIndex = 4;
            this.labelMosse.Text = "label6";
            // 
            // tornaMenu
            // 
            this.tornaMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.tornaMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tornaMenu.Location = new System.Drawing.Point(264, 401);
            this.tornaMenu.Name = "tornaMenu";
            this.tornaMenu.Size = new System.Drawing.Size(404, 98);
            this.tornaMenu.TabIndex = 1;
            this.tornaMenu.Text = "Torna Al Menu Principale";
            this.tornaMenu.UseVisualStyleBackColor = false;
            this.tornaMenu.Click += new System.EventHandler(this.tornaMenu_Click);
            // 
            // titoloVittoria
            // 
            this.titoloVittoria.AutoSize = true;
            this.titoloVittoria.Font = new System.Drawing.Font("Microsoft New Tai Lue", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titoloVittoria.Location = new System.Drawing.Point(354, 179);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(230, 63);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai vinto!";
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.AutoSize = true;
            this.gamePanel.Controls.Add(this.labelTornaMenu);
            this.gamePanel.Controls.Add(this.labelTempo);
            this.gamePanel.Controls.Add(this.label_nMosse);
            this.gamePanel.Location = new System.Drawing.Point(931, 43);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(802, 491);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // labelTornaMenu
            // 
            this.labelTornaMenu.AutoSize = true;
            this.labelTornaMenu.BackColor = System.Drawing.Color.Transparent;
            this.labelTornaMenu.Location = new System.Drawing.Point(24, 461);
            this.labelTornaMenu.Name = "labelTornaMenu";
            this.labelTornaMenu.Size = new System.Drawing.Size(75, 13);
            this.labelTornaMenu.TabIndex = 5;
            this.labelTornaMenu.Text = "Torna al menu";
            this.labelTornaMenu.Click += new System.EventHandler(this.labelTornaMenu_Click);
            // 
            // labelTempo
            // 
            this.labelTempo.AutoSize = true;
            this.labelTempo.BackColor = System.Drawing.Color.Transparent;
            this.labelTempo.Location = new System.Drawing.Point(25, 25);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(29, 13);
            this.labelTempo.TabIndex = 4;
            this.labelTempo.Text = "label";
            // 
            // label_nMosse
            // 
            this.label_nMosse.AutoSize = true;
            this.label_nMosse.BackColor = System.Drawing.Color.Transparent;
            this.label_nMosse.Location = new System.Drawing.Point(673, 25);
            this.label_nMosse.Name = "label_nMosse";
            this.label_nMosse.Size = new System.Drawing.Size(35, 13);
            this.label_nMosse.TabIndex = 1;
            this.label_nMosse.Text = "label3";
            // 
            // levelPanel
            // 
            this.levelPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.levelPanel.AutoSize = true;
            this.levelPanel.Location = new System.Drawing.Point(59, 76);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(50, 62);
            this.levelPanel.TabIndex = 3;
            this.levelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.levelPanel_Paint);
            this.levelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseClick);
            this.levelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseMove);
            // 
            // gameoverPanel
            // 
            this.gameoverPanel.Location = new System.Drawing.Point(167, 25);
            this.gameoverPanel.Name = "gameoverPanel";
            this.gameoverPanel.Size = new System.Drawing.Size(96, 70);
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
        private System.Windows.Forms.Panel victoryPanel;
        private System.Windows.Forms.Label titoloVittoria;
        private System.Windows.Forms.Button tornaMenu;
        private System.Windows.Forms.Panel levelPanel;
        private System.Windows.Forms.Label label_nMosse;
        private System.Windows.Forms.Panel gameoverPanel;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.Label labelMosse;
        private System.Windows.Forms.Label labelTempoRimasto;
        private System.Windows.Forms.Label labelTornaMenu;
    }
}

