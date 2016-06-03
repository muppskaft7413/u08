using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    public class gruppmedlemmar
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Personnummer { get; set; }
        public bool deltagit { get; set; }
        public string narvaro { get; set; }
        public string gruppnamn { get; set; }
        public string medlemId { get; set; }
        public string datum { get; set; }
        public string start { get; set; }
        public string slut { get; set; }
        public string gruppId { get; set; }


        public string redanGruppMedlemmar
        {
            get
            {

                return Förnamn + " " + Efternamn + "\t" + Personnummer;
            }
        }

        public string forEftNamn
        {
            get
            {

                return Förnamn + " " + Efternamn;
            }
        }

    }
}
