using System;
using System.Collections.ObjectModel;

[Serializable]
public class TopicCollection : ObservableCollection<Topic>
{
    public TopicCollection()
    {

    }



    //Override
    public new bool Add(Topic topic)
    {
        if (topic.Name == null)
            return false;

        base.Add(topic);

        return true;
    }


}
