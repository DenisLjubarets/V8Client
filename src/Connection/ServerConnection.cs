﻿namespace V8Client
{
    public class ServerConnection : IConnection
    {
        public string ClusterAddress { get; set; }
        public string InfobaseReference { get; set; }
        public string ConnectionArguments => $@"/S ""{ClusterAddress}\{InfobaseReference}""";
    }
}