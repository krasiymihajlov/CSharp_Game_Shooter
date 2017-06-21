namespace AsteroidsGame.GameOption
{
    using System;

    public class QuitGame
    {
        private const int exit = 0;

        public static void ExitGame()
        {
            Environment.Exit(exit);
        }
    }
}