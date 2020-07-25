namespace V8Client
{
    public class FileConnection : IConnection
    {
        public string InfobaseDirectory { get; set; }

        public string ConnectionArguments { get { return $@"/F ""{InfobaseDirectory}"""; } }
    }
}
