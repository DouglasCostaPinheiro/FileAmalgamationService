using FileAmalgamationService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceProcess;
using System.Xml;

namespace FileAmalgamationService
{
    public partial class FileAmalgamationService : ServiceBase
    {
        private List<Profile> profiles;
        private List<FolderTimer> folderTimers;
        public static new EventLog EventLog = new EventLog();

        public FileAmalgamationService()
        {
            InitializeComponent();

            if (!EventLog.SourceExists(nameof(FileAmalgamationService)))
            {
                EventLog.CreateEventSource(nameof(FileAmalgamationService), "Application");
            }

            EventLog.Source = nameof(FileAmalgamationService);
            EventLog.Log = "Application";
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            EventLog.WriteEntry("FileAmalgamationService started.", EventLogEntryType.Information);
            LoadProfiles();

            folderTimers = this.profiles.Select(p => new FolderTimer(p)).ToList();
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("FileAmalgamationService stopped.", EventLogEntryType.Information);
        }

        private void LoadProfiles()
        {
            var profileFilePath = ConfigurationManager.AppSettings["profileFile"];

            if (Path.GetExtension(profileFilePath).Equals(".json", StringComparison.InvariantCultureIgnoreCase))
            {
                profiles = JsonConvert.DeserializeObject<List<Profile>>(File.ReadAllText(profileFilePath));
            }
            else if (Path.GetExtension(profileFilePath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                var dcs = new DataContractSerializer(typeof(List<Profile>));
                using (var fs = new FileStream(profileFilePath, FileMode.Open))
                {
                    using (var xr = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                    {
                        profiles = (List<Profile>)dcs.ReadObject(xr);
                    }
                }
            }
        }
    }
}
