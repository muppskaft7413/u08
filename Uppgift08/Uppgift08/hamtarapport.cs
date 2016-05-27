using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift08
{
    public partial class hamtarapport : Form
    {
        private DateTime startDatum;
        private DateTime slutDatum;
        
        public hamtarapport()
        {
            InitializeComponent();
            dtpSlutDatum.Enabled = false;
            dtpSlutDatum.Value = dtpStartDatum.Value.AddDays(1);
        }

        /// <summary>
        /// Kontrollerar ifall man vill söka med datumintervall och hämtar upp värden
        /// sokDatIntervall sätts till true om så är fallet.
        /// </summary>
        private void checkIntervallSok()
        {
            if (cbAktivSlutDatum.Checked)
            {
                slutDatum = dtpSlutDatum.Value;
            }  
        }

        /// <summary>
        /// Reder ut vilken SQL-sats som skall skickas till servern
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
                    sql = "select distinct traningsgrupp.grupp_id, namn, datum from traningsgrupp join deltagare on deltagare.grupp_id = traningsgrupp.grupp_id join trantillf on deltagare.narvarolista_id = trantillf.narvarolista_id WHERE trantillf.datum = '" + startDatum + "' group by traningsgrupp.grupp_id, namn, datum;";
                    break;
                case "sokNarv":
                    //sql = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + datum + "' and traningsgrupp.namn = 'Enhjuling'";
                    sql = "select fnamn, enamn, pnr, deltagit from medlem join deltagare on deltagare.medlem_id = medlem.medlem_id join traningsgrupp on traningsgrupp.grupp_id = deltagare.grupp_id join trantillf on trantillf.narvarolista_id = deltagare.narvarolista_id where trantillf.datum = '" + startDatum.ToShortDateString() + "' and traningsgrupp.namn = 'Enhjuling'";
                    break;
            }

            return sql;
        }

        /// <summary>
        /// Skickar SQL-frågan till databasen med hjälp av postgres-klassen
        /// </summary>
        /// <param name="sokTyp"></param>
        /// <returns>DataTable datatyp</returns>
        private DataTable getSome(string sokTyp)
        {
            DataTable _tabellSvar;
            postgres nyPostGres = new postgres();

            _tabellSvar = nyPostGres.sqlfråga(vilkenSqlFraga(sokTyp));

            return _tabellSvar;
        }
        
// ############# EVENT HANDLERS ##############

        //Stänger närvarorapporteringsfönstret
        private void btn_klar_Click(object sender, EventArgs e)
        {
            this.Close();                                               // stänger detta fönster
        }


        // Startar en sökning baserad på valda sökkriterier
        private void btnSok_Click(object sender, EventArgs e)
        {
            startDatum = dtpStartDatum.Value;           // Hämtar startdatumet för sök
            checkIntervallSok();                        // Kontrollerar för att söka i datumintervall
            bool fel = false;
            string felmeddelande = "";
            DataTable svarGrupp;
            DataTable svarNarvaro;
            DataTable svarNarvarolista;

            string sokInGrp = "sokInGrp";
            string sokGrp = "sokGrp";
            string sokNarv = "sokNarv";

            // outputen blir bara massa gibberish nu för att det är tabellens header som spottas ut och inte innehållet i kolumnerna. TO-DO!!!
            svarGrupp = getSome(sokInGrp);          // hämtar sökning efter träningsgrupper
            svarNarvaro = getSome(sokNarv);         // hämtar sökning efter närvaro
            lbxGrupper.DataSource = null;
            dgvRapport.DataSource = null;
            lbxGrupper.DataSource = svarGrupp;      // ska ersättas med ett objekt av traningsgrupper-klassen, kod ej klart för att hacka upp tabell =(
            dgvRapport.DataSource = svarNarvaro;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(

            if (fel)
            {
                MessageBox.Show(felmeddelande);
            }
            
        }



        // Aktivererar/deaktiverar datetimepicker för slutdatum
        private void cbAktivSlutDatum_CheckedChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Enabled == false)
            {
                dtpSlutDatum.Enabled = true;
            }
            else
            {
                dtpSlutDatum.Enabled = false;
            }
        }

        /// <summary>
        /// Kontrollerar så att funktionen som väljer slutdatum 
        /// om man vill göra sökintervall ej är mindre än startdatumet.
        /// Är den mindre returneras ett meddelande i feedbackfältet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSlutDatum_ValueChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Value <= dtpStartDatum.Value)
            {
                dtpSlutDatum.Value = dtpStartDatum.Value.AddHours(24);
                tbFeedback.Text = "Slutdatumet måste vara minst en dag mer än startdatumet.";
            }
            else
            {
                tbFeedback.Clear();   // rensar feedbackfältet
            }
        }

        // ändrar man startdatum till högre än slutdatum så ändras slutdatum till en dag mer än startdatum
        private void dtpStartDatum_ValueChanged(object sender, EventArgs e)
        {
            if(dtpStartDatum.Value >= dtpSlutDatum.Value)
            {
                dtpSlutDatum.Value = dtpStartDatum.Value.AddDays(1);
            }

        }
    }
}
