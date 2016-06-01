using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    class traningsgrupp
    {
        public int grupp_id { get; set; }
        public string namn { get; set; }
        public string datum { get; set; }
        public string tid { get; set; }
        public string beskrivning { get; set; }

        public string traningsgrupps
        {
            get
            {
                return namn + tid;
            }
        }


    }
}
