using System.ComponentModel;
using System.ServiceProcess;

namespace WindowsService
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            ServiceProcessInstaller processInstaller;
            ServiceInstaller serviceInstaller;

            processInstaller = new ServiceProcessInstaller();
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller = new ServiceInstaller();
            //TODO: change service name and description
            serviceInstaller.ServiceName = "Convert and sync photos";
            serviceInstaller.Description = "";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            base.Installers.Add(processInstaller);
            base.Installers.Add(serviceInstaller);
        }
    }
}
