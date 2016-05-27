using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08
{
    class intressent
    {
        public int intressent_id { get; set; }
        public string namn { get; set; }
        public string epost { get; set; }
        public string telefon { get; set; }
        private DataTable _tabellIntressent;

        postgres nyPostGress = new postgres();


        /// <summary>
        /// Metod som uppdaterar en intressent.
        /// </summary>
        /// <returns>intressent med nya uppgifter.</returns>
        public void uppdatera()
        {
            //return null;
        }

        /// <summary>
        /// Lägger till en ny intressent.
        /// </summary>
        /// <returns>ny intressent</returns>
        public void laggTill()
        {
            //return null;
        }

        /// <summary>
        /// ta bort en intressent
        /// </summary>
        /// <returns>Färre intressenter</returns>
        public void taBort()
        {
            //return null;
        }

/// <summary>
/// Hämtar alla intressenter 
/// </summary>
/// <param name="fel">Kollar om det är fel</param>
/// <param name="felmeddelande">Skickar felmeddelandet</param>
/// <returns>Lista med intressenter</returns>
        public List<intressent> getIntressenter(ref bool fel, ref string felmeddelande)
        {
            string sql = "select language_id as \"la.language_id\", name as \"la.name\" from language la";
            _tabellIntressent = nyPostGress.sqlfråga(sql);

            List<intressent> intressenter = new List<intressent>();
            if (_tabellIntressent.Columns[0].ColumnName.Equals("error"))
            {

                intressent intressFel = new intressent();
                intressenter.Add(intressFel);
                fel = true;
                felmeddelande = _tabellIntressent.Rows[0][1].ToString();

            }
            else
            {
                intressent intress;
                for (int i = 0; i < _tabellIntressent.Rows.Count; i++)
                {
                    intress = new intressent()
                    {
                        intressent_id = (int)_tabellIntressent.Rows[i]["la.language_id"],
                        namn = _tabellIntressent.Rows[i]["la.name"].ToString(),
                        epost = _tabellIntressent.Rows[i]["la.name"].ToString(),
                        telefon = _tabellIntressent.Rows[i]["la.name"].ToString()
                    };
                    intressenter.Add(intress);
                }

            }
            return intressenter;
        }

    }
}
