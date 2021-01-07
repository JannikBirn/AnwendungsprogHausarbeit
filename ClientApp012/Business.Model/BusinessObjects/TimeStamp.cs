using System;

public class TimeStamp
{
    public long Start { set; get; }
    public long End { set; get; }


    public TimeStamp()
    {

    }

    public void SetStart()
    {
        //TODO set start time
    }

    public void SetEnd()
    {
        //TODO set end time
    }

    public long GetSpan()
    {
        return End - Start;
    }
}
