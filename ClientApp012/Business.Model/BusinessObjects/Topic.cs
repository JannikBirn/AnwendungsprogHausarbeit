﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

[Serializable]
public class Topic : ObservableCollection<Card>
{
	public int Id { set; get; }
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

	public new void Add(Card card)
    {
		card.Id = NextCardId();
		base.Add(card);
    }

	public int NextCardId()
    {
		return this.Max(param => param.Id) + 1;
	}

}
