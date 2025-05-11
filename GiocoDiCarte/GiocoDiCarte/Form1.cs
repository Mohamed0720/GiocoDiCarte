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
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
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
            public bool changed { get; set; }
            public bool hover { get; set; }

            public Carta(Rectangle rect)
            {
                this.rect = rect;
                this.girato = false;
                this.hover = false;
                this.changed = false;
            }
        }

        //Classe Pulsante//----------------------------------------------------------//
        private class Pulsante
        {
            public Rectangle r { get; set; }
            public bool hover { get; set; }
            public bool changed { get; set; }
            public Bitmap sprite { get; set; }
            public Bitmap hoveredSprite { get; set; }

            public Pulsante(Rectangle r, Bitmap sprite, Bitmap hSprite)
            {
                this.r = r;
                this.hover = false;
                this.sprite = sprite;
                this.hoveredSprite = hSprite;
                this.changed = false;
            }
        }

        //Variabili generali//-------------------------------------------------------//
        private bool inMenu = true;
        private bool inGame = false;
        private bool inLevels = false;
        private bool inVictory = false;
        private bool inGameover = false;
        private bool inImpostaz = false;

        //Le Bitmap//
        private Bitmap retroCarta = new Bitmap("Sprite/carte/retroCarta.png");
        private Bitmap retroCartaHover  = new Bitmap("Sprite/carte/retroCartaHover.png");
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
        private Bitmap esci = new Bitmap("Sprite/Pulsanti/esci.png");
        private Bitmap sfondo = new Bitmap("Sprite/sfondo.png");
        private Bitmap livelli = new Bitmap("Sprite/livelli.png");
        private Bitmap gameover = new Bitmap("Sprite/gameover.png");
        private Bitmap tornaAlMenu = new Bitmap("Sprite/tornaAlMenu.png");
        private Bitmap riquadro = new Bitmap("Sprite/riquadro.png");
        private Bitmap livelloCompletato = new Bitmap("Sprite/livelloCompletato.png");
        private Bitmap impostazioni = new Bitmap("Sprite/impostazioni.png");
        private Bitmap livelloBloccato = new Bitmap("Sprite/livelli/livelloBloccato.png");

        Rectangle titoloR;
        Rectangle livelliR;
        Rectangle gameoverR;

        //Gli Oggetti Pulsante nel Main//
        private Pulsante Gioca;
        private Pulsante Esci;
        //Oggetti Pulsante nella selezione livelli//
        private List<Pulsante> pulsantiLivello = new List<Pulsante>();
        //Oggetti tornaMenu//
        private Pulsante tornaMenuGameOver;
        private Pulsante tornaMenuVittoria;
        private Pulsante tornaMenuImpostaz;
        //Pulsante impostazioni//
        private Pulsante Impostazioni;

        //Liste per tenere le carte//
        List<string> colori = new List<string> { "Arancio", "Rosso", "Blu", "Verde", "Giallo", "Turchese", "Viola", "Fuoco", "Acqua", "Sole" };
        List<Bitmap> sprites = new List<Bitmap>();

        //Variabili per gestire le carte//
        private List<Carta> carte = new List<Carta>();
        private bool primaCarta = false;
        private Carta cartaGirata;
        //Variabili per gestire i livelli e la condizione di vittoria//
        private int condVittoria = 0;
        private int livelliSbloccati = 1;
        private int livelloSelezionato;
        private int nmosse;
        private int secondiTimer;
        Timer timergioco = new Timer();
        private int punteggio = 0;
        //Variabili booleane per altro
        private bool pausaClick = false;

        //Aggiunge il font//
        private PrivateFontCollection ff1 = new PrivateFontCollection();
        Font kiwiSoda;



        //--------------------------------------#/GENERALI\#-----------------------------------------\\

        //Fade in//
        private void fadeOut()
        {
            this.Opacity -= 0.5;
        }

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
            //Inizializza il form//
            InitializeComponent();

            //Centra i pannelli//
            centraPannello(menuPanel);
            centraPannello(levelPanel);
            centraPannello(gamePanel);
            centraPannello(victoryPanel);
            centraPannello(gameoverPanel);
            centraPannello(impostazPanel);

            //Fa sì che i pannelli riempano tutto lo spazio disponibile nella finestra//
            menuPanel.Dock = DockStyle.Fill;
            levelPanel.Dock = DockStyle.Fill;
            gamePanel.Dock = DockStyle.Fill;
            victoryPanel.Dock = DockStyle.Fill;
            gameoverPanel.Dock = DockStyle.Fill;

            //Aggiunge lo sfondo ad ogni pannello//
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

            //Aggiunge il font//
            ff1.AddFontFile("Font/KiwiSoda.ttf");
            kiwiSoda = new Font(ff1.Families[0], 16, FontStyle.Regular);

            //Imposta la dimensione e la posizione dei diversi pulsanti//
            int giocaX = this.ClientSize.Width / 2 - gioca.Width / 2;
            int giocaY = this.ClientSize.Height / 2 - gioca.Height / 2;
            Rectangle r = new Rectangle(giocaX, giocaY, gioca.Width, gioca.Height);
            Gioca = new Pulsante(r, gioca, new Bitmap("Sprite/Pulsanti/giocaHover.png"));

            int esciX = this.ClientSize.Width / 2 - esci.Width / 2;
            int esciY = this.ClientSize.Height / 2 + esci.Height;
            r = new Rectangle(esciX, esciY, esci.Width, esci.Height);
            Esci = new Pulsante(r, esci, new Bitmap("Sprite/Pulsanti/esciHover.png"));

            int tornaMenuGOX = this.ClientSize.Width / 2 - tornaAlMenu.Width / 2;
            int tornaMenuGOY = this.ClientSize.Height / 2 - tornaAlMenu.Height / 2;
            r = new Rectangle(tornaMenuGOX, tornaMenuGOY, tornaAlMenu.Width, tornaAlMenu.Height);
            tornaMenuGameOver = new Pulsante(r, tornaAlMenu, new Bitmap("Sprite/tornaAlMenuHover.png"));

            int tornaMenuVX = this.ClientSize.Width / 2 - tornaAlMenu.Width / 2;
            int tornaMenuVY = this.ClientSize.Height / 2 + tornaAlMenu.Height;
            r = new Rectangle(tornaMenuVX, tornaMenuVY, tornaAlMenu.Width, tornaAlMenu.Height);
            tornaMenuVittoria = new Pulsante(r, tornaAlMenu, new Bitmap("Sprite/tornaAlMenuHover.png"));

            int tornaMenuImpX = impostazPanel.Width/2 - tornaAlMenu.Width/6;
            int tornaMenuImpY = impostazPanel.Height / 2 + tornaAlMenu.Height/3*2;
            r = new Rectangle(tornaMenuImpX, tornaMenuImpY, tornaAlMenu.Width, tornaAlMenu.Height);
            tornaMenuImpostaz = new Pulsante(r, tornaAlMenu, new Bitmap("Sprite/tornaAlMenuHover.png"));

            int impostazioniX = 50;
            int impostazioniY = this.ClientSize.Height - 100;
            r = new Rectangle(impostazioniX, impostazioniY, impostazioni.Width, impostazioni.Height);
            Impostazioni = new Pulsante(r, impostazioni, new Bitmap("Sprite/impostazioniHover.png"));

            //pannello di impostazioni//
            impostazPanel.Width = riquadro.Width;
            impostazPanel.Height = riquadro.Height;
            centraPannello(impostazPanel);
            impostazPanel.BackgroundImage = riquadro;

            //Aggiunge le bitmap delle carte alla lista sprites//
            sprites.AddRange(new List<Bitmap>{ cartaArancio, cartaRosso, cartaBlu, cartaVerde, cartaGiallo, cartaTurchese, cartaViola, cartaFuoco, cartaAcqua, cartaSole});
            
            //Richiama la funzione che genera i pulsanti di selezione livello//
            genLivelli();

            //Struttura For che imposta l'opzione DoubleBuffered di tutti i pannelli a True//
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

            //Timer che chiama la funzione di ridisegno ad ogni tot tick//s
            Timer fps = new Timer();
            fps.Interval = 64;
            fps.Tick += ridisegno;
            fps.Start();
            
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
                    if (carte[i].changed)
                    {
                        gamePanel.Invalidate(carte[i].rect);
                        carte[i].changed = false;
                    }
                }

                if (inImpostaz)
                {
                    if (tornaMenuImpostaz.changed)
                    {
                        impostazPanel.Invalidate(tornaMenuImpostaz.r);
                        tornaMenuImpostaz.changed = false;
                    }
                }
            }
            else if (inLevels) {
                for(int i = 0; i < 9; i++)
                {
                    if (pulsantiLivello[i].changed)
                    {
                        levelPanel.Invalidate(pulsantiLivello[i].r);
                        pulsantiLivello[i].changed = false;
                    }
                }
            }
            else if (inGameover)
            {
                gameoverPanel.Invalidate(gameoverR);

                if(tornaMenuGameOver.changed)
                { 
                    gameoverPanel.Invalidate(tornaMenuGameOver.r);
                    tornaMenuGameOver.changed = false;
                }
            }
            else if (inVictory)
            {
                if(tornaMenuVittoria.changed)
                { 
                    victoryPanel.Invalidate(tornaMenuVittoria.r);
                    tornaMenuVittoria.changed = false;
                }
            }


        }

//-----------------------------------------#/MENU\#------------------------------------------\\

        //Funzione per ridisegno Main Menu//-----------------------------------------//
        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {
            if (Gioca.hover)
            {
                e.Graphics.DrawImage(Gioca.hoveredSprite, Gioca.r);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                e.Graphics.DrawImage(gioca, Gioca.r);
                this.Cursor = Cursors.Default;
            }

            if (Esci.hover)
            {
                e.Graphics.DrawImage(Esci.hoveredSprite, Esci.r);
                this.Cursor = Cursors.Hand;
            }
            else
            { 
                e.Graphics.DrawImage(esci, Esci.r);
                this.Cursor = Cursors.Default;
            }
            

            titoloR = new Rectangle(this.ClientSize.Width / 2 - titolo.Width / 2, this.ClientSize.Height / 2 - titolo.Height * 2, titolo.Width, titolo.Height);
            e.Graphics.DrawImage(titolo, titoloR);

            
        }

        //Funzione di rilevamento click nel main Menu//------------------------------//
        private void menuPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (inMenu)
            {
                if (Gioca.r.Contains(e.Location))
                {
                    impostazPanel.Hide();
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
                    Pulsante livello = new Pulsante(new Rectangle(startX + tmp.Width * j + padding * j, startY + tmp.Height * i + padding * i, tmp.Width, tmp.Height), tmp, tmp);
                    pulsantiLivello.Add(livello);
                }
            }
            for (int i = 0; i < 9; i++)
            {
                pulsantiLivello[i].sprite = new Bitmap($"Sprite/Livelli/livello{i + 1}.png");
                pulsantiLivello[i].hoveredSprite = new Bitmap($"Sprite/Livelli/livello{i + 1}Hover.png");
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
                            nmosse = (livelloSelezionato + 1)*2+5;
                            label_nMosse.Text = "mosse: "+nmosse.ToString();
                           
                            labelTempo.Font = new Font(kiwiSoda.FontFamily, 50, FontStyle.Regular);
                            labelTempo.ForeColor = Color.White;                           
                            label_nMosse.Font = new Font(kiwiSoda.FontFamily, 50, FontStyle.Regular); ;
                            label_nMosse.ForeColor = Color.White;


                            generaCarte(livelloSelezionato);
                            gamePanel.Show();
                            levelPanel.Hide();

                            secondiTimer = 100;
                            labelTempo.Text=secondiTimer.ToString();
                            timergioco.Interval = 1000;
                            timergioco.Tick -= timer;
                            timergioco.Tick += timer;
                            timergioco.Start();

                        }
                    }
                }
            }
        }

        //Quando il mouse si muove mentre è nel pannello dei livelli//---------------//
        private void levelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!inLevels)
                return;

            for (int i = 0; i < 9; i++)
            {
                if (pulsantiLivello[i].r.Contains(e.Location) != pulsantiLivello[i].hover)
                {
                    pulsantiLivello[i].changed = true;
                    pulsantiLivello[i].hover = pulsantiLivello[i].r.Contains(e.Location);
                }
            }
        }

        //Ridisegno del pannello selezione livelli//---------------------------------//
        private void levelPanel_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if(i+1 <= livelliSbloccati)
                {
                    if (pulsantiLivello[i].hover)
                    {
                        e.Graphics.DrawImage(pulsantiLivello[i].hoveredSprite, pulsantiLivello[i].r);
                        this.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        e.Graphics.DrawImage(pulsantiLivello[i].sprite, pulsantiLivello[i].r);
                        this.Cursor = Cursors.Default;
                    }
                    
                }
                else
                {
                    e.Graphics.DrawImage(livelloBloccato, pulsantiLivello[i].r);
                }


                livelliR = new Rectangle(this.ClientSize.Width / 2 - livelli.Width / 2, this.ClientSize.Height / 2 - livelli.Height * 3, livelli.Width, livelli.Height);
                e.Graphics.DrawImage(livelli, livelliR);
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

        //Tasto riprendi partita//
        private void riprendi_Click(object sender, EventArgs e)
        {
            timergioco.Start();
            inImpostaz = false;
            inGame = true;
            impostazPanel.Hide();
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
                        if (carte[i].hover)
                        {
                            e.Graphics.DrawImage(retroCartaHover, carte[i].rect);
                        }
                        else
                        {
                            e.Graphics.DrawImage(retroCarta, carte[i].rect);
                        }
                        
                    }
                }

                if (Impostazioni.hover)
                {
                    e.Graphics.DrawImage(Impostazioni.hoveredSprite, Impostazioni.r);
                }
                else
                {
                    e.Graphics.DrawImage(impostazioni, Impostazioni.r);
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
                    if (carte[i].rect.Contains(e.Location) != carte[i].hover)
                    {
                        carte[i].changed = true;
                        carte[i].hover = carte[i].rect.Contains(e.Location);
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
                        label_nMosse.Text = "mosse: "+nmosse.ToString();
                        
                        if (nmosse == 0)
                        {
                            inGameover = true;
                            gameoverPanel.Show();
                            gameoverPanel.BringToFront();
                            gamePanel.Hide();
                            timergioco.Stop();
                        }
                        //Se le carte sono di colore diverso le rigira
                        if (carte[i].colore == cartaGirata.colore)
                        {
                            condVittoria += 1;
                            if (condVittoria >= livelloSelezionato + 1)
                            {
                                inGame = false;
                                inVictory = true;
                                gamePanel.Hide();
                                
                                
                                if(livelliSbloccati < 9)
                                {
                                    livelliSbloccati += 1;
                                }
                                timergioco.Stop();

                                //grafica label e bottoni
                                labelMosse.Text = "mosse rimaste: "+nmosse.ToString();
                                labelMosse.TextAlign = ContentAlignment.MiddleCenter;
                                labelMosse.Location = new Point((this.ClientSize.Width - labelMosse.Width) / 2, labelMosse.Location.Y);
                                labelMosse.Font = new Font(kiwiSoda.FontFamily, 40, FontStyle.Regular);
                                labelMosse.ForeColor = Color.Black;

                                labelTempoRimasto.Text = "secondi rimasti: "+secondiTimer.ToString();
                                labelTempoRimasto.TextAlign = ContentAlignment.MiddleCenter;
                                labelTempoRimasto.Font = new Font(kiwiSoda.FontFamily, 40, FontStyle.Regular);
                                labelTempoRimasto.Location = new Point((this.ClientSize.Width - labelTempoRimasto.Width) / 2, labelTempoRimasto.Location.Y);
                                labelTempoRimasto.ForeColor = Color.Black;

                                punteggio = nmosse * 10 + secondiTimer * 3;
                                labelPunteggio.Text= "punteggio: " + punteggio.ToString();
                                labelPunteggio.TextAlign = ContentAlignment.MiddleCenter;
                                labelPunteggio.Location= new Point((this.ClientSize.Width - labelPunteggio.Width) / 2,labelPunteggio.Location.Y);
                                labelPunteggio.ForeColor = Color.Black;
                                labelPunteggio.Font = new Font(kiwiSoda.FontFamily, 40, FontStyle.Regular);



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

            if (!inImpostaz && !primaCarta) {
                if (Impostazioni.r.Contains(e.Location))
                {
                    inImpostaz = true;
                    timergioco.Stop();
                    impostazPanel.Show();

                    riprendi.Text = "Riprendi";
                    riprendi.Font = new Font(kiwiSoda.FontFamily, 40, FontStyle.Regular);
                    riprendi.Location = new Point(impostazPanel.Width / 2 - riprendi.Width / 2, impostazPanel.Height / 2 - riprendi.Height / 2 * 3);
                    riprendi.ForeColor = Color.Black;


                }
            }
            

        }

        
        //sconfitta per il tempo
        private void timer(object sender, EventArgs e)
        {
            secondiTimer--;
            labelTempo.Text=secondiTimer.ToString();
            if (secondiTimer < 0)
            {
                timergioco.Stop();
                gamePanel.Hide();
                gameoverPanel.Show();
                gameoverPanel.BringToFront();
                inGameover = true;
            }

        }

        //Disegno del pannello impostazioni//
        private void impostazPanel_Paint(object sender, PaintEventArgs e)
        {
            if (!inImpostaz)
                return;

            if (tornaMenuImpostaz.hover)
            {
                e.Graphics.DrawImage(tornaMenuImpostaz.hoveredSprite, tornaMenuImpostaz.r);
                this.Cursor = Cursors.Hand;
            }
            else
            {
                e.Graphics.DrawImage(tornaAlMenu, tornaMenuImpostaz.r);
                this.Cursor = Cursors.Default;
            } 
        }

        //Rilevamento click nel pannello impostazioni//
        private void impostazPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!inImpostaz)
                return;

            if (tornaMenuImpostaz.r.Contains(e.Location))
            {
                timergioco.Stop();
                gamePanel.Hide();
                menuPanel.Show();
                inGame = false;
                inImpostaz = false;
                condVittoria = 0;
                carte.Clear();
                menuPanel.Invalidate();
                inMenu = true;
            }
        }

        //Al movimenti del mouse nel pannello impostazioni//
        private void impostazPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!inImpostaz)
                return;

            if (tornaMenuImpostaz.r.Contains(e.Location) != tornaMenuImpostaz.hover)
            {
                tornaMenuImpostaz.changed = true;
                tornaMenuImpostaz.hover = tornaMenuImpostaz.r.Contains(e.Location);
            }
        }


        //------------------------------------------#/VITTORIA/GAMEOVER\#---------------------------------------\\

        //Ridisegno del pannello di GameOver//
        private void gameoverPanel_Paint(object sender, PaintEventArgs e)
        {
            int centerW = this.Width / 2;
            int centerH = this.Height / 2;

            gameoverR = new Rectangle(centerW - gameover.Width / 2, centerH - gameover.Height * 2, gameover.Width, gameover.Height);

            e.Graphics.DrawImage(gameover, gameoverR);

            e.Graphics.DrawImage(tornaAlMenu, tornaMenuGameOver.r);
        }

        //Risposta al click del mouse nel pannello di Game Over//
        private void gameoverPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (inGameover)
            {
                if (tornaMenuGameOver.r.Contains(e.Location))
                {   
                    gameoverPanel.Hide();
                    menuPanel.Show();
                    inGameover = false;
                    inMenu = true;
                }
                    
                    
            }
        }

        //Movimento mouse all'interno del pannello di gameover//
        private void gameoverPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!inGameover)
                return;

            if(tornaMenuGameOver.r.Contains(e.Location) != tornaMenuGameOver.hover)
            {
                tornaMenuGameOver.changed = true;
                tornaMenuGameOver.hover = tornaMenuGameOver.r.Contains(e.Location);
            }
        }

        //Ridisegno del pannello di vittoria//
        private void victoryPanel_Paint(object sender, PaintEventArgs e)
        {
            int centerW = this.Width / 2;
            int centerH = this.Height / 2;

            int riqW = riquadro.Width;
            int riqH = riquadro.Height;
            e.Graphics.DrawImage(riquadro, new Rectangle(centerW - riqW / 2 - 10, centerH - riqH / 5 * 2, riqW, riqH));

            int livW = livelloCompletato.Width;
            int LivH = livelloCompletato.Height;
            e.Graphics.DrawImage(livelloCompletato, new Rectangle(centerW - livW/2, centerH - LivH/2*3, livW, LivH));

            if (tornaMenuVittoria.hover)
            {
                e.Graphics.DrawImage(tornaMenuVittoria.hoveredSprite, tornaMenuVittoria.r);
            }
            else
            {
                e.Graphics.DrawImage(tornaAlMenu, tornaMenuVittoria.r);
            }
            
        }

        private void victoryPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (!inVictory)
                return;

            if (tornaMenuVittoria.r.Contains(e.Location))
            {
                victoryPanel.Hide();
                menuPanel.Show();
                inGameover = false;
                inMenu = true;
            }
        }

        private void victoryPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!inVictory)
                return;

            if (tornaMenuVittoria.r.Contains(e.Location) != tornaMenuVittoria.hover)
            {
                tornaMenuVittoria.changed = true;
                tornaMenuVittoria.hover = tornaMenuVittoria.r.Contains(e.Location);
            }
        }
    }


}
