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
        private int livelliSbloccati = 12;
        private int livelloSelezionato;

        private List<Button> pulsantiLivello = new List<Button>();

        private bool pausaClick = false;

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
            pulsantiLivello.AddRange(new List<Button> { livello1, livello2, livello3, livello4, livello5, livello6, livello7, livello8, livello9, livello10, livello11, livello12 });
        }

        //Funzione di generazione//--------------------------------------------------//
        private void generaCarte(int livello)
        {
            carte.Clear();
            //Creazione delle sprite delle carte//-----------------------------------//
            int screenWidth = gamePanel.Width / 2;
            int screenHeight = gamePanel.Height / 2;
            int padding = 20;
            int totaleCarte = (livello + 1) * 2;
            int righe = (int)Math.Ceiling((double)totaleCarte / 6);
            int colonne;
            colonne = totaleCarte < 6 ? totaleCarte : totaleCarte / righe;
            
            int larghezzaCarta = retroCarta.Width / 2;
            int altezzaCarta = retroCarta.Height / 2;

            int grigliaWidth = ((larghezzaCarta * colonne) + (padding * (colonne - 1)))/2;
            int grigliaHeight = (altezzaCarta * righe + padding * righe)/2;

            int startX = screenWidth - grigliaWidth;
            int startY = screenHeight - grigliaHeight;

            for (int i = 0; i < righe; i++)
            {
                for (int j = 0; j < colonne; j++)
                {
                    int x = startX + j * (larghezzaCarta + padding);
                    int y = startY + altezzaCarta * i + padding * i;

                    Rectangle r = new Rectangle(x, y, larghezzaCarta, altezzaCarta);
                    carte.Add(new Carta(r));
                }
            }

            //Generazione casuale dell'ordine delle carte//--------------------------//
            List<string> coloriDisponibili = new List<string>();
            Dictionary<string, Bitmap> dictColori = new Dictionary<string, Bitmap>();

            coloriDisponibili.AddRange(colori.Take(livello + 1));
            coloriDisponibili.AddRange(colori.Take(livello + 1));

            for (int i = 0; i < livello+1; i++)
            {
                dictColori.Add(coloriDisponibili[i], sprites[i]);
            }

            Random oggettoRand = new Random();

            for(int i = coloriDisponibili.Count - 1; i > 0; i--)
            {
                int m = oggettoRand.Next(i + 1);

                var temp = coloriDisponibili[m];
                coloriDisponibili[m] = coloriDisponibili[i];
                coloriDisponibili[i] = temp;
            }

            for(int i = 0; i < (livello+1)*2; i++)
            {
                carte[i].colore = coloriDisponibili[i];
                carte[i].sprite = dictColori[coloriDisponibili[i]];

            }

            coloriDisponibili.Clear();
            dictColori.Clear();
            

            inGame = true;
        }

        //tasto Gioca//--------------------------------------------------------------//
        private void tastoGioca_Click(object sender, EventArgs e)
        {
            menuPanel.Hide();
            victoryPanel.Hide();
            gamePanel.Hide();
            levelPanel.Show();
            
            for(int i = 0; i < livelliSbloccati; i++)
            {
                pulsantiLivello[i].BackColor = Color.White;
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
            condVittoria = 0;
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
            if (!inGame || pausaClick)
                return;

            for (int i = 0; i < (livelloSelezionato + 1) * 2; i++)
            {
                if (carte[i].rect.Contains(e.Location) && !carte[i].girato)
                {
                    //Quando si preme su una carta il programma controlla se è
                    //la prima o la seconda carta che si sceglie
                    if (!primaCarta)
                    {
                        carte[i].girato = true;
                        primaCarta = true;
                        cartaGirata = carte[i];
                        gamePanel.Invalidate();
                    }
                    else
                    {
                        carte[i].girato = true;
                        pausaClick = true;
                        gamePanel.Invalidate();

                        //Se le carte sono di colore diverso le rigira
                        if (carte[i].colore == cartaGirata.colore)
                        {
                            condVittoria += 1;
                            if (condVittoria >= livelloSelezionato + 1)
                            {
                                inGame = false;
                                gamePanel.Hide();
                                victoryPanel.Show();
                                victoryPanel.BringToFront();
                                this.Refresh();
                                condVittoria = 0;
                                livelliSbloccati += 1;
                            }
                        }
                        else
                        {
                            await Task.Delay(500);
                            carte[i].girato = false;
                            cartaGirata.girato = false;

                            gamePanel.Invalidate();
                        }

                        pausaClick = false;
                        primaCarta = false;
                    }

                    break;
                }
            }

        }

        //Quando si preme si torna al menu principale//------------------------------//
        private void tornaMenu_Click(object sender, EventArgs e)
        {
            menuPanel.Show();
            victoryPanel.Hide();
            carte.Clear();

            for (int i = 0; i < livelliSbloccati; i++)
            {
                pulsantiLivello[i].BackColor = Color.White;
            }
        }
        

//------------------------------------------LIVELLI------------------------------------------//

        //livello1//-----------------------------------------------------------------//
        private void livello1_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 1;
            generaCarte(livelloSelezionato);
            gamePanel.Show();
            levelPanel.Hide();
        }

        //Livello 2//----------------------------------------------------------------//
        private void livello2_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 2;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 3//----------------------------------------------------------------//
        private void livello3_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 3;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 4//----------------------------------------------------------------//
        private void livello4_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 4;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 5//----------------------------------------------------------------//
        private void livello5_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 5;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 6//----------------------------------------------------------------//
        private void livello6_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 6;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 7//---------------------------------------------------------------//
        private void livello7_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 7;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 8//----------------------------------------------------------------//
        private void livello8_Click(object sender, EventArgs e)
        {
            if (livelliSbloccati >= 8)
            {
                livelloSelezionato = 8;
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 9//----------------------------------------------------------------//
        private void livello9_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 9;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 10//---------------------------------------------------------------//
        private void livello10_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 10;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 11//---------------------------------------------------------------//
        private void livello11_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 11;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }

        //Livello 12//---------------------------------------------------------------//
        private void livello12_Click(object sender, EventArgs e)
        {
            livelloSelezionato = 12;
            if (livelliSbloccati >= livelloSelezionato)
            {
                generaCarte(livelloSelezionato);
                gamePanel.Show();
                levelPanel.Hide();
            }
        }
    }


}
