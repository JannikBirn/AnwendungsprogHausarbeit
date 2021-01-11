using System;
using System.Collections.Generic;

[Serializable]
public class TopicStatistics : List<TimeStamp>
{
	private TimeStamp CurrentTimeStamp { set; get; }

	public TopicStatistics()
	{

	}

    public void SetStart()
    {
        CurrentTimeStamp = new TimeStamp();
        CurrentTimeStamp.SetStart();
    }

    public void SetEnd()
    {
        CurrentTimeStamp.SetEnd();
        this.Add(CurrentTimeStamp);
    }

    //Methods for starting and ending the last(index) TimeStamp
}
