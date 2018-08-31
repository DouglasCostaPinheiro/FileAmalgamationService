using FileAmalgamationService.Support;
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
                        v = string.Join(this.Separator, dir.GetFiles(inp.Value, inp.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => !this.Outputs.Any(otp => Path.Combine(this.Root, otp.SubFolder ?? "", otp.FileName).Equals(file.FullName, System.StringComparison.CurrentCultureIgnoreCase))).Select(file => File.ReadAllText(file.FullName, inp.ParsedEncoding ?? file.GuessEncoding())));
                        break;
                    case Enums.InputType.FileSearchExpressionRegex:
                        dir = new DirectoryInfo(Path.Combine(this.Root, inp.SubFolder ?? ""));
                        v = string.Join(this.Separator, dir.GetFiles("*", inp.Recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => new Regex(inp.Value, RegexOptions.CultureInvariant).IsMatch(file.Name)).Where(file => !this.Outputs.Any(otp => Path.Combine(this.Root, otp.SubFolder ?? "", otp.FileName).Equals(file.FullName, System.StringComparison.CurrentCultureIgnoreCase))).Select(file => File.ReadAllText(file.FullName, inp.ParsedEncoding ?? file.GuessEncoding())));
                        break;
                    default:
                        throw new System.Exception("Unexpected Case");
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
                var fi = new FileInfo(Path.Combine(this.Root, outp.SubFolder, outp.FileName));

                if (!Directory.Exists(fi.DirectoryName))
                    Directory.CreateDirectory(fi.DirectoryName);


                File.WriteAllText(fi.FullName, finalValue, outp.ParsedEncoding);
            }
        }
    }
}
