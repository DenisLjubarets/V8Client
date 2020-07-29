using System.Text;

namespace V8Client
{
    public abstract class CommonParameters : ILauncherParameters
    {
        public IConnection Connection { get; set; }
        public TrafficCompression? TrafficCompression { get; set; }
        public MainWindowMode? MainWindowMode { get; set; }
        public ClientType ClientType { get; set; }
        public ClientArch? ClientArch { get; set; }
        public Language? Language { get; set; }
        public bool? AutoCheckClientMode { get; set; }
        public bool? AutoCheckClientVersion { get; set; }
        public bool? AutoInstallLatestVersion { get; set; }
        public bool? UseHwLicenses { get; set; }
        public bool? TruncateLog { get; set; }
        public bool? WindowsAuthentication { get; set; }
        public bool? WSWindowsAuthentication { get; set; }
        public bool UsePrivilegedMode { get; set; }
        public bool DisableStartupDialogs { get; set; }
        public bool DisableStartupMessages { get; set; }
        public bool DisableSplash { get; set; }
        public bool ClearCache { get; set; }
        public string LogFile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string WSUsername { get; set; }
        public string WSPassword { get; set; }
        public string Locale { get; set; }

        public virtual string GenerateArguments()
        {
            var builder = new StringBuilder();
            if (TrafficCompression != null) builder.Append($"/TComp {TrafficCompression} ");
            if (MainWindowMode != null) builder.Append($"/MainWindowMode -{MainWindowMode} ");
            if (ClientType == ClientType.ThickClient) builder.Append("/RunModeOrdinaryApplication ");
            if (ClientType == ClientType.ThinClient) builder.Append("/RunModeManagedApplication ");
            if (ClientType == ClientType.WebClient) builder.Append("/RunModeManagedApplication ");
            if (ClientArch != null) builder.Append($"/AppArch {ClientArchToString()} ");
            if (Language != null) builder.Append($"/L{LanguageToString()} ");
            if (AutoCheckClientMode == true) builder.Append("/AppAutoCheckMode+ ");
            if (AutoCheckClientMode == false) builder.Append("/AppAutoCheckMode- ");
            if (AutoCheckClientVersion == true) builder.Append("/AppAutoCheckVersion+ ");
            if (AutoCheckClientVersion == false) builder.Append("/AppAutoCheckVersion- ");
            if (UseHwLicenses == true) builder.Append("/UseHwLicenses+ ");
            if (UseHwLicenses == false) builder.Append("/UseHwLicenses- ");
            if (WindowsAuthentication == true) builder.Append("/WA+ ");
            if (WindowsAuthentication == false) builder.Append("/WA- ");
            if (WSWindowsAuthentication == true) builder.Append("/WSA+ ");
            if (WSWindowsAuthentication == false) builder.Append("/WSA- ");
            if (UsePrivilegedMode) builder.Append("/UsePrivilegedMode ");
            if (DisableStartupDialogs) builder.Append("/DisableStartupDialogs ");
            if (DisableStartupMessages) builder.Append("/DisableStartupMessages ");
            if (DisableSplash) builder.Append("/DisableSplash ");
            if (ClearCache) builder.Append("/ClearCache ");
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                builder.Append($@"/Out ""{LogFile}"" ");
                if (TruncateLog == false) builder.Append("-NoTruncate ");
            }
            if (!string.IsNullOrWhiteSpace(Username))
            {
                builder.Append($@"/N ""{Username}"" ");
                if (!string.IsNullOrWhiteSpace(Password)) builder.Append($@"/P ""{Password}"" ");
            }
            if (WSWindowsAuthentication == true && !string.IsNullOrWhiteSpace(WSUsername))
            {
                builder.Append($@"/WSN ""{WSUsername}"" ");
                if (!string.IsNullOrWhiteSpace(WSPassword)) builder.Append($@"/WSP ""{WSPassword}"" ");
            }

            return builder.ToString();
        }

        private string ClientArchToString()
        {
            return ClientArch switch
            {
                V8Client.ClientArch.Only_32bit => "x86",
                V8Client.ClientArch.Prioritize_32bit => "x86_prt",
                V8Client.ClientArch.Only_64bit => "x86_64",
                V8Client.ClientArch.Prioritize_64bit => "x86_64_prt",
                _ => null
            };
        }

        private string LanguageToString()
        {
            return Language switch
            {
                V8Client.Language.Azerbaijani => "az",
                V8Client.Language.English => "en",
                V8Client.Language.Armenian => "hy",
                V8Client.Language.Bulgarian => "bg",
                V8Client.Language.Hungarian => "hu",
                V8Client.Language.Vietnamese => "vi",
                V8Client.Language.Greek => "el",
                V8Client.Language.Georgian => "ka",
                V8Client.Language.Spanish => "es",
                V8Client.Language.Italian => "it",
                V8Client.Language.Kazakh => "kz",
                V8Client.Language.Chinese => "zh",
                V8Client.Language.Latvian => "lv",
                V8Client.Language.Lithuanian => "lt",
                V8Client.Language.German => "de",
                V8Client.Language.Polish => "pl",
                V8Client.Language.Romanian => "ro",
                V8Client.Language.Russian => "ru",
                V8Client.Language.Turkish => "tr",
                V8Client.Language.Ukrainian => "uk",
                V8Client.Language.French => "fr",
                _ => null
            };
        }
    }

    public enum MainWindowMode
    {
        Normal,
        Workplace,
        EmbeddedWorkplace,
        FullscreenWorkplace,
        Kiosk
    }

    public enum ClientArch
    {
        Only_32bit,
        Prioritize_32bit,
        Only_64bit,
        Prioritize_64bit
    }

    public enum ClientType
    {
        Auto,
        ThinClient,
        WebClient,
        ThickClient
    }

    public enum Language
    {
        Azerbaijani,
        English,
        Armenian,
        Bulgarian,
        Hungarian,
        Vietnamese,
        Greek,
        Georgian,
        Spanish,
        Italian,
        Kazakh,
        Chinese,
        Latvian,
        Lithuanian,
        German,
        Polish,
        Romanian,
        Russian,
        Turkish,
        Ukrainian,
        French
    }

    public enum TrafficCompression
    {
        None,
        Deflate,
        SDC
    }
}