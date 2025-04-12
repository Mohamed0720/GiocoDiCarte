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
        private bool inGame = false;
        private Pen penna = new Pen(Color.Gray, 2);
        private Brush bruscio = new SolidBrush(Color.Gray);
        private List<Bitmap> carte = new List<Bitmap>();
        private Bitmap retroCarta = new Bitmap("../../Sprite/retroCarta.png");
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

            List<int> esclusi = new List<int>();
            List<Bitmap> carteInGioco = new List<Bitmap>();
            Random rand = new Random();



            for(int i = 1; i < 5; i++)
            {
                carte.Add(new Bitmap($"../../Sprite/carta{i}.png"));
                carte.Add(new Bitmap($"../../Sprite/carta{i}.png"));
            }

            int cartaCasuale;

            for (int i = 0; i < 8; i++)
            {
                do
                {
                    cartaCasuale = rand.Next(0, 9);
                    carteInGioco.Add(carte[rand.Next(carte.Count)]);

                    if (esclusi.Contains(cartaCasuale))
                    {
                        carteInGioco.RemoveAt(i);
                    }
                } while (esclusi.Contains(cartaCasuale));
                 
                esclusi.Add(cartaCasuale);
            }
        }

        private void Indietro_Click(object sender, EventArgs e)
        {
            panelGame.Hide();
            menuPanel.Show();
            inGame = false;

            for (int i = 0; i < 8; i++)
            {
                carte[i].Dispose();
            }
        }
        

        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            float width = panelGame.Width / 2;
            float height = panelGame.Height / 2;

            if (inGame)
            {
                for(int i = 1; i <= 2; i++)
                {
                    for(int j = 1; j <= 4; j++)
                    {
                        e.Graphics.DrawImage(retroCarta, (width-(90*2))+(j*90), (height-(2* 130))+(i * 130), carte[j].Width/2, carte[i].Height/2);
                    }
                }
                
            }
        }
    }


}
