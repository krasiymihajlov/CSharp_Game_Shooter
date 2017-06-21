using System;
using System.Drawing;
using System.Windows.Forms;
using AsteroidsGame.GameOption;
using AsteroidsGame.Properties;
using AsteroidsGame.Sounds;
using System.Runtime.InteropServices;

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        private const int BombLife = 3;
        private const int GiftContentShowTime = 10;

        private Random rnd = new Random();
        private static int score = 0;
        private static int DestroyedImageCounter = 0;
        private static bool Destroyed = false;
        private static int NukeCloudCounter = 0;
        private static bool NukeCity = false;
        private static bool isGiftVisible = false;
        private static int missCount = 5;


        public AsteroidsForm()
        {
            InitializeComponent();

            ExplodingAsteroid.Hide();
            NukeCloud.Hide();
            RocketPB.Hide();
            RedGift.Hide();
            LaserPB.Hide();
            RocketGift.Hide();
            DashboardGiftLabel.Hide();
            GameOver.Hide();

            BombPB.BringToFront();

            Bomb.X = 200;
            Bomb.Y = -60;
            Bomb.Life = BombLife;
            Rocket.Count = 10;
        }

        private void ScoreCounter()
        {
            score++;
            ScoreCount.Text = "Score: " + score;
        }

        private void MissCounter()
        {
            missCount--;
            Lives.Text = "Lives: " + missCount;
        }

        public void RocketCount(int count)
        {
            Rockets.Text = "Rockets: " + count;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]
        extern static bool DestroyIcon(IntPtr handle);

        private void AsteroidsForm_MouseMove(object sender, MouseEventArgs e)
        {
            // Show mouse position
            mouseXposer.Text = $"X: {e.X} / Y: {e.Y}";
            
            // Convert the cursor to Gunsight
            PictureBox gunSight = new PictureBox() { Image = Resources.Sight };
            var tempIcon = (Bitmap)gunSight.Image;

            // The resulting icon for the cursor should be disposed, so that the resources are released, otherwise the program crashes
            IntPtr hicon = tempIcon.GetHicon();
            Icon bitmapIcon = Icon.FromHandle(hicon);
            this.Cursor = new Cursor(hicon);

            DestroyIcon(bitmapIcon.Handle);
        }

        private void AsteroidPositionTimer_Tick(object sender, EventArgs e)
        {
            if (!StartGame.GameIsStarted())
            {
                AsteroidPositionTimer.Stop();
            }

            // Gift >>----------------------------->
            if (Gift.ContentShowTyme > 0)
            {
                Gift.ContentShowTyme--;

                if (Gift.ContentShowTyme == 0)
                {
                    RocketGift.Hide();
                    DashboardGiftLabel.Hide();
                }
            }
            // <----------------------------------<<

            // Rocket movement >>------------------>
            if (Rocket.IsFired)
            {
                Rocket.Move(RocketPB, BombPB);
            }
            // <----------------------------------<<

            if (Bomb.IsExploding)
            {
                DestroyBomb();
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
            else if (Bomb.Y >= rnd.Next(380, 470) || NukeCity)
            {
                if (NukeCloudCounter == 0)
                {
                    NukeCity = true;

                    MissCounter();
                    if (missCount == 0)
                    {
                        AsteroidPositionTimer.Stop();
                        GiftPositionTimer.Stop();
                        StartGame.IsStarted = false;

                        BombPB.Hide();
                        RedGift.Hide();
                        NukeCloud.Hide();
                        ExplodingAsteroid.Hide();
                        RocketPB.Hide();
                        RocketGift.Hide();

                        GameOver.Show();

                    }

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
                int showGiftRandom = rnd.Next(0, 50);

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

        private void GiftPositionTimer_Tick(object sender, EventArgs e)
        {
            if (Gift.Y >= 700)
            {
                isGiftVisible = false;
                GiftPositionTimer.Stop();
                RedGift.Hide();
            }
            else
            {
                Gift.Y += 5;
                RedGift.Location = new Point(Gift.X, Gift.Y);
            }
        }

        // Shot Outside the target
        private void AsteroidsForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rocket.Count > 0 && !Rocket.IsFired && StartGame.IsStarted)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, e.X);                    
                }
            }
            else // mouse button == Left
            {
                if(StartGame.IsStarted)
                {
                    PlaySound.PlayMouseSound(e.Button);
                    Laser.LightUp(LaserPB, e.X, BombPB, false);
                }                
            }
        }

        // Shot Inside the target
        private void Asteroid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Rocket
            {
                if (Rocket.Count > 0 && !Rocket.IsFired && StartGame.IsStarted)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);   
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, BombPB.Left + BombPB.Width / 4);
                }
            }
            else // Laser
            {
                if(StartGame.IsStarted)
                {
                    PlaySound.PlayMouseSound(e.Button);
                    Bomb.Life--;
                    Laser.LightUp(LaserPB, e.X, BombPB, true);
                }                
            }

            if (Bomb.IsExploding || Bomb.Life <= 0)
            {
                DestroyBomb();
            }
        }

        private void RedGift_MouseClick(object sender, MouseEventArgs e)
        {
            //this is redGift
            if (e.Button == MouseButtons.Right) // Rocket
            {
                if (Rocket.Count > 0 && !Rocket.IsFired && StartGame.IsStarted)
                {
                    RedGift.Hide();
                    int count = Rocket.Count--;
                    RocketCount(count - 1);
                    ScoreCounter();         // label for rocket counting
                    PlaySound.PlayMouseSound(e.Button);
                    Gift.IsExploding = true;
                    Rocket.Fire(RocketPB, Height, RedGift.Left + RedGift.Width / 4);
                }
            }

            else // Laser
            {
                if (StartGame.IsStarted)
                {
                    RedGift.Hide();
                    PlaySound.PlayMouseSound(e.Button);
                    Laser.LightUp(LaserPB, e.X, RedGift, true);
                    Gift.IsExploding = true;
                }                
            }

            if (Gift.IsExploding)
            {
                DestroyGift();
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
            ScoreCounter();

            AsteroidPositionTimer.Start();
            LaserPB.Hide();
        }

        private void DestroyGift()
        {
            RedGift.Hide();
            //ExplodingAsteroid.Left = RedGift.Left - 10;
            //ExplodingAsteroid.Top = RedGift.Top - 20;
            //ExplodingAsteroid.Show();
            Gift.IsRocketComming = false;
           
            Rocket.IsFired = false;
            RocketPB.Hide();
            RedGift.Hide();
            score += 4;
            ScoreCounter();
            Rocket.Count++;
            RocketCount(Rocket.Count);

 			Gift.IsExploding = false;
            GiftPositionTimer.Start();
            RocketGift.Left = RedGift.Left + RedGift.Width / 2 - RocketGift.Width / 2;
            RocketGift.Top = RedGift.Top + RedGift.Height / 2;
            RocketGift.Show();
            DashboardGiftLabel.Show();
            Gift.ContentShowTyme = GiftContentShowTime;

            LaserPB.Hide();
        }

        private void PauseGame_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
            GiftPositionTimer.Stop();
            StartGame.IsStarted = false;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            StartGame.IsStarted = true;
            AsteroidPositionTimer.Start();
            GiftPositionTimer.Start();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
            GiftPositionTimer.Stop();
            StartGame.IsStarted = false;
            Destroyed = true;
            Bomb.IsExploding = false;
            Gift.IsRocketComming = false;
            Rocket.IsFired = false;
            Bomb.Life = 3;
            BombPB.Hide();
            RocketPB.Hide();
            LaserPB.Hide();
            RedGift.Hide();
            Rocket.Count = 10;
            ExplodingAsteroid.Hide();
            NukeCloud.Hide();
            RocketCount(Rocket.Count);
            score = -1;
            ScoreCounter();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            QuitGame.ExitGame();
        }
    }
}