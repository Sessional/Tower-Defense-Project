using System;

namespace TowerDefenseGame
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TowerDefenseGame game = new TowerDefenseGame())
            {
                game.Run();
            }
        }
    }
#endif
}

