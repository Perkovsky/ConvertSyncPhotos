using System.ServiceProcess;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        private readonly Watcher watcher;

        //FileInfo file;
        //StreamWriter writer;
        //FileSystemWatcher watcher;

        public Service()
        {
            InitializeComponent();

            watcher = new Watcher(new Logger());

            //file = new FileInfo(@"log_watcher.txt");
            //writer = file.CreateText();

            //watcher = new FileSystemWatcher(@"c:\");
            //watcher.Created += WatcherChanged;
            //watcher.Deleted += WatcherChanged;
            //watcher.Renamed += WatcherChanged;
            //watcher.Changed += WatcherChanged;
        }

        //void WatcherChanged(object sender, FileSystemEventArgs e)
        //{
        //    writer.WriteLine("Directory changed({0}): {1}", e.ChangeType, e.FullPath);
        //    writer.Flush();
        //}

        protected override void OnStart(string[] args)
        {
            //watcher.EnableRaisingEvents = true;
            if (!watcher.Start())
            {
                watcher.Log(string.Format(@"{0}\settings.xml", GeneralMethods.GetCurrentDirectory()), "Not started! Specify settings.");
            }
        }

        protected override void OnStop()
        {
            //watcher.EnableRaisingEvents = false;
            watcher.Stop();
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
