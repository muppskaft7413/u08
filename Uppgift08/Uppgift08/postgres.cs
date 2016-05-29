using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift08 
{
    class postgres
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _cmd;
        private NpgsqlDataReader _dr;
        private DataTable _tabell;

        public string grupp { get; set; }
        public DateTime slutDatum { get; set; }          // Gör man datumintervallsökning behöver båda dessa DateTime-properties
        public DateTime startDatum { get; set; }         // få ett värde då objekt skapas av klassen. slutDatum måste alltid
                                                    // få ett värde.

        ///// <summary>
        ///// konstruktor som öppnar en connection mot databasen så fort en instans skapas av klassen.
        ///// </summary>
        public postgres()
        {
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
            _conn.Open();
            _tabell = new DataTable();
        }


        /// <summary>
        /// Metod för att ställa fråga mot sql.
        /// Input till metoden är ett textsträngskommando som
        /// metoden vilkenSqlFråga() behöver för att kunna avgöra vilket
        /// värde den skall ge till variabeln sql, som i sin tur blir den
        /// SQL-fråga som skickas till databasen.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>tabell där svaren lagras</returns>
        public DataTable sqlFråga(string sokTyp)
        {
            string sql;
            sql = vilkenSqlFraga(sokTyp);

            // Öppnar anslutning mot databasen.  
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
            _conn.Open();
            _tabell = new DataTable();

            try
            {
                _cmd = new NpgsqlCommand(sql, _conn);
                _dr = _cmd.ExecuteReader();
                _tabell.Load(_dr);
                return _tabell;
            }
            catch (NpgsqlException ex)
            {
                DataColumn c1 = new DataColumn("error");
                DataColumn c2 = new DataColumn("errorMessage");

                c1.DataType = System.Type.GetType("System.Boolean");
                c2.DataType = System.Type.GetType("System.String");

                _tabell.Columns.Add(c1);
                _tabell.Columns.Add(c2);

                DataRow rad = _tabell.NewRow();
                rad[c1] = true;
                rad[c2] = ex.Message;
                _tabell.Rows.Add(rad);

                return _tabell;
            }
            finally
            {
                _conn.Close();
            }
        }

        /// <summary>
        /// Reder ut vilken SQL-sats som metoden sqlfråga() skall skicka till servern
        /// </summary>
        /// <param name="soktyp"></param>
        /// <returns>string datatyp med SQL-sats</returns>
        private string vilkenSqlFraga(string soktyp)
        {
            string sql = "";

            switch (soktyp)
            {
                case "sokInGrp":
                    sql = "select distinct traningsgrupp.grupp_id, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' group by traningsgrupp.grupp_id, namn, datum;";
                    break;
                case "sokGrp":
                    sql = "select distinct traningsgrupp.grupp_id, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum = '" + startDatum.ToShortDateString() + "' group by traningsgrupp.grupp_id, namn, datum;";
                    break;
                case "sokNarv":
                    //sql = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + datum + "' and traningsgrupp.namn = 'Enhjuling'";
                    sql = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and traningsgrupp.namn = 'Enhjuling'";
                    break;
                case "sokNarvAdv":
                    sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and traningsgrupp.namn = '" + grupp + "'";
                    break;
            }

            return sql;
        }
    }
}
