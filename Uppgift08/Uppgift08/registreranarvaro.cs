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

        private NpgsqlConnection _conn;
        private NpgsqlDataAdapter _da;
        private DataTable _dt;
        private NpgsqlCommandBuilder builder;
        string id2;
        string id3;
        string id4;
        string grupp;


        
 private void sokLedare()
        {

            DataTable svarNarvaro;
            string sokGrp = "sokGrpLed";

            postgres sokning = new postgres();
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            sokning.grupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);
            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(false, false, false), sokGrp);     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                textBox1.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut

                List<gruppledare> nyGruppledareLista = new List<gruppledare>();
                gruppledare gruppledaren;
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    gruppledaren = new gruppledare()
                    {
                        förnamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        efternamn = svarNarvaro.Rows[i]["enamn"].ToString()
                    };
                    nyGruppledareLista.Add(gruppledaren);
                }
                //lbxInfo.DataSource = null;
                lbxInfo.DataSource = nyGruppledareLista;
                lbxInfo.DisplayMember = "gruppledaren";


            }
        }


        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter träningsgrupper.
        /// </summary>
        private void sokGrp()
        {
            DataTable svarNarvaro;
            //string sokGrp = "sokGrp";
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            //bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            postgres sokning = new postgres();
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "grupp");     // hämtar sökning efter träningsgrupper

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

                lbxGrupper.DataSource = null;
                lbxGrupper.DataSource = nyTraningsgruppLista;
                lbxGrupper.DisplayMember = "traningsgrupps";


            }
        }
        /// <summary>
        /// Metod som kallar på sökmetoden från postgres-klassen. Söker efter närvarande.
        /// </summary>
        private void sokNarvaro()
        {

            DataTable svarNarvaro;
            bool sokDatInterv = cbAktivSlutDatum.Checked;                                       // kollar om datumintervallsökning skall göras
            bool sokGrupp = !(lbxGrupper.SelectedItems.Count == 0) ? true : false;              // kollar om poster i grupplistboxen är markerade
            //bool sokLedare = !(lbxLedare.SelectedItems.Count == 0) ? true : false;              // kollar om poster i ledarlistboxen är markerade
            postgres sokning = new postgres();
            sokning.grupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);
            sokning.startDatum = dtpFran.Value;
            sokning.slutDatum = dtpSlutDatum.Value;
            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(sokDatInterv, sokGrupp, false), "narvaro");     // hämtar sökning efter träningsgrupper

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
        /// När datum ändras kallar den på metoden sokGrp och placerar svaret i lbxGrupper.
        /// </summary>
        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            sokGrp();
            //lbxGrupper.ClearSelected();
        }
        /// <summary>
        /// När grupp markeras i lbxGrupper presenterar programmet vilka som är närvarande i dgvRegistreraNarvaro. När svaren presenteras gör systemet så att endast deltagitraden kan ändras.
        /// </summary>
        private void lbxGrupper_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    sokLedare(); //Metod som ska hämta ledare
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
        /// <summary>
        /// När en rad blir markerad hämtas värden från personnummer, deltagit och närvarolistan från raden.
        /// Värdena placeras sedan in i en fråga som uppdaterar vald persons närvaro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
                _da = new NpgsqlDataAdapter("update deltagare set deltagit = '" + id3 + "' where deltagare.grupp_id = (select grupp_id from traningsgrupp where namn = '" + grupp + "') and deltagare.medlem_id = (select medlem_id from medlem where pnr = '" + id2 + "') and deltagare.narvarolista_id = '" + id4 + "'", _conn);
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

        private void registreranarvaro_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Problem just nu: Gruppledaren och tid för aktuell grupp vill inte visas. Antagligen dålig query. Buggar: Man kan registrera närvaro oavsett var man klickar i tabellen. Dubbelklickar man på gruppnamnet så registreras närvaro på personen högst upp. KOM IHÅG: fixa listboxnamnet.");
        }
    }
}
