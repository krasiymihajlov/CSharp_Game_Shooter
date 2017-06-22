namespace AsteroidsGame.GameOption
{
    using System;

    public class QuitGame
    {
        private const int Exit = 0;

        public static void ExitGame()
        {
            Environment.Exit(Exit);
        }
    }
}