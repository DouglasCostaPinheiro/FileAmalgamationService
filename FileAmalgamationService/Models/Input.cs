using FileAmalgamationService.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileAmalgamationService.Models
{
    [DataContract]
    public class Input
    {
        [DataMember]
        public InputType Type { get; private set; }

        [DataMember]
        public string Value { get; private set; }

        [DataMember]
        public string SubFolder { get; private set; }

        [DataMember]
        public bool Recursive { get; private set; }

        [DataMember]
        public string Encoding { get; private set; }

        [JsonIgnore]
        public Encoding ParsedEncoding
        {
            get
            {
                if (this.Encoding == null)
                    return null;
                return System.Text.Encoding.GetEncoding(this.Encoding);
            }
        }

        [DataMember]
        public List<Expression> Expressions { get; private set; } = new List<Expression>();

        public Input(InputType inputType, string value, string subFolder = null, bool recursive = false, string encoding = null, IEnumerable<Expression> expressions = null)
        {
            this.Type = inputType;
            this.Value = value;
            this.SubFolder = subFolder;
            this.Encoding = encoding;
            this.Recursive = recursive;

            if (expressions != null)
                foreach (var item in expressions)
                    this.Expressions.Add(item);
        }

        private Input()
        {

        }

        public void AddExpression(Expression expression)
        {
            this.Expressions.Add(expression);
        }
    }
}
