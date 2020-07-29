namespace V8Client
{
    public class FileConnection : IConnection
    {
        public string Directory { get; set; }
        public string ConnectionArguments => $@"/F ""{Directory}""";
    }
}