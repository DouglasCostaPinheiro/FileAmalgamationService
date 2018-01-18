using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileAmalgamationService.Models
{
    public class FolderTimer
    {
        public Timer Timer { get; private set; }
        public FileSystemWatcher FolderWatcher { get; private set; }
        private Profile Profile { get; set; }

        public FolderTimer(Profile profile)
        {
            this.Profile = profile;

            FileAmalgamationService.EventLog.WriteEntry(string.Format("Profile loaded: FolderTimer configured to watch '{0}'", this.Profile.Root));
            
            this.Timer = new Timer()
            {
                Interval = int.Parse(ConfigurationManager.AppSettings["watcherTimer"]) * 1000,
                AutoReset = false
            };

            this.Timer.Elapsed += (sender, e) => { this.Profile.Process(); };

            this.FolderWatcher = new FileSystemWatcher(profile.Root)
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.LastWrite
            };

            this.FolderWatcher.Created += FolderWatchEvent;
            this.FolderWatcher.Deleted += FolderWatchEvent;
            this.FolderWatcher.Changed += FolderWatchEvent;

            this.FolderWatcher.EnableRaisingEvents = true;
        }

        private void FolderWatchEvent(object sender, FileSystemEventArgs e)
        {
            if (this.Profile.Outputs.All(o => !(Path.Combine(this.Profile.Root, o.FileName) == e.FullPath)))
            {
                FileAmalgamationService.EventLog.WriteEntry(string.Format("Event of type '{0}' in file '{1}' triggered.", e.ChangeType, e.FullPath));
                if (this.Timer.Enabled)
                {
                    FileAmalgamationService.EventLog.WriteEntry("Resetting previous timer...");
                    this.Timer.Stop();
                }
                this.Timer.Start();
                FileAmalgamationService.EventLog.WriteEntry(string.Format("Files will be processed in {0} seconds, unless a new change resets the timer.", this.Timer.Interval / 1000));
            }
        }
    }
}
