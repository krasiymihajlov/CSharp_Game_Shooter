namespace AsteroidsGame
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using AsteroidsGame.GameOption;
    using AsteroidsGame.Properties;
    using AsteroidsGame.Sounds;

    public partial class AsteroidsForm : Form
    {
        private const int BombLife = 3;
        private const int GiftContentShowTime = 10;

        private Random rnd = new Random();
        private static int score = 0;
        private static int destroyedImageCounter = 0;
        private static bool destroyed = false;
        private static int nukeCloudCounter = 0;
        private static bool nukeCity = false;
        private static bool isGiftVisible = false;
        private static int missCount = 5;

        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = CharSet.Auto)]

        private static extern bool DestroyIcon(IntPtr handle);

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

        /// <summary>
        /// Calculates the points and draws score label it on the screen
        /// </summary>
        private void ScoreCounter()
        {
            score++;
            ScoreCount.Text = "Score: " + score;
        }

        /// <summary>
        /// Calculates the missing asteroid and draws lives label on the screen
        /// </summary>
        private void MissCounter()
        {
            missCount--;
            Lives.Text = "Lives: " + missCount;
        }

        /// <summary>
        /// Calculates the rocket and draws roceket label on the screen
        /// </summary>
        public void RocketCount(int count)
        {
            Rockets.Text = "Rockets: " + count;
        }

        /// <summary>
        /// Draw sight on the screen
        /// Convert the cursor to Gunsight
        /// The resulting icon for the cursor should be disposed so that the resources are released
        /// </summary>
        private void AsteroidsForm_MouseMove(object sender, MouseEventArgs e)
        {      
            PictureBox gunSight = new PictureBox() { Image = Resources.Sight };
            var tempIcon = (Bitmap)gunSight.Image;
       
            IntPtr hicon = tempIcon.GetHicon();
            Icon bitmapIcon = Icon.FromHandle(hicon);
            this.Cursor = new Cursor(hicon);

            DestroyIcon(bitmapIcon.Handle);
        }

        /// <summary>
        /// The logic implement movement of gifts and asteroids and calculating using a timer
        /// </summary>
        private void AsteroidPositionTimer_Tick(object sender, EventArgs e)
        {
            /// <summary>
            /// Stop timer, when the game is not start with start buton
            /// </summary>            
            if (!StartGame.GameIsStarted())
            {
                AsteroidPositionTimer.Stop();
            }

            /// <summary>
            /// If an asteroid and a gift appear at the same place, new coordinates are calculated
            /// </summary>  
            if (Gift.ContentShowTyme > 0)
            {
                Gift.ContentShowTyme--;

                if (Gift.ContentShowTyme == 0)
                {
                    RocketGift.Hide();
                    DashboardGiftLabel.Hide();
                }
            }

            /// <summary>
            /// Look Rocket.cs class
            /// </summary>
            if (Rocket.IsFired)
            {
                Rocket.Move(RocketPB);
            }

            /// <summary>
            /// Chek count laser hits on asteroid and when asteroid is dead, hide Laser from the screen.
            /// </summary>
            if (Laser.TimeCounter > 0)
            {
                Laser.TimeCounter--;
            }
            else
            {
                LaserPB.Hide();
            }

            /// <summary>
            /// If asteroid is hiting by laser or rocket, we destroying him.
            /// </summary>
            if (Bomb.IsExploding)
            {
                DestroyBomb();
            }

            /// <summary>
            /// Set new coordinates on asteroid and show bomb.
            /// </summary>
            Bomb.Y += 7;
            BombPB.Location = new Point(Bomb.X, Bomb.Y);
            BombPB.Show();

            /// <summary>
            /// Chek coordinates and explode asteroid random on screen.
            /// </summary>
            if (Bomb.Y >= rnd.Next(380, 470) && !Bomb.IsExploding)
            {
                nukeCity = true;
                nukeCloudCounter = 0;
                AnimationTimer.Start();
            }

            /// <summary>
            /// If gift is hiting by laser or rocket, we destroying him.
            /// </summary>
            if (Gift.IsExploding)
            {
                DestroyGift();
            }

            /// <summary>
            /// Logic encompasses the movement and the disappearance of the gift when it's not hiting.
            /// </summary>
            if (isGiftVisible)
            {
                if (Gift.Y >= 700)
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
        }

        /// <summary>
        /// The logic implement movement of destroing asteroids and calculating using a timer
        /// This method chek if lives == 0 -> Game Over
        /// </summary>
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (destroyedImageCounter > 1 && destroyed)
            {
                ExplodingAsteroid.Hide();
                destroyed = false;
                destroyedImageCounter = 0;
            }
            else if (destroyed)
            {
                destroyedImageCounter++;
            }

            if (nukeCity && !destroyed)
            {
                if (nukeCloudCounter == 0)
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

                    nukeCity = true;
                    NukeCloud.Location = new Point(Bomb.X, Bomb.Y);
                    NukeCloud.Show();
                    PlaySound.PlayExplodeSound();

                    Bomb.Life = BombLife;
                    SpawnNewBomb();
                }
                else if (nukeCloudCounter > 10)
                {
                    NukeCloud.Hide();
                    AnimationTimer.Stop();
                    nukeCity = false;
                }

                nukeCloudCounter++;
            }
        }

        /// <summary>
        /// We enter this method when we click Somewhere on the screen
        /// Check rigth or left button on the mouse is click and make some logic
        /// </summary>
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
            else 
            {
                if (StartGame.IsStarted)
                {
                    PlaySound.PlayMouseSound(e.Button);
                    Laser.LightUp(LaserPB, e.X, BombPB, false);
                }
            }
        }

        /// <summary>
        /// We enter this method when we click on the asteroid icon
        /// Check rigth or left button on the mouse is click and make some logic
        /// </summary>
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
            else 
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

        /// <summary>
        /// We enter this method when we click on the gift icon
        /// Check rigth or left button on the mouse is click and make some logic
        /// </summary>
        private void RedGift_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (Rocket.Count > 0 && !Rocket.IsFired && StartGame.IsStarted)
                {
                    int count = Rocket.Count--;
                    RocketCount(count - 1);
                    ScoreCounter();     
                    PlaySound.PlayMouseSound(e.Button);
                    Rocket.Fire(RocketPB, Height, RedGift.Left + RedGift.Width / 4);
                }
            }
            else 
            {
                if (StartGame.IsStarted)
                {
                    PlaySound.PlayMouseSound(e.Button);
                    Laser.LightUp(LaserPB, Gift.X, RedGift, true);
                    DestroyGift();
                }
            }
        }

        /// <summary>
        /// Logic implement spawn a Gift.
        /// We get current Bomb location x and if coordinates match with the gift, give it new random location x
        /// Chek while gift is spawn on other coordinates.
        /// And get new coordinates for Y 
        /// </summary>
        private void SpawnGift()
        {
            int[] bombXLocation =
            {
                Bomb.X - BombPB.Width,
                Bomb.X + BombPB.Width
            };

            Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10); 

            while (Gift.X >= bombXLocation[0] && Gift.X <= bombXLocation[1])
            {
                Gift.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            }

            Gift.Y = -30; 
            RedGift.Location = new Point(Gift.X, Gift.Y);
            RedGift.Show();
        }

        /// <summary>
        /// Logic implement spawn a Asteroid.
        /// We get current Gift location X and if coordinates match with the asteroid, give it new random location x
        /// Chek while asteroid is spawn on other coordinates.
        /// And get new coordinates for Y 
        /// </summary>
        private void SpawnNewBomb()
        {
            Bomb.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            Bomb.Y = -30;
            BombPB.Location = new Point(Bomb.X, Bomb.Y);

            int[] giftXLocation = 
            {
                Gift.X - RedGift.Width,
                Gift.X + RedGift.Width
            };

            while (Bomb.X >= giftXLocation[0] && Bomb.X <= giftXLocation[1])
            {
                Bomb.X = rnd.Next(BombPB.Width + 10, this.Width - BombPB.Width - 10);
            }

            BombPB.Show();
        }

        /// <summary>
        /// Logic implement Destroying a Bomb
        /// Hide unnecessary pictures
        /// Show destroing animation, reset the constants and spawn new bomb.
        /// </summary>
        private void DestroyBomb()
        {
            PlaySound.PlayExplodeSound();
            BombPB.Hide();
            RocketPB.Hide();
            LaserPB.Hide();

            ExplodingAsteroid.Left = BombPB.Left - 10;
            ExplodingAsteroid.Top = BombPB.Top - 20;
            ExplodingAsteroid.Show();

            destroyed = true;
            nukeCity = false;
            Bomb.IsExploding = false;
            Rocket.IsFired = false;
            Bomb.Life = 3;

            SpawnNewBomb();            
            ScoreCounter();
            AnimationTimer.Start();
        }

        /// <summary>
        /// Logic implement Destroying a Gift
        /// Hide unnecessary pictures
        /// Show destroing animation, reset the constants and аdding rockets.
        /// </summary>
        private void DestroyGift()
        {
            
            RocketPB.Hide();
            RedGift.Hide();

            score += 4;
            ScoreCounter();
            Rocket.Count++;
            RocketCount(Rocket.Count);

            Gift.IsRocketComming = false;
            Rocket.IsFired = false;
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
            destroyed = false;
            Bomb.IsExploding = false;
            Gift.IsRocketComming = false;
            Rocket.IsFired = false;
            nukeCity = false;

            Bomb.Life = 3;
            Bomb.Y = -30;
            Gift.Y = -30;

            BombPB.Hide();
            RocketPB.Hide();
            LaserPB.Hide();
            RedGift.Hide();
            GameOver.Hide();
            DashboardGiftLabel.Hide();

            Rocket.Count = 10;
            score = -1;
            missCount = 6;

            RocketCount(Rocket.Count);
            ScoreCounter();
            MissCounter();
            Lives.Show();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            QuitGame.ExitGame();
        }
    }
}