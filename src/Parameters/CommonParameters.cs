using System.Text;

namespace V8Client
{
    public abstract class CommonParameters
    {
        public IConnection Connection { get; set; }
        public TrafficCompression? TrafficCompression { get; set; }
        public MainWindowMode? MainWindowMode { get; set; }
        public ClientType ClientType { get; set; }
        public ClientArch ClientArch { get; set; }
        public Language Language { get; set; }
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
            if (ClientArch != null) builder.Append($"/AppArch {ClientArch} ");
            if (ClientType == ClientType.ThickClient) builder.Append("/RunModeOrdinaryApplication ");
            if (ClientType == ClientType.ThinClient) builder.Append("/RunModeManagedApplication ");
            if (ClientType == ClientType.WebClient) builder.Append("/RunModeManagedApplication ");
            if (Language != null) builder.Append($"/L{Language} ");
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
            if (UsePrivilegedMode == true) builder.Append("/UsePrivilegedMode ");
            if (DisableStartupDialogs) builder.Append("/DisableStartupDialogs ");
            if (DisableStartupMessages) builder.Append("/DisableStartupMessages ");
            if (DisableSplash) builder.Append("/DisableSplash ");
            if (ClearCache) builder.Append("/ClearCache ");
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                builder.Append($"/Out {LogFile} ");
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
    }

    public enum MainWindowMode
    {
        Normal, Workplace, EmbeddedWorkplace, FullscreenWorkplace, Kiosk
    }

    public enum ClientType
    {
        Auto, ThinClient, WebClient, ThickClient
    }

    public enum TrafficCompression
    {
        None, Deflate, SDC
    }

    public class ClientArch
    {
        public static string Only32Bit => "x86";
        public static string Prioritize32Bit => "x86_prt";
        public static string Only64bit => "x86_64";
        public static string Prioritize64bit => "x86_64_prt";
    }

    public class Language
    {
        public static string Azerbaijani => "az";
        public static string English => "en";
        public static string Armenian => "hy";
        public static string Bulgarian => "bg";
        public static string Hungarian => "hu";
        public static string Vietnamese => "vi";
        public static string Greek => "el";
        public static string Georgian => "ka";
        public static string Spanish => "es";
        public static string Italian => "it";
        public static string Kazakh => "kz";
        public static string Chinese => "zh";
        public static string Latvian => "lv";
        public static string Lithuanian => "lt";
        public static string German => "de";
        public static string Polish => "pl";
        public static string Romanian => "ro";
        public static string Russian => "ru";
        public static string Turkish => "tr";
        public static string Ukrainian => "uk";
        public static string French => "fr";
    }
}