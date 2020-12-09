using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Topic : ObservableCollection<Card>
{
	public String name { set; get; }
	public String img { set; get; }

	public TopicStatistics topicStatistics { set; get; }

	public Topic()
	{

	}

	public List<Card> startQuestioning()
    {
		//generating a list of cards, with theire difficulty in mind
        return null;
    }

	public void finishQuestioning()
    {
		//End the questioning, genearte end timestap
    }

	public void updateDifficulties()
    {
		//updating the difficulties of the cards of this collection
    }


	//Override
	public new void Add(Card card)
    {

    }

}
