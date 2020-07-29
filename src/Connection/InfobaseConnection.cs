namespace V8Client
{
    public class InfobaseConnection : IConnection
    {
        public string InfobaseName { get; set; }
        public string ConnectionArguments => $@"/IBName ""{InfobaseName}""";
    }
}
