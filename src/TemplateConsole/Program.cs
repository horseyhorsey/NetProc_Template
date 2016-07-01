using NetProcgame.Display.Sdl;
using NetProcgame.Game;
using NetProcgame.Logging;
using NetProcgame.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                try
                {

                    HorseGame game = new HorseGame(NetProcgame.NetPinproc.MachineType.WPC95, new ConsoleLogger());

                    var attract = new Attract(game, 20);
                    game.Modes.Add(attract);

                    game.run_loop();

                }

                catch (System.Exception ex)
                {
                    if (DisplayManager.SdlWindow != null && DisplayManager.SdlWindow.SDL_Window != IntPtr.Zero)
                        DisplayManager.QuitSdl();

                    Console.WriteLine(ex.Message + "   " + ex.InnerException);
                    Console.WriteLine(ex.StackTrace);

                    Console.ReadLine();

                    Environment.Exit(-1);
                }
            });

            string line = "";
            while (true)
            {
                line = Console.ReadLine();

                if (line == "q")
                    break;
            }
        }
    }
}
