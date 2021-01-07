using System;
using System.Collections.Generic;

public class Card
{
    public List<CardAnswer> cardAnswers;
    public enum Difficulty {Leicht, Mittel, Schwer};
    public String QuestionText { set; get; }
    public String QuestionVideo { set; get; } //Video reference
    public String QuestionImage { set; get; }
    public String QuestionAudio { set; get; }
    public String AnswerText { set; get; }
    public String AnswerVideo { set; get; }//Video reference
    public String AnswerImage { set; get; }
    public String AnswerAudio { set; get; }


    public Card()
    {
        // do stuff
    }

    public void StartAnswering()
    {
        // for statistic
    }

    public void FinishAnswer(bool bol)
    {

    }
}
