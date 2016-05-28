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
        public string beskrivning { get; set; }
        public object tid { get; set; }

        public string traningsgrupps
        {
            get
            {
                return namn;
            }
        }

        private DataTable _tabellGrupp;

        postgres nyPostGress = new postgres();

        public List<traningsgrupp> getTraningsgrupp(ref bool fel, ref string felmeddelande, string datum)
        {
            //string sql = "select fnamn, enamn, pnr, namn, datum, starttid, sluttid, deltagit, trantillf.narvarolista_id from trantillf JOIN deltagare ON trantillf.narvarolista_id = deltagare.narvarolista_id JOIN medlem ON deltagare.medlem_id = medlem.medlem_id JOIN traningsgrupp ON deltagare.grupp_id = traningsgrupp.grupp_id WHERE trantillf.datum >= '2016-02-26' and trantillf.datum <= '2016-05-30';";

            string sql = "select traningsgrupp.grupp_id, starttid, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum = '"+datum+"' group by traningsgrupp.grupp_id, namn, datum, starttid;";
            _tabellGrupp = nyPostGress.sqlfråga(sql);

            List<traningsgrupp> traningsgrupp = new List<traningsgrupp>();
            if (_tabellGrupp.Columns[0].ColumnName.Equals("error"))
            {

                traningsgrupp traningFel = new traningsgrupp();
                traningsgrupp.Add(traningFel);
                fel = true;
                felmeddelande = _tabellGrupp.Rows[0][1].ToString();

            }
            else
            {
                traningsgrupp traningsgruppRatt;
                for (int i = 0; i < _tabellGrupp.Rows.Count; i++)
                {
                    traningsgruppRatt = new traningsgrupp()
                    {
                        namn = (string)_tabellGrupp.Rows[i]["namn"],
                        tid = _tabellGrupp.Rows[i]["starttid"]
                    };
                    traningsgrupp.Add(traningsgruppRatt);
                }

            }
            return traningsgrupp;
        }

    }
}
