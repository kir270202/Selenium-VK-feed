using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace OS_Hometask
{
    [DataContract]
    class VkNews
    {
        [DataMember]
        public string Text;
        [DataMember]
        public string Id;
        [DataMember]
        public DateTime PublicationTime;
    }
}
