using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiocoDiCarte
{
    public partial class Form1 : Form
    {
        public bool inGame = false;
        public Pen penna = new Pen(Color.Gray, 2);
        public Brush bruscio = new SolidBrush(Color.Gray);
        public Form1()
        {
            InitializeComponent();
            menuPanel.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            bruscio.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            panelGame.Show();
            inGame = true;
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            panelGame.Hide();
            menuPanel.Show();
            inGame = false;
        }

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            if (inGame)
            {
                for(int i = 1; i <= 2; i++)
                {
                    for(int j = 1; j <= 6; j++)
                    {
                        e.Graphics.DrawRectangle(penna, j*100, i*110, 80, 100);
                        e.Graphics.FillRectangle(bruscio, j*100, i*110, 80, 100);
                    }
                }
                
            }
        }
    }


}
