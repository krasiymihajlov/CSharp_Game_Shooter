using System;
using System.Windows.Forms;

namespace AsteroidsGame
{
    internal static class GiftShow
    {
        public static bool IsFired { get; set; }

        public static int Count { get; set; }


        internal static void Move(PictureBox RedGift, PictureBox rocketPB)
        {
            rocketPB.Top -= 55; // Speed of movement

            if (IsOnScreen(rocketPB))
            {
                if (IsInTarget(rocketPB, RedGift))
                {
                    Gift.IsExploding = true;
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
        private static bool IsInTarget(PictureBox rocketPB, PictureBox redGift)
        {
            var rocketCenterX = rocketPB.Right - rocketPB.Width / 2;

            return rocketPB.Top <= redGift.Bottom &&
                   rocketCenterX >= redGift.Left &&
                   rocketCenterX <= redGift.Right + 10;
        }
    }
}