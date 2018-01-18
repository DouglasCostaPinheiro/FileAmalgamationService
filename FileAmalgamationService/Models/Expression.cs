using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace FileAmalgamationService.Models
{
    [DataContract]
    public class Expression
    {
        [DataMember]
        /// <summary>
        /// Regex to look for in expression
        /// </summary>
        public string Regex { get; private set; }

        [JsonIgnore]
        public Regex ParsedRegex
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.Regex))
                    return null;

                return new Regex(this.Regex, RegexOptions.CultureInvariant);
            }
        }

        [DataMember]
        /// <summary>
        /// Replacement to the match, under a string formats {0}
        /// </summary>
        public string Replacement { get; private set; }

        public Expression(string regex, string replacement)
        {
            this.Regex = regex;
            this.Replacement = replacement;
        }

        public string Apply(string text)
        {
            return this.ParsedRegex.Replace(text, delegate (Match m) { return string.Format(this.Replacement, m.Value); });
        }

        private Expression()
        {

        }
    }
}
