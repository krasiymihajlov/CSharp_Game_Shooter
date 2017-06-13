using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AsteroidsGame.Properties;

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        private Random rnd = new Random();
        private SoundPlayer GunSound = new SoundPlayer(Resources.gun_sound);
        private SoundPlayer NukeCitySound = new SoundPlayer(Resources.bomb);
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

                    NukeCitySound.Play();

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
            GunSound.Play();
            // Rocket.BlankShot();
        }

        // Shot Inside the target
        private void Asteroid_MouseClick(object sender, MouseEventArgs e)
        {
            AsteroidPositionTimer.Stop();

            // Rocket.DestroyTarget(e.X, e.Y);

            Asteroid.Hide();
            ExplodingAsteroid.Left = Asteroid.Left - 10;
            ExplodingAsteroid.Top = Asteroid.Top - 20;
            ExplodingAsteroid.Show();
            GunSound.Play();
            Destroyed = true;

            AsteroidPositionTimer.Start();
        }
    }
}