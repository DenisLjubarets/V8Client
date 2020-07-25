namespace V8Client
{
    public interface ILaunchMode : IParameter
    {
        public IConnection Connection { get; set; }
    }
}
