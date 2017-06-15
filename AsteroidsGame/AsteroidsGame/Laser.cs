using System;
using System.Windows.Forms;

namespace AsteroidsGame
{
    public static class Laser
    {
        public const byte TimeToShow = 5;

        public static byte TimeCounter { get; set; }

        internal static void LightUp(PictureBox laserPB, int x, PictureBox bombPB, bool isInTarget)
        {
            if (isInTarget)
            {
                laserPB.Left = bombPB.Left + bombPB.Width / 2;
                laserPB.Top = bombPB.Bottom;
            }
            else
            {
                laserPB.Left = x;
                laserPB.Top = -10;
            }

            TimeCounter = TimeToShow;
            laserPB.Show();
        }
    }
}
