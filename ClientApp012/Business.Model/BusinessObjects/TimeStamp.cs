using System;

[Serializable]
public class TimeStamp
{
    public long Start { set; get; }
    public long End { set; get; }


    public TimeStamp()
    {

    }

    public void SetStart()
    {
        Start = DateTime.Now.Ticks;
    }

    public void SetEnd()
    {
        End = DateTime.Now.Ticks;
    }

    public long GetSpan()
    {
        return End - Start;
    }
}
