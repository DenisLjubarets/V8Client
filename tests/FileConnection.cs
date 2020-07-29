using NUnit.Framework;

namespace V8Client.Tests
{
    public class FileConnectionTests
    {
        public FileConnection FileConnection;

        [SetUp]
        public void Setup()
        {
            FileConnection = new FileConnection
            {
                Directory = @"C:\1CDatabases\"
            };
            
        }

        [Test]
        public void ConnectionArguments_ConversionOfAllParametersIsCorrect()
        {
            var expected = @"/F ""C:\1CDatabases\""";
            var actual = FileConnection.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}