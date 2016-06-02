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

        private List<narvarolista> jamforLista;
        private string felSlutDatum = "Slutdatumet måste vara minst en dag mer än startdatumet.";       // textmeddelande som genereras till gula feedbackfältet om man väljer felaktiga kombos av datum
        private string sokOk = "Sökning ok";                                                            // textmeddelande som genereras till gula feedbackfältet om allt går ok
        private int kolumn;                                                                             // startindex för att lägga till extra kolumner utöver det som datasource ger.
        private int tillägg = 0;                                                                        // håller koll på hur många extra kolumner som lagts till.
        private int summa;
        private List<string> summering = new List<string>();
        private bool sokDatInterv;
        private bool sokGrupp;
        private bool sokLedare;
        

        /// <summary>
        /// Listboxar/etc knyts till variablar.
        /// Deras identitet kan därmed kontrolleras från ett ställe (constructorn).
        /// </summary>
        #region ##### Variablar kopplade till listboxar/textbox/datagridview #####
        private CheckBox chkBoxDat;                                                                     // checkboxen för att aktivera/deaktivera datumintervallsökning
        private ListBox _lbxGrupper;                                                                    // listboxen för grupper 
        private ListBox _lbxLedare;                                                                     // listboxen för ledare
        private DateTimePicker _dtpStartDatum;                                                          // date time picker för startdatum
        private DateTimePicker _dtpSlutDatum;                                                           // date time picker för slutdatum
        private ListBox _lbxSummering;                                                                  // listbox för summering av träningsresultat
        private DataGridView _dgvRapport;                                                               // outputfönstret för vilka som deltagit i träningar
        private TextBox _tbFeedback;                                                                    // outputfältet för feedback

        #endregion

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public hamtarapport()
        {
            InitializeComponent();
            chkBoxDat = cbAktivSlutDatum;                                                       // checkbox-control:ern cbAktivSlutDatum knyts till en checkbox-variabel
            _lbxGrupper = lbxGrupper;                                                           // listbox-control:ern för grupper knyts till en listbox-variabel
            _lbxLedare = lbxLedare;                                                             // listbox-control:ern för ledare knyts till en listbox-variabel
            _dtpStartDatum = dtpStartDatum;                                                     // date time picker för startdatum knyts till en datetimepicker-variabel
            _dtpSlutDatum = dtpSlutDatum;                                                       // date time picker för slutdatum knyts till en datetimepicker-variabel
            _lbxSummering = lbxSummering;                                                       // listbox-control:ern för summering av träningsresultat knyts till en listbox-variabel
            _dgvRapport = dgvRapport;                                                           // datagridviewern för listning av träningsresultat knyts till en listbox-variabel
            _tbFeedback = tbFeedback;                                                           // feedbackfältet knyts till en listbox-variabel
            chkBoxDat.Checked = false;
            _dtpSlutDatum.Enabled = false;
            _dtpSlutDatum.Value = _dtpStartDatum.Value.AddDays(1);
         }

        /// <summary>
        /// kontrollerar vad för typ av sökning som skall göras
        /// </summary>
        private void vilkaParam()
        {
            sokDatInterv = chkBoxDat.Checked;                                         // kollar om datumintervallsökning skall göras
            sokGrupp = !(_lbxGrupper.Items.Count == 0) ? true : false;                // kollar om poster i grupplistboxen är markerade
            sokLedare = !(_lbxLedare.Items.Count == 0) ? true : false;                // kollar om poster i ledarlistboxen är markerade
        }

        /// <summary>
        /// Verktyg för att prata med databasen
        /// </summary>
        /// <returns></returns>
        private postgres startaPostgres()
        {
            postgres s = new postgres();                                              // objekt av postgres skapas för att göra sökning mot db
            s.startDatum = _dtpStartDatum.Value;
            s.slutDatum = _dtpSlutDatum.Value;
            return s;
        }


        /// <summary>
        /// Sökning görs efter de ledare som har 
        /// inbokade pass inom den valda tiden. 
        /// </summary>
        private void sokledare()
        {
            DataTable sokningResultat;
            vilkaParam();                                                             // sökparameterkontroll
            string soktyp = "ledare";

            postgres s = startaPostgres();
          
            // sökning i db görs här, svaret skickas tillbaka in i tabellen sokningResultat som har datatypen DataTable
            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);


            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                _tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
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

                _lbxLedare.DataSource = ledarlista;
                _lbxLedare.DisplayMember = "forOchEftNamn";
                _tbFeedback.Text = sokOk;
            }
        }




        

        /// <summary>
        /// Sökning görs efter de grupper som 
        /// en viss ledare ansvarar för. (Stöd för Multiselect)
        /// </summary>
        private void sokgrupper()
        {
            DataTable sokningResultat;
            
            vilkaParam();                                                             // sökparameterkontroll

            string soktyp = "grupp";

            List<string> ledarLista = new List<string>();
            
            foreach (gruppledare selectedItem in _lbxLedare.SelectedItems)
            {
                ledarLista.Add(selectedItem.medlemId.ToString());
            }

            postgres s = startaPostgres();
            s.ledare = ledarLista;

            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                _tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
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

                _lbxGrupper.DataSource = grupplista;
                _lbxGrupper.DisplayMember = "namn";
                _tbFeedback.Text = sokOk;
            }
        }
        
        /// <summary>
        /// Sökning görs efter de individer som tillhör
        /// en viss grupp. (Stöd för Multiselect)
        /// </summary>
        private void sokNarvaro()
        {
            DataTable sokningResultat;
           
            vilkaParam();                                                             // sökparameterkontroll

            string soktyp = "narvaro";

            List<string> gruppLista = new List<string>();
            foreach (traningsgrupp selectedItem in lbxGrupper.SelectedItems)
            {
                gruppLista.Add(selectedItem.namn.ToString());
            }


            postgres s = startaPostgres();
            s.grupp = gruppLista;

            sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

            if (sokningResultat.Columns[0].ColumnName.Equals("error"))
            {
                _tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
            }
            else
            {
                List<narvarolista> narvarolistan = new List<narvarolista>();
                for (int y = 0; y < sokningResultat.Rows.Count; y++)
                {
                    narvarolista narvaro = new narvarolista();
                    narvaro.Förnamn = sokningResultat.Rows[y]["fnamn"].ToString();
                    narvaro.Efternamn = sokningResultat.Rows[y]["enamn"].ToString();
                    narvaro.Personnummer = sokningResultat.Rows[y]["pnr"].ToString();
                    narvaro.medlemId = sokningResultat.Rows[y]["medlem_id"].ToString();
                    narvarolistan.Add(narvaro);
                }

                _dgvRapport.DataSource = narvarolistan;
                _dgvRapport.ReadOnly = true;

                int hej = _dgvRapport.Columns.Count -1;

                //for (int i = 2; i < 10; i++)
                //{
                //    dgvRapport.Columns[i].Visible = false;
                //}

                for (int i = hej; i > 2; i--)
                {
                    _dgvRapport.Columns.RemoveAt(i);
                }


                //ny sökning för att ta fram en jämförelselista mot narvarolista
                soktyp = "jamfor";
                sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

                if (sokningResultat.Columns[0].ColumnName.Equals("error"))
                {
                    _tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
                }
                else
                {
                    jamforLista = new List<narvarolista>();
                    for (int y = 0; y < sokningResultat.Rows.Count; y++)
                    {
                        narvarolista jamforning = new narvarolista();
                        jamforning.Förnamn = sokningResultat.Rows[y]["fnamn"].ToString();
                        jamforning.Efternamn = sokningResultat.Rows[y]["enamn"].ToString();
                        jamforning.Personnummer = sokningResultat.Rows[y]["pnr"].ToString();
                        jamforning.medlemId = sokningResultat.Rows[y]["medlem_id"].ToString();
                        jamforning.narvaro = sokningResultat.Rows[y]["narvarolista_id"].ToString();
                        jamforning.gruppnamn = sokningResultat.Rows[y]["namn"].ToString();
                        jamforning.datum = sokningResultat.Rows[y]["datum"].ToString();
                        jamforning.start = sokningResultat.Rows[y]["starttid"].ToString();
                        jamforning.slut = sokningResultat.Rows[y]["sluttid"].ToString();
                        jamforning.deltagit = (bool)sokningResultat.Rows[y]["deltagit"];

                        jamforLista.Add(jamforning);
                    }
                }

                //ny sökning för att ta fram unika grupper
                soktyp = "unikagrupper";
                sokningResultat = s.sqlFråga(s.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), soktyp);

                if (sokningResultat.Columns[0].ColumnName.Equals("error"))
                {
                    _tbFeedback.Text = sokningResultat.Rows[0][1].ToString();
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
 
                    
                    tillägg = 0;
                    string kolNamn = "";
                    kolumn = 3;
                    summa = 0;
                    summering.Clear();
                    int antalDeltagare = 0;

                    // lägger till kolumner för träningstillfälle
                    List<narvarolista> _narvarolistan;
                    
                        foreach (narvarolista item in unikaGrupperLista)
                        {
                            tillägg++;
                            kolNamn = item.gruppnamn + "\n" + "Datum: " + Convert.ToDateTime(item.datum).ToShortDateString() + "\nTid: " + Convert.ToDateTime(item.start).ToShortTimeString() + "-" + Convert.ToDateTime(item.slut).ToShortTimeString();
                            _dgvRapport.Columns.Add(kolNamn, kolNamn);

                            _narvarolistan = new List<narvarolista>();

                            int index = 0;
                            antalDeltagare = 0;
                            _narvarolistan.Clear();

                            foreach (narvarolista narvarande in narvarolistan)
                            {
                                foreach (narvarolista jamfor in jamforLista)
                                {
                                    if (narvarande.medlemId == jamfor.medlemId && item.narvaro == jamfor.narvaro && jamfor.deltagit == true && item.gruppnamn == jamfor.gruppnamn)
                                    {
                                        bool test2 = _narvarolistan.Contains(narvarande);
                                        if (!test2)
                                        {
                                            _dgvRapport.Rows[index].Cells[kolumn].Value = "x";
                                            _narvarolistan.Add(narvarande);
                                            antalDeltagare++;
                                            break;
                                        }

                                    }
                                }
                                index++;
                            }
                            kolumn++;
                            skickaTillSummering(kolNamn, antalDeltagare, false);
                            
                        }
                        skickaTillSummering(kolNamn, antalDeltagare, true);
                }
                _tbFeedback.Text = sokOk;
            }
        }

        /// <summary>
        /// Summeringsfönstret sammanställer träningsresultaten avseende deltagande.
        /// </summary>
        /// <param name="kolNamn"></param>
        /// <param name="antalDeltagare"></param>
        /// <param name="jaNej"></param>
        private void skickaTillSummering(string kolNamn, int antalDeltagare, bool jaNej)
        {
            if (!jaNej)
            {
                summa += antalDeltagare;
                string sammansatt = kolNamn + ", antal deltagare: " + antalDeltagare;
                summering.Add(sammansatt);
            }
            else
            {
                summering.Add("--");
                summering.Add("Totalt antal deltagare: " + summa);
                _lbxSummering.SelectionMode = SelectionMode.MultiExtended;
                _lbxSummering.DataSource = summering;
                _lbxSummering.SelectionMode = SelectionMode.None;
                
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
            if(_dtpSlutDatum.Enabled == false)
            {
                _dtpSlutDatum.Enabled = true;
                _lbxLedare.DataSource = null;
                _lbxGrupper.DataSource = null;
            }
            else
            {
                _dtpSlutDatum.Enabled = false;
                _lbxLedare.DataSource = null;
                _lbxGrupper.DataSource = null;
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
            if(_dtpSlutDatum.Value <= _dtpStartDatum.Value)
            {
                _dtpSlutDatum.Value = _dtpStartDatum.Value.AddHours(24);
                _tbFeedback.Text = felSlutDatum;
            }
            else
            {
                _tbFeedback.Clear();   // rensar feedbackfältet
                _lbxLedare.DataSource = null;
                _lbxGrupper.DataSource = null;
                sokledare();
                _lbxLedare.ClearSelected();  
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
            if(_dtpStartDatum.Value >= _dtpSlutDatum.Value)
            {
                _dtpSlutDatum.Value = _dtpStartDatum.Value.AddDays(1);
            }
            _lbxLedare.DataSource = null;
            _lbxGrupper.DataSource = null;
            sokledare();
            _lbxLedare.ClearSelected();  
        }
       

        /// <summary>
        /// Aktiverar metoden för gruppsökning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxLedare_Click(object sender, EventArgs e)
        {
            _lbxGrupper.DataSource = null;
            sokgrupper();
            _lbxGrupper.ClearSelected(); 
        }

        /// <summary>
        /// Genererar en lista med vilka som har deltagit i träningstillfällen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxGrupper_Click(object sender, EventArgs e)
        {

            _lbxSummering.DataSource = null;

            _dgvRapport.DataSource = null;
            _dgvRapport.Rows.Clear();
            _dgvRapport.Columns.Clear();
            sokNarvaro();
            

        }

        #endregion


    }
}
