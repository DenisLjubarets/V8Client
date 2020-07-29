using NUnit.Framework;

namespace V8Client.Tests
{
    public class InfobaseConnectionTests
    {
        public InfobaseConnection InfobaseConnection;

        [SetUp]
        public void Setup()
        {
            InfobaseConnection = new InfobaseConnection
            {
                InfobaseName = "Accounting Infobase"
            };
        }

        [Test]
        public void ConnectionArguments_ConversionOfAllParametersIsCorrect()
        {
            var expected = @"/IBName ""Accounting Infobase""";
            var actual = InfobaseConnection.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}