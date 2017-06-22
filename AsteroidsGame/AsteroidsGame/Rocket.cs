namespace AsteroidsGame
{
    using System.Windows.Forms;
    using AsteroidsGame.Sounds;

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

        /// <summary>
        /// If rocket is fired set move speed and check if she hit or miss the target
        /// </summary>
        internal static void Move(PictureBox rocketPB)
        {
            rocketPB.Top -= 55;

            if (IsOnScreen(rocketPB))
            {
                bool isInBomb;
                bool isInGift;

                if (IsInTarget(rocketPB, out isInGift, out isInBomb))
                {
                    if (isInGift)
                    {
                        Gift.IsExploding = true;
                    }
                    else if (isInBomb)
                    {
                        Bomb.IsExploding = true;
                    }

                    PlaySound.PlayExplodeSound();
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

        private static bool IsInTarget(PictureBox rocketPB, out bool isInGift, out bool isInBomb)
        {
            var rocketCenterX = rocketPB.Right - rocketPB.Width / 2;

            isInBomb = rocketPB.Top <= Bomb.Y &&
                            rocketCenterX >= Bomb.X &&
                            rocketCenterX <= Bomb.X + 60;

            isInGift = rocketPB.Top <= Gift.Y &&
                            rocketCenterX >= Gift.X &&
                            rocketCenterX <= Gift.X + 60;

            return isInGift || isInBomb;
        }
    }
}