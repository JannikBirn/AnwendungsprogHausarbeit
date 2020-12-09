using System;
using System.Collections.Generic;

public class Card
{
    public List<CardAnswer> cardAnswers;
    public enum Difficulty {Leicht, Mittel, Schwer};
    public string QuestionText { set; get; }
    public string questionVideo { set; get; } //Video refrence
public string questionImage { set; get; }
    public System.IO.Stream questionAudio { set; get; }
    public string AnswerText { set; get; }
    public string answerVideo { set; get; }//Video refrence
    public string answerImage { set; get; }
    public System.IO.Stream answerAudio { set; get; }


    public Card()
    {

    }

    public void startAnswering()
    {

    }

    public void finishAnswer(bool bol)
    {

    }
}
