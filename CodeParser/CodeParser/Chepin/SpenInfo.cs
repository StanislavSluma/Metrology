using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParser.Chepin
{
    public class SpenInfo
    {
        public SpenInfo(string spen_id, int spen) 
        {
            Name = spen_id;
            Spen = spen;
        }

        public string Name { get; set; }
        public int Spen { get; set; }
    }
}
