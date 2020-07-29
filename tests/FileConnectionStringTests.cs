using NUnit.Framework;

namespace V8Client.Tests
{
    public class FileConnectionStringTests
    {
        public FileConnectionString FileConnectionString;

        [SetUp]
        public void Setup()
        {
            FileConnectionString = new FileConnectionString
            {
                Directory = @"C:\1CDatabases\",
                DBFormat = "8.3.8",
                DBPageSize = PageSize.Size_16K,
                Username = "Administrator",
                Password = "Pwd1234",
                Locale = "ru_RU",
                PriviledgedMode = true,
                LicenseDistribution = true
            };
            
        }

        [Test]
        public void ConnectionArguments_CorrectlyHandlesMinimumParameters()
        {
            FileConnectionString = new FileConnectionString
            {
                Directory = @"C:\1CDatabases\"
            };

            var expected = @"File=""C:\1CDatabases\"";";
            var actual = FileConnectionString.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConnectionArguments_ParametersConversionIsCorrect()
        {
            var expected = @"File=""C:\1CDatabases\"";DBFormat=8.3.8;DBPageSize=16384;Usr=""Administrator"";Pwd=""Pwd1234"";Locale=ru_RU;prmod=1;LicDstr=Y;";
            var actual = FileConnectionString.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}