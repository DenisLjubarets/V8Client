using System.Text;

namespace V8Client
{
    public class DesignerMode : LaunchModeParameters, ILaunchMode
    {
        public IConnection Connection { get; set; }

        public string BackupInfobasePath { get; set; }

        public string RestoreInfobasePath { get; set; }

        public bool RestoreInfobaseIntegrity { get; set; }

        public string ExportConfigPath { get; set; }

        public string ImportConfigPath { get; set; }

        public string UpdateConfigPath { get; set; }

        public override string StartupArguments { get { return $"{CollectArguments()} {base.StartupArguments}".Trim(); } }

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            if (Connection != null) builder.Append($"DESIGNER {Connection.ConnectionArguments} ");
            if (!string.IsNullOrWhiteSpace(BackupInfobasePath)) builder.Append($@"/DumpIB ""{BackupInfobasePath}"" ");
            if (!string.IsNullOrWhiteSpace(RestoreInfobasePath)) builder.Append($@"/RestoreIB ""{RestoreInfobasePath}"" ");
            if (RestoreInfobaseIntegrity) builder.Append("/IBRestoreIntegrity ");
            if (!string.IsNullOrWhiteSpace(ExportConfigPath)) builder.Append($@"/DumpCfg ""{ExportConfigPath}"" ");
            if (!string.IsNullOrWhiteSpace(ImportConfigPath)) builder.Append($@"/LoadCfg ""{ImportConfigPath}"" ");
            if (!string.IsNullOrWhiteSpace(UpdateConfigPath)) builder.Append($@"/UpdateCfg ""{UpdateConfigPath}"" ");
            return builder.ToString().Trim();
        }
    }
}
