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

        //Classe Pulsante//----------------------------------------------------------//
        private class Pulsante
        {
            public Rectangle r { get; set; }
            public bool hover { get; set; }

            public Pulsante(Rectangle r)
            {
                this.r = r;
                this.hover = false;
                this.hover = hover;
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
        private Bitmap cartaTurchese = new Bitmap("Sprite/cartaTurchese.png");
        private Bitmap cartaViola = new Bitmap("Sprite/cartaViola.png");
        private Bitmap cartaFuoco = new Bitmap("Sprite/cartaFuoco.png");
        private Bitmap cartaAcqua = new Bitmap("Sprite/cartaAcqua.png");
        private Bitmap cartaSole = new Bitmap("Sprite/cartaSole.png");

        private Bitmap titolo = new Bitmap("Sprite/titolo.png");
        private Bitmap gioca = new Bitmap("Sprite/gioca.png");
        private Bitmap esci = new Bitmap("Sprite/esci.png");

        private Pulsante Gioca;
        private Pulsante Esci;
        private Pulsante Titolo;

        Rectangle giocaR;
        Rectangle esciR;
        Rectangle titoloR;

        List<string> colori = new List<string> { "Arancio", "Rosso", "Blu", "Verde", "Giallo", "Turchese", "Viola", "Fuoco", "Acqua", "Sole" };
        List<Bitmap> sprites = new List<Bitmap>();

        private List<Carta> carte = new List<Carta>();
        private bool primaCarta = false;
        private Carta cartaGirata;
        private int condVittoria = 0;
        private int livelliSbloccati = 9;
        private int livelloSelezionato;
        private int carteLivello = 0;

        private List<Button> pulsantiLivello = new List<Button>();

        private bool pausaClick = false;

        private bool inMenu = true;

        //Centra i Pannelli//--------------------------------------------------------//
        private void centraPannello(Panel p)
        {
            int x = (this.ClientSize.Width - p.Width) / 2;
            int y = (this.ClientSize.Height - p.Height) / 2;
            p.Location = new Point(Math.Max(0, x), Math.Max(0, y));
        }

        //Funzione chiamata all'avvio del programma//--------------------------------//
        public Form1()                                                              
        {                                                                           
            InitializeComponent();
            centraPannello(menuPanel);
            centraPannello(levelPanel);
            centraPannello(gamePanel);
            centraPannello(victoryPanel);

            menuPanel.Dock = DockStyle.Fill;
            levelPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            victoryPanel.Dock = DockStyle.Fill;

            Color prugna = Color.FromArgb(7, 59, 76);
            victoryPanel.BackColor = prugna;
            gamePanel.BackColor = prugna;
            levelPanel.BackColor = prugna;
            menuPanel.BackColor = prugna;
            menuPanel.BringToFront();

            int giocaX = this.ClientSize.Width / 2 - gioca.Width / 2;
            int giocaY = this.ClientSize.Height / 2 - gioca.Height / 2;
            giocaR = new Rectangle(giocaX, giocaY, gioca.Width, gioca.Height);
            Gioca = new Pulsante(giocaR);
            

            int esciX = this.ClientSize.Width / 2 - esci.Width / 2;
            int esciY = this.ClientSize.Height / 2 + esci.Height;
            esciR = new Rectangle(esciX, esciY, esci.Width, esci.Height);
            Esci = new Pulsante(esciR);


            int titoloX = this.ClientSize.Width / 2 - titolo.Width / 2;
            int titoloY = this.ClientSize.Height / 2 - titolo.Height * 2;
            titoloR = new Rectangle(titoloX, titoloY, titolo.Width, titolo.Height);
            Titolo = new Pulsante(titoloR);

            sprites.AddRange(new List<Bitmap>{ cartaArancio, cartaRosso, cartaBlu, cartaVerde, cartaGiallo, cartaTurchese, cartaViola, cartaFuoco, cartaAcqua, cartaSole});
            pulsantiLivello.AddRange(new List<Button> { livello1, livello2, livello3, livello4, livello5, livello6, livello7, livello8, livello9});
        }

        //Funzione di generazione//--------------------------------------------------//
        private void generaCarte(int livello)
        {
            carte.Clear();
            //Creazione delle sprite delle carte//-----------------------------------//
            int screenWidth = gamePanel.Width;
            int screenHeight = gamePanel.Height;
            int padding = 20;
            int totaleCarte = (livello + 1) * 2;
            int righe = 0;

            if(totaleCarte >6 && totaleCarte % 4 == 0)
            {
                righe = (int)Math.Ceiling((double)totaleCarte / 4);
            } else
            {
                righe = (int)Math.Ceiling((double)totaleCarte / 6);
            }

                int colonne = totaleCarte <= 6 ? totaleCarte : totaleCarte / righe;
            
            int larghezzaCarta = retroCarta.Width / 2;
            int altezzaCarta = retroCarta.Height / 2;

            int grigliaWidth = ((larghezzaCarta * colonne) + (padding * (colonne - 1)));
            int grigliaHeight = (altezzaCarta * righe + padding * righe);

            int startX = (screenWidth - grigliaWidth)/2;
            int startY = (screenHeight - grigliaHeight)/2;

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
            if(livello + 1 == 7)
            {
                Rectangle r = new Rectangle(startX - larghezzaCarta - padding, startY + altezzaCarta + padding, larghezzaCarta, altezzaCarta);
                carte.Add(new Carta(r));
                r = new Rectangle(startX + 4*(larghezzaCarta + padding), startY + altezzaCarta + padding, larghezzaCarta, altezzaCarta);
                carte.Add(new Carta(r));
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

        //Tasto Torna al Menu Principale//-------------------------------------------//
        private void Indietro_Click(object sender, EventArgs e)
        {
            gamePanel.Hide();
            menuPanel.Show();
            inGame = false;
            condVittoria = 0;
            carte.Clear();
            menuPanel.Invalidate();
        }

        //Funzione chiamata ad ogni ridisegno del pannello di gioco//----------------//
        private void panelGame_Paint(object sender, PaintEventArgs e)
        {

            if (inGame)
            {
                for(int i = 0; i < (livelloSelezionato +1)*2; i++)
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

        //Funzione per ridisegno Main Menu//-----------------------------------------//
        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(gioca, Gioca.r);
            
            e.Graphics.DrawImage(esci, Esci.r);

            e.Graphics.DrawImage(titolo, Titolo.r);
        }

        //Funzione di rilevamento click nel main Menu//------------------------------//
        private void menuPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (inMenu)
            {
                if (Gioca.r.Contains(e.Location))
                {
                    menuPanel.Hide();
                    victoryPanel.Hide();
                    gamePanel.Hide();
                    levelPanel.Show();

                    for (int i = 0; i < livelliSbloccati; i++)
                    {
                        pulsantiLivello[i].BackColor = Color.White;
                    }
                } else if (Esci.r.Contains(e.Location))
                {
                    this.Close();
                }
            }
        }

        //Quando il mouse sta su un pulsante nel main menu//-------------------------//
        private void menuPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (inMenu)
            {
                if (Gioca.r.Contains(e.Location) && !Gioca.hover)
                {
                    Gioca.r = new Rectangle(Gioca.r.X, Gioca.r.Y, Gioca.r.Width + Gioca.r.Width / 10, Gioca.r.Height + Gioca.r.Height/ 10);
                    Gioca.hover = true;
                    menuPanel.Invalidate();
                }
                else if (!Gioca.r.Contains(e.Location) && Gioca.hover)
                {
                    Gioca.r = giocaR;
                    Gioca.hover = false;
                    menuPanel.Invalidate();
                }

                if(Esci.r.Contains(e.Location) && !Esci.hover)
                {
                    Esci.r = new Rectangle(Esci.r.X, Esci.r.Y, Esci.r.Width + Esci.r.Width/10, Esci.r.Height + Esci.r.Height/ 10);
                    Esci.hover = true;
                    menuPanel.Invalidate();
                }
                else if (!Esci.r.Contains(e.Location) && Esci.hover)
                {
                    Esci.r = esciR;
                    Esci.hover = false;
                    menuPanel.Invalidate();
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
                                
                                
                                if(livelliSbloccati < 9)
                                {
                                    livelliSbloccati += 1;
                                }

                                victoryPanel.Show();
                                victoryPanel.BringToFront();
                                this.Refresh();
                                condVittoria = 0;
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
            menuPanel.Invalidate();
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

        
    }


}
