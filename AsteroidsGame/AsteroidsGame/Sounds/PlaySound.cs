using System.Media;
using System.Windows.Forms;

namespace AsteroidsGame.Sounds
{
    public class PlaySound
    {
        /// <summary>
        /// Get path to the sorce files in sonds.
        /// </summary>
        private const string RocketSoundPath = "../../Resources/Rocket.wav";

        private const string LaserSoundPath = "../../Resources/Laser.wav";
        private const string BombSoundPath = "../../Resources/Bomb.wav";

        /// <summary>
        /// Declared new SoundPlayer with sound path
        /// </summary>
        public static SoundPlayer rocketSound = new SoundPlayer(RocketSoundPath);

        public static SoundPlayer laserSound = new SoundPlayer(LaserSoundPath);
        public static SoundPlayer explodeSound = new SoundPlayer(BombSoundPath);

        /// <summary>
        /// Get and set the mouseSound outside of the class.
        /// </summary>
        public static SoundPlayer MouseSound
        {
            get { return rocketSound; }
            set { rocketSound = value; }
        }

        /// <summary>
        /// Get and set the mouseSound outside of the class.
        /// </summary>
        public static SoundPlayer ExplodeSound
        {
            get { return explodeSound; }
            set { explodeSound = value; }
        }

        /// <summary>
        /// Play mouse sound outside of the class
        /// </summary>
        public static void PlayMouseSound(MouseButtons button)
        {
            switch (button)
            {
                case MouseButtons.Left:
                    laserSound.Play();
                    break;

                case MouseButtons.Right:
                    rocketSound.Play();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Play explode sound outside of the class
        /// </summary>
        public static void PlayExplodeSound()
        {
            explodeSound.Play();
        }
    }
}