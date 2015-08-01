using System;

namespace TapTitanXNA_JonryBorbe
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TapTitan game = new TapTitan())
            {
                game.Run();
            }
        }
    }
#endif
}

