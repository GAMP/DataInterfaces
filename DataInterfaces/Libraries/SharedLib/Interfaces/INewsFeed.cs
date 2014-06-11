using System;

namespace SharedLib
{
    public interface INewsFeed
    {
        int Id { get; set; }
        string Data { get; set; }
        DateTime Date { get; set; }
        DateTime EndDate { get; set; }
        bool IsMedia { get; }
        bool IsSyndicationSource { get; }
        DateTime StartDate { get; set; }
        string Title { get; set; }
        Uri Uri { get; }
        string Url { get; set; }
    }
}
