using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
		//generating a list of cards, with their difficulty in mind
        return null;
    }

	public void FinishQuestioning()
    {
		//End the questioning, genearte end timestap
    }

	public void UpdateDifficulties()
    {
		//updating the difficulties of the cards of this collection
    }


	//Override
	public new void Add(Card card)
    {

    }

}
