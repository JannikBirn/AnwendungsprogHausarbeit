using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

[Serializable]
public class Topic : ObservableCollection<Card>
{
	public long Id { set; get; }
	public String Name { set; get; }
	public String Img { set; get; }


	public Topic()
	{
		Id = DateTime.Now.Ticks;
	}

	public Topic(long id)
	{
		Id = id;
	}

	public List<Card> StartQuestioning()
    {
		//generating a list of cards, with their difficulty in mind
		//TODO Sort
		List<Card> cards = new List<Card>(this);
		cards = cards.OrderBy(i => Guid.NewGuid()).ToList();        //schuffle Cards
		return cards;
    }
}
