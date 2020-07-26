using System.Text;

namespace V8Client
{
    public abstract class EnterpriseParameters : CommonParameters
    {
        public override string GenerateArguments()
        {
            var builder = new StringBuilder();
            builder.Append($"ENTERPRISE {Connection.ConnectionArguments} ");
            return builder.ToString() + base.GenerateArguments();
        }
    }
}