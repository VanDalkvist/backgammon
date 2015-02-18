using System;

namespace BackgammonGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BackgammonGame game = new BackgammonGame())
            {
                game.Run();
            }
        }
    }
#endif
}

