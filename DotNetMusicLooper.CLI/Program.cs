using DotNetMusicLooper.Library;

namespace DotNetMusicLooper.CLI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var inputFile = "audio.wav";

        var analyzer = new Analysis();
        analyzer.AnalyzeAudio(inputFile);
    }
}
