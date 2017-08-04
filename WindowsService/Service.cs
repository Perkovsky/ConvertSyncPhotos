using System.ServiceProcess;

namespace WindowsService
{
    public partial class Service : ServiceBase
    {
        private readonly Watcher watcher;

        public Service()
        {
            InitializeComponent();
            watcher = new Watcher(new Logger());
        }

        protected override void OnStart(string[] args)
        {
            if (!watcher.Start())
            {
                watcher.Log(string.Format(@"{0}\settings.xml", GeneralMethods.GetCurrentDirectory()), "Not started! Specify settings.");
            }
        }

        protected override void OnStop() => watcher.Stop();

        protected override void OnContinue() => this.OnStart(null);

        protected override void OnPause() => this.OnStop();

        protected override void OnShutdown() => this.OnStop();
    }
}
