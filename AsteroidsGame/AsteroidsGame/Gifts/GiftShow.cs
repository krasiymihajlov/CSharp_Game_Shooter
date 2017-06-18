using System;
using System.Windows.Forms;

namespace AsteroidsGame
{
    internal static class GiftShow
    {
        public static bool IsFired { get; set; }

        public static int Count { get; set; }

        internal static void Fire(PictureBox RedGift, int formWidth, int Y)
        {
            RedGift.Top = Y;
            RedGift.Left = formWidth + RedGift.Width;
            RedGift.Show();
            IsFired = true;
        }

        internal static void Move(PictureBox RedGift, PictureBox bomb)
        {
            RedGift.Left += 15; // Speed of movement

            if (IsOnScreen(RedGift))
            {
                if (IsInTarget(RedGift, bomb))
                {
                    Bomb.IsExploding = true;
                }
            }
        }

        private static bool IsOnScreen(PictureBox RedGift)
        {
            if (RedGift.Left <= 0 - RedGift.Width)
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