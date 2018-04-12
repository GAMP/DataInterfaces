using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class ModuleInfo
    {
        [DataMember()]
        public string FullPath
        {
            get; set;
        }

        [DataMember()]
        public Version Version
        {
            get; set;
        }
    }
}
