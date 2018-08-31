using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FileAmalgamationService.Models
{
    public class FolderTimer : IDisposable
    {
        public Timer Timer { get; private set; }
        public FileSystemWatcher FolderWatcher { get; private set; }
        private Profile Profile { get; set; }
        public log4net.ILog Log { get; set; }

        public FolderTimer(Profile profile, log4net.ILog log)
        {
            this.Profile = profile;
            this.Log = log;

            this.Log.Info($"Profile loaded: FolderTimer configured to watch '{this.Profile.Root}'");
            
            this.Timer = new Timer
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
            if (this.Profile.Outputs.All(o => !(Path.Combine(this.Profile.Root, o.SubFolder, o.FileName) == e.FullPath)))
            {
                this.Log.Info($"Event of type '{e.ChangeType}' in file '{e.FullPath}' triggered.");
                if (this.Timer.Enabled)
                {
                    this.Log.Info("Resetting previous timer...");
                    this.Timer.Stop();
                }
                this.Timer.Start();
                this.Log.Info($"Files will be processed in {this.Timer.Interval / 1000} seconds, unless a new change resets the timer.");
            }
        }

        public void Dispose()
        {
            Timer.Dispose();
            FolderWatcher.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
