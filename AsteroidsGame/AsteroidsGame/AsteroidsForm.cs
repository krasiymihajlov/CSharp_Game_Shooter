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

namespace AsteroidsGame
{
    public partial class AsteroidsForm : Form
    {
        Random rdn = new Random();
        SoundPlayer mouseSound;

        public AsteroidsForm()
        {
            InitializeComponent();

            mouseSound = new SoundPlayer("../../Resources/Rocket.wav");
            ExplodingAsteroid.Hide();
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
            mouseSound.Play();
            // Rocket.BlankShot();
        }

        // Shot Inside the target
        private void Asteroid_MouseClick(object sender, MouseEventArgs e)
        {
            AsteroidPositionTimer.Stop(); 

            mouseSound.Play();
            // Rocket.DestroyTarget(e.X, e.Y);

            Asteroid.Hide();

            ExplodingAsteroid.Left = Asteroid.Left;
            ExplodingAsteroid.Top = Asteroid.Top;
            ExplodingAsteroid.Show();

            AsteroidPositionTimer.Start();
        }
    }
}
