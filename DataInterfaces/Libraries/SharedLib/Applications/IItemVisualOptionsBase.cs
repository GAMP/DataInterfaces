using System;
namespace SharedLib.Applications
{
    public interface IItemVisualOptions
    {
        int ID { get; set; }
        bool Accessible { get; set; }
        string Caption { get; set; }
        string Description { get; set; }
        byte[] ImageData { get; set; }
    }
    public interface IHasVisualOptions
    {
        IItemVisualOptions VisualOptions
        {
            get;
        }
    }
}
