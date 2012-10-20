using System;

namespace OgmoXNADemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (OgmoXNADemoGame game = new OgmoXNADemoGame())
            {
                game.Run();
            }
        }
    }
}

