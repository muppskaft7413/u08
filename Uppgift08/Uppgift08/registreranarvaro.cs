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

        string id2;
        string id3;
        string id4;
        string grupp;




        private void sokGrp()
        {

            DataTable svarNarvaro;
            string sokGrp = "sokGrp";

            postgres sokning = new postgres();
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            //svarGrupp = sokning.getSome(sokGrp);        // hämtar sökning efter träningsgrupper
            svarNarvaro = sokning.sqlFråga(sokGrp);     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                textBox1.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
                List<traningsgrupp> nyTraningsgruppLista = new List<traningsgrupp>();
                traningsgrupp traningsgruppRatt;
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    traningsgruppRatt = new traningsgrupp()
                    {
                        namn = svarNarvaro.Rows[i]["namn"].ToString(),
                    };
                    nyTraningsgruppLista.Add(traningsgruppRatt);
                }
                lbxGrupper.DataSource = nyTraningsgruppLista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(
                lbxGrupper.DisplayMember = "traningsgrupps";
            }
        }

        private void sokNarvaro()
        {

            DataTable svarNarvaro;
            string sokNarv = "sokNarvAdv";

            postgres sokning = new postgres();
            sokning.grupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            svarNarvaro = sokning.sqlFråga(sokNarv);     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                textBox1.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
                List<narvarolista> nyNarvarolista = new List<narvarolista>();
                narvarolista narvarolistaRatt;
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    narvarolistaRatt = new narvarolista()
                    {
                        fornamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                        personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                        narvaro = svarNarvaro.Rows[i]["narvarolista_id"].ToString(),
                        deltagit = (bool)svarNarvaro.Rows[i]["deltagit"]
                    };
                    nyNarvarolista.Add(narvarolistaRatt);
                }
                dgvRegistreraNarvaro.DataSource = nyNarvarolista;    // ska ersättas med ett objekt av narvarolista-klassen, kod ej klart för att hacka upp tabell =(
            }
        }

        
        /// <summary>
        /// Hämtar träningsgrupperna från ett datum som valt i datetimepickern.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            sokGrp();
        }
        /// <summary>
        /// Hämtar narvarolista från ett datum som valt i datetimepickern och gruppnamnet som man valt i listboxen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxGrupper_SelectedIndexChanged(object sender, EventArgs e)
        {

            sokNarvaro();
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


        private NpgsqlConnection _conn;
        private NpgsqlDataAdapter _da;
        private DataTable _dt;
        private NpgsqlCommandBuilder builder;

        private void dgvRegistreraNarvaro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            //{
            //    string id = dgvRegistreraNarvaro.SelectedCells[0].Value.ToString();
            //    if (id == "True")
            //    {
            //        id2 = "0";
            //    }
            //    else
            //    {
            //        id2 = "1";
            //    }
            //}
            {
                if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgvRegistreraNarvaro.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];

                    string id2 = Convert.ToString(selectedRow.Cells["fornamn"].Value.ToString());


                }
            }
        }

        private void dgvRegistreraNarvaro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvRegistreraNarvaro.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvRegistreraNarvaro.Rows[selectedrowindex];
                 id2 = Convert.ToString(selectedRow.Cells["personnummer"].Value.ToString());
                 id3 = Convert.ToString(selectedRow.Cells["deltagit"].Value.ToString());
                 id4 = Convert.ToString(selectedRow.Cells["narvaro"].Value.ToString());

                if (id3 == "False")
                {
                    id3 = "1";
                }
                else
                {
                    id3 = "0";
                }
                //if (grupp == "Enhjuling")
                //{
                //    grupp = "2";
                //}
                _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
                _da = new NpgsqlDataAdapter("update deltagare set deltagit = '" + id3 + "' where deltagare.grupp_id = (select grupp_id from traningsgrupp where namn = '"+grupp+"') and deltagare.medlem_id = (select medlem_id from medlem where pnr = '" + id2 + "') and deltagare.narvarolista_id = '" + id4 + "'", _conn);
                _dt = new DataTable();
                _da.Fill(_dt);

                try
                {
                    builder = new NpgsqlCommandBuilder(_da);
                    _da.Update(_dt);
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }
    }
}
