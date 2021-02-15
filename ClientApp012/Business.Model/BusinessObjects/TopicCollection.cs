using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

[Serializable]
public class TopicCollection : ObservableCollection<Topic>
{
    public TopicCollection()
    {
    }
}
