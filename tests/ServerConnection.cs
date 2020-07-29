using NUnit.Framework;

namespace V8Client.Tests
{
    public class ServerConnectionTests
    {
        public ServerConnection ServerConnection;

        [SetUp]
        public void Setup()
        {
            ServerConnection = new ServerConnection
            {
                ClusterAddress = @"192.168.0.1",
                InfobaseReference = "1C_DATABASE"
            };
            
        }

        [Test]
        public void ConnectionArguments_ConversionOfAllParametersIsCorrect()
        {
            var expected = @"/S ""192.168.0.1\1C_DATABASE""";
            var actual = ServerConnection.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}