namespace V8Client
{
    public class EnterpriseMode : LaunchModeParameters, ILaunchMode
    {
        public IConnection Connection { get; set; }

        public override string StartupArguments { get { return $"ENTERPRISE {Connection.ConnectionArguments} {base.StartupArguments}".Trim(); } }
    }
}
