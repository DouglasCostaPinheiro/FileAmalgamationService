using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

namespace FileAmalgamationService.Models
{
    [DataContract]
    public class Profile
    {
        [DataMember]
        /// <summary>
        /// Full path of the monitored folder
        /// </summary>
        public string Root { get; private set; }

        [DataMember]
        public List<Input> Inputs { get; private set; } = new List<Input>();

        [DataMember]
        public List<Output> Outputs { get; private set; } = new List<Output>();

        [DataMember]
        public string Separator { get; private set; }

        public Profile(string root, string separator, IEnumerable<Input> inputs = null, IEnumerable<Output> outputs = null)
        {
            this.Root = root;
            this.Separator = separator;

            if (inputs != null)
                foreach (var item in inputs)
                    this.Inputs.Add(item);

            if (outputs != null)
                foreach (var item in outputs)
                    this.Outputs.Add(item);
        }

        private Profile()
        {

        }

        public void AddInput(Input input)
        {
            this.Inputs.Add(input);
        }

        public void AddOutput(Output output)
        {
            this.Outputs.Add(output);
        }

        public void Process()
        {
            var builder = new List<string>();

            foreach (var inp in this.Inputs)
            {
                DirectoryInfo dir = null;
                string v = string.Empty;

                switch (inp.Type)
                {
                    case Enums.InputType.Text:
                        v = inp.Value;
                        break;
                    case Enums.InputType.FileSearchExpressionFilter:
                        dir = new DirectoryInfo(Path.Combine(this.Root, inp.SubFolder ?? ""));
                        v = string.Join(this.Separator,dir.GetFiles(inp.Value).Select(file => File.ReadAllText(file.FullName, inp.ParsedEncoding)));
                        break;
                    case Enums.InputType.FileSearchExpressionRegex:
                        dir = new DirectoryInfo(Path.Combine(this.Root, inp.SubFolder ?? ""));
                        v = string.Join(this.Separator, dir.GetFiles().Where(file => new Regex(inp.Value, RegexOptions.CultureInvariant).IsMatch(file.Name)).Select(file => File.ReadAllText(file.FullName, inp.ParsedEncoding)));
                        break;
                }

                foreach (var expr in inp.Expressions)
                {
                    v = expr.Apply(v);
                }

                builder.Add(v);
            }

            foreach (var outp in this.Outputs)
            {
                var finalValue = string.Join(this.Separator, builder);
                var fi = new FileInfo(Path.Combine(this.Root, outp.FileName));

                if (!Directory.Exists(fi.DirectoryName))
                    Directory.CreateDirectory(fi.DirectoryName);


                File.WriteAllText(fi.FullName, finalValue, outp.ParsedEncoding);
            }
        }
    }
}
