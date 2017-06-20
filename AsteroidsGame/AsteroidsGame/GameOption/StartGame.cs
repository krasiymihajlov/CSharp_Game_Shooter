namespace AsteroidsGame.GameOption
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class StartGame
    {
        public static bool IsStarted = false;

        public static bool GameIsStarted()
        {
            if (IsStarted)
            {
                return true;
            }

            return false;
        }
        
        
    }
}
