namespace DotNetMusicLooper.Library.Models;

public class LoopPoint
{
    public int StartSample { get; set; }

    public int EndSample { get; set; }

    public float NoteDifference { get; set; }

    public float LoudnessDifference { get; set; }

    public float Score { get; set; }
}
