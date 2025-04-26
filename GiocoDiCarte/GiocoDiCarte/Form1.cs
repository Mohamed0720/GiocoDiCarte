using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            public string colore { get; set; }

            public Carta(Rectangle rect)
            {
                this.rect = rect;
                this.girato = false;
            }
        }

        //Variabili generali//-------------------------------------------------------//
        private bool inGame = false;

        private Bitmap retroCarta = new Bitmap("Sprite/retroCarta.png");
        private Bitmap cartaArancio = new Bitmap("Sprite/cartaArancio.png");
        private Bitmap cartaRosso = new Bitmap("Sprite/cartaRosso.png");
        private Bitmap cartaBlu = new Bitmap("Sprite/cartaBlu.png");
        private Bitmap cartaVerde = new Bitmap("Sprite/cartaVerde.png");
        private Bitmap cartaGiallo = new Bitmap("Sprite/cartaGiallo.png");
        private Bitmap cartaRosa = new Bitmap("Sprite/cartaRosa.png");
        private Bitmap cartaTurchese = new Bitmap("Sprite/cartaTurchese.png");
        private Bitmap cartaViola = new Bitmap("Sprite/cartaViola.png");
        private Bitmap cartaFuoco = new Bitmap("Sprite/cartaFuoco.png");
        private Bitmap cartaAcqua = new Bitmap("Sprite/cartaAcqua.png");
        private Bitmap cartaFoglia = new Bitmap("Sprite/cartaFoglia.png");
        private Bitmap cartaPietra = new Bitmap("Sprite/cartaPietra.png");
        private Bitmap cartaSole = new Bitmap("Sprite/cartaSole.png");

        List<string> colori = new List<string> { "Arancio", "Rosso", "Blu", "Verde", "Giallo", "Rosa", "Turchese", "Viola", "Fuoco", "Acqua", "Foglia", "Pietra", "Sole" };
        List<Bitmap> sprites = new List<Bitmap>();

        private List<Carta> carte = new List<Carta>();
        private bool primaCarta = false;
        private Carta cartaGirata;
        private int condVittoria = 0;
        private int livelliSbloccati;
        private int livelloSelezionato;

        //Funzione chiamata all'avvio del programma//--------------------------------//
        public Form1()                                                              
        {                                                                           
            InitializeComponent();                                                  
            menuPanel.Dock = DockStyle.Fill;
            levelPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            victoryPanel.Dock = DockStyle.Fill;
            menuPanel.BringToFront();

            sprites.AddRange(new List<Bitmap>{ cartaArancio, cartaRosso, cartaBlu, cartaVerde, cartaGiallo, cartaRosa, cartaTurchese, cartaViola, cartaFuoco, cartaAcqua, cartaFoglia, cartaPietra, cartaSole});
        }

        //Funzione di generazione//--------------------------------------------------//
        private void generaCarte(int livello)
        {
            //Creazione delle sprite delle carte//-----------------------------------//
            float width = gamePanel.Width / 2;
            float height = gamePanel.Height / 2;
            int padding = 20;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < livello+1; j++)
                {
                    Rectangle r = new Rectangle(Convert.ToInt32((width - ((retroCarta.Width/2*(livello+1)) + padding * (livello) / 2)) + (retroCarta.Width / 2 * j + padding * j / 2)), Convert.ToInt32((height - (retroCarta.Height / 2 + padding / 2)) + (retroCarta.Height / 2 * i + padding * i)), retroCarta.Width / 2, retroCarta.Height / 2);
                    carte.Add(new Carta(r));
                }
            }

            //Generazione casuale dell'ordine delle carte//--------------------------//
            List<string> coloriDisponibili = colori.Take(livello+1).ToList();
            coloriDisponibili.AddRange(colori.Take(livello + 1));
            Dictionary<string, Bitmap> dictColori = new Dictionary<string, Bitmap>();

            for(int i = 0; i < livello+1; i++)
            {
                dictColori.Add(coloriDisponibili[i], sprites[i]);
            }

            List<int> esclusi = new List<int>();
            Random oggettoRand = new Random();
            int cartaCasuale;

            for(int i = 0; i < (livello+1)*2; i++)
            {
                do
                {
                    cartaCasuale = oggettoRand.Next(0, coloriDisponibili.Count);

                } while (esclusi.Contains(cartaCasuale));

                carte[i].colore = coloriDisponibili[cartaCasuale];
                carte[i].sprite = dictColori[coloriDisponibili[i]];

                esclusi.Add(cartaCasuale);
            }

            inGame = true;
        }

        //tasto Gioca//--------------------------------------------------------------//
        private void tastoGioca_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            victoryPanel.Hide();
            gamePanel.Hide();
            levelPanel.Show();
            
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
                for(int i = 0; i < (livelloSelezionato+1)*2; i++)
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
                for (int i = 0; i < (livelloSelezionato+1)*2; i++)
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
                for (int i = 0; i < (livelloSelezionato + 1) * 2; i++)
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
                                if(condVittoria >= livelloSelezionato+1)
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

        private void tornaMenu_Click(object sender, EventArgs e)
        {
            

            menuPanel.Show();
            victoryPanel.Hide();
        }

        private void livello1_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 1;
            generaCarte(livelloSelezionato);
            gamePanel.Show();
            levelPanel.Hide();
        }
    }


}
