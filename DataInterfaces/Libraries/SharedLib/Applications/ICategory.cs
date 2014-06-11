using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Applications
{
    public interface ICategory
    {
        int ID { get; set; }
        Guid Guid { get; set; }
        string Name { get; set; }
        int ParentID { get; set; }
    }
}
