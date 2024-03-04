using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.Chepin
{
    public class ChepinInfo
    {
        public ChepinInfo(string name, string pfull, string mfull, string cfull, string tfull, string pio, string mio, string cio, string tio) 
        {
            Name = name;
            PFULL = pfull;
            MFULL = mfull;
            CFULL = cfull;
            TFULL = tfull;
            PIO = pio;
            MIO = mio;
            CIO = cio;
            TIO = tio;
        }
        public string Name {  get; set; }
        public string PFULL { get; set; }
        public string MFULL { get; set; }
        public string CFULL {  get; set; }
        public string TFULL { get; set; }
        public string PIO {  get; set; }
        public string MIO {  get; set; }
        public string CIO { get; set; }
        public string TIO { get; set; }
    }
}
