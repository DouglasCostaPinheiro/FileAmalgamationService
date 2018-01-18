using FileAmalgamationService.Models;
using FileAmalgamationService.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Xml;

namespace FileAmalgamationService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                FileAmalgamationService service1 = new FileAmalgamationService();
                service1.TestStartupAndStop(args);

                /*var profiles = new List<Profile>();
                var prof = new Profile(@"C:\Bitbucket\tmp\orquestra3\Scripts\SQLServer\Atualizacoes", string.Format("{0}--SEPARATOR--{0}",Environment.NewLine));

                prof.AddInput(new Input(InputType.Text, "--FILE AMALGAMATION", recursive: true));
                prof.AddInput(new Input(InputType.FileSearchExpressionRegex, @"3\.(\d\.*)+(_Atualizacoes)", recursive: true, encoding: "UTF-8"));
                prof.AddOutput(new Output("OUT/out.sql"));
                
                profiles.Add(prof);

                prof.Process();*/

                /*DataContractSerializer writer = new DataContractSerializer(typeof(List<Profile>));
                var settings = new XmlWriterSettings { Indent = true };

                using (var w = XmlWriter.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "File Amalgamation Service.xml"), settings))
                {
                    writer.WriteObject(w, profiles);
                }

                using (var fs = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "File Amalgamation Service.json")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(fs, profiles);
                }*/
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new FileAmalgamationService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
