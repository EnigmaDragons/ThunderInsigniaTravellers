﻿using System;
using ThunderInsigniaTravellers.Engine;

namespace ThunderInsigniaTravellers
{
#if WINDOWS || LINUX
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame())
                game.Run();
        }
    }
#endif
}
