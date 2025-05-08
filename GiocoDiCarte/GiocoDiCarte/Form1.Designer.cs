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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Indietro = new System.Windows.Forms.Button();
            this.levelPanel = new System.Windows.Forms.Panel();
            this.gameoverPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.s = new System.Windows.Forms.Label();
            this.victoryPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.gameoverPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuPanel.Location = new System.Drawing.Point(917, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(511, 374);
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
            this.victoryPanel.Location = new System.Drawing.Point(917, 418);
            this.victoryPanel.Name = "victoryPanel";
            this.victoryPanel.Size = new System.Drawing.Size(729, 415);
            this.victoryPanel.TabIndex = 1;
            // 
            // labelTempoRimasto
            // 
            this.labelTempoRimasto.AutoSize = true;
            this.labelTempoRimasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempoRimasto.Location = new System.Drawing.Point(346, 252);
            this.labelTempoRimasto.Name = "labelTempoRimasto";
            this.labelTempoRimasto.Size = new System.Drawing.Size(70, 25);
            this.labelTempoRimasto.TabIndex = 5;
            this.labelTempoRimasto.Text = "label6";
            // 
            // labelMosse
            // 
            this.labelMosse.AutoSize = true;
            this.labelMosse.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMosse.Location = new System.Drawing.Point(346, 169);
            this.labelMosse.Name = "labelMosse";
            this.labelMosse.Size = new System.Drawing.Size(70, 25);
            this.labelMosse.TabIndex = 4;
            this.labelMosse.Text = "label6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(289, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "tempo rimanente:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "mosse rimanenti:";
            // 
            // tornaMenu
            // 
            this.tornaMenu.BackColor = System.Drawing.Color.LimeGreen;
            this.tornaMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tornaMenu.Location = new System.Drawing.Point(194, 321);
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
            this.titoloVittoria.Location = new System.Drawing.Point(262, 49);
            this.titoloVittoria.Name = "titoloVittoria";
            this.titoloVittoria.Size = new System.Drawing.Size(230, 63);
            this.titoloVittoria.TabIndex = 0;
            this.titoloVittoria.Text = "Hai vinto!";
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamePanel.AutoSize = true;
            this.gamePanel.Controls.Add(this.s);
            this.gamePanel.Controls.Add(this.labelTempo);
            this.gamePanel.Controls.Add(this.label1);
            this.gamePanel.Controls.Add(this.label2);
            this.gamePanel.Controls.Add(this.label3);
            this.gamePanel.Controls.Add(this.Indietro);
            this.gamePanel.Location = new System.Drawing.Point(12, 12);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(930, 546);
            this.gamePanel.TabIndex = 3;
            this.gamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGame_Paint);
            this.gamePanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseClick);
            this.gamePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelGame_MouseMove);
            // 
            // labelTempo
            // 
            this.labelTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempo.Location = new System.Drawing.Point(98, 55);
            this.labelTempo.Name = "labelTempo";
            this.labelTempo.Size = new System.Drawing.Size(41, 22);
            this.labelTempo.TabIndex = 4;
            this.labelTempo.Text = "150";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "tempo rimanente:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(811, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 33);
            this.label2.TabIndex = 2;
            this.label2.Text = "mosse:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(822, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // Indietro
            // 
            this.Indietro.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Indietro.Location = new System.Drawing.Point(18, 477);
            this.Indietro.Name = "Indietro";
            this.Indietro.Size = new System.Drawing.Size(172, 55);
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
            this.levelPanel.Size = new System.Drawing.Size(59, 34);
            this.levelPanel.TabIndex = 3;
            this.levelPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.levelPanel_Paint);
            this.levelPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseClick);
            this.levelPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.levelPanel_MouseMove);
            // 
            // gameoverPanel
            // 
            this.gameoverPanel.Controls.Add(this.button1);
            this.gameoverPanel.Location = new System.Drawing.Point(12, 35);
            this.gameoverPanel.Name = "gameoverPanel";
            this.gameoverPanel.Size = new System.Drawing.Size(49, 35);
            this.gameoverPanel.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(352, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Torna al menu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s.Location = new System.Drawing.Point(132, 53);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(19, 24);
            this.s.TabIndex = 5;
            this.s.Text = "s";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 570);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.victoryPanel);
            this.Controls.Add(this.gameoverPanel);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.menuPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.victoryPanel.ResumeLayout(false);
            this.victoryPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.gameoverPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel gameoverPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTempo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMosse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTempoRimasto;
        private System.Windows.Forms.Label s;
    }
}

