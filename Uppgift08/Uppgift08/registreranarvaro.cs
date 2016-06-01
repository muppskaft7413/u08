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

        //private NpgsqlConnection _conn;
        //private NpgsqlDataAdapter _da;
        //private DataTable _dt;
        //private NpgsqlCommandBuilder builder;
        string grupp;
        string personnummer;
        string deltagit;
        int counter = 0;
        string narvaro;
        traningsgrupp traningsgruppRatt;
        narvarolista narvarolistaRatt;
        List<narvarolista> jamforLista;
        int tillägg;
        string kolNamn;

 

        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter närvarolistor.
        /// </summary>
        private void andraNarvaro()
        {
            DataTable svarAndraNarvaro;
            
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            //bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            
            postgres sokning = new postgres();
            
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            sokning.narvaro = narvaro;
            sokning.pnr = personnummer;
            sokning.deltagit = deltagit;
            //sokning.enkelGrupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);
            sokning.enkelGrupp = grupp;

            svarAndraNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "bajs");     // hämtar sökning efter träningsgrupper

            //if (svarAndraNarvaro.Columns[0].ColumnName.Equals("error"))
            //{
                     //    tbFel.Text = svarAndraNarvaro.Rows[0][1].ToString();
            //}
            //else
            //{
            //}
         }
        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter träningsgrupper.
        /// </summary>
        private void sokGrp()
        {
            DataTable svarGrp;

            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            //bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            
            postgres sokning = new postgres();
            
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            svarGrp = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "grupp");     // hämtar sökning efter träningsgrupper

            if (svarGrp.Columns[0].ColumnName.Equals("error"))
            {
                tbFel.Text = svarGrp.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
                List<traningsgrupp> nyTraningsgruppLista = new List<traningsgrupp>();
                for (int i = 0; i < svarGrp.Rows.Count; i++)
                {
                    traningsgruppRatt = new traningsgrupp()
                    {
                        namn = svarGrp.Rows[i]["namn"].ToString(),
                        tid = svarGrp.Rows[i]["starttid"].ToString()
                    };


                    nyTraningsgruppLista.Add(traningsgruppRatt);
                }


                lbxGrupper.DataSource = nyTraningsgruppLista;
                lbxGrupper.DisplayMember = "traningsgrupps";


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

            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade

            postgres sokning = new postgres();

            sokning.grupp = gruppLista;
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;

            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), "narvaro");     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                tbFel.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {

                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
                List<narvarolista> nyNarvarolista = new List<narvarolista>();
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    narvarolistaRatt = new narvarolista()
                    {
                        fornamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                        personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                        narvaro = svarNarvaro.Rows[i]["narvarolista_id"].ToString(),
                        gruppnamn = svarNarvaro.Rows[i]["namn"].ToString(),
                        medlemId = svarNarvaro.Rows[i]["medlem_id"].ToString(),
                        deltagit = (bool)svarNarvaro.Rows[i]["deltagit"]
                    };

                    nyNarvarolista.Add(narvarolistaRatt);
                }
                dgvRegistreraNarvaro.DataSource = nyNarvarolista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(

                int hej = dgvRegistreraNarvaro.Columns.Count - 1;

                for (int i = 3; i < 10; i++)
                {
                    dgvRegistreraNarvaro.Columns[i].Visible = false;
                }


                svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), "jamfor");

                if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
                {
                    tbFel.Text = svarNarvaro.Rows[0][1].ToString();
                }
                else
                {
                    jamforLista = new List<narvarolista>();
                    for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                    {
                        narvarolista jamforning = new narvarolista()
                        {
                            fornamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                            efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                            personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
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
                              
                svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, sokLedare), "unikagrupper");

                if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
                {
                    tbFel.Text = svarNarvaro.Rows[0][1].ToString();
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

                    tillägg = 0;


                    int kolumn = 10;

                    List<narvarolista> _narvarolistan;

                    foreach (narvarolista item in unikaGrupperLista)
                    {
                        tillägg++;
                        counter++;
                        
                        kolNamn = item.gruppnamn + "\n " + " Datum: " + Convert.ToDateTime(item.datum).ToShortDateString() + "\n Tid: " + Convert.ToDateTime(item.start).ToShortTimeString() + "-" + Convert.ToDateTime(item.slut).ToShortTimeString();
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
        /// När datum ändras kallar den på metoden sokGrp och placerar svaret i lbxGrupper.
        /// </summary>
        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            lbxGrupper.DataSource = null;
            lbxLedare.DataSource = null;
            dgvRegistreraNarvaro.DataSource = null;
            sokGrp();

        }


        /// <summary>
        /// När en rad blir markerad hämtas värden från personnummer, deltagit och närvarolistan från raden.
        /// Värdena placeras sedan in i en fråga som uppdaterar vald persons närvaro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRegistreraNarvaro_SelectionChanged(object sender, EventArgs e)
        {
        }
        //Används inte.
        private void registreranarvaro_Load(object sender, EventArgs e)
        {
            //  MessageBox.Show("Problem just nu: Gruppledaren och tid för aktuell grupp vill inte visas. Har alla ett närvaro_id? kan var abugg om de inte har det eller databasen.");
        }

        private void cbAktivSlutDatum_CheckedChanged(object sender, EventArgs e)
        {
            if (dtpSlutDatum.Enabled == false)
            {
                dtpSlutDatum.Enabled = true;
                lbxGrupper.DataSource = null;
                lbxLedare.DataSource = null;
                dgvRegistreraNarvaro.DataSource = null;

            }
            else
            {
                dtpSlutDatum.Enabled = false;
                lbxGrupper.DataSource = null;
                lbxLedare.DataSource = null;
                dgvRegistreraNarvaro.DataSource = null;
            }
        }

        //Kanske inte behövs. Måste testas.
        private void dgvRegistreraNarvaro_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            //if (dgvRegistreraNarvaro.IsCurrentCellDirty)
            //{
            //    dgvRegistreraNarvaro.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //}
        }

        private void dgvRegistreraNarvaro_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistreraNarvaro.Columns[e.ColumnIndex].DataPropertyName == "deltagit" || dgvRegistreraNarvaro.Columns[e.ColumnIndex].DataPropertyName == "nyaKol")
             {

                 andraNarvaro();
            }

        }

        /// <summary>
        /// När grupp markeras i lbxGrupper presenterar programmet vilka som är närvarande i dgvRegistreraNarvaro. När svaren presenteras gör systemet så att endast deltagitraden kan ändras.
        /// </summary>
        private void lbxGrupper_Click(object sender, EventArgs e)
        {
            dgvRegistreraNarvaro.DataSource = null; //Kanske ta bort
            dgvRegistreraNarvaro.Rows.Clear();
            dgvRegistreraNarvaro.Columns.Clear();
            dgvRegistreraNarvaro.Refresh();
            sokNarvaro(); //Metod som hämtar närvarolistan.


            for (int i = 0; i < dgvRegistreraNarvaro.Columns.Count; i++)
            {
                if (dgvRegistreraNarvaro.Columns[i].DataPropertyName == "deltagit" || dgvRegistreraNarvaro.Columns[i].DataPropertyName == "nyaKol")
                {
                    dgvRegistreraNarvaro.Columns[i].ReadOnly = false;
                }
                else
                {
                    dgvRegistreraNarvaro.Columns[i].ReadOnly = true;
                }
            }
            grupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);
            dgvRegistreraNarvaro.ClearSelection();
        }

        private void dgvRegistreraNarvaro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            {

                int selectedrowindex = dgvRegistreraNarvaro.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];

                personnummer = Convert.ToString(selectedRow.Cells["personnummer"].Value.ToString());
                //deltagit = Convert.ToString(selectedRow.Cells["deltagit"].Value.ToString());
                narvaro = Convert.ToString(selectedRow.Cells["narvaro"].Value.ToString());
                grupp = Convert.ToString(selectedRow.Cells["gruppnamn"].Value.ToString());

                if (selectedRow.Cells[kolNamn].Value == null)
                {
                    selectedRow.Cells[kolNamn].Value = false;
                }

                deltagit = Convert.ToString(selectedRow.Cells[kolNamn].Value.ToString());
                MessageBox.Show("bae");
                //for (int i = 0; i < dgvRegistreraNarvaro.Columns.Count; i++)
                //{
                // if (dgvRegistreraNarvaro.Columns[i].DataPropertyName == "häst")
                // {

                //     //string bla2 = dgvRegistreraNarvaro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                //     //string bla = ((bool)dgvRegistreraNarvaro[e.ColumnIndex, e.RowIndex].) == true ? "true" : "false";
                //     //DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvRegistreraNarvaro[e.ColumnIndex, e.RowIndex].Value;
                //     ////DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dgvRegistreraNarvaro.CurrentCell;
                //     //bool isChecked = (bool)checkbox.EditedFormattedValue;
                //     MessageBox.Show("hej");
                //     break;

                // }
                //}


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
        }
        #endregion
    }

