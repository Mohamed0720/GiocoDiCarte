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
            this.Indietro = new System.Windows.Forms.Button();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.livello9 = new System.Windows.Forms.Button();
            this.livello8 = new System.Windows.Forms.Button();
            this.livello7 = new System.Windows.Forms.Button();
            this.livello6 = new System.Windows.Forms.Button();
            this.livello5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.livello4 = new System.Windows.Forms.Button();
            this.livello3 = new System.Windows.Forms.Button();
            this.livello2 = new System.Windows.Forms.Button();
            this.livello1 = new System.Windows.Forms.Button();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.levelPanel.SuspendLayout();
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
            this.victoryPanel.Size = new System.Drawing.Size(800, 450);
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
            this.titoloVittoria.Font = new System.Drawing.Font("SansSerif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.titoloVittoria.Location = new System.Drawing.Point(114, 91);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(558, 56);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai Completato Il Livello!";
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.AutoSize = true;
            this.gamePanel.Controls.Add(this.Indietro);
            this.gamePanel.Location = new System.Drawing.Point(87, 32);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(800, 514);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
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
            this.levelPanel.Controls.Add(this.livello9);
            this.levelPanel.Controls.Add(this.livello8);
            this.levelPanel.Controls.Add(this.livello7);
            this.levelPanel.Controls.Add(this.livello6);
            this.levelPanel.Controls.Add(this.livello5);
            this.levelPanel.Controls.Add(this.label2);
            this.levelPanel.Controls.Add(this.livello4);
            this.levelPanel.Controls.Add(this.livello3);
            this.levelPanel.Controls.Add(this.livello2);
            this.levelPanel.Controls.Add(this.livello1);
            this.levelPanel.Location = new System.Drawing.Point(54, 75);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(799, 413);
            this.levelPanel.TabIndex = 3;
            this.levelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseClick);
            this.levelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseMove);
            // 
            // livello9
            // 
            this.livello9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello9.Location = new System.Drawing.Point(482, 262);
            this.livello9.Name = "livello9";
            this.livello9.Size = new System.Drawing.Size(75, 23);
            this.livello9.TabIndex = 9;
            this.livello9.Text = "9";
            this.livello9.UseVisualStyleBackColor = false;
            this.livello9.Click += new System.EventHandler(this.livello9_Click);
            // 
            // livello8
            // 
            this.livello8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello8.Location = new System.Drawing.Point(351, 262);
            this.livello8.Name = "livello8";
            this.livello8.Size = new System.Drawing.Size(75, 23);
            this.livello8.TabIndex = 8;
            this.livello8.Text = "8";
            this.livello8.UseVisualStyleBackColor = false;
            this.livello8.Click += new System.EventHandler(this.livello8_Click);
            // 
            // livello7
            // 
            this.livello7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello7.Location = new System.Drawing.Point(224, 262);
            this.livello7.Name = "livello7";
            this.livello7.Size = new System.Drawing.Size(75, 23);
            this.livello7.TabIndex = 7;
            this.livello7.Text = "7";
            this.livello7.UseVisualStyleBackColor = false;
            this.livello7.Click += new System.EventHandler(this.livello7_Click);
            // 
            // livello6
            // 
            this.livello6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello6.Location = new System.Drawing.Point(482, 208);
            this.livello6.Name = "livello6";
            this.livello6.Size = new System.Drawing.Size(75, 23);
            this.livello6.TabIndex = 6;
            this.livello6.Text = "6";
            this.livello6.UseVisualStyleBackColor = false;
            this.livello6.Click += new System.EventHandler(this.livello6_Click);
            // 
            // livello5
            // 
            this.livello5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello5.Location = new System.Drawing.Point(353, 208);
            this.livello5.Name = "livello5";
            this.livello5.Size = new System.Drawing.Size(75, 23);
            this.livello5.TabIndex = 5;
            this.livello5.Text = "5";
            this.livello5.UseVisualStyleBackColor = false;
            this.livello5.Click += new System.EventHandler(this.livello5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Swis721 BlkOul BT", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(318, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 39);
            this.label2.TabIndex = 4;
            this.label2.Text = "Livelli";
            // 
            // livello4
            // 
            this.livello4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello4.Location = new System.Drawing.Point(224, 208);
            this.livello4.Name = "livello4";
            this.livello4.Size = new System.Drawing.Size(75, 23);
            this.livello4.TabIndex = 3;
            this.livello4.Text = "4";
            this.livello4.UseVisualStyleBackColor = false;
            this.livello4.Click += new System.EventHandler(this.livello4_Click);
            // 
            // livello3
            // 
            this.livello3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello3.Location = new System.Drawing.Point(482, 153);
            this.livello3.Name = "livello3";
            this.livello3.Size = new System.Drawing.Size(75, 23);
            this.livello3.TabIndex = 2;
            this.livello3.Text = "3";
            this.livello3.UseVisualStyleBackColor = false;
            this.livello3.Click += new System.EventHandler(this.livello3_Click);
            // 
            // livello2
            // 
            this.livello2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.livello2.Location = new System.Drawing.Point(351, 153);
            this.livello2.Name = "livello2";
            this.livello2.Size = new System.Drawing.Size(75, 23);
            this.livello2.TabIndex = 1;
            this.livello2.Text = "2";
            this.livello2.UseVisualStyleBackColor = false;
            this.livello2.Click += new System.EventHandler(this.livello2_Click);
            // 
            // livello1
            // 
            this.livello1.Location = new System.Drawing.Point(228, 153);
            this.livello1.Name = "livello1";
            this.livello1.Size = new System.Drawing.Size(75, 23);
            this.livello1.TabIndex = 0;
            this.livello1.Text = "1";
            this.livello1.UseVisualStyleBackColor = true;
            this.livello1.Click += new System.EventHandler(this.livello1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.victoryPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.victoryPanel.ResumeLayout(false);
            this.victoryPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.levelPanel.ResumeLayout(false);
            this.levelPanel.PerformLayout();
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
        private System.Windows.Forms.Button livello9;
        private System.Windows.Forms.Button livello8;
        private System.Windows.Forms.Button livello7;
        private System.Windows.Forms.Button livello6;
        private System.Windows.Forms.Button livello5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button livello4;
        private System.Windows.Forms.Button livello3;
        private System.Windows.Forms.Button livello2;
        private System.Windows.Forms.Button livello1;
    }
}

