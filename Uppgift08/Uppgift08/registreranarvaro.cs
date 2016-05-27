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
    public partial class registreranarvaro : Form
    {
        public registreranarvaro()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string theDate = dtpFran.Value.ToString("yyyy-MM-dd");

            //traningsgrupp nyTraningsgrupp = new traningsgrupp();
            //List<traningsgrupp> traningsgrupp = new List<traningsgrupp>();
            //bool fel = false;
            //string felmeddelande = "";
            //traningsgrupp = nyTraningsgrupp.getTraningsgrupp(ref fel, ref felmeddelande, theDate);
            //lbxGrupper.DataSource = traningsgrupp;
            //lbxGrupper.DisplayMember = "traningsgrupps";
            
            
            //if (fel)
            //{
            //    MessageBox.Show(felmeddelande);
            //}

        }

        private void dtpFran_ValueChanged(object sender, EventArgs e)
        {
            string theDate = dtpFran.Value.ToString("yyyy-MM-dd");

            traningsgrupp nyTraningsgrupp = new traningsgrupp();
            List<traningsgrupp> traningsgrupp = new List<traningsgrupp>();
            bool fel = false;
            string felmeddelande = "";
            traningsgrupp = nyTraningsgrupp.getTraningsgrupp(ref fel, ref felmeddelande, theDate);
            lbxGrupper.DataSource = traningsgrupp;
            lbxGrupper.DisplayMember = "traningsgrupps";


            if (fel)
            {
                MessageBox.Show(felmeddelande);
            }
        }
    }
}
