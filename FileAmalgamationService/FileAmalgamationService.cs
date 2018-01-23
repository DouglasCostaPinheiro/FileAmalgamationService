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

        public FileAmalgamationService()
        {
            InitializeComponent();

            if (!EventLog.SourceExists(nameof(FileAmalgamationService)))
            {
                EventLog.CreateEventSource(nameof(FileAmalgamationService), nameof(FileAmalgamationService));
            }

            EventLog.Source = nameof(FileAmalgamationService);
            EventLog.Log = nameof(FileAmalgamationService);
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("FileAmalgamationService started.", EventLogEntryType.Information);
            LoadProfiles();

            folderTimers = this.profiles.Select(p => new FolderTimer(p, this.EventLog)).ToList();
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
