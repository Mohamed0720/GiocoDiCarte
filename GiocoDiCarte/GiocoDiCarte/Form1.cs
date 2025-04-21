using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-----------------------------------------------------------------------------------//
namespace GiocoDiCarte
{
    public partial class Form1 : Form
    {
        //Variabili generali
        private bool inGame = false;
        private List<Bitmap> carte = new List<Bitmap>();
        private Bitmap retroCarta = new Bitmap("../../Sprite/retroCarta.png");
        List<Bitmap> carteGenerate = new List<Bitmap>();
        private List<Rectangle> posSprite= new List<Rectangle>();
        private bool paintedFirstTime = false;


        public Form1()                                                              
        {                                                                           
            InitializeComponent();                                                  
            menuPanel.BringToFront();                                               
        }                                                                           


        //tasto Gioca
        private void tastoGioca_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            panelGame.Show();
            inGame = true;


            //Creazione delle sprite delle carte
            for(int i = 1; i < 5; i++)
            {
                carte.Add(new Bitmap($"../../Sprite/carta{i}.png"));
                carte.Add(new Bitmap($"../../Sprite/carta{i}.png"));
            }

            //----------------------------------------------------------
            //Generazione casuale dell'ordine delle carte
            List<int> esclusi = new List<int>();
            Random oggettoRand = new Random();
            int cartaCasuale;

            for (int i = 0; i < 8; i++)
            {
                do
                {
                    cartaCasuale = oggettoRand.Next(0, 9);
                    carteGenerate.Add(carte[oggettoRand.Next(carte.Count)]);

                    if (esclusi.Contains(cartaCasuale))
                    {
                        carteGenerate.RemoveAt(i);
                    }
                } while (esclusi.Contains(cartaCasuale));
                 
                esclusi.Add(cartaCasuale);
            }
        }

        //Tasto Esci
        private void tastoEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tasto Torna al Menu Principale
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
        
        //Funzione chiamata ad ogni ridisegno del pannello di gioco
        private void panelGame_Paint(object sender, PaintEventArgs e)
        {
            float width = panelGame.Width / 2;
            float height = panelGame.Height / 2;
            int padding = 20;

            if (inGame)
            {
                for(int i = 0; i < 2; i++)
                {
                    for(int j = 0; j < 4; j++)
                    {
                        if (paintedFirstTime)
                        {
                            Rectangle rect = new Rectangle(Convert.ToInt32(width - (carte[j].Width + padding * 2)) + (j * carte[j].Width / 2 + (j * padding)), Convert.ToInt32((height - (carte[i].Height / 2 + padding)) + (i * carte[i].Height / 2 + (i * padding / 2))), carte[j].Width / 2, carte[i].Height / 2);
                            posSprite.Add(rect);
                        }
                        
                        e.Graphics.DrawImage(retroCarta, posSprite[j+(5*i)]);
                    }
                }
                
            }

            paintedFirstTime = true;
        }

        //Quando il mouse sta su una carta
        private void panelGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (inGame)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (posSprite[i].Contains(e.Location))
                    {

                    }
                }
            }
        }

        //Quando si preme col mouse su una carta
        private void panelGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (inGame)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (posSprite[i].Contains(e.Location))
                    {
                        e.Graphics.DrawImage(carteGenerate[i], posSprite[i].X, posSprite[i].Y, posSprite[i].Width, posSprite[i].Height);
                    }
                }
            }
        }
    }


}
