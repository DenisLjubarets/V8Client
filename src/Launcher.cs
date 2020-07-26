using System.Diagnostics;

namespace V8Client
{
    public class Launcher
    {
        private readonly string clientPath;

        public Launcher(string clientPath)
        {
            this.clientPath = clientPath;
        }

        public void Launch(ILauncherParameters parameters)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = clientPath,
                Arguments = parameters.GenerateArguments()
            });
        }
    }
}