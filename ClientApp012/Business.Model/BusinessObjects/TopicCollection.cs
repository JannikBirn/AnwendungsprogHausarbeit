using System;
using System.Collections.ObjectModel;

public class TopicCollection : ObservableCollection<Topic>
{
	public TopicCollection()
	{
		// get list
	}



	//Override
	public new bool Add(Topic topic)
	{
		//Check if topic has a String
		//returns boolean
		return true;
	}


}
