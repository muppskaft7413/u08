using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uppgift08
{
    public partial class registreranarvaro : Form
    {
        public registreranarvaro()
        {
            InitializeComponent();
        }
        string grupp;
        string personnummer;
        string deltagit;
        string narvaro;
        narvarolista narvarolistaRatt;
        List<narvarolista> jamforLista;
        string kolNamn;
        private string sokOk = "Sökning ok";   
        private string felSlutDatum = "Slutdatumet måste vara minst en dag mer än startdatumet.";       // textmeddelande som genereras till gula feedbackfältet om man väljer felaktiga kombos av datum
        private bool sokDatInterv;
        private bool sokGrupp;

        /// <summary>
        /// kontrollerar vad för typ av sökning som skall göras.
        /// </summary>
        private void vilkaParam()
        {
            sokDatInterv = cbAktivSlutDatum.Checked;                                         // kollar om datumintervallsökning skall göras
            sokGrupp = !(lbxGrupper.Items.Count == 0) ? true : false;                // kollar om poster i grupplistboxen är markerade
        }


        /// <summary>
        /// Meto som ändrar en deltagas närvaro.
        /// </summary>
        private void andraNarvaro()
        {
            vilkaParam();            
            postgres sokning = new postgres();
            
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            sokning.narvaro = narvaro;
            sokning.pnr = personnummer;
            sokning.deltagit = deltagit;
            sokning.enkelGrupp = grupp;
            string narvaroSvar = sokning.sqlNonQuery(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "andraNarvaro");     // hämtar sökning efter träningsgrupper
            tbSvar.Text = narvaroSvar;
         }

        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter träningsgrupper.
        /// </summary>
        private void sokGrp()
        {
            DataTable svarGrp;
            vilkaParam();
            postgres sokning = new postgres();
            
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            svarGrp = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "grupp");     // hämtar sökning efter träningsgrupper

            if (svarGrp.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = svarGrp.Rows[0][1].ToString();
            }
            else
            {
                List<traningsgrupp> nyTraningsgruppLista = new List<traningsgrupp>();
                for (int i = 0; i < svarGrp.Rows.Count; i++)
                {
                    traningsgrupp traningsgruppRatt = new traningsgrupp()
                    {
                        namn = svarGrp.Rows[i]["namn"].ToString(),
                        tid = svarGrp.Rows[i]["starttid"].ToString(),
                        datum = svarGrp.Rows[i]["datum"].ToString()
                    };


                    nyTraningsgruppLista.Add(traningsgruppRatt);
                }


                lbxGrupper.DataSource = nyTraningsgruppLista;
                lbxGrupper.DisplayMember = "traningsgrupps";
                tbSvar.Text = sokOk;

            }
        }

        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter närvarande.
        /// </summary>
        private void sokNarvaro()
        {
            List<string> gruppLista = new List<string>();
            foreach (traningsgrupp selectedItem in lbxGrupper.SelectedItems)
            {
                gruppLista.Add(selectedItem.namn);
            }

            DataTable svarNarvaro;
            vilkaParam();

            postgres sokning = new postgres();

            sokning.grupp = gruppLista;
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;

            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "narvaro");     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
                List<narvarolista> nyNarvarolista = new List<narvarolista>();
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    narvarolistaRatt = new narvarolista()
                    {
                        Förnamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        Efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                        Personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                        narvaro = svarNarvaro.Rows[i]["narvarolista_id"].ToString(),
                        gruppnamn = svarNarvaro.Rows[i]["namn"].ToString(),
                        medlemId = svarNarvaro.Rows[i]["medlem_id"].ToString(),
                        deltagit = (bool)svarNarvaro.Rows[i]["deltagit"]
                    };


                    nyNarvarolista.Add(narvarolistaRatt);
                    tbSvar.Text = sokOk;
                }
                dgvRegistreraNarvaro.DataSource = nyNarvarolista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(



                for (int i = 3; i < 10; i++)
                {
                    dgvRegistreraNarvaro.Columns[i].Visible = false;
                }


                svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "jamfor");

                if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
                {
                    tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
                }
                else
                {
                    jamforLista = new List<narvarolista>();
                    for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                    {
                        narvarolista jamforning = new narvarolista()
                        {
                            Förnamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                            Efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                            Personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                            narvaro = svarNarvaro.Rows[i]["narvarolista_id"].ToString(),
                            gruppnamn = svarNarvaro.Rows[i]["namn"].ToString(),
                            deltagit = (bool)svarNarvaro.Rows[i]["deltagit"],
                            datum = svarNarvaro.Rows[i]["datum"].ToString(),
                            medlemId = svarNarvaro.Rows[i]["medlem_id"].ToString(),
                            start = svarNarvaro.Rows[i]["starttid"].ToString(),
                            slut = svarNarvaro.Rows[i]["sluttid"].ToString()
                        };
                        jamforLista.Add(jamforning);
                    }

                }
                              
                svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "unikagrupper");

                if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
                {
                    tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
                }
                else
                {
                    List<narvarolista> unikaGrupperLista = new List<narvarolista>();

                    for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                    {
                        narvarolista unikaGrupper = new narvarolista()
                        {
                            narvaro = svarNarvaro.Rows[i]["narvarolista_id"].ToString(),
                            gruppnamn = svarNarvaro.Rows[i]["namn"].ToString(),
                            datum = svarNarvaro.Rows[i]["datum"].ToString(),
                            start= svarNarvaro.Rows[i]["starttid"].ToString(),
                            slut = svarNarvaro.Rows[i]["sluttid"].ToString(),
                        };
                        unikaGrupperLista.Add(unikaGrupper);
                    }



                    int kolumn = 10;

                    List<narvarolista> _narvarolistan;

                    foreach (narvarolista item in unikaGrupperLista)
                    {                       
                        kolNamn = item.gruppnamn + "\n" + "Datum: " + Convert.ToDateTime(item.datum).ToShortDateString() + "\nTid: " + Convert.ToDateTime(item.start).ToShortTimeString() + "-" + Convert.ToDateTime(item.slut).ToShortTimeString();
                        DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                        checkboxColumn.Name = kolNamn;
                        checkboxColumn.DataPropertyName = "nyaKol";
                        dgvRegistreraNarvaro.Columns.Add(checkboxColumn);

                        _narvarolistan = new List<narvarolista>();
                        
                        int index = 0;
                        _narvarolistan.Clear();

                        foreach (narvarolista narvarande in nyNarvarolista) //
                        {
                            
                            foreach (narvarolista jamfor in jamforLista)
                            {
                                if (narvarande.gruppnamn == item.gruppnamn && narvarande.narvaro == item.narvaro)
                                {
                                if (narvarande.medlemId == jamfor.medlemId && item.narvaro == jamfor.narvaro && jamfor.deltagit == true && item.gruppnamn == jamfor.gruppnamn)
                                {


                                    bool test2 = _narvarolistan.Contains(narvarande);
                                    if (!test2)
                                    {

                                        dgvRegistreraNarvaro.Rows[index].Cells[kolumn].Value = true;
                                        _narvarolistan.Add(narvarande);
                                        break;
                                    }

                                }
                                else if (narvarande.medlemId == jamfor.medlemId && item.narvaro == jamfor.narvaro && jamfor.deltagit == false && item.gruppnamn == jamfor.gruppnamn)
                                {
                                    dgvRegistreraNarvaro.Rows[index].Cells[kolumn].Value = false;
                                }
                                }
                                else
                                {
                                    // checkboxarna simuleras som disablade för att illustrera att medlemmar ej tillhör en viss grupp.
                                    DataGridViewCell cell = dgvRegistreraNarvaro.Rows[index].Cells[kolumn];
                                    DataGridViewCheckBoxCell chkCell = cell as DataGridViewCheckBoxCell;
                                    chkCell.Value = false;
                                    chkCell.FlatStyle = FlatStyle.Flat;
                                    chkCell.Style.ForeColor = Color.White;
                                    cell.ReadOnly = true;
                                    
                                }
                                
                            }
                            index++;
                        }
                        kolumn++;
                        
                    }
                }

            }
        }


        #region ############# EVENT HANDLERS ##############



        /// <summary>
/// när checkboxen för aktiveras eller avaktiveras töms alla eventuella söksvarsobjekt.
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void cbAktivSlutDatum_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpSlutDatum.Enabled == false)
            {
                dtpSlutDatum.Enabled = true;
                lbxGrupper.DataSource = null;
                dgvRegistreraNarvaro.DataSource = null;
                dgvRegistreraNarvaro.Rows.Clear();
                dgvRegistreraNarvaro.Columns.Clear();
                dgvRegistreraNarvaro.Refresh();

            }
            else
            {
                dtpSlutDatum.Enabled = false;
                lbxGrupper.DataSource = null;
                dgvRegistreraNarvaro.DataSource = null;
                dgvRegistreraNarvaro.Rows.Clear();
                dgvRegistreraNarvaro.Columns.Clear();
                dgvRegistreraNarvaro.Refresh();
            }
        }

        //Kanske inte behövs. Måste testas.
        private void dgvRegistreraNarvaro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRegistreraNarvaro.IsCurrentCellDirty)
            {
                dgvRegistreraNarvaro.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// När en cell ändras kontrolleras om deltagit är 1 eller 0 och sedan om den ändrade kolumnen är av datapropertyn nyaKol så körs metoden 
        /// andraNarvaro, som ändrar en medlems närvaro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRegistreraNarvaro_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (deltagit == "1" || deltagit == "0")
            {
                if (dgvRegistreraNarvaro.Columns[e.ColumnIndex].DataPropertyName == "nyaKol")
                {
                    andraNarvaro(); //Metod som närvaro på en medlem.
                }

            }
        }

        /// <summary>
        /// När grupp markeras i lbxGrupper presenterar programmet vilka som är närvarande i dgvRegistreraNarvaro. När svaren presenteras gör systemet så att endast deltagitraden kan ändras.
        /// </summary>
        private void lbxGrupper_Click(object sender, EventArgs e)
        {
            dgvRegistreraNarvaro.DataSource = null;
            dgvRegistreraNarvaro.Rows.Clear();
            dgvRegistreraNarvaro.Columns.Clear();
            dgvRegistreraNarvaro.Refresh();
            sokNarvaro(); //Metod som hämtar närvarolistan.


            for (int i = 0; i < dgvRegistreraNarvaro.Columns.Count; i++) //Öppnar upp kolumner som har datapropertyn nyaKol. De andra stänger programmet.
            {
                if (dgvRegistreraNarvaro.Columns[i].DataPropertyName == "nyaKol") 
                {
                    dgvRegistreraNarvaro.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgvRegistreraNarvaro.Columns[i].ReadOnly = true;
                }
            }
            dgvRegistreraNarvaro.ClearSelection();
        }

        /// <summary>
        /// När en rad markeras så hämtar den aktuella värden från raden. Värdena används sedan till att registrera en deltagare som närvarande
        /// eller inte i metoden andraNarvaro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRegistreraNarvaro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            {

                int selectedrowindex = dgvRegistreraNarvaro.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];

                personnummer = Convert.ToString(selectedRow.Cells["personnummer"].Value.ToString());
                narvaro = Convert.ToString(selectedRow.Cells["narvaro"].Value.ToString());
                grupp = Convert.ToString(selectedRow.Cells["gruppnamn"].Value.ToString());
                deltagit = dgvRegistreraNarvaro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            }
            if (deltagit == "False")
            {
                deltagit = "1";
            }
            else
            {
                deltagit = "0";
            }
            }

        /// <summary>
        /// När datum ändras kallar den på metoden sokGrp och placerar svaret i lbxGrupper.
        /// </summary>
        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            lbxGrupper.DataSource = null;
            dgvRegistreraNarvaro.DataSource = null;
            dgvRegistreraNarvaro.Rows.Clear();
            dgvRegistreraNarvaro.Columns.Clear();
            dgvRegistreraNarvaro.Refresh();
            sokGrp();
        }

        /// <summary>
        /// När datum ändras kallar den på metoden sokGrp och placerar svaret i lbxGrupper.
        /// </summary>
        private void dtpSlutDatum_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSlutDatum.Value <= dtpFran.Value)
            {
                dtpSlutDatum.Value = dtpFran.Value.AddHours(24);
                tbSvar.Text = felSlutDatum;
            }
            else
            {
                lbxGrupper.DataSource = null;
                dgvRegistreraNarvaro.DataSource = null;
                dgvRegistreraNarvaro.Rows.Clear();
                dgvRegistreraNarvaro.Columns.Clear();
                dgvRegistreraNarvaro.Refresh();
                sokGrp();
                tbSvar.Clear();
            }
        }



        }
        #endregion
    }

