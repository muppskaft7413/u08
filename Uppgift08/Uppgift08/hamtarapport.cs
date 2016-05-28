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
         string felSlutDatum = "Slutdatumet måste vara minst en dag mer än startdatumet.";
        
        // konstruktor
        public hamtarapport()
        {
            InitializeComponent();
            dtpSlutDatum.Enabled = false;
            cbAktivSlutDatum.Checked = false;
            dtpSlutDatum.Value = dtpStartDatum.Value.AddDays(1);
        }

        
        
        /// <summary>
        /// Denna metod kör igång en sökning i databasen utefter
        /// de sökparametrar som är aktuella.
        /// </summary>
        private void sok()
        {
            DataTable sokningResultat;
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade

            postgres s = new postgres();                                                        // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = dtpStartDatum.Value;
            s.slutDatum = dtpSlutDatum.Value;

            //sökning
            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare));   //case finns för "sokInGrp", "sokGrp" eller "sokNarv" i postrges

            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut

                //lbxGrupper.DataSource = svarGrupp;      // ska ersättas med ett objekt av traningsgrupper-klassen, kod ej klart för att hacka upp tabell =(
                dgvRapport.DataSource = sokningResultat;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(
                dgvRapport.ReadOnly = true;
            }
        }

        #region ############# EVENT HANDLERS ##############

        //Stänger närvarorapporteringsfönstret
        private void btn_klar_Click(object sender, EventArgs e)
        {
            this.Close();                                               // stänger detta fönster
        }

        /// <summary>
        /// 1. Aktivererar/deaktiverar datetimepicker för slutdatum.
        /// 2. Om en aktivering sker så görs en sökning i databasen utefter
        ///    de sökparametrar som är aktuella.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbAktivSlutDatum_CheckedChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Enabled == false)
            {
                dtpSlutDatum.Enabled = true;
                sok();
            }
            else
            {
                dtpSlutDatum.Enabled = false;
            }
        }

        /// <summary>
        /// 1. Kontrollerar så att dtpSlutDatum ej är mindre eller samma 
        ///    som dtpStartDatum. Är den det sätts dtpSlutDatum automatiskt
        ///    till en dag senare än dtpStartDatum. Felmeddelande genereras
        ///    till feedbackfältet!
        /// 2. Om allt är OK så görs istället en sökning i databasen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpSlutDatum_ValueChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Value <= dtpStartDatum.Value)
            {
                dtpSlutDatum.Value = dtpStartDatum.Value.AddHours(24);
                tbFeedback.Text = felSlutDatum;
            }
            else
            {
                tbFeedback.Clear();   // rensar feedbackfältet
                sok();
            }
        }

        /// <summary>
        /// 1. Ändrar man startdatum till högre än slutdatum 
        ///    så ändras slutdatum till en dag mer än startdatum.
        /// 2. Sökning görs i databasen på aktuella sökparametrar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartDatum_ValueChanged(object sender, EventArgs e)
        {
            if(dtpStartDatum.Value >= dtpSlutDatum.Value)
            {
                dtpSlutDatum.Value = dtpStartDatum.Value.AddDays(1);
            }
            sok();
        }
        #endregion
    }
}
