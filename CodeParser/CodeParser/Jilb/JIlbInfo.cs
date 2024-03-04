
namespace CodeParser.Jilb
{
    public class JIlbInfo
    {
        public JIlbInfo(string key, double value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public double Value { get; set; }
    }
}
