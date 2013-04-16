using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace CoreLib
{
    public interface IFeed
    {
        void Refresh();
        ObservableCollection<IFeedChannel> Channels
        {
            get;
        }

    }
    public interface IFeedChannel
    {
 
    }
}
