using System;
using System.Collections.ObjectModel;
using System.Linq;

[Serializable]
public class TopicCollection : ObservableCollection<Topic>
{
    public TopicCollection()
    {

    }

    public new void Add(Topic topic)
    {
        topic.Id = this.Max(param => param.Id) + 1;
        base.Add(topic);
    }



    //Override
    //public new bool Add(Topic topic)
    //{
    //    if (topic.Name == null)
    //        return false;

    //    base.Add(topic);

    //    return true;
    //}


}
