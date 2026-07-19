using Avalonia;
using System;

namespace GovAdmin.UI;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Console.WriteLine("Debug: Main started");
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace();
}
