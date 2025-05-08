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
            this.tornaMenu = new System.Windows.Forms.Button();
            this.titoloVittoria = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Indietro = new System.Windows.Forms.Button();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gameoverPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.levelPanel.SuspendLayout();
            this.gameoverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuPanel.Location = new System.Drawing.Point(379, 8);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(800, 450);
            this.menuPanel.TabIndex = 3;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            this.menuPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseClick);
            this.menuPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuPanel_MouseMove);
            // 
            // victoryPanel
            // 
            this.victoryPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.victoryPanel.AutoSize = true;
            this.victoryPanel.Controls.Add(this.tornaMenu);
            this.victoryPanel.Controls.Add(this.titoloVittoria);
            this.victoryPanel.Location = new System.Drawing.Point(42, 139);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(1227, 450);
            this.victoryPanel.TabIndex = 1;
            // 
            // tornaMenu
            // 
            this.tornaMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.tornaMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tornaMenu.Location = new System.Drawing.Point(194, 269);
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
            this.titoloVittoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.titoloVittoria.Location = new System.Drawing.Point(114, 91);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(1110, 53);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai Completato Il Livello!";
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.AutoSize = true;
            this.gamePanel.Controls.Add(this.label3);
            this.gamePanel.Controls.Add(this.Indietro);
            this.gamePanel.Location = new System.Drawing.Point(87, 32);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 514);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(636, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
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
            this.levelPanel.Controls.Add(this.gameoverPanel);
            this.levelPanel.Location = new System.Drawing.Point(59, 76);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(835, 445);
            this.levelPanel.TabIndex = 3;
            this.levelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.levelPanel_Paint);
            this.levelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseClick);
            this.levelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // gameoverPanel
            // 
            this.gameoverPanel.Controls.Add(this.label2);
            this.gameoverPanel.Location = new System.Drawing.Point(116, 15);
            this.gameoverPanel.Name = "gameoverPanel";
            this.gameoverPanel.Size = new System.Drawing.Size(716, 427);
            this.gameoverPanel.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "GAME OVER";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gamePanel);
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
            this.levelPanel.ResumeLayout(false);
            this.gameoverPanel.ResumeLayout(false);
            this.gameoverPanel.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel gameoverPanel;
        private System.Windows.Forms.Label label2;
    }
}

