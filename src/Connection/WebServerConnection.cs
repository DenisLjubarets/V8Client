using System;

namespace V8Client
{
    public class WebServerConnection : IConnection
    {
        public Uri Uri { get; set; }

        public string ConnectionArguments { get { return $@"/WS ""{Uri.AbsoluteUri}"""; } }
    }
}
