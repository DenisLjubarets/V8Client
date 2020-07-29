using NUnit.Framework;

namespace V8Client.Tests
{
    public class ServerConnectionStringTests
    {
        public ServerConnectionString ServerConnectionString;

        [SetUp]
        public void Setup()
        {
            ServerConnectionString = new ServerConnectionString
            {
                ClusterAddress = @"https://1c.website.com/ws/something.html",
                InfobaseReference = "1C_DATABASE",
                ClusterUsername = "CAdmin",
                ClusterPassword = "CPwd",
                SQLServerType = SQLServerType.MSSQLServer,
                SQLServerAddress = "192.168.0.1",
                SQLServerDatabase = "SQL_DATABASE",
                SQLServerUsername = "SQLAdmin",
                SQLServerPassword = "SQLPwd",
                SQLServerYearOffset = 2000,
                CreateSQLDatabase = true,
                BlockScheduledJobs = true,
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
            ServerConnectionString = new ServerConnectionString
            {
                ClusterAddress = @"SERVER",
                InfobaseReference = "1C_DATABASE",
            };

            var expected = @"Srvr=""SERVER"";Ref=""1C_DATABASE"";";
            var actual = ServerConnectionString.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ConnectionArguments_ConversionOfAllParametersIsCorrect()
        {
            var expected = @"Srvr=""https://1c.website.com/ws/something.html"";Ref=""1C_DATABASE"";SUsr=""CAdmin"";SPwd=""CPwd"";DBMS=MSSQLServer;DBSrvr=""192.168.0.1"";DB=""SQL_DATABASE"";DBUID=""SQLAdmin"";DBPwd=""SQLPwd"";SQLYOffs=2000;CrSQLDB=Y;SchJobDn=Y;Usr=""Administrator"";Pwd=""Pwd1234"";Locale=ru_RU;prmod=1;LicDstr=Y;";
            var actual = ServerConnectionString.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}