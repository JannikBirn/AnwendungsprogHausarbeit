using System;

public class Card
{
    public CardAnswers[] cardAnswers;
    public enum Difficulty {Leicht, Schwer};
    public string QuestionText;
    public video questionVideo;
    public System.IO.Stream questionAudio;
    public string AnswerText;
    public video answerVideo;
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
