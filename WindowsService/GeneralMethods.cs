using System.IO;
using System.Reflection;

namespace WindowsService
{
    public static class GeneralMethods
    {
        public static string GetCurrentDirectory()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            return path;
        }
    }
}
