using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-----------------------------------------------------------------------------------//
namespace GiocoDiCarte
{
    public partial class Form1 : Form
    {

        //Classe Carte//-------------------------------------------------------------//
        private class Carta
        {
            public Rectangle rect { get; set; }
            public bool girato { get; set; }
            public Bitmap sprite { get; set; }
            public char colore { get; set; }

            public Carta(Rectangle rect)
            {
                this.rect = rect;
                this.girato = false;
            }
        }

        //Variabili generali//-------------------------------------------------------//
        private bool inGame = false;
        private Bitmap retroCarta = new Bitmap("../../Sprite/retroCarta.png");
        private Bitmap cartaArancio = new Bitmap("../../Sprite/cartaArancio.png");
        private Bitmap cartaRosso = new Bitmap("../../Sprite/cartaRosso.png");
        private Bitmap cartaBlu = new Bitmap("../../Sprite/cartaBlu.png");
        private Bitmap cartaVerde = new Bitmap("../../Sprite/cartaVerde.png");
        private List<Carta> carte = new List<Carta>();
        private bool primaCarta = false;
        private Carta cartaGirata;
        private int condVittoria = 0;


        public Form1()                                                              
        {                                                                           
            InitializeComponent();                                                  
            menuPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            victoryPanel.Dock = DockStyle.Fill;
            menuPanel.BringToFront();
        }


        //tasto Gioca//--------------------------------------------------------------//
        private void tastoGioca_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            victoryPanel.Hide();
            gamePanel.Show();
            inGame = true;


            //Creazione delle sprite delle carte//-----------------------------------//
            float width = gamePanel.Width / 2;
            float height = gamePanel.Height / 2;
            int padding = 20;

            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    Rectangle r = new Rectangle(Convert.ToInt32((width - (retroCarta.Width + padding*3/2)) + (retroCarta.Width/2*j + padding*j/2)), Convert.ToInt32((height - (retroCarta.Height/2 + padding/2)) + (retroCarta.Height/2*i + padding*i)), retroCarta.Width/2, retroCarta.Height/2);
                    carte.Add(new Carta(r));
                }
            }


            //Generazione casuale dell'ordine delle carte//--------------------------//
            List<int> esclusi = new List<int>();
            Random oggettoRand = new Random();
            int cartaCasuale;

            for (int i = 0; i < 8; i++)
            {
                do
                {
                    cartaCasuale = oggettoRand.Next(1, 9);

                } while(esclusi.Contains(cartaCasuale));

                if (cartaCasuale == 1 || cartaCasuale == 2)
                {
                    carte[i].sprite = (Bitmap)cartaArancio.Clone();
                    carte[i].colore = 'a';
                }
                else if (cartaCasuale == 3 || cartaCasuale == 4)
                {
                    carte[i].sprite = (Bitmap)cartaRosso.Clone();
                    carte[i].colore = 'r';
                }
                else if (cartaCasuale == 5 || cartaCasuale == 6)
                {
                    carte[i].sprite = (Bitmap)cartaBlu.Clone();
                    carte[i].colore = 'b';
                }
                else if (cartaCasuale == 7 || cartaCasuale == 8)
                {
                    carte[i].sprite = (Bitmap)cartaVerde.Clone();
                    carte[i].colore = 'v';
                }

                esclusi.Add(cartaCasuale);
            }
            
        }

        //Tasto Esci//---------------------------------------------------------------//
        private void tastoEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tasto Torna al Menu Principale//-------------------------------------------//
        private void Indietro_Click(object sender, EventArgs e)
        {
            gamePanel.Hide();
            menuPanel.Show();
            inGame = false;

        }

        //Funzione chiamata ad ogni ridisegno del pannello di gioco//----------------//
        private void panelGame_Paint(object sender, PaintEventArgs e)
        {

            if (inGame)
            {
                for(int i = 0; i < 8; i++)
                {
                    if (carte[i].girato)
                    {
                        e.Graphics.DrawImage(carte[i].sprite, carte[i].rect);
                    }
                    else
                    {
                        e.Graphics.DrawImage(retroCarta, carte[i].rect);
                    }
                }
                
            }
            
        }

        //Quando il mouse sta su una carta//-----------------------------------------//
        private void panelGame_MouseMove(object sender, MouseEventArgs e)
        {
            if (inGame)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (carte[i].rect.Contains(e.Location))
                    {

                    }
                }
            }
        }

        //Quando si preme col mouse su una carta//-----------------------------------//
        private async void panelGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (inGame)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (carte[i].rect.Contains(e.Location))
                    {
                        //Quando si preme su una carta il programma controlla se è
                        //la prima o la seconda carta che si sceglie
                        if (primaCarta) 
                        {
                            carte[i].girato = true;
                            gamePanel.Invalidate();

                            await Task.Delay(500);

                            //Se le carte sono di colore diverso le rigira
                            if (carte[i].colore != cartaGirata.colore)
                            {
                                carte[i].girato = false;
                                cartaGirata.girato = false;
                                gamePanel.Invalidate();
                            }
                            else
                            {
                                condVittoria += 1;
                                if(condVittoria >= 4)
                                {
                                    gamePanel.Hide();
                                    victoryPanel.Show();
                                    victoryPanel.BringToFront();
                                    this.Refresh();
                                }
                            }

                                primaCarta = false;
                        }
                        else
                        {
                            carte[i].girato = true;
                            primaCarta = true;
                            cartaGirata = carte[i];
                            gamePanel.Invalidate();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuPanel.Show();
            victoryPanel.Hide();
        }
    }


}
