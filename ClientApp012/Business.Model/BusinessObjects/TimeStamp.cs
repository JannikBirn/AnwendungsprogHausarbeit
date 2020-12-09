using System;

public class TimeStamp
{
    public long start { set; get; }
    public long end { set; get; }


    public TimeStamp()
    {

    }

    public void setStart()
    {
        //TODO set start time
    }

    public void setEnd()
    {
        //TODO set end time
    }

    public long getSpan()
    {
        return end - start;
    }
}
