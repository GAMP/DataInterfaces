using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace SharedLib.Media
{   
    public interface IMediaPlayList
    {
        ObservableCollection<IMediaSource> Media
        {
            get;
            set;
        }
    }

    public interface IMediaLibrary
    {

    }

    public interface IMediaHandler
    {
        Visual GetVisualInstance();
    }

    public interface IMediaSource
    {
        /// <summary>
        /// Gets medias universal resource identifier.
        /// </summary>
        Uri Url { get; }
    }
}
