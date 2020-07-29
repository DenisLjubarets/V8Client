using NUnit.Framework;

namespace V8Client.Tests
{
    public class WebServerConnectionTests
    {
        public WebServerConnection WebServerConnection;

        [SetUp]
        public void Setup()
        {
            WebServerConnection = new WebServerConnection
            {
                Uri = new System.Uri("https://1c.website.com/ws/something.html")
            };
            
        }

        [Test]
        public void ConnectionArguments_ConversionOfAllParametersIsCorrect()
        {
            var expected = @"/WS ""https://1c.website.com/ws/something.html""";
            var actual = WebServerConnection.ConnectionArguments;
            Assert.AreEqual(expected, actual);
        }
    }
}