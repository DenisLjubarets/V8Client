using System.Text;

namespace V8Client
{
    public enum PageSize
    {
        Size_4K = 4096,
        Size_8K = 8192,
        Size_16K = 16384,
        Size_32K = 32768,
        Size_64K = 65536
    }

    public class FileConnectionString : ConnectionString
    {
        public string File { get; set; }
        public string Locale { get; set; }
        public string DBFormat { get; set; }
        public PageSize DBPageSize { get; set; }
        public override string ConnectionArguments => CollectArguments() + base.ConnectionArguments;

        private string CollectArguments()
        {
            var builder = new StringBuilder();
            builder.Append($@"File=""{File}"";");
            if (!string.IsNullOrWhiteSpace(Locale)) builder.Append($"Locale={Locale};");
            if (!string.IsNullOrWhiteSpace(DBFormat)) builder.Append($"Locale={DBFormat};");
            builder.Append($"DBPageSize={(int)DBPageSize};");
            return builder.ToString().Trim();
        }
    }
}