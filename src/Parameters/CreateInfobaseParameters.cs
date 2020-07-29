using System.Text;

namespace V8Client
{
    public class CreateInfobaseParameters : CommonParameters
    {
        public new ConnectionString Connection { get; set; }
        public string TemplateFile { get; set; }
        public string DumpResultFile { get; set; }
        public string AddToListWithName { get; set; }

        public override string GenerateArguments()
        {
            var builder = new StringBuilder();
            builder.Append($"CREATEINFOBASE {Connection.ConnectionArguments} ");
            if (!string.IsNullOrWhiteSpace(TemplateFile)) builder.Append($@"/UseTemplate ""{TemplateFile}"" ");
            if (!string.IsNullOrWhiteSpace(DumpResultFile)) builder.Append($@"/DumpResult ""{DumpResultFile}"" ");
            if (!string.IsNullOrWhiteSpace(AddToListWithName)) builder.Append($@"/AddToList ""{AddToListWithName}"" ");
            return (builder.ToString() + base.GenerateArguments()).Trim();
        }
    }
}