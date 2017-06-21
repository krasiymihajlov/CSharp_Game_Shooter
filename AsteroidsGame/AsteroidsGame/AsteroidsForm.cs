using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AsteroidsGame.GameOption;
using AsteroidsGame.Properties;
using AsteroidsGame.Sounds;

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

            LaserPB.BringToFront();

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

        private static extern bool DestroyIcon(IntPtr handle);

        private void AsteroidsForm_MouseMove(object sender, MouseEventArgs e)
        {
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
                Rocket.Move(RocketPB);
            }
            // <----------------------------------<<

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

            // Bomb >>----------------------------->
            if (Bomb.IsExploding)
            {
                DestroyBomb();
            }

            Bomb.Y += 7;
            BombPB.Location = new Point(Bomb.X, Bomb.Y);
            BombPB.Show();

            if (Bomb.Y >= rnd.Next(380, 470) && !Bomb.IsExploding)
            {
                NukeCity = true;
                NukeCloudCounter = 0;
                AnimationTimer.Start();
            }
            // <-----------------------------------<<

            //Gift --------------------------------->
            if (Gift.IsExploding)
            {
                DestroyGift();
            }

            if (isGiftVisible)
            {
                if (Gift.Y >= 700) // Check if Gift is off screen
                {
                    isGiftVisible = false;
                    RedGift.Hide();
                }
                else
                {
                    Gift.Y += 5;
                    RedGift.Location = new Point(Gift.X, Gift.Y);
                }
            }
            else
            {
                isGiftVisible = rnd.Next(0, 50) == 1;

                if (isGiftVisible)
                {
                    SpawnGift();
                }
            }
            // <-----------------------------<<
        }

        private void SpawnGift()
        {
            int[] bombXLocation = // Current Bomb Location X
            {
                Bomb.X - BombPB.Width,
                Bomb.X + BombPB.Width
            };

            Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10); // Gift X location randomizer

            while (Gift.X >= bombXLocation[0] && Gift.X <= bombXLocation[1]) // While current gift X location is inside current bomb X location
            {
                Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            }

            Gift.Y = -30; // Gift Y reset
            RedGift.Location = new Point(Gift.X, Gift.Y);
            RedGift.Show();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (DestroyedImageCounter > 1 && Destroyed)
            {
                ExplodingAsteroid.Hide();
                Destroyed = false;
                DestroyedImageCounter = 0;
            }
            else if (Destroyed)
            {
                DestroyedImageCounter++;
            }

            if (NukeCity && !Destroyed)
            {
                if (NukeCloudCounter == 0)
                {
                    MissCounter();
                    if (missCount == 0)
                    {
                        AsteroidPositionTimer.Stop();
                        StartGame.IsStarted = false;

                        BombPB.Hide();
                        RedGift.Hide();
                        NukeCloud.Hide();
                        ExplodingAsteroid.Hide();
                        RocketPB.Hide();
                        RocketGift.Hide();
                        Lives.Hide();

                        GameOver.Show();

                    }
                    NukeCloud.Location = new Point(Bomb.X, Bomb.Y);
                    NukeCloud.Show();
                    PlaySound.PlayExplodeSound();

                    Bomb.Life = BombLife;
                    SpawnNewBomb();
                }
                else if (NukeCloudCounter > 10)
                {
                    NukeCloud.Hide();
                    AnimationTimer.Stop();
                    NukeCity = false;
                }

                NukeCloudCounter++;
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
                if (StartGame.IsStarted)
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
                    Rocket.Count--;
                    RocketCount(Rocket.Count);
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, BombPB.Left + BombPB.Width / 4);
                }
            }
            else // Laser
            {
                if (StartGame.IsStarted)
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
            if (e.Button == MouseButtons.Right) // Rocket
            {
                if (Rocket.Count > 0 && !Rocket.IsFired && StartGame.IsStarted)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);
                    ScoreCounter();         // label for rocket counting
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, RedGift.Left + RedGift.Width / 4);
                }
            }
            else // Laser
            {
                if (StartGame.IsStarted)
                {
                    PlaySound.PlayMouseSound(e.Button);
                    Laser.LightUp(LaserPB, Gift.X, RedGift, true);
                    DestroyGift();
                }
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
            SpawnNewBomb();
            RocketPB.Hide();
            ScoreCounter();
            AnimationTimer.Start();
            LaserPB.Hide();
        }

        private void SpawnNewBomb()
        {
            Bomb.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            Bomb.Y = -30;
            BombPB.Location = new Point(Bomb.X, Bomb.Y);

            int[] giftXLocation = // Current Bomb Location X
            {
                Bomb.X - RedGift.Width,
                Bomb.X + RedGift.Width
            };

            while (Gift.X >= giftXLocation[0] && Gift.X <= giftXLocation[1])
            {
                Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            }
            NukeCity = false;
            BombPB.Show();
        }

        private void DestroyGift()
        {
            Gift.IsRocketComming = false;
            Rocket.IsFired = false;
            RocketPB.Hide();
            RedGift.Hide();
            score += 4;
            ScoreCounter();
            Rocket.Count++;
            RocketCount(Rocket.Count);
            isGiftVisible = false;
            Gift.IsExploding = false;
            RocketGift.Left = RedGift.Left + RedGift.Width / 2 - RocketGift.Width / 2;
            RocketGift.Top = RedGift.Top + RedGift.Height / 2;
            RocketGift.Show();
            DashboardGiftLabel.Show();
            Gift.ContentShowTyme = GiftContentShowTime;
        }

        private void PauseGame_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
            StartGame.IsStarted = false;
            NukeCloud.Hide();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            StartGame.IsStarted = true;
            AsteroidPositionTimer.Start();
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            AsteroidPositionTimer.Stop();
            StartGame.IsStarted = false;
            Destroyed = false;
            Bomb.IsExploding = false;
            Gift.IsRocketComming = false;
            Rocket.IsFired = false;
            NukeCity = false;
            Bomb.Life = 3;
            Bomb.Y = -30;
            Gift.Y = -30;
            BombPB.Hide();
            RocketPB.Hide();
            LaserPB.Hide();
            RedGift.Hide();
            Rocket.Count = 10;
            RocketCount(Rocket.Count);
            score = -1;
            ScoreCounter();
            Lives.Show();

            GameOver.Hide();
            missCount = 6;
            MissCounter();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            QuitGame.ExitGame();
        }
        
    }
}