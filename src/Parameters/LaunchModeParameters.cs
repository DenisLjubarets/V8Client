using System.Text;

namespace V8Client
{
    public abstract class LaunchModeParameters : IParameter
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool? WindowsAuthentication { get; set; }

        public bool? WSWindowsAuthentication { get; set; }

        public string WSUsername { get; set; }

        public string WSPassword { get; set; }

        public bool? ProxyEnabled { get; set; }

        public string ProxyAddress { get; set; }

        public string ProxyPort { get; set; }

        public string ProxyUsername { get; set; }

        public string ProxyPassword { get; set; }

        public bool ClearCache { get; set; }

        public string RunShortcutPath { get; set; }

        public bool? AutoInstallLatestVersion { get; set; }

        public string ExecuteConfigFilePath { get; set; }

        public string ExportLogFilePath { get; set; }

        public bool TruncateLog { get; set; }

        public bool DisableStartupMessages { get; set; }

        public bool DisableStartupDialogs { get; set; }

        public bool DisableSplash { get; set; }

        public bool? UseHwLicenses { get; set; }

        public bool? AutoCheckClientVersion { get; set; }

        public bool? AutoCheckClientMode { get; set; }

        public ClientMode ClientMode { get; set; }

        public ClientArch ClientArch { get; set; }

        public MainWindowMode MainWindowMode { get; set; }

        public Language Language { get; set; }

        public virtual string StartupArguments { get { return CollectArguments().Trim(); } }

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            builder.Append(CollectAuthArguments());
            builder.Append(CollectClientMode());
            builder.Append(CollectClientArch());
            builder.Append(CollectMainWindowMode());
            builder.Append(CollectLanguage());
            builder.Append(CollectAdditionalArguments());
            return builder.ToString();
        }

        private string CollectAuthArguments()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Username))
            {
                builder.Append($@"/N ""{Username}"" ");
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    builder.Append($@"/P ""{Password}"" ");
                }
            }

            if (WindowsAuthentication == true) builder.Append("/WA+ ");
            if (WindowsAuthentication == false) builder.Append("/WA- ");
            if (WSWindowsAuthentication == true) builder.Append("/WSA+ ");
            if (WSWindowsAuthentication == false) builder.Append("/WSA- ");
            if (WSWindowsAuthentication == true && !string.IsNullOrWhiteSpace(WSUsername))
            {
                builder.Append($@"/WSN ""{Username}"" ");
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    builder.Append($@"/WSP ""{Password}"" ");
                }
            }

            if (ProxyEnabled == true)
            {
                builder.Append("/Proxy ");
                if (!string.IsNullOrWhiteSpace(ProxyAddress))
                {
                    builder.Append($@"-PSrv ""{ProxyAddress}"" ");
                    if (!string.IsNullOrWhiteSpace(ProxyPort)) builder.Append($@"-PPort ""{ProxyPort}""");
                    if (!string.IsNullOrWhiteSpace(ProxyUsername))
                    {
                        builder.Append($@"/PUser ""{ProxyUsername}"" ");
                        if (!string.IsNullOrWhiteSpace(ProxyPassword))
                        {
                            builder.Append($@"/PPwd ""{ProxyPassword}"" ");
                        }
                    }
                }
            }

            if (ProxyEnabled == false)
            {
                builder.Append("/NoProxy ");
            }

            return builder.ToString();
        }

        private string CollectAdditionalArguments()
        {
            var builder = new StringBuilder();
            if (ClearCache) builder.Append("/ClearCache ");
            if (AutoInstallLatestVersion == true) builder.Append("/AppAutoInstallLastVersion+ ");
            if (AutoInstallLatestVersion == false) builder.Append("/AppAutoInstallLastVersion- ");
            if (DisableStartupMessages) builder.Append("/DisableStartupMessages ");
            if (DisableStartupDialogs) builder.Append("/DisableStartupDialogs ");
            if (DisableSplash) builder.Append("/DisableSplash ");
            if (UseHwLicenses == true) builder.Append("/UseHwLicenses+ ");
            if (UseHwLicenses == false) builder.Append("/UseHwLicenses- ");
            if (AutoCheckClientVersion == true) builder.Append("/AppAutoCheckVersion+ ");
            if (AutoCheckClientVersion == false) builder.Append("/AppAutoCheckVersion- ");
            if (AutoCheckClientMode == true) builder.Append("/AppAutoCheckMode+ ");
            if (AutoCheckClientMode == false) builder.Append("/AppAutoCheckMode- ");
            if (!string.IsNullOrWhiteSpace(RunShortcutPath)) builder.Append($@"/RunShortcut ""{RunShortcutPath}"" ");
            if (!string.IsNullOrWhiteSpace(ExecuteConfigFilePath)) builder.Append($@"/Execute ""{ExecuteConfigFilePath}"" ");
            if (!string.IsNullOrWhiteSpace(ExportLogFilePath))
            {
                builder.Append($@"/Out ""{ExportLogFilePath}"" ");
                if (!TruncateLog)
                {
                    builder.Append("-NoTruncate ");
                }
            }
            return builder.ToString();
        }

        private string CollectClientMode()
        {
            var builder = new StringBuilder();

            switch (ClientMode)
            {
                case ClientMode.Auto:
                    break;
                case ClientMode.ThinClient:
                case ClientMode.WebClient:
                    builder.Append("/RunModeManagedApplication ");
                    break;
                case ClientMode.ThickClient:
                    builder.Append("/RunModeOrdinaryApplication ");
                    break;
            }

            return builder.ToString();
        }

        private string CollectClientArch()
        {
            var builder = new StringBuilder();

            switch (ClientArch)
            {
                case ClientArch.Auto:
                    break;
                case ClientArch.x86:
                    builder.Append("/AppArch x86 ");
                    break;
                case ClientArch.Prefer_x86:
                    builder.Append("/AppArch x86_prt ");
                    break;
                case ClientArch.x86_64:
                    builder.Append("/AppArch x86_64 ");
                    break;
                case ClientArch.Prefer_x86_64:
                    builder.Append("/AppArch x86_64_prt ");
                    break;
            }

            return builder.ToString();
        }

        private string CollectMainWindowMode()
        {
            var builder = new StringBuilder();

            switch (MainWindowMode)
            {
                case MainWindowMode.Auto:
                    break;
                case MainWindowMode.Normal:
                    builder.Append("/MainWindowMode -Normal ");
                    break;
                case MainWindowMode.Workplace:
                    builder.Append("/MainWindowMode -Workplace ");
                    break;
                case MainWindowMode.EmbeddedWorkplace:
                    builder.Append("/MainWindowMode -EmbeddedWorkplace ");
                    break;
                case MainWindowMode.FullscreenWorkplace:
                    builder.Append("/MainWindowMode -FullscreenWorkplace ");
                    break;
                case MainWindowMode.Kiosk:
                    builder.Append("/MainWindowMode -Kiosk ");
                    break;
            }

            return builder.ToString();
        }

        private string CollectLanguage()
        {
            var builder = new StringBuilder();

            switch (Language)
            {
                case Language.Auto:
                    break;
                case Language.English:
                    builder.Append("/L en ");
                    break;
                case Language.Russian:
                    builder.Append("/L ru ");
                    break;
                case Language.Ukrainian:
                    builder.Append("/L uk ");
                    break;
            }

            return builder.ToString();
        }
    }

    public enum ClientMode
    {
        Auto, ThinClient, WebClient, ThickClient
    }

    public enum ClientArch
    {
        Auto, x86, Prefer_x86, x86_64, Prefer_x86_64
    }

    public enum MainWindowMode
    {
        Auto, Normal, Workplace, EmbeddedWorkplace, FullscreenWorkplace, Kiosk
    }

    public enum Language
    {
        Auto, English, Russian, Ukrainian
    }
}
