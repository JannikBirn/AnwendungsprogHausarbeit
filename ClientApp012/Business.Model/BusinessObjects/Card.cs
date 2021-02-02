using System;
using System.Collections.Generic;

[Serializable]
public class Card
{
    public List<CardAnswer> cardAnswers;
    private CardAnswer CurrentCardAnswer { set; get; }
    public enum Difficulty {Leicht, Mittel, Schwer};
    public String QuestionText { set; get; }
    public String QuestionVideo { set; get; } //Video reference
    public String QuestionImage { set; get; }
    public String QuestionAudio { set; get; }
    public String AnswerText { set; get; }
    public String AnswerVideo { set; get; } //Video reference
    public String AnswerImage { set; get; }
    public String AnswerAudio { set; get; }


    public Card()
    {
        cardAnswers = new List<CardAnswer>();
    }

    public void StartAnswering()
    {
        CurrentCardAnswer = new CardAnswer();
        CurrentCardAnswer.SetStart();
    }

    public void FinishAnswer(bool bol)
    {
        CurrentCardAnswer.SetEnd(bol);
        cardAnswers.Add(CurrentCardAnswer);
    }
}
