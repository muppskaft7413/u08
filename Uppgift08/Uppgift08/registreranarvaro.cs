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
        string narvaro;
        traningsgrupp traningsgruppRatt;
        narvarolista narvarolistaRatt;


        
 

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
                        deltagit = (bool)svarNarvaro.Rows[i]["deltagit"]
                    };

                    nyNarvarolista.Add(narvarolistaRatt);
                }
                dgvRegistreraNarvaro.DataSource = nyNarvarolista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(

                //for (int i = 4; i < 10; i++)
                //{
                //    dgvRegistreraNarvaro.Columns[i].Visible = false;
                //}
                int hej = dgvRegistreraNarvaro.Columns.Count - 1;

                for (int i = hej; i > 3; i--)
                {
                    dgvRegistreraNarvaro.Columns.RemoveAt(i);
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

                //foreach (DataGridViewCell item in dgvRegistreraNarvaro.SelectedCells)
                //{
                //    foreach (DataGridViewRow row in dgvRegistreraNarvaro.SelectedRows)
                //    {
                //    grupp = traningsgruppRatt.namn;
                //    personnummer = narvarolistaRatt.personnummer;
                //    narvaro = narvarolistaRatt.narvaro;
                //    deltagit = narvarolistaRatt.deltagit.ToString();
                //    //MessageBox.Show(item.Value.ToString());
                //}
 

            //}

            
            //if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            //{
            //    int selectedrowindex = dgvRegistreraNarvaro.SelectedCells[0].RowIndex;
                
            //    DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];
            //    id2 = Convert.ToString(selectedRow.Cells["personnummer"].Value.ToString());
            //    id3 = Convert.ToString(selectedRow.Cells["deltagit"].Value.ToString());
            //    id4 = Convert.ToString(selectedRow.Cells["narvaro"].Value.ToString());
            //    id3 = Convert.ToString(selectedRow.Cells["deltagit"].Value.ToString());

            int rowindex = dgvRegistreraNarvaro.CurrentCell.RowIndex;
            int columnindex = dgvRegistreraNarvaro.CurrentCell.ColumnIndex;

            if (dgvRegistreraNarvaro.Rows[rowindex].Cells[columnindex].Value == narvarolistaRatt.personnummer)
            {
                
                personnummer = dgvRegistreraNarvaro.Rows[rowindex].Cells[columnindex].Value.ToString();
            }


            //    if (id3 == "False")
            //    {
            //        id3 = "1";
            //    }
            //    else
            //    {
            //        id3 = "0";
            //    }
                //andraNarvaro();
                //_conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
                //_da = new NpgsqlDataAdapter("update deltagare set deltagit = '" + id3 + "' where deltagare.grupp_id = (select grupp_id from traningsgrupp where namn = '" + grupp + "') and deltagare.medlem_id = (select medlem_id from medlem where pnr = '" + id2 + "') and deltagare.narvarolista_id = '" + id4 + "'", _conn);
                //_dt = new DataTable();
                //_da.Fill(_dt);

                //try
                //{
                //    builder = new NpgsqlCommandBuilder(_da);
                //    _da.Update(_dt);
                //}
                //catch (NpgsqlException ex)
                //{
                //    MessageBox.Show("Error" + ex.Message);
                //}

            //}
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
            if (dgvRegistreraNarvaro.Columns[e.ColumnIndex].DataPropertyName == "deltagit")
             {

                 andraNarvaro();
            }

        }

        /// <summary>
        /// När grupp markeras i lbxGrupper presenterar programmet vilka som är närvarande i dgvRegistreraNarvaro. När svaren presenteras gör systemet så att endast deltagitraden kan ändras.
        /// </summary>
        private void lbxGrupper_Click(object sender, EventArgs e)
        {
            //dgvRegistreraNarvaro.DataSource = null; //Kanske ta bort
            sokNarvaro(); //Metod som hämtar närvarolistan.

            for (int i = 0; i < dgvRegistreraNarvaro.Columns.Count; i++)
            {
                if (dgvRegistreraNarvaro.Columns[i].DataPropertyName == "deltagit")
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

// Ska tas bort
        private void dgvRegistreraNarvaro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //foreach (DataGridViewCell row in dgvRegistreraNarvaro.SelectedCells)
            //{
            //    grupp = traningsgruppRatt.namn;
            //    personnummer = narvarolistaRatt.personnummer;
            //    narvaro = narvarolistaRatt.narvaro;
            //    deltagit = narvarolistaRatt.deltagit.ToString();
            //}



                //if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
                //{

            //DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];
            //personnummer = Convert.ToString(selectedRow.Cells["personnummer"].Value.ToString());
            //deltagit = Convert.ToString(selectedRow.Cells["deltagit"].Value.ToString());
            //narvaro = Convert.ToString(selectedRow.Cells["narvaro"].Value.ToString());
            //grupp = Convert.ToString(selectedRow.Cells["gruppnamn"].Value.ToString());
            //grupp = dgvRegistreraNarvaro[traningsgruppRatt.namn, dgvRegistreraNarvaro.CurrentRow.Index].Value.ToString();

            //grupp = dgvRegistreraNarvaro.SelectedRows.Contains((traningsgruppRatt.namn).ToString());
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

