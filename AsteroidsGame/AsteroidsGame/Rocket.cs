using System;
using System.Windows.Forms;

namespace AsteroidsGame
{
    internal static class Rocket
    {
        public static bool IsFired { get; set; }

        public static int Count { get; set; }

        internal static void Fire(PictureBox rocketPB, int formHeight, int x)
        {
            rocketPB.Top = formHeight + rocketPB.Height;
            rocketPB.Left = x;
            rocketPB.Show();
            IsFired = true;
        }

        internal static void Move(PictureBox rocketPB, PictureBox bomb)
        {
            rocketPB.Top -= 55; // Speed of movement

            if (IsOnScreen(rocketPB))
            {
                if (IsInTarget(rocketPB, bomb))
                {
                    Bomb.IsExploding = true;
                }
            }
        }

        private static bool IsOnScreen(PictureBox rocketPB)
        {
            if (rocketPB.Bottom <= 0 - rocketPB.Height)
            {
                IsFired = false;
            }

            return IsFired;
        }

        private static bool IsInTarget(PictureBox rocketPB, PictureBox bombPB)
        {
            var rocketCenterX = rocketPB.Right - rocketPB.Width / 2;

            return rocketPB.Top <= bombPB.Bottom &&
                rocketCenterX >= bombPB.Left &&
                rocketCenterX <= bombPB.Right + 10;
        }
    }
}