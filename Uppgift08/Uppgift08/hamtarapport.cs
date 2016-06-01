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
         string sokOk = "Sökning ok";
         int kolumncounter = 0;
         int tillägg = 0;
        
        // konstruktor
        public hamtarapport()
        {
            InitializeComponent();
            dtpSlutDatum.Enabled = false;
            cbAktivSlutDatum.Checked = false;
            dtpSlutDatum.Value = dtpStartDatum.Value.AddDays(1);
        }

        /// <summary>
        /// Sökning görs efter de ledare som har 
        /// inbokade pass inom den valda tiden. 
        /// </summary>
        private void sokledare()
        {
            DataTable sokningResultat;
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.Items.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            bool sokLedare = !(lbxLedare.Items.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade

            string soktyp = "ledare";

            postgres s = new postgres();                                                        // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = dtpStartDatum.Value;
            s.slutDatum = dtpSlutDatum.Value;

            // sökning i db görs här, svaret skickas tillbaka in i tabellen sokningResultat som har datatypen DataTable
            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);


            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
            }
            else
            {
                List<gruppledare> ledarlista = new List<gruppledare>();
                gruppledare ledare;
                for (int i = 0; i < sokningResultat.Rows.Count; i++)
                {
                    ledare = new gruppledare()
                    {
                        medlemId = sokningResultat.Rows[i]["ledare"].ToString(),
                        förnamn = sokningResultat.Rows[i]["fnamn"].ToString(),
                        efternamn = sokningResultat.Rows[i]["enamn"].ToString()
                    };

                    ledarlista.Add(ledare);
                }

                lbxLedare.DataSource = ledarlista;
                lbxLedare.DisplayMember = "forOchEftNamn";
                tbFeedback.Text = sokOk;
            }
        }

        /// <summary>
        /// Sökning görs efter de grupper som 
        /// en viss ledare ansvarar för. (Stöd för Multiselect)
        /// </summary>
        private void sokgrupper()
        {
            DataTable sokningResultat;
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            string soktyp = "grupp";

            List<string> ledarLista = new List<string>();
            
            foreach (gruppledare selectedItem in lbxLedare.SelectedItems)
            {
                ledarLista.Add(selectedItem.medlemId.ToString());
            }

            postgres s = new postgres();                                                        // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = dtpStartDatum.Value;
            s.slutDatum = dtpSlutDatum.Value;
            s.ledare = ledarLista;

            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
            }
            else
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
                tbFeedback.Text = sokOk;
            }
        }
        
        /// <summary>
        /// Sökning görs efter de individer som tillhör
        /// en viss grupp. (Stöd för Multiselect)
        /// </summary>
        private void sokNarvaro()
        {
            DataTable sokningResultat;
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            string soktyp = "narvaro";

            List<string> gruppLista = new List<string>();
            foreach (traningsgrupp selectedItem in lbxGrupper.SelectedItems)
            {
                gruppLista.Add(selectedItem.namn.ToString());
            }


            postgres s = new postgres();                                                        // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = dtpStartDatum.Value;
            s.slutDatum = dtpSlutDatum.Value;
            s.grupp = gruppLista;

            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
            }
            else
            {
                List<narvarolista> narvarolista = new List<narvarolista>();
                for (int y = 0; y < sokningResultat.Rows.Count; y++)
                {
                    narvarolista narvaro = new narvarolista();
                    narvaro.fornamn = sokningResultat.Rows[y]["fnamn"].ToString();
                    narvaro.efternamn = sokningResultat.Rows[y]["enamn"].ToString();
                    narvaro.personnummer = sokningResultat.Rows[y]["pnr"].ToString();
                    narvaro.medlemId = sokningResultat.Rows[y]["medlem_id"].ToString();
                    narvarolista.Add(narvaro);
                }

                dgvRapport.DataSource = narvarolista;
                dgvRapport.ReadOnly = true;
                for (int i = 3; i < 10; i++)
                {
                    dgvRapport.Columns[i].Visible = false;
                }


                //ny sökning för att ta fram en jämförelselista mot narvarolista
                soktyp = "jamfor";
                sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

                if (sokningResultat.Columns[0].ColumnName.Equals("error"))
                {
                    tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
                }
                else
                {
                    List<narvarolista> jamforLista = new List<narvarolista>();
                    for (int y = 0; y < sokningResultat.Rows.Count; y++)
                    {
                        narvarolista jamforning = new narvarolista();
                        jamforning.fornamn = sokningResultat.Rows[y]["fnamn"].ToString();
                        jamforning.efternamn = sokningResultat.Rows[y]["enamn"].ToString();
                        jamforning.personnummer = sokningResultat.Rows[y]["pnr"].ToString();
                        jamforning.medlemId = sokningResultat.Rows[y]["medlem_id"].ToString();
                        jamforning.narvaro = sokningResultat.Rows[y]["narvarolista_id"].ToString();
                        jamforning.gruppnamn = sokningResultat.Rows[y]["namn"].ToString();
                        jamforning.datum = sokningResultat.Rows[y]["datum"].ToString();
                        jamforning.start = sokningResultat.Rows[y]["starttid"].ToString();
                        jamforning.slut = sokningResultat.Rows[y]["sluttid"].ToString();

                        jamforLista.Add(jamforning);
                    }
                    //narvarolista; jamforLista;  <-- skicka ut till metod och loopa/jämför, skapa ny kolumn för varje grupp
                }

                //ny sökning för att ta fram unika grupper
                soktyp = "unikagrupper";
                sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

                if (sokningResultat.Columns[0].ColumnName.Equals("error"))
                {
                    tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
                }
                else
                {
                    List<narvarolista> unikaGrupperLista = new List<narvarolista>();
                    for (int y = 0; y < sokningResultat.Rows.Count; y++)
                    {
                        narvarolista unikaGrupper = new narvarolista();
                        unikaGrupper.narvaro = sokningResultat.Rows[y]["narvarolista_id"].ToString();
                        unikaGrupper.gruppnamn = sokningResultat.Rows[y]["namn"].ToString();
                        unikaGrupper.datum = sokningResultat.Rows[y]["datum"].ToString();
                        unikaGrupper.start = sokningResultat.Rows[y]["starttid"].ToString();
                        unikaGrupper.slut = sokningResultat.Rows[y]["sluttid"].ToString();

                        unikaGrupperLista.Add(unikaGrupper);
                    }
                    MessageBox.Show(unikaGrupperLista.Count.ToString());

                    string kolNamn = "";
                    
                    kolumncounter = dgvRapport.Columns.Count;
                    tillägg = 0;
                    foreach (narvarolista item in unikaGrupperLista)
                    {
                        tillägg++;
                        kolNamn = item.gruppnamn + "\n " + " Datum: " + Convert.ToDateTime(item.datum).ToShortDateString() + "\n Tid: " + Convert.ToDateTime(item.start).ToShortTimeString() + "-" + Convert.ToDateTime(item.slut).ToShortTimeString();
                        dgvRapport.Columns.Add(kolNamn, kolNamn);
                    }
                    
                }

                tbFeedback.Text = sokOk;
            }
        }


        #region ############# EVENT HANDLERS ##############

        /// <summary>
        /// Stänger närvarorapporteringsfönstret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                lbxLedare.DataSource = null;
                lbxGrupper.DataSource = null;
                //sokledare();
            }
            else
            {
                dtpSlutDatum.Enabled = false;
                lbxLedare.DataSource = null;
                lbxGrupper.DataSource = null;
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
                lbxLedare.DataSource = null;
                lbxGrupper.DataSource = null;
                sokledare();
                lbxLedare.ClearSelected();  //ta bort
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
            lbxLedare.DataSource = null;
            lbxGrupper.DataSource = null;
            sokledare();
            lbxLedare.ClearSelected();  //ta bort
        }
       

        /// <summary>
        /// Aktiverar metoden för gruppsökning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        #endregion

        private void lbxLedare_Click(object sender, EventArgs e)
        {
            lbxGrupper.DataSource = null;
            sokgrupper();
            lbxGrupper.ClearSelected();  //ta bort
        }

        private void lbxGrupper_Click(object sender, EventArgs e)
        {
            if (kolumncounter > 0)
            {
                for (int i = kolumncounter; i < kolumncounter + tillägg; i++)
                {
                    dgvRapport.Columns.RemoveAt(i);
                }
                
            }
            
            sokNarvaro();

        }



    }
}
