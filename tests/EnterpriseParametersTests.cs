using NUnit.Framework;
using System.IO;

namespace V8Client.Tests
{
    public class EnterpriseParametersTests
    {
        public EnterpriseParameters EnterpriseParameters;

        [Test]
        public void GenerateArguments_CorrectlyHandlesMinimumParameters()
        {
            EnterpriseParameters = new EnterpriseParameters
            {
                Connection = new FileConnection
                {
                    Directory = @"C:\Database\"
                }
            };

            var expected = $@"ENTERPRISE /F ""C:\Database\""";
            var actual = EnterpriseParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateArguments_CorrectlyGeneratesEnums()
        {
            EnterpriseParameters = new EnterpriseParameters
            {
                Connection = new FileConnection
                {
                    Directory = @"C:\Database\"
                },
                TrafficCompression = TrafficCompression.SDC,
                MainWindowMode = MainWindowMode.FullscreenWorkplace,
                ClientType = ClientType.ThinClient,
                ClientArch = ClientArch.Only_32bit,
                Language = Language.English
            };

            var expected = $@"ENTERPRISE /F ""C:\Database\"" /TComp SDC /MainWindowMode -FullscreenWorkplace /RunModeManagedApplication /AppArch x86 /Len";
            var actual = EnterpriseParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateArguments_CorrectlyGeneratesBooleans()
        {
            EnterpriseParameters = new EnterpriseParameters
            {
                Connection = new FileConnection
                {
                    Directory = @"C:\Database\"
                },
                AutoCheckClientMode = true,
                AutoCheckClientVersion = true,
                AutoInstallLatestVersion = true,
                UseHwLicenses = true,
                WindowsAuthentication = true,
                WSWindowsAuthentication = false,
                UsePrivilegedMode = true,
                DisableStartupDialogs = true,
                DisableStartupMessages = true,
                DisableSplash = true,
                ClearCache = true,
            };

            var expected = $@"ENTERPRISE /F ""C:\Database\"" /AppAutoCheckMode+ /AppAutoCheckVersion+ /UseHwLicenses+ /WA+ /WSA- /UsePrivilegedMode /DisableStartupDialogs /DisableStartupMessages /DisableSplash /ClearCache";
            var actual = EnterpriseParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GenerateArguments_CorrectlyGeneratesStrings()
        {
            EnterpriseParameters = new EnterpriseParameters
            {
                Connection = new FileConnection
                {
                    Directory = @"C:\Database\"
                },
                LogFile = @"C:\Log.log",
                TruncateLog = false,
                Username = "Admin",
                Password = "Pswd",
                WSWindowsAuthentication = true,
                WSUsername = "WSAdmin",
                WSPassword = "WSPswd",
                Locale = "ru_RU"
            };

            var expected = $@"ENTERPRISE /F ""C:\Database\"" /WSA+ /Out ""C:\Log.log"" -NoTruncate /N ""Admin"" /P ""Pswd"" /WSN ""WSAdmin"" /WSP ""WSPswd""";
            var actual = EnterpriseParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }
    }
}
