using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemortMatchingGame
{
    public partial class GameRoom : Form
    {
        public GameRoom()
        {
            InitializeComponent();
        }

        private void GameRoom_Load(object sender, EventArgs e)
        {
            
        }
      

        bool allowClick = false;
        PictureBox firstguess;
        Random rnd = new Random();
        Timer clickTimer = new Timer();
        int time = 0;
        int moves = 0;
        int counter = 8;
        Timer timer = new Timer
        {
            Interval = 1000
        };


        private PictureBox[] pictureBoxes
        {
            get { return Controls.OfType<PictureBox>().ToArray(); }
        }

        private static IEnumerable<Image> images
        {
            get
            {
                return new Image[]
                {
                Properties.Resources.img1,
                Properties.Resources.img2,
                Properties.Resources.img3,
                Properties.Resources.img4,
                Properties.Resources.img5,
                Properties.Resources.img6,
                Properties.Resources.img7,
                Properties.Resources.img8
                };
            }

        }

        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time++;

                var ssTime = TimeSpan.FromSeconds(time);
                if (time < 10)
                    label1.Text = "Time: 00:0" + time.ToString();
                else
                    label1.Text = "Time: 00:" + time.ToString();
            };
        }




        private void HideImages()
        {
            foreach (var pic in pictureBoxes)
            {
                if (pic.Enabled == true)
                    pic.Image = Properties.Resources.mystery;
            }
        }

        private PictureBox getFreeSlot()
        {
            int num;

            do
            {
                num = rnd.Next(0, pictureBoxes.Count());

            }
            while (pictureBoxes[num].Tag != null);
            return pictureBoxes[num];
        }

        private void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }

        }

        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }



        private void gameroom_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;

            label1.FlatStyle = FlatStyle.Flat;
            label1.BackColor = Color.Transparent;

            label2.FlatStyle = FlatStyle.Flat;
            label2.BackColor = Color.Transparent;

            button3.FlatStyle = FlatStyle.Flat;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;

            


        }

        private void clickImage(object sender, EventArgs e)
        {
            if (!allowClick) return;

            var pic = (PictureBox)sender;

            if (firstguess == null)
            {
                firstguess = pic;

                pic.Image = (Image)pic.Tag;
                return;

            }
            pic.Image = (Image)pic.Tag;

            if (pic.Image == firstguess.Image && pic != firstguess)
            {
                pic.Enabled = firstguess.Enabled = false;
                {
                    firstguess = pic;
                    counter--;
                    if (counter == 0)
                    {
                        timer.Stop();
                        button3.Visible = true;
                    }
                }

            }
            else
            {
                allowClick = false;
                clickTimer.Start();

            }

            firstguess = null;
            moves++;
            label2.Text = "Moves: " + moves;
        }

        private void startGame(object sender, EventArgs e)
        {

            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;

            button1.Visible = false;
            button3.Visible = false;



        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Enabled = true;

            }

            HideImages();
            setRandomImages();
            time = 0;
            counter = 8;
            moves = 0;
            label2.Text = "Moves: " + moves;
            timer.Start();
            button3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = 1000;
            clickTimer.Tick += CLICKTIMER_TICK;

            button1.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            foreach (var pic in pictureBoxes)
            {
                pic.Tag = null;
                pic.Enabled = true;

            }

            HideImages();
            setRandomImages();
            time = 0;
            counter = 8;
            moves = 0;
            label2.Text = "Moves: " + moves;
            timer.Start();
            button3.Visible = false;
        }
    }
}

