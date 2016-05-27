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
        private bool sokDatIntervall = false;
        
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
                sokDatIntervall = true;
                slutDatum = dtpSlutDatum.Value;
            }   
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
            

            postgres db = new postgres();

            
            //List<language> lang = new List<language>();

            //bool fel = false;
            //string felmeddelande = "";
            //lang = db.HämtaSpråk(ref fel, ref felmeddelande);
            //dgvRapport.DataSource = lang;
            //dgvRapport.Columns.Add("apa", "header");

            //if (fel)
            //{
            //    tbFeedback.Text = felmeddelande;
            //}
            
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
