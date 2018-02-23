using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAmalgamationService.Support
{
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Guesses the encoding of the contents of a text file using UDE, in case it fails guessing, returns UTF-8
        /// </summary>
        /// <param name="fileInfo"></param>
        /// <returns></returns>
        public static Encoding GuessEncoding(this FileInfo fileInfo)
        {
            using (var fs = File.OpenRead(fileInfo.FullName))
            {
                var cdet = new Ude.CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                {
                    return Encoding.GetEncoding(cdet.Charset);
                }

                return Encoding.UTF8;
            }
        }
    }
}
