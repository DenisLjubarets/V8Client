using System.Text;

namespace V8Client
{
    public abstract class ConnectionString : IConnection
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Locale { get; set; }
        public bool? PriviledgedMode { get; set; }
        public bool? LicenseDistribution { get; set; }
        public virtual string ConnectionArguments => CollectArguments();

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Username))
            {
                builder.Append($@"Usr=""{Username}"";");
                if (!string.IsNullOrWhiteSpace(Password))
                {
                    builder.Append($@"Pwd=""{Password}"";");
                }
            }
            if (!string.IsNullOrWhiteSpace(Locale)) builder.Append($"Locale={Locale};");
            if (PriviledgedMode == true) builder.Append("prmod=1;");
            if (PriviledgedMode == false) builder.Append("prmod=0;");
            if (LicenseDistribution == true) builder.Append($"LicDstr=Y;");
            if (LicenseDistribution == false) builder.Append($"LicDstr=N;");
            return builder.ToString().Trim();
        }
    }
}