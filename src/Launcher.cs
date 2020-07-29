using System.Diagnostics;

namespace V8Client
{
    public class Launcher
    {
        private readonly string clientFile;

        public Launcher(string clientFile)
        {
            this.clientFile = clientFile;
        }

        public void Launch(ILauncherParameters parameters)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = clientFile,
                Arguments = parameters.GenerateArguments()
            });
        }
    }
}