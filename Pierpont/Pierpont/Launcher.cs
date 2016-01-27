using System;
using Microsoft.Owin.Hosting;

namespace Pierpont
{
    internal class Launcher
    {
        internal static void Main()
        {
            var baseAddress = $"http://localhost:80/";
            Console.WriteLine($"Pierpont is starting up on {baseAddress}");
            var server = WebApp.Start<Startup>(baseAddress);
            Console.WriteLine($"Seshat has started on {baseAddress}{Environment.NewLine}Press enter to exit.");
            Console.ReadLine();
            server.Dispose();
        }
    }
}
