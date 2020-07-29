using NUnit.Framework;

namespace V8Client.Tests
{
    public class DesignerParametersTests
    {
        public DesignerParameters DesignerParameters;

        [Test]
        public void GenerateArguments_ConversionOfAllParametersIsCorrect()
        {
            DesignerParameters = new DesignerParameters
            {
                Connection = new FileConnection
                {
                    Directory = @"C:\1CDatabases\"
                },
                InfobaseUpdateFile = @"C:\Update.cfu",
                InfobaseBackupFile = @"C:\Backup.dt",
                InfobaseRestoreFile = @"C:\Restore.dt",
                ConfigurationImportFile = @"C:\ImportConfig.cf",
                ConfigurationExportFile = @"C:\ExportConfig.cf",
            };
            var expected = @"DESIGNER /F ""C:\1CDatabases\"" /UpdateCfg ""C:\Update.cfu"" /UpdateDBCfg /DumpIB ""C:\Backup.dt"" /RestoreIB ""C:\Restore.dt"" /LoadCfg ""C:\ImportConfig.cf"" /DumpCfg ""C:\ExportConfig.cf""";
            var actual = DesignerParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }
    }
}