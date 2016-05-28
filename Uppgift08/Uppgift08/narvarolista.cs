using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    class narvarolista
    {
        public string fornamn { get; set; }
        public string efternamn { get; set; }
        public string personnummer { get; set; }
        public bool deltagit { get; set; }
        private DataTable _tabellNarvaro;
        postgres narvaroPost = new postgres();

        /// <summary>
        /// Hämtar närvarolista.
        /// </summary>
        /// <param name="fel"></param>
        /// <param name="felmeddelande"></param>
        /// <param name="datum">Datum måste läggas in som en parameter.</param>
        /// <param name="namn">Namn måste läggas in som en parameter.</param>
        /// <returns>DataTable med närvarolistan.</returns>
        public List<narvarolista> getNarvarolista(ref bool fel, ref string felmeddelande, string datum, string namn)
        {
            string sql = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + datum + "' and traningsgrupp.namn = '" + namn + "'";
            _tabellNarvaro = narvaroPost.sqlFråga(sql);

            List<narvarolista> narvarolistan = new List<narvarolista>();
            if (_tabellNarvaro.Columns[0].ColumnName.Equals("error"))
            {

                narvarolista narvarolistaFel = new narvarolista();
                narvarolistan.Add(narvarolistaFel);
                fel = true;
                felmeddelande = _tabellNarvaro.Rows[0][1].ToString();

            }
            else
            {
                narvarolista narvarolistaRatt;
                for (int i = 0; i < _tabellNarvaro.Rows.Count; i++)
                {
                    narvarolistaRatt = new narvarolista()
                    {
                        fornamn = _tabellNarvaro.Rows[i]["fnamn"].ToString(),
                        efternamn = _tabellNarvaro.Rows[i]["enamn"].ToString(),
                        personnummer = _tabellNarvaro.Rows[i]["pnr"].ToString(),
                        deltagit = (bool)_tabellNarvaro.Rows[i]["deltagit"]
                    };
                    narvarolistan.Add(narvarolistaRatt);
                }

            }
            return narvarolistan;
        }

        //public List<narvarolista> setNarvaro (ref bool fel, ref string felmeddelande, string medlem, string grupp, string narvaro, string datum, string namn)
        //{
        //    string sql = "update deltagare set deltagit = '1' where grupp_id = '"+grupp+"' and medlem_id = '"+medlem+"' and narvarolista_id = '"+narvaro+"'";
        //    _tabellNarvaro = narvaroPost.sqlfråga(sql);
        //    string sql2 = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + datum + "' and traningsgrupp.namn = '" + namn + "'";
        //    _tabellNarvaro = narvaroPost.sqlfråga(sql2);

        //    List<narvarolista> narvarolistan = new List<narvarolista>();
        //    if (_tabellNarvaro.Columns[0].ColumnName.Equals("error"))
        //    {

        //        narvarolista narvarolistaFel = new narvarolista();
        //        narvarolistan.Add(narvarolistaFel);
        //        fel = true;
        //        felmeddelande = _tabellNarvaro.Rows[0][1].ToString();

        //    }
        //    else
        //    {
        //        narvarolista narvarolistaRatt;
        //        for (int i = 0; i < _tabellNarvaro.Rows.Count; i++)
        //        {
        //            narvarolistaRatt = new narvarolista()
        //            {
        //                fornamn = _tabellNarvaro.Rows[i]["fnamn"].ToString(),
        //                efternamn = _tabellNarvaro.Rows[i]["enamn"].ToString(),
        //                personnummer = _tabellNarvaro.Rows[i]["pnr"].ToString(),
        //                deltagit = (bool)_tabellNarvaro.Rows[i]["deltagit"]
        //            };
        //            narvarolistan.Add(narvarolistaRatt);
        //        }

        //    }
        //    return narvarolistan;
        //}
    }
}
