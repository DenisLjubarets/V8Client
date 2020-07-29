using NUnit.Framework;

namespace V8Client.Tests
{
    public class CreateInfobaseParametersTests
    {
        public CreateInfobaseParameters CreateInfobaseParameters;

        [Test]
        public void GenerateArguments_ConversionOfAllParametersIsCorrect()
        {
            CreateInfobaseParameters = new CreateInfobaseParameters
            {
                Connection = new FileConnectionString
                {
                    Directory = @"C:\1CDatabases\"
                },
                TemplateFile = @"C:\1CDatabases\1C Template File.cf",
                DumpResultFile = @"C:\1CDatabases\Result File.txt",
                AddToListWithName = "Accounting Infobase",
            };
            var expected = @"CREATEINFOBASE File=""C:\1CDatabases\""; /UseTemplate ""C:\1CDatabases\1C Template File.cf"" /DumpResult ""C:\1CDatabases\Result File.txt"" /AddToList ""Accounting Infobase""";
            var actual = CreateInfobaseParameters.GenerateArguments();
            Assert.AreEqual(expected, actual);
        }
    }
}