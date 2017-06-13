using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AsteroidsGame.Sounds;

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        Random rdn = new Random();
        private static int score = 0;
        private static int missingShots = 0;
        private static int totalShots = 0;

        public AsteroidsForm()
        {
            InitializeComponent();
            
            ExplodingAsteroid.Hide();
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
            PictureBox gunSight = new PictureBox() { Image = Image.FromFile(@"..\..\Resources\Gunsight.png") };
            this.Cursor = new Cursor(((Bitmap)gunSight.Image).GetHicon());
        }

        private void AsteroidPositionTimer_Tick(object sender, EventArgs e)
        {
            var x = rdn.Next(Asteroid.Width, this.Width - Asteroid.Width);
            var y = rdn.Next(Asteroid.Height, 340);
            Asteroid.Location = new Point(x, y);

            Asteroid.Show();
            ExplodingAsteroid.Hide();
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
            AsteroidPositionTimer.Stop();
            PlaySound.PlayMouseSound();

            // Rocket.DestroyTarget(e.X, e.Y);

            Asteroid.Hide();
            ExplodingAsteroid.Left = Asteroid.Left - 35;
            ExplodingAsteroid.Top = Asteroid.Top - 40;
            ExplodingAsteroid.Show();
            PlaySound.PlayExplodeSound();

            AsteroidPositionTimer.Start();
        }

        //private void Asteroid_Click(object sender, EventArgs e)
        //{
        //}
    }
}
