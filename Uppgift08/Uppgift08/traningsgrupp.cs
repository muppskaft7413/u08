using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    public class traningsgrupp
    {
        public int grupp_id { get; set; }
        public string namn { get; set; }
        public string datum { get; set; }
        public string tid { get; set; }
        public string beskrivning { get; set; }
        public int plats { get; set; }

        public int narvarolista { get; set; }
        public int del_grupp_id { get; set; }
        public int trn_grp_id { get; set; }
        public int medlem_id { get; set; }
        public bool deltagit { get; set; }

        public string traningsgrupps
        {
            get
            {

                return namn + " " + Convert.ToDateTime(datum).ToShortDateString() + " " + Convert.ToDateTime(tid).ToShortTimeString();
            }
        }

        public string nyaGrupper
        {
            get
            {
                return namn;
            }
        }


    }
}
