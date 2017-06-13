using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;
using AsteroidsGame.Sounds;
using System.Windows.Forms.VisualStyles;
using AsteroidsGame.Properties;

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        private Random rnd = new Random();
        private int totalShots = 0;
        private static int score = 0;
        private static int missingShots = 0;
        private int X = 200;
        private int Y = -30;
        private int DestroyedImageCounter = 0;
        private bool Destroyed = false;
        private int NukeCloudCounter = 0;
        private bool NukeCity = false;

        public AsteroidsForm()
        {
            InitializeComponent();

            ExplodingAsteroid.Hide();
            NukeCloud.Hide();
        }

        private void ShotFunction()
        {
            
            score++;
            label3.Text = "Score = " + score;
            totalShots++;
            label1.Text = "Total Shots = " + totalShots;
        }

        public void MissShot()
        {
            missingShots++;
            label2.Text = "Missing Shots = " + missingShots;
            totalShots++;
            label1.Text = "Total Shots = " + totalShots;

            if (missingShots >= 20)
            {
                label2.Hide();
                label1.Hide();
                label3.Hide();

            }
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

            Y += 7;
            Asteroid.Location = new Point(X, Y);

            //Asteroid.Show();

            if (DestroyedImageCounter >= 10 && Destroyed)
            {
                ExplodingAsteroid.Hide();
                DestroyedImageCounter = 0;

                X = rnd.Next(Asteroid.Width + 10, this.Width - Asteroid.Width - 10);
                Y = -30;
                Destroyed = false;
                Asteroid.Location = new Point(X, Y);
                Asteroid.Show();
            }
            else if (Destroyed)
            {
                DestroyedImageCounter++;
            }
            else if (Y >= rnd.Next(500, 600) || NukeCity)
            {
                if (NukeCloudCounter == 0)
                {
                    NukeCity = true;
                    NukeCloud.Location = new Point(X, Y);
                    NukeCloud.Show();

                    PlaySound.PlayExplodeSound(); 

                    // New Asteroid Spawn Location
                    X = rnd.Next(Asteroid.Width + 10, this.Width - Asteroid.Width - 10);
                    Y = -30;

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
        }

        // Shot Outside the target
        private void AsteroidsForm_MouseClick(object sender, MouseEventArgs e)
        {
            PlaySound.PlayMouseSound();

            // Rocket.BlankShot();
            MissShot();
        }

        // Shot Inside the target
        private void Asteroid_MouseClick(object sender, MouseEventArgs e)
        {
            ShotFunction();
            PlaySound.PlayMouseSound();

            // Rocket.DestroyTarget(e.X, e.Y);

            Asteroid.Hide();
            ExplodingAsteroid.Left = Asteroid.Left - 10;
            ExplodingAsteroid.Top = Asteroid.Top - 20;
            ExplodingAsteroid.Show();
            PlaySound.PlayExplodeSound();
            Destroyed = true;

            AsteroidPositionTimer.Start();
        }

        //private void Asteroid_Click(object sender, EventArgs e)
        //{
        //}
    }
}