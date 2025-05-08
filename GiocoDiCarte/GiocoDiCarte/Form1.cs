using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
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
            public bool changed { get; set; }

            public Pulsante(Rectangle r)
            {
                this.r = r;
                this.hover = false;
            }
        }
 
        //Classe Pulsanti Livello//--------------------------------------------------//
        private class PulsanteLivello : Pulsante
        {
            public Bitmap sprite { get; set; }

            public PulsanteLivello(Rectangle r, Bitmap sprite) : base(r)
            {
                this.r = r;
                this.sprite = sprite;
            }
        }
        
        //Variabili generali//-------------------------------------------------------//
        private bool inGame = false;
        private bool inMenu = true;
        private bool inLevels = false;
        private bool inVictory = false;

        //Le Bitmap//
        private Bitmap retroCarta = new Bitmap("Sprite/carte/retroCarta.png");
        private Bitmap cartaArancio = new Bitmap("Sprite/carte/arancia.png");
        private Bitmap cartaRosso = new Bitmap("Sprite/carte/pizza.png");
        private Bitmap cartaBlu = new Bitmap("Sprite/carte/ghiaccio.png");
        private Bitmap cartaVerde = new Bitmap("Sprite/carte/foglia.png");
        private Bitmap cartaGiallo = new Bitmap("Sprite/carte/sole.png");
        private Bitmap cartaTurchese = new Bitmap("Sprite/carte/tamburo.png");
        private Bitmap cartaViola = new Bitmap("Sprite/carte/saturno.png");
        private Bitmap cartaFuoco = new Bitmap("Sprite/carte/calcio.png");
        private Bitmap cartaAcqua = new Bitmap("Sprite/carte/orso.png");
        private Bitmap cartaSole = new Bitmap("Sprite/carte/balena.png");

        private Bitmap titolo = new Bitmap("Sprite/titolo.png");
        private Bitmap gioca = new Bitmap("Sprite/Pulsanti/gioca.png");
        private Bitmap giocaHover = new Bitmap("Sprite/Pulsanti/giocaHover.png");
        private Bitmap esci = new Bitmap("Sprite/Pulsanti/esci.png");
        private Bitmap esciHover = new Bitmap("Sprite/Pulsanti/esciHover.png");
        private Bitmap sfondo = new Bitmap("Sprite/sfondo.png");
        private Bitmap livelli = new Bitmap("Sprite/livelli.png");

        //Gli Oggetti Pulsante nel Main//
        private Pulsante Gioca;
        private Pulsante Esci;
        private Pulsante Titolo;
        //Oggetti Pulsante nella selezione livelli
        private Pulsante Livelli;
        private List<PulsanteLivello> pulsantiLivello = new List<PulsanteLivello>();

        //Liste per tenere le carte//
        List<string> colori = new List<string> { "Arancio", "Rosso", "Blu", "Verde", "Giallo", "Turchese", "Viola", "Fuoco", "Acqua", "Sole" };
        List<Bitmap> sprites = new List<Bitmap>();

        //Variabili per gestire le carte//
        private List<Carta> carte = new List<Carta>();
        private bool primaCarta = false;
        private Carta cartaGirata;
        //Variabili per gestire i livelli e la condizione di vittoria//
        private int condVittoria = 0;
        private int livelliSbloccati = 9;
        private int livelloSelezionato;
        private int nmosse; 
        //Variabili booleane per altro
        private bool pausaClick = false;

        


//--------------------------------------#/GENERALI\#-----------------------------------------\\

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
            centraPannello(gameoverPanel);

            menuPanel.Dock = DockStyle.Fill;
            levelPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            victoryPanel.Dock = DockStyle.Fill;
            gameoverPanel.Dock = DockStyle.Fill;

            foreach (Control ctrl in this.Controls)
            {
                if(ctrl is Panel panel)
                {
                    panel.BackgroundImage = sfondo;
                    panel.BackgroundImageLayout = ImageLayout.Tile;
                }
            }
            gameoverPanel.Hide();
            menuPanel.BringToFront();

            int giocaX = this.ClientSize.Width / 2 - gioca.Width / 2;
            int giocaY = this.ClientSize.Height / 2 - gioca.Height / 2;
            Rectangle r = new Rectangle(giocaX, giocaY, gioca.Width, gioca.Height);
            Gioca = new Pulsante(r);

            int esciX = this.ClientSize.Width / 2 - esci.Width / 2;
            int esciY = this.ClientSize.Height / 2 + esci.Height;
            r = new Rectangle(esciX, esciY, esci.Width, esci.Height);
            Esci = new Pulsante(r);

            int titoloX = this.ClientSize.Width / 2 - titolo.Width / 2;
            int titoloY = this.ClientSize.Height / 2 - titolo.Height * 2;
            r = new Rectangle(titoloX, titoloY, titolo.Width, titolo.Height);
            Titolo = new Pulsante(r);

            int livelliX = this.ClientSize.Width / 2 - livelli.Width / 2;
            int livelliY = this.ClientSize.Height / 2 - livelli.Height * 3;
            r = new Rectangle(livelliX, livelliY, livelli.Width, livelli.Height);
            Livelli = new Pulsante(r);

            sprites.AddRange(new List<Bitmap>{ cartaArancio, cartaRosso, cartaBlu, cartaVerde, cartaGiallo, cartaTurchese, cartaViola, cartaFuoco, cartaAcqua, cartaSole});
            genLivelli();

            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    typeof(Panel).InvokeMember("DoubleBuffered",
                        System.Reflection.BindingFlags.SetProperty |
                        System.Reflection.BindingFlags.Instance |
                        System.Reflection.BindingFlags.NonPublic,
                        null, c, new object[] { true });
                }
            }
            Timer timer = new Timer();
            timer.Interval = 64;
            timer.Tick += ridisegno;
            timer.Start();

        }

        //Ridisegno pannelli ogni tot tempo//----------------------------------------//
        private void ridisegno(object sender, EventArgs e)
        {
            if (inMenu)
            {
                if (Gioca.changed)
                {
                    menuPanel.Invalidate(Gioca.r);
                    Gioca.changed = false;
                }

                if (Esci.changed)
                {
                    menuPanel.Invalidate(Esci.r);
                    Esci.changed = false;
                }
            }
            else if (inGame)
            {

                for (int i = 0; i < (livelloSelezionato + 1) * 2; i++)
                {
                    gamePanel.Invalidate(carte[i].rect);
                }
            }
            else if (inLevels) {
                for(int i = 0; i < 9; i++)
                {
                    levelPanel.Invalidate(pulsantiLivello[i].r);
                }
            }

        }

//-----------------------------------------#/MENU\#------------------------------------------\\

        //Funzione per ridisegno Main Menu//-----------------------------------------//
        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawImage(Gioca.hover ? giocaHover : gioca, Gioca.r);
            
            e.Graphics.DrawImage(Esci.hover ? esciHover : esci, Esci.r);

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

                    /**for (int i = 0; i < livelliSbloccati; i++)
                    {
                        pulsantiLivello[i].sprite = pulsantiLivello.spriteBloccata;
                    }**/
                    inMenu = false;
                    inLevels = true;
                }
                else if (Esci.r.Contains(e.Location))
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
                //Gioca
                if (Gioca.r.Contains(e.Location) != Gioca.hover)
                {
                    Gioca.changed = true;
                    Gioca.hover = Gioca.r.Contains(e.Location);
                }


                //Esci
                if (Esci.r.Contains(e.Location) != Esci.hover)
                {
                    Esci.changed = true;
                    Esci.hover = Esci.r.Contains(e.Location);
                }
            }

        }

//------------------------------------#/SELEZIONE LIVELLI\#---------------------------------------\\

        //Generazione  tasti livello//-----------------------------------------------//
        private void genLivelli()
        {

            var tmp = new Bitmap("Sprite/livelli/livello1.png");

            int screenW = this.Width;
            int screenH = this.Height;

            int padding = 40;

            int startX = screenW / 2 - tmp.Width/2 * 3 - padding;
            int startY = screenH / 2 - tmp.Height/2 * 3 - padding;

            for(int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    PulsanteLivello livello = new PulsanteLivello(new Rectangle(startX + tmp.Width * j + padding * j, startY + tmp.Height * i + padding * i, tmp.Width, tmp.Height), tmp);
                    pulsantiLivello.Add(livello);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                pulsantiLivello[i].sprite = new Bitmap($"Sprite/Livelli/livello{i + 1}.png");
            }

        }

        //Quando il mouse clicca sul pannello dei livelli//--------------------------//
        private void levelPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (inLevels)
            {
                for (int i = 0; i < 9; i++) {
                    if (pulsantiLivello[i].r.Contains(e.Location))
                    {
                        livelloSelezionato = i+1; 
                        if(livelliSbloccati >= livelloSelezionato)
                        {
                            nmosse = (livelloSelezionato + 1)*2;
                            label3.Text = nmosse.ToString();
                            generaCarte(livelloSelezionato);
                            gamePanel.Show();
                            levelPanel.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Livello non ancora sbloccato!");
                        }
                    }
                }
            }
        }

        //Quando il mouse si muove mentre è nel pannello dei livelli//---------------//
        private void levelPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        //Ridisegno del pannello selezione livelli//---------------------------------//
        private void levelPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                e.Graphics.DrawImage(pulsantiLivello[i].sprite, pulsantiLivello[i].r);

                e.Graphics.DrawImage(livelli, Livelli.r);
            }
        }


//------------------------------------------#/GIOCO\#---------------------------------------\\

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
            int larghezzaCarta = retroCarta.Width / 2;
            int altezzaCarta = retroCarta.Height / 2;

            if (livello + 1 < 8)
            {
                if (totaleCarte >6 && totaleCarte % 4 == 0)
                {
                    righe = (int)Math.Ceiling((double)totaleCarte / 4);
                } else
                {
                    righe = (int)Math.Ceiling((double)totaleCarte / 6);
                }

                int colonne = totaleCarte <= 6 ? totaleCarte : totaleCarte / righe;
            
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
                if (livello + 1 == 7)
                {
                    Rectangle r = new Rectangle(startX - larghezzaCarta - padding, startY + altezzaCarta + padding, larghezzaCarta, altezzaCarta);
                    carte.Add(new Carta(r));
                    r = new Rectangle(startX + 4 * (larghezzaCarta + padding), startY + altezzaCarta + padding, larghezzaCarta, altezzaCarta);
                    carte.Add(new Carta(r));
                }
            }
            else if(livello + 1 == 8)
            {
                righe = 4;
                int colonne = 7;

                int grigliaWidth = ((larghezzaCarta * colonne) + (padding * (colonne - 1)));
                int grigliaHeight = (altezzaCarta * righe + padding * righe);

                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < (colonne-i*2); j++)
                    {
                        int startX = (screenWidth - grigliaWidth) / 2 + i * (larghezzaCarta + padding);
                        int startY = (screenHeight - grigliaHeight) / 2;

                        int x = startX + j * (larghezzaCarta + padding);
                        int y = startY + altezzaCarta * i + padding * i;

                        Rectangle r = new Rectangle(x, y, larghezzaCarta, altezzaCarta);
                        carte.Add(new Carta(r));
                    }
                }
            }
            else if (livello + 1 == 9)
            {
                righe = 3;
                int colonne = 6;

                int grigliaWidth = (larghezzaCarta * colonne) + (padding * (colonne - 1)) + 2*(larghezzaCarta + padding);
                int grigliaHeight = altezzaCarta * righe + padding * righe;

                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < colonne; j++)
                    {
                        int startX = (screenWidth - grigliaWidth) / 2 + i * (larghezzaCarta + padding);
                        int startY = (screenHeight - grigliaHeight) / 2;

                        int x = startX + j * (larghezzaCarta + padding);
                        int y = startY + altezzaCarta * i + padding * i;

                        Rectangle r = new Rectangle(x, y, larghezzaCarta, altezzaCarta);
                        carte.Add(new Carta(r));
                    }
                }
            }
            else if (livello + 1 == 10)
            {
                righe = 4;
                int colonne = 7;

                int grigliaWidth = ((larghezzaCarta * colonne) + (padding * (colonne - 1)));
                int grigliaHeight = (altezzaCarta * righe + padding * righe);

                for (int i = 0; i < righe; i++)
                {
                    for (int j = 0; j < (colonne - i * 2); j++)
                    {
                        int startX = (screenWidth - grigliaWidth) / 2 + i * (larghezzaCarta + padding);
                        int startY = (screenHeight - grigliaHeight) / 2;

                        int x = startX + j * (larghezzaCarta + padding);
                        int y = startY + altezzaCarta * i + padding * i;

                        Rectangle r = new Rectangle(x, y, larghezzaCarta, altezzaCarta);
                        carte.Add(new Carta(r));
                    }
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

        //Tasto Torna al Menu Principale//-------------------------------------------//
        private void Indietro_Click(object sender, EventArgs e)
        {
            gamePanel.Hide();
            menuPanel.Show();
            inGame = false;
            condVittoria = 0;
            carte.Clear();
            menuPanel.Invalidate();
            inMenu = true;
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
                       
                    }
                    else
                    {
                        carte[i].girato = true;
                        pausaClick = true;
                        nmosse--;
                        
                        label3.Text = nmosse.ToString();
                        
                        if (nmosse == 0)
                        {
                            gameoverPanel.Show();
                            gameoverPanel.BringToFront();
                            gamePanel.Hide();
                        }
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
            inMenu = true;

            /**for (int i = 0; i < livelliSbloccati; i++)
            {
                pulsantiLivello[i].sprite = spriteBloccata;
            }**/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        //------------------------------------------#/VITTORIA/GAMEOVER\#---------------------------------------\\

        

    }


}
