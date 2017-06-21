namespace AsteroidsGame.GameOption
{
    internal class StartGame
    {
        public static bool IsStarted = false;

        public static bool GameIsStarted()
        {
            return IsStarted;
        }
    }
}