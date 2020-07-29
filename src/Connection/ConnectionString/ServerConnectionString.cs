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
        public SQLServerType? SQLServerType { get; set; }
        public string SQLServerAddress { get; set; }
        public string SQLServerDatabase { get; set; }
        public string SQLServerUsername { get; set; }
        public string SQLServerPassword { get; set; }
        public int? SQLServerYearOffset { get; set; }
        public bool? CreateSQLDatabase { get; set; }
        public bool? BlockScheduledJobs { get; set; }
        public override string ConnectionArguments => CollectArguments() + base.ConnectionArguments;

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            builder.Append($@"Srvr=""{ClusterAddress}"";Ref=""{InfobaseReference}"";");
            if (!string.IsNullOrWhiteSpace(ClusterUsername))
            {
                builder.Append($@"SUsr=""{ClusterUsername}"";");
                if (!string.IsNullOrWhiteSpace(ClusterPassword))
                {
                    builder.Append($@"SPwd=""{ClusterPassword}"";");
                }
            }
            if (SQLServerType != null) builder.Append($"DBMS={SQLServerType};");
            if (!string.IsNullOrWhiteSpace(SQLServerAddress)) builder.Append($@"DBSrvr=""{SQLServerAddress}"";");
            if (!string.IsNullOrWhiteSpace(SQLServerDatabase)) builder.Append($@"DB=""{SQLServerDatabase}"";");
            if (!string.IsNullOrWhiteSpace(SQLServerUsername))
            {
                builder.Append($@"DBUID=""{SQLServerUsername}"";");
                if (!string.IsNullOrWhiteSpace(SQLServerPassword))
                {
                    builder.Append($@"DBPwd=""{SQLServerPassword}"";");
                }
            }
            if (SQLServerYearOffset != null) builder.Append($"SQLYOffs={SQLServerYearOffset};");
            if (CreateSQLDatabase != null) builder.Append("CrSQLDB=" + (CreateSQLDatabase == true ? "Y" : "N") + ";");
            if (BlockScheduledJobs != null) builder.Append("SchJobDn=" + (CreateSQLDatabase == true ? "Y" : "N") + ";");
            return builder.ToString();
        }
    }
}