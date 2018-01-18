using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileAmalgamationService.Models
{
    [DataContract]
    public class Output
    {
        [DataMember]
        public string FileName { get; private set; }

        [DataMember]
        public string Encoding { get; private set; }

        [JsonIgnore]
        public Encoding ParsedEncoding
        {
            get
            {
                if (this.Encoding == null)
                    return System.Text.Encoding.UTF8;
                return System.Text.Encoding.GetEncoding(this.Encoding);
            }
        }

        public Output(string fileName, string encoding = null)
        {
            this.FileName = fileName;
            this.Encoding = encoding;
        }

        private Output()
        {

        }
    }
}
