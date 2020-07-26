using System;

namespace V8Client
{
    public class WebServerConnection : IConnection
    {
        public Uri Uri { get; set; }
        public string ConnectionArguments => $@"/WS ""{Uri.AbsoluteUri}""";
    }
}