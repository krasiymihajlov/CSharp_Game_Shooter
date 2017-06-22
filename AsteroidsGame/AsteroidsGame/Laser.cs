namespace AsteroidsGame
{
    using System.Windows.Forms;

    public static class Laser 
    {
        public const byte TimeToShow = 5;

        public static byte TimeCounter { get; set; }

        internal static void LightUp(PictureBox laserPB, int x, PictureBox targetPB, bool isInTarget)
        {
            if (isInTarget)
            {
                laserPB.Left = targetPB.Left + targetPB.Width / 2;
                laserPB.Top = targetPB.Bottom;
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