using System;

namespace BallGame2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MasterController controller = new MasterController())
            {
                controller.Run();
            }
        }
    }
#endif
}

