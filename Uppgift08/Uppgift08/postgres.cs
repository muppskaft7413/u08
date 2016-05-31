using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift08 
{
    class postgres
    {
        private NpgsqlConnection _conn;
        private NpgsqlCommand _cmd;
        private NpgsqlDataReader _dr;
        private DataTable _tabell;

        public List<string> ledare { get; set; }
        public List<string> grupp { get; set; }
        public DateTime slutDatum { get; set; }          // Gör man datumintervallsökning behöver båda dessa DateTime-properties
        public DateTime startDatum { get; set; }         // få ett värde då objekt skapas av klassen. slutDatum måste alltid
                                                         // få ett värde.
        string nyaGrupper;                               //variabel där frågeställningssträng lagras.
        private string nyaLedare;                        //variabel där frågeställningssträng lagras.


        /// <summary>
        /// Metod som omvandlar hämtade ledare till sträng med rätt frågeställning.
        /// </summary>
        /// <param name="hamtadLista"></param>
        /// <returns>string med sqlfrågetillägg</returns>
        private string antalLedare(List<string> hamtadLista)
        {

            List<string> ledarLista = new List<string>();
            foreach (string item in hamtadLista)
            {

                ledarLista.Add("medlem.medlem_id = '" + item + "'");
            }

            for (int i = 0; i < ledarLista.Count; i++)
            {
                if (i == 0)
                {
                    nyaLedare = ledarLista[i];
                }
                else
                {
                    nyaLedare = nyaLedare + " OR " + ledarLista[i];
                }
            }
            //gruppas = "traningsgrupp.namn = 'Enhjuling'";
            return nyaLedare;
        }

        /// <summary>
        /// Metod som omvandlar hämtade grupper till sträng med rätt frågeställning.
        /// </summary>
        /// <param name="hamtadLista"></param>
        /// <returns>string med sqlfrågetillägg</returns>
        private string antalGrupper(List<string> hamtadLista)
        {

            List<string> gruppLista = new List<string>();
            foreach (string item in hamtadLista)
            {

                gruppLista.Add("traningsgrupp.namn = '" + item + "'");                
            }

            for (int i = 0; i < gruppLista.Count; i++)
            {
                if (i == 0)
                {
                    nyaGrupper = gruppLista[i];
                }
                else
                {
                    nyaGrupper = nyaGrupper + " OR " + gruppLista[i];
                }
            }
            //gruppas = "traningsgrupp.namn = 'Enhjuling'";
            return nyaGrupper;
        }

        /// <summary>
        /// Reder ut vilka sökparametrar som skall användas och returnerar
        /// ett unikt "kodord" som motsvarar detta.
        /// </summary>
        /// <param name="sokDatInterv"></param>
        /// <param name="sokGrupp"></param>
        /// <param name="sokLedare"></param>
        /// <returns>Datatyp String</returns>
        public string vilkenSokning(bool sokDatInterv, bool sokGrupp, bool sokLedare)
        {
            string resultat = "sokNarv";

            if (!sokDatInterv && !sokGrupp && !sokLedare)                            // enbart söka enkeldatum
            {
                resultat = "datEnk";
            }
            else if (sokDatInterv && !sokGrupp && !sokLedare)                       // enbart söka datumintervall
            {
                resultat = "datInt";
            }
            else if (!sokDatInterv && sokGrupp && !sokLedare)                        // söka enkeldatum och grupp
            {
                resultat = "datEnkGrp";
            }
            else if (sokDatInterv && sokGrupp && !sokLedare)                        // söka datumintervall och grupp
            {
                resultat = "datIntGrp";
            }
            else if (!sokDatInterv && sokGrupp && sokLedare)                        // sök enkeldatum, grupp och ledare
            {
                resultat = "datEnkGrpLed";
            }
            else if (sokDatInterv && sokGrupp && sokLedare)                        // sök datumintervall, grupp och ledare
            {
                resultat = "datIntGrpLed";
            }
            else if (!sokDatInterv && !sokGrupp && sokLedare)                        // sök enkeldatum och ledare
            {
                resultat = "datEnkLed";
            }
            else if (sokDatInterv && !sokGrupp && sokLedare)                        // sök datumintervall och ledare
            {
                resultat = "datIntLed";
            }

            return resultat;
        }


        /// <summary>
        /// Metod för att ställa fråga mot sql.
        /// Input till metoden är ett "kodord" som
        /// metoden vilkenSqlFraga() behöver för att kunna avgöra vilket
        /// värde den skall ge till variabeln sql, som i sin tur blir den
        /// SQL-fråga som skickas till databasen.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>tabell där svaren lagras</returns>
        public DataTable sqlFråga(string sokparameter, string soktyp)
        {
            string sql;
            sql = vilkenSqlFraga(sokparameter, soktyp);

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
        /// <param name="sokparameter"></param>
        /// <returns>string datatyp med SQL-sats</returns>
        private string vilkenSqlFraga(string sokparameter, string soktyp)
        {
            string sql = "";

            if (soktyp == "grupp")
            {
                switch (sokparameter)
                {
                case "datInt": // Datumintervallsökning som återger vilka träningsgrupper som tränar inom ett datumintervall
                    sql = "select distinct traningsgrupp.grupp_id, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "';";
                    break;
                case "datEnk": // Enkel datumsökning som återger vilka träningsgrupper som tränar ett visst datum
                    sql = "select distinct traningsgrupp.grupp_id, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum = '" + startDatum.ToShortDateString() + "';";
                    break;
                case "datEnkLed":
                    string sokLedare1 = antalLedare(ledare); //omvandlar Listboxobjekt av markerad(e) ledare och returnerar en SQL-anpassad textsträng med dessa
                    sql = "SELECT DISTINCT traningsgrupp.grupp_id, namn FROM traningsgrupp JOIN deltagare ON deltagare.grupp_id = traningsgrupp.grupp_id JOIN trantillf ON deltagare.narvarolista_id = trantillf.narvarolista_id JOIN gruppledare ON traningsgrupp.grupp_id = gruppledare.grupp JOIN medlem ON medlem.medlem_id = gruppledare.ledare WHERE trantillf.datum = '" + startDatum.ToShortDateString() + "' AND " + sokLedare1 + ";";
                    break;
                case "datIntLed":
                    string sokLedare2 = antalLedare(ledare); //omvandlar Listboxobjekt av markerad(e) ledare och returnerar en SQL-anpassad textsträng med dessa
                    sql = "SELECT DISTINCT traningsgrupp.grupp_id, namn FROM traningsgrupp JOIN deltagare ON deltagare.grupp_id = traningsgrupp.grupp_id JOIN trantillf ON deltagare.narvarolista_id = trantillf.narvarolista_id JOIN gruppledare ON traningsgrupp.grupp_id = gruppledare.grupp JOIN medlem ON medlem.medlem_id = gruppledare.ledare WHERE trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' AND " + sokLedare2 + ";";
                    break;

                        
                }
            }
            else if (soktyp == "ledare")  // söker ledare baserat på vilken grupp som är markerad i grupplistan.
            {
                switch (sokparameter)
                {
                    case "datEnk":
                        //sql = "select fnamn, enamn FROM medlem JOIN gruppledare ON gruppledare.ledare = medlem.medlem_id JOIN traningsgrupp ON traningsgrupp.grupp_id = gruppledare.grupp WHERE " + sokGrupper;
                        sql = "select distinct gruppledare.ledare, medlem.fnamn, medlem.enamn FROM medlem JOIN gruppledare ON gruppledare.ledare = medlem.medlem_id JOIN traningsgrupp ON traningsgrupp.grupp_id = gruppledare.grupp JOIN deltagare ON deltagare.grupp_id = traningsgrupp.grupp_id JOIN trantillf ON trantillf.narvarolista_id = deltagare.narvarolista_id WHERE trantillf.datum = '" + startDatum.ToShortDateString() + "';";
                        break;
                    case "datInt":
                        //sql = "select fnamn, enamn FROM medlem JOIN gruppledare ON gruppledare.ledare = medlem.medlem_id JOIN traningsgrupp ON traningsgrupp.grupp_id = gruppledare.grupp WHERE " + sokGrupper;
                        sql = "select distinct gruppledare.ledare, medlem.fnamn, medlem.enamn FROM medlem JOIN gruppledare ON gruppledare.ledare = medlem.medlem_id JOIN traningsgrupp ON traningsgrupp.grupp_id = gruppledare.grupp JOIN deltagare ON deltagare.grupp_id = traningsgrupp.grupp_id JOIN trantillf ON trantillf.narvarolista_id = deltagare.narvarolista_id WHERE trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "';";
                        break;

                }
                
            }
            else if (soktyp == "narvaro")
            {
                string sokGrupper = antalGrupper(grupp); //Kallar på metoden antalgrupper
                switch (sokparameter)
                {
                    case "datEnkGrp":
                        //sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and traningsgrupp.namn = '" + grupp + "'";
                        sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and " + sokGrupper;
                        break;
                    case "datIntGrp":
                        //sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' and traningsgrupp.namn = '" + grupp + "'";
                        sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' AND " + sokGrupper;
                        break;
                    case "datEnkGrpLed":
                        //sql = "select fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and " + sokGrupper;
                        sql = "select distinct fnamn, enamn, pnr, medlem.medlem_id from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and " + sokGrupper;
                        break;
                    case "datIntGrpLed":
                        //sql = "select distinct fnamn, enamn, pnr, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' and " + sokGrupper;
                        sql = "select distinct fnamn, enamn, pnr, medlem.medlem_id from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' and " + sokGrupper;
                        break;
                }

            }
            else if (soktyp == "jamfor")
            {
                string sokGrupper = antalGrupper(grupp); //Kallar på metoden antalgrupper
                switch (sokparameter)
                {
                    case "datEnkGrpLed":
                        sql = "select fnamn, enamn, pnr, medlem.medlem_id, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and " + sokGrupper;
                        break;
                    case "datIntGrpLed":
                        sql = "select distinct fnamn, enamn, pnr, medlem.medlem_id, deltagare.narvarolista_id, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum >= '" + startDatum.ToShortDateString() + "' AND trantillf.datum <= '" + slutDatum.ToShortDateString() + "' and " + sokGrupper;
                        break;
                }

            }


            return sql;
        }

    }
}
