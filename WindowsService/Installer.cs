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
            serviceInstaller.ServiceName = "Test My NT-Service";
            serviceInstaller.Description = "This is my NT-Service!";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            base.Installers.Add(processInstaller);
            base.Installers.Add(serviceInstaller);
        }
    }
}
