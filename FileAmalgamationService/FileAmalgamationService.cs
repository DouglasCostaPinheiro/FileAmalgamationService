using FileAmalgamationService.Models;
using FileAmalgamationService.Util;
using Microsoft.Win32;
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
        private List<Profile> profiles = new List<Profile>();
        private List<FolderTimer> folderTimers;
        private static readonly string configType = ConfigurationManager.AppSettings["ConfigType"];
        private static string profileFilePath = Path.ChangeExtension(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, nameof(FileAmalgamationService)), GetConfigTypeExtension());

        //Log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FileAmalgamationService()
        {
            InitializeComponent();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);

            while (true)
            {

            }

            this.OnStop();
        }

        protected override void OnStart(string[] args)
        {
            log.Info("FileAmalgamationService started.");

            LoadProfiles();

            folderTimers = this.profiles.Select(p => new FolderTimer(p, log)).ToList();
        }

        protected override void OnStop()
        {
            log.Info("FileAmalgamationService stopped.");
        }

        private void LoadProfiles()
        {
            if (!File.Exists(profileFilePath))
                SaveProfiles();

            if (Path.GetExtension(profileFilePath).Equals(".json", StringComparison.InvariantCultureIgnoreCase))
            {
                profiles = JsonConvert.DeserializeObject<List<Profile>>(File.ReadAllText(profileFilePath));
            }
            else if (Path.GetExtension(profileFilePath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
            {
                var dcs = new DataContractSerializer(typeof(List<Profile>));
                using (var fs = new FileStream(profileFilePath, FileMode.OpenOrCreate))
                {
                    using (var xr = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas()))
                    {
                        profiles = (List<Profile>)dcs.ReadObject(xr);
                    }
                }
            }
        }

        private void SaveProfiles()
        {
            try
            {
                if (Path.GetExtension(profileFilePath).Equals(".json", StringComparison.InvariantCultureIgnoreCase))
                {
                    File.WriteAllText(profileFilePath, JsonConvert.SerializeObject(this.profiles));
                }
                else if (Path.GetExtension(profileFilePath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase))
                {
                    var dcs = new DataContractSerializer(typeof(List<Profile>));

                    using (var fs = new FileStream(profileFilePath, FileMode.Create))
                    {
                        using (var xw = XmlDictionaryWriter.CreateTextWriter(fs))
                        {
                            dcs.WriteObject(xw, this.profiles);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Error saving profiles: {ex.Message}");
            }
        }

        private static string GetConfigTypeExtension()
        {
            switch (configType)
            {
                case "XML":
                    return ".xml";
                case "JSON":
                    return ".json";
                default:
                    throw new Exception("Invalid configuration type, valid types are: XML, JSON");
            }
        }
    }
}
