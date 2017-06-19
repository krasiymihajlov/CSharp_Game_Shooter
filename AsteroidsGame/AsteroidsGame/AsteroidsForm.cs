using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidsGame.GameOption;
using AsteroidsGame.Properties;
using AsteroidsGame.Sounds;

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        private const int BombLife = 3;

        private Random rnd = new Random();
        private static int totalShots = 0;
        private static int score = 0;
        private static int missingShots = 0;
        private static int DestroyedImageCounter = 0;
        private static bool Destroyed = false;
        private static bool DestroyedGift = false;
        private static int NukeCloudCounter = 0;
        private static int GiftCounter = 0;
        private static int DestroyedGiftCounter = 0;
        private static bool NukeCity = false;
        private static bool isGiftVisible = false;

        public AsteroidsForm()
        {
            InitializeComponent();

            label1.Hide();
            ExplodingAsteroid.Hide();
            NukeCloud.Hide();
            RocketPB.Hide();
            RedGift.Hide();
            LaserPB.Hide();

            BombPB.BringToFront();

            Bomb.X = 200;
            Bomb.Y = -30;
            Bomb.Life = BombLife;
            Rocket.Count = 10;
        }

        private void ScoreCounter()
        {
            score++;
            ScoreCount.Text = "Score = " + score;

            //totalShots++;
            //label1.Text = "Total Shots = " + totalShots;
        }

        public void MissShot()
        {
            missingShots++;
            totalShots++;
            label1.Text = "Total Shots = " + totalShots;

            //if (missingShots >= 20)
            //{
            //    Rockets.Hide();
            //    label1.Hide();
            //    ScoreCount.Hide();
            //}
        }

        public void RocketCount(int count)
        {
            Rockets.Text = "Rockets: " + count;
        }

        private void AsteroidsForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Show mouse position
            mouseXposer.Text = $"X: {e.X} / Y: {e.Y}";

            // Convert the cursor to Gunsight
            PictureBox gunSight = new PictureBox() { Image = Resources.Sight };
            this.Cursor = new Cursor(((Bitmap)gunSight.Image).GetHicon());
        }

        private void AsteroidPositionTimer_Tick(object sender, EventArgs e)
        {
            if (!StartGame.GameIsStarted())
            {
                AsteroidPositionTimer.Stop();
            }

            // Rocket movement >>------------------>
            if (Rocket.IsFired)
            {
                Rocket.Move(RocketPB, BombPB);
                //GiftShow.Move(RocketPB,RedGift);
            }
            // <----------------------------------<<

            if (Bomb.IsExploding)
            {
                DestroyBomb();
            }
            if (Gift.IsExploding)
            {
                RedGift.Hide();
            }
            // Laser >>---------------------------->
            if (Laser.TimeCounter > 0)
            {
                Laser.TimeCounter--;
            }

            if (Laser.TimeCounter <= 0)
            {
                LaserPB.Hide();
            }
            // <----------------------------------<<

            Bomb.Y += 7;
            BombPB.Location = new Point(Bomb.X, Bomb.Y);

            if (DestroyedImageCounter >= 10 && Destroyed)
            {
                ExplodingAsteroid.Hide();
                DestroyedImageCounter = 0;

                Bomb.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
                Bomb.Y = -30;
                Destroyed = false;
                BombPB.Location = new Point(Bomb.X, Bomb.Y);
                BombPB.Show();
            }
            else if (Destroyed)
            {
                DestroyedImageCounter++;
            }
            else if (Bomb.Y >= rnd.Next(500, 600) || NukeCity)
            {
                if (NukeCloudCounter == 0)
                {
                    NukeCity = true;
                    NukeCloud.Location = new Point(Bomb.X, Bomb.Y);
                    NukeCloud.Show();

                    PlaySound.PlayExplodeSound();

                    // New Asteroid Spawn Location
                    Bomb.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
                    Bomb.Y = -30;
                    Bomb.Life = BombLife;

                    NukeCloudCounter++;
                }
                else if (NukeCloudCounter >= 50)
                {
                    NukeCloud.Hide();
                    NukeCloudCounter = 0;
                    NukeCity = false;
                }
                else
                {
                    NukeCloudCounter++;
                }
            }

            //Gift logic -----------------------------------------
            if (!isGiftVisible)
            {
                int showGiftRandom = rnd.Next(0, 200);

                if (showGiftRandom == 1)
                {
                    int[] bombXLocation =
                    {
                        Bomb.X - BombPB.Width,
                        Bomb.X + BombPB.Width
                    };

                    Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);

                    if (Gift.X >= bombXLocation[0] && Gift.X <= bombXLocation[1])
                    {
                        Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
                    }

                    Gift.Y = -30;
                    RedGift.Location = new Point(Gift.X, Gift.Y);

                    isGiftVisible = true;

                    RedGift.Show();
                    GiftPositionTimer.Start();
                }
            }
        }


        // Shot Outside the target
        private void AsteroidsForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rocket.Count > 0 && !Rocket.IsFired)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);                  // label for rocket counting
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, e.X);

                    if (Rocket.IsFired)
                    {
                        ScoreCounter();                    // label for Score counting
                    }
                }
            }
            else // mouse button == Left
            {
                PlaySound.PlayMouseSound(e.Button);
                Laser.LightUp(LaserPB, e.X, BombPB, false);
            }

            MissShot();
        }

        // Shot Inside the target
        private void Asteroid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Rocket
            {
                if (Rocket.Count > 0 && !Rocket.IsFired)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);
                    ScoreCounter();         // label for rocket counting
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, BombPB.Left + BombPB.Width / 4);
                }
            }
            else // Laser
            {
                PlaySound.PlayMouseSound(e.Button);
                Bomb.Life--;
                if (Bomb.Life == 0)
                {
                    ScoreCounter();    // label for Score counting
                }
                Laser.LightUp(LaserPB, e.X, BombPB, true);
            }

            if (Bomb.IsExploding || Bomb.Life <= 0)
            {
                DestroyBomb();
            }
        }

        private void DestroyBomb()
        {
            BombPB.Hide();
            ExplodingAsteroid.Left = BombPB.Left - 10;
            ExplodingAsteroid.Top = BombPB.Top - 20;
            ExplodingAsteroid.Show();
            PlaySound.PlayExplodeSound();
            Destroyed = true;
            Bomb.IsExploding = false;
            Bomb.Life = 3;
            Rocket.IsFired = false;
            RocketPB.Hide();

            AsteroidPositionTimer.Start();
            LaserPB.Hide();
        }

        private void DestroyGift()
        {
            RedGift.Hide();
            //ExplodingAsteroid.Left = RedGift.Left - 10;
            //ExplodingAsteroid.Top = RedGift.Top - 20;
            //ExplodingAsteroid.Show();
            PlaySound.PlayExplodeSound();
            DestroyedGift = true;
            Gift.IsExploding = false;
            Rocket.IsFired = false;
            RocketPB.Hide();

            AsteroidPositionTimer.Start();
            LaserPB.Hide();
        }


        private void pictureBox4_Click(object sender, MouseEventArgs e)
        {
            ////this is redGift
            //if (e.Button == MouseButtons.Right) // Rocket
            //{
            //    if (Rocket.Count > 0 && !Rocket.IsFired)
            //    {
            //        RedGift.Hide();
            //        int count = Rocket.Count--;
            //        RocketCount(count - 1);
            //        ScoreCounter();         // label for rocket counting
            //        PlaySound.PlayMouseSound(e.Button);
            //        Rocket.Fire(RocketPB, Height, BombPB.Left + BombPB.Width / 4);
            //    }
            //}
            //else // Laser
            //{
            //    RedGift.Hide();

            //    PlaySound.PlayMouseSound(e.Button);

            //    Laser.LightUp(LaserPB, e.X, BombPB, true);
            //}

            //if (Gift.IsExploding)
            //{
            //    DestroyGift();
            //}
        }
        private void GiftPositionTimer_Tick(object sender, EventArgs e)
        {
            if (DestroyedGift || Gift.Y >= 700)
            {
                DestroyedGift = false;
                isGiftVisible = false;
                GiftPositionTimer.Stop();
                RedGift.Hide();
                int count = Rocket.Count++;
                RocketCount(count - 1);
            }
            else
            {
                Gift.Y += 5;
                RedGift.Location = new Point(Gift.X, Gift.Y);
            }
        }


        private void PauseGame_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            StartGame.IsStarted = true;
            AsteroidPositionTimer.Start();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
            GiftPositionTimer.Stop();
            StartGame.IsStarted = false;
            Destroyed = true;
            Bomb.IsExploding = false;
            Gift.IsExploding = false;
            Rocket.IsFired = false;
            Bomb.Life = 3;
            BombPB.Hide();
            RocketPB.Hide();
            LaserPB.Hide();
            RedGift.Hide();
            Rocket.Count = 11;
            score = 0;
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            QuitGame.ExitGame();
        }
    }
}