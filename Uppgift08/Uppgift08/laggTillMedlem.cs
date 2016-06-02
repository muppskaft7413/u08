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
    public partial class laggTillMedlem : Form
    {
        public laggTillMedlem()
        {
            InitializeComponent();
        }
        private string sokOk = "Sökning ok";   

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void laggTillMedlem_Load(object sender, EventArgs e)
        {
            DataTable svarGrp;
            postgres sokning = new postgres();

            svarGrp = sokning.sqlFråga(sokning.vilkenSokning(false, false, false), "gruppNy");     // hämtar sökning efter träningsgrupper

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
                        //tid = svarGrp.Rows[i]["starttid"].ToString(),
                        //datum = svarGrp.Rows[i]["datum"].ToString()
                    };


                    nyTraningsgruppLista.Add(traningsgruppRatt);
                }

                lbxTraningsgrupper.DataSource = nyTraningsgruppLista;
                lbxTraningsgrupper.DisplayMember = "traningsgrupps";
                tbSvar.Text = sokOk;

            }
        }
        }
    }
