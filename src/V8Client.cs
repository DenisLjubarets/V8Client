using System.Diagnostics;

namespace V8Client
{
    public class V8Client
    {
        private readonly string clientPath;

        public V8Client(string clientPath)
        {
            this.clientPath = clientPath;
        }

        public void Start(ILaunchMode launchMode)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = clientPath,
                Arguments = launchMode.StartupArguments
            });
        }
    }
}
