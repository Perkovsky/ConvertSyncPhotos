using System.IO;
using System.ServiceProcess;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        FileInfo file;
        StreamWriter writer;
        FileSystemWatcher watcher;

        public Service()
        {
            InitializeComponent();

            file = new FileInfo(@"c:\log_watcher.txt");
            writer = file.CreateText();

            watcher = new FileSystemWatcher(@"c:\");
            watcher.Created += WatcherChanged;
            watcher.Deleted += WatcherChanged;
            watcher.Renamed += WatcherChanged;
            watcher.Changed += WatcherChanged;
        }

        void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            writer.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
            writer.Flush();
        }

        protected override void OnStart(string[] args)
        {
            watcher.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            watcher.EnableRaisingEvents = false;
        }

        protected override void OnContinue()
        {
            this.OnStart(null);
        }

        protected override void OnPause()
        {
            this.OnStop();
        }

        protected override void OnShutdown()
        {
            this.OnStop();
        }
    }
}
