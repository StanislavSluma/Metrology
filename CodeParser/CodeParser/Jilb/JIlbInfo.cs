
namespace CodeParser.Jilb
{
    public class JIlbInfo
    {
        public JIlbInfo(int CL, int cl, int CLI)
        {
            this.CL = CL;
            this.CLI = CLI;
            this.cl = cl;
        }

        public int CL { get { return CL; } set { CL = value; } }
        public int CLI { get { return CLI; } set { CLI = value; } }
        public int cl { get { return cl; } set { cl = value; } }
    }
}
