namespace V8Client
{
    public class CreateInfobaseMode : LaunchModeParameters, ILaunchMode
    {
        public IConnection Connection { get; set; }

        public string AddToListWithName { get; set; }

        public string UseTemplatePath { get; set; }

        public override string StartupArguments { get { return $"CREATEINFOBASE {Connection.ConnectionArguments} " + base.StartupArguments; } }
    }
}
