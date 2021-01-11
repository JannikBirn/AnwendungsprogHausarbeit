using System;

public class CardAnswer : TimeStamp
{
	public bool IsAnswerCorrect { set; get; }

	public CardAnswer()
	{
	}

	public void SetEnd(bool bol)
    {
		IsAnswerCorrect = bol;
		End = DateTime.Now.Ticks;
	}
}
