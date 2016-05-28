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
        string grupp;
        /// <summary>
        /// Hämtar träningsgrupperna från ett datum som valt i datetimepickern.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dtpFran.Value.ToString("yyyy-MM-dd"); //Hämtar datumet från datetimepickern. Läggs sedan in i metoden.
            traningsgrupp nyTraningsgrupp = new traningsgrupp();
            List<traningsgrupp> traningsgrupp = new List<traningsgrupp>(); //lista där resultatet lagras.
            bool fel = false;
            string felmeddelande = "";
            traningsgrupp = nyTraningsgrupp.getTraningsgrupp(ref fel, ref felmeddelande, theDate);
            lbxGrupper.DataSource = null;
            lbxGrupper.DataSource = traningsgrupp;
            lbxGrupper.DisplayMember = "traningsgrupps";
            lbxGrupper.SelectedIndex = -1; //Den här ska göra så att inget item i listboxen är selected. Men den funkar inte så bra.
            if (fel)
            {
                MessageBox.Show(felmeddelande);
            }
        }
        /// <summary>
        /// Hämtar narvarolista från ett datum som valt i datetimepickern och gruppnamnet som man valt i listboxen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxGrupper_SelectedIndexChanged(object sender, EventArgs e)
        {

            string theDate = dtpFran.Value.ToString("yyyy-MM-dd"); //Hämtar datumet från datetimepickern. Läggs sedan in i metoden.
            grupp = lbxGrupper.GetItemText(lbxGrupper.SelectedItem);

            narvarolista nyNarvarolista = new narvarolista();
            List<narvarolista> narvarolista = new List<narvarolista>(); //lista där resultatet lagras.
            bool fel = false;
            string felmeddelande = "";
            narvarolista = nyNarvarolista.getNarvarolista(ref fel, ref felmeddelande, theDate, grupp);
            //dgvRegistreraNarvaro.DataSource = null;
            dgvRegistreraNarvaro.DataSource = narvarolista;

            if (fel)
            {
                MessageBox.Show(felmeddelande);
            }
        }


        private NpgsqlConnection _conn;
        private NpgsqlDataAdapter _da;
        private DataTable _dt;
        private NpgsqlCommandBuilder builder; 



        private void registreranarvaro_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistreraNarvaro_Click(object sender, EventArgs e)
        {
            if (grupp == "Enhjuling")
            {
                grupp = "2";
            }
            _conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["db_g12"].ConnectionString);
            _da = new NpgsqlDataAdapter("update deltagare set deltagit = '"+id2+"' where deltagare.grupp_id = '"+grupp+"' and deltagare.medlem_id = '3' and deltagare.narvarolista_id = '5'", _conn);
            _dt = new DataTable();
            _da.Fill(_dt);
            dgvRegistreraNarvaro.DataSource = _dt;
            try
            {
                builder = new NpgsqlCommandBuilder(_da);
                _da.Update(_dt);
                MessageBox.Show("japp");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void dgvRegistreraNarvaro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRegistreraNarvaro.SelectedCells.Count > 0)
            {
                string id = dgvRegistreraNarvaro.SelectedCells[0].Value.ToString();
                if (id == "True")
                {
                    id2 = "0";
                }
                else
                {
                    id2 = "1";
                }
            }
        }
    }
}
