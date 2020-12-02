using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Topic : ObservableCollection<Card>
{
	public String name;
	// public Image img;
	public TopicStatistics topicStatistics;

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

}
