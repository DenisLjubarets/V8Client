using System.Text;

namespace V8Client
{
    public abstract class DesignerParameters : CommonParameters
    {
        public string InfobaseUpdateFile { get; set; }
        public string InfobaseBackupFile { get; set; }
        public string InfobaseRestoreFile { get; set; }
        public string ConfigurationImportFile { get; set; }
        public string ConfigurationExportFile { get; set; }
        public bool RestoreInfobaseIntegrity { get; set; }

        public override string GenerateArguments()
        {
            var builder = new StringBuilder();
            builder.Append($"DESIGNER {Connection.ConnectionArguments} ");
            if (!string.IsNullOrWhiteSpace(InfobaseUpdateFile)) builder.Append($@"/UpdateCfg ""{InfobaseUpdateFile}"" /UpdateDBCfg ");
            if (!string.IsNullOrWhiteSpace(InfobaseBackupFile)) builder.Append($@"/DumpIB ""{InfobaseBackupFile}"" ");
            if (!string.IsNullOrWhiteSpace(InfobaseRestoreFile)) builder.Append($@"/RestoreIB ""{InfobaseRestoreFile}"" ");
            if (!string.IsNullOrWhiteSpace(ConfigurationImportFile)) builder.Append($@"/DumpCfg ""{ConfigurationImportFile}"" ");
            if (!string.IsNullOrWhiteSpace(ConfigurationExportFile)) builder.Append($@"/LoadCfg ""{ConfigurationExportFile}"" ");
            return builder.ToString() + base.GenerateArguments();
        }
    }
}
