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
            public Bitmap colore { get; set; }

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


        public Form1()                                                              
        {                                                                           
            InitializeComponent();                                                  
            menuPanel.BringToFront();                                               
        }


        //tasto Gioca//--------------------------------------------------------------//
        private void tastoGioca_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            panelGame.Show();
            inGame = true;


            //Creazione delle sprite delle carte//-----------------------------------//
            float width = panelGame.Width / 2;
            float height = panelGame.Height / 2;
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
                    cartaCasuale = oggettoRand.Next(0, 9);

                    if (esclusi.Contains(cartaCasuale))
                    {
                        Console.WriteLine("C'è già");
                    } else
                    {
                        if (cartaCasuale == 1 || cartaCasuale == 2)
                        {
                            carte[i].colore = cartaArancio;
                        }
                        else if (cartaCasuale == 3 || cartaCasuale == 4)
                        {
                            carte[i].colore = cartaRosso;
                        }
                        else if (cartaCasuale == 5 || cartaCasuale == 6)
                        {
                            carte[i].colore = cartaBlu;
                        }
                        else if (cartaCasuale == 7 || cartaCasuale == 8)
                        {
                            carte[i].colore = cartaVerde;
                        }
                    }
                } while (esclusi.Contains(cartaCasuale));
                 
                esclusi.Add(cartaCasuale);
            }

            Invalidate();
        }

        //Tasto Esci//---------------------------------------------------------------//
        private void tastoEsci_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tasto Torna al Menu Principale//-------------------------------------------//
        private void Indietro_Click(object sender, EventArgs e)
        {
            panelGame.Hide();
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
                        e.Graphics.DrawImage(carte[i].colore, carte[i].rect);
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
        private void panelGame_MouseClick(object sender, MouseEventArgs e)
        {
            if (inGame)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (carte[i].rect.Contains(e.Location))
                    {
                        carte[i].girato = true;
                        Invalidate();
                    }
                }
            }
        }
    }


}
