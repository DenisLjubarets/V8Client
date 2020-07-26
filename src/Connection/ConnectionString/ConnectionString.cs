using System.Text;

namespace V8Client
{
    abstract public class ConnectionString : IConnection
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? PriviledgedMode { get; set; }
        public bool? LicenseDistribution { get; set; }
        public virtual string ConnectionArguments => CollectArguments();

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Username))
            {
                builder.Append($"Usr={Username};");
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    builder.Append($"Pwd={Password};");
                }
            }
            if (PriviledgedMode == true) builder.Append("prmod=1;");
            if (PriviledgedMode == false) builder.Append("prmod=0;");
            if (LicenseDistribution == true) builder.Append($"LicDstr=Y;");
            if (LicenseDistribution == false) builder.Append($"LicDstr=N;");
            return builder.ToString().Trim();
        }
    }
}