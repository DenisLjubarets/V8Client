using System.Text;

namespace V8Client
{
    public enum SQLServerType
    {
        MSSQLServer, PostgreSQL, IBMDB2, OracleDatabase
    }

    public class ServerConnectionString : ConnectionString
    {
        public string ClusterAddress { get; set; }
        public string InfobaseReference { get; set; }
        public string ClusterUsername { get; set; }
        public string ClusterPassword { get; set; }
        public SQLServerType SQLServerType { get; set; }
        public string SQLServerAddress { get; set; }
        public string SQLServerDatabase { get; set; }
        public string SQLServerUsername { get; set; }
        public string SQLServerPassword { get; set; }
        public int? SQLServerYearOffset { get; set; }
        public bool CreateSQLDatabase { get; set; }
        public bool BlockScheduledJobs { get; set; }
        public override string ConnectionArguments => CollectArguments() + base.ConnectionArguments;

        private string CollectArguments()
        {
            var builder = new StringBuilder();

            builder.Append($@"Srvr=""{ClusterAddress}"";Ref=""{InfobaseReference}"";");
            builder.Append("CrSQLDB=" + (CreateSQLDatabase ? "Y" : "N") + ";");
            builder.Append("SchJobDn=" + (BlockScheduledJobs ? "Y" : "N") + ";");
            builder.Append($"DBMS={SQLServerType};");
            builder.Append($"DB={SQLServerAddress};");

            if (!string.IsNullOrWhiteSpace(ClusterUsername))
            {
                builder.Append($"SUsr={ClusterUsername};");
                if (!string.IsNullOrWhiteSpace(ClusterPassword))
                {
                    builder.Append($"SPwd={ClusterPassword};");
                }
            }

            if (!string.IsNullOrWhiteSpace(SQLServerUsername))
            {
                builder.Append($"SUsr={SQLServerUsername};");
                if (!string.IsNullOrWhiteSpace(SQLServerPassword))
                {
                    builder.Append($"SPwd={SQLServerPassword};");
                }
            }

            if (SQLServerYearOffset != null) builder.Append($"SQLYOffs={SQLServerYearOffset};");

            return builder.ToString();
        }
    }
}