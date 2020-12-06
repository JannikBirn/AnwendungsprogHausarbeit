using System;

public class Card
{
    public CardAnswer[] cardAnswers;
    public enum Difficulty {Leicht, Schwer};
    public string QuestionText;
    public string questionVideo; //Video refrence
    public string questionImage;
    public System.IO.Stream questionAudio;
    public string AnswerText;
    public string answerVideo; //Video refrence
    public string answerImage;
    public System.IO.Stream answerAudio;


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
