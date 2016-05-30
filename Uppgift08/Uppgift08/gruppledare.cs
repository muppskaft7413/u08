using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    class gruppledare
    {
        public string förnamn { get; set; }
        public string efternamn { get; set; }

        public string a;
        public string b;

        public string helaGruppledaren
        {
            get
            {
                return "ledare " + förnamn + " " + efternamn;
            }
        }

        public string forOchEftNamn
        {
            get
            {
                return förnamn + " " + efternamn;
            }
        }

    }
}
