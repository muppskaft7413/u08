﻿using System;
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

            string soktyp = "";

            postgres s = new postgres();                                                        // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = dtpStartDatum.Value;
            s.slutDatum = dtpSlutDatum.Value;

            //for (int i = 0; i < 3; i++)
            for (int i = 0; i < 2; i++)
            {

                // ovan iteration körs 3ggr, vilket nedan kommer generar 3 olika sökningar (dvs efter grupp, ledare eller narvaro).
                if (i == 0)
                {
                    soktyp = "grupp";
                }
                else if (i == 1)
                {
                    soktyp = "ledare";
                }
                else
                {
                    soktyp = "narvaro";
                }

                // sökning i db görs här, svaret skickas tillbaka in i tabellen sokningResultat som har datatypen DataTable
                sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

                // variabeln sokningResultat behandlas. Först kollas om den är felaktig, annars portioneras infon ut till de olika listboxarna och datagridviewen.
                if (sokningResultat.Columns[0].ColumnName.Equals("error"))
                {
                    tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
                }
                else
                {
                    if (soktyp == "grupp")
                    {
                        List<traningsgrupp> grupplista = new List<traningsgrupp>(); 
                        
                        for (int y = 0; y < sokningResultat.Rows.Count; y++)
                        {
                            traningsgrupp grupp = new traningsgrupp();
                            grupp.namn = sokningResultat.Rows[y]["namn"].ToString();
                            grupplista.Add(grupp);
                        }

                        lbxGrupper.DataSource = grupplista;
                        lbxGrupper.DisplayMember = "namn";

                    }
                    else if (soktyp == "ledare")
                    {
                        List<gruppledare> ledarlista = new List<gruppledare>();

                        for (int x = 0; x < sokningResultat.Rows.Count; x++)
                        {
                            gruppledare ledare = new gruppledare();
                            ledare.förnamn = sokningResultat.Rows[x]["fnamn"].ToString();
                            ledare.efternamn = sokningResultat.Rows[x]["enamn"].ToString();
                            ledarlista.Add(ledare);
                        }

                        lbxLedare.DataSource = ledarlista;
                    }
                    else
                    {
                        List<narvarolista> narvarolista = new List<narvarolista>();

                        for (int a = 0; a < sokningResultat.Rows.Count; a++)
                        {
                            narvarolista narvaro = new narvarolista();
                            narvaro.fornamn = sokningResultat.Rows[a]["fnamn"].ToString();
                            narvaro.efternamn = sokningResultat.Rows[a]["enamn"].ToString();
                            narvaro.personnummer = sokningResultat.Rows[a]["pnr"].ToString();
                            narvarolista.Add(narvaro);
                        }
                        dgvRapport.DataSource = narvarolista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(
                        dgvRapport.ReadOnly = true;
                    }


                }
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
       

        private void lbxGrupper_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
