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

        public string gruppledaren
        {
            get
            {
                return "ledare " + förnamn + " " + efternamn;
            }
        }
    }
}
