using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class Topic : ObservableCollection<Card>
{
	public String Name { set; get; }
	public String Img { set; get; }

	public TopicStatistics TopicStatistics { set; get; }

	public Topic()
	{

	}

	public List<Card> StartQuestioning()
    {
		TopicStatistics.SetStart();
		//generating a list of cards, with their difficulty in mind
		//TODO Sort
		List<Card> cards = new List<Card>(this);

		return cards;
    }

	public void FinishQuestioning()
    {
		TopicStatistics.SetEnd();
		//End the questioning, genearte end timestap
    }

	public void UpdateDifficulties()
    {
		//updating the difficulties of the cards of this collection
    }


	//Override
	public new void Add(Card card)
    {
        if (card.QuestionText == null || card.AnswerText == null)
        {
			throw new EntryPointNotFoundException();
        }

        base.Add(card);

    }

}
