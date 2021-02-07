using System;
using System.Collections.Generic;

[Serializable]
public class Card
{
    public int Id { get; set; }
    public List<CardAnswer> cardAnswers;
    private CardAnswer CurrentCardAnswer { get; set; }
    public enum Difficulty {Leicht, Mittel, Schwer};
    public String QuestionText { get; set; }
    public String QuestionVideo { get; set; } //Video reference
    public String QuestionImage { get; set; }
    public String QuestionAudio { get; set; }
    public String AnswerText { get; set; }
    public String AnswerVideo { get; set; } //Video reference
    public String AnswerImage { get; set; }
    public String AnswerAudio { get; set; }


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
