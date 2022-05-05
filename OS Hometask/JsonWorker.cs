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


    class JsonWorker
    {
        public void setDataInJson(VkNews[] news, string fileName)
        {
            DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(VkNews[]));
            using (FileStream fileStream = new FileStream(fileName+".json", FileMode.Create))
            {
                dataContractJsonSerializer.WriteObject(fileStream, news);
            }
        }

    }
}
