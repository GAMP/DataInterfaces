using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Applications
{
    public interface IApplicationProfile
    {
        int ID { get; set; }
        string PublisherName { get; }
        string DeveloperName { get; }
        string Title { get; }
        int AgeRating { get; }
    }
}
