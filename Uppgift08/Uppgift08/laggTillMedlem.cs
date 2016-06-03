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
        string nyMedlem;
        string nyGrupp;

        /// <summary>
        /// Ta bort länk mellan medlem och grupp.
        /// </summary>
        private void taBortGruppmedlem()
        {

            foreach (gruppmedlemmar selectedItem in lbxGruppmedlemmar.SelectedItems)
            {
                nyMedlem = selectedItem.medlemId;
            }
            foreach (traningsgrupp selectedItem in lbxTraningsgrupper.SelectedItems)
            {

                nyGrupp = selectedItem.grupp_id.ToString();
            }
            postgres sokning = new postgres();
            sokning.nyMedlem = nyMedlem;
            sokning.enkelGrupp = nyGrupp;
            string narvaroSvar = sokning.sqlNonQuery(sokning.vilkenSokning(false, false, false), "taBortMedlem");     // hämtar sökning efter träningsgrupper
            tbSvar.Text = narvaroSvar;
        }

        /// <summary>
        /// Metod som länker ihop medlem med en vald grupp.
        /// </summary>
        private void lankaGruppOchMedlem()
        {

            foreach (gruppmedlemmar selectedItem in lbxMedlemmar.SelectedItems)
            {
                nyMedlem = selectedItem.medlemId;
            }
            foreach (traningsgrupp selectedItem in lbxTraningsgrupper.SelectedItems)
            {

                nyGrupp = selectedItem.grupp_id.ToString();
            }                
                postgres sokning = new postgres();
                sokning.nyMedlem = nyMedlem;
                sokning.enkelGrupp = nyGrupp;
                string narvaroSvar = sokning.sqlNonQuery(sokning.vilkenSokning(false, false, false), "laggTillMedlem");     // hämtar sökning efter träningsgrupper
                tbSvar.Text = narvaroSvar;
        }

        /// <summary>
        /// Metod som hämtar grupper.
        /// </summary>
        private void hamtaGrupper()
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
                        grupp_id = (int)svarGrp.Rows[i]["grupp_id"]
                    };


                    nyTraningsgruppLista.Add(traningsgruppRatt);
                }

                lbxTraningsgrupper.DataSource = nyTraningsgruppLista;
                lbxTraningsgrupper.DisplayMember = "nyaGrupper";
                tbSvar.Text = sokOk;

            }
        }

        /// <summary>
        /// Metod som hämtar medlemmar som ej finns i aktuell grupp..
        /// </summary>
        private void hamtaEjGruppmedlemmar()
        {
            List<string> gruppLista = new List<string>();
            foreach (traningsgrupp selectedItem in lbxTraningsgrupper.SelectedItems)
            {
                gruppLista.Add(selectedItem.namn);
            }

            DataTable svarNarvaro;

            postgres sokning = new postgres();

            sokning.grupp = gruppLista;


            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(false, false, false), "hamtaEjGruppmedlemmar");   
            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                List<gruppmedlemmar> nyNarvarolista = new List<gruppmedlemmar>();
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {
                    gruppmedlemmar narvarolistaRatt = new gruppmedlemmar()
                    {
                        Förnamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        Efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                        Personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                        medlemId = svarNarvaro.Rows[i]["medlem_id"].ToString(),
                    };


                    nyNarvarolista.Add(narvarolistaRatt);
                    tbSvar.Text = sokOk;
                }

                lbxMedlemmar.DataSource = nyNarvarolista;
                lbxMedlemmar.DisplayMember = "redanGruppMedlemmar";
            }
        }

        /// <summary>
        /// Metod som hämtar medlemmar som finns i aktuell grupp..
        /// </summary>
        public void hamtaGruppmedlemmar()
        {
            List<string> gruppLista = new List<string>();
            foreach (traningsgrupp selectedItem in lbxTraningsgrupper.SelectedItems)
            {
                gruppLista.Add(selectedItem.namn);
            }

            DataTable svarNarvaro;

            postgres sokning = new postgres();

            sokning.grupp = gruppLista;


            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(false, false, false), "hamtaGruppmedlemmar");

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                List<gruppmedlemmar> nyNarvarolista = new List<gruppmedlemmar>();
                for (int i = 0; i < svarNarvaro.Rows.Count; i++)
                {

                    gruppmedlemmar narvarolistaRatt = new gruppmedlemmar()
                    {
                        Förnamn = svarNarvaro.Rows[i]["fnamn"].ToString(),
                        Efternamn = svarNarvaro.Rows[i]["enamn"].ToString(),
                        Personnummer = svarNarvaro.Rows[i]["pnr"].ToString(),
                        medlemId = svarNarvaro.Rows[i]["medlem_id"].ToString(),
                    };


                    nyNarvarolista.Add(narvarolistaRatt);
                    tbSvar.Text = sokOk;
                }

                lbxGruppmedlemmar.DataSource = nyNarvarolista;
                lbxGruppmedlemmar.DisplayMember = "redanGruppMedlemmar";
            }
    }

        #region EVENTHANDLERS

        /// <summary>
        /// Kallar på metoden hamtaGrupper när formen laddas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void laggTillMedlem_Load(object sender, EventArgs e)
        {
            hamtaGrupper();
        }

        /// <summary>
        /// Kallar på metoden hamtaGruppmedlemmar och hamtaEjGruppmedlemmar när man klickar i lbxTraningsgrupper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbxTraningsgrupper_Click(object sender, EventArgs e)
        {
            hamtaGruppmedlemmar();
            hamtaEjGruppmedlemmar();
        }

        /// <summary>
        /// Stänger fönstret.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKlar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Kallar på metoderna lankaGruppOchMedlem, hamtaEjGruppmedlemmar och hamtaGruppmedlemmar
        /// Det som händer är att en medlem registreras som medlem i en vald grupp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTill_Click(object sender, EventArgs e)
        {
            lankaGruppOchMedlem();
            hamtaEjGruppmedlemmar();
            hamtaGruppmedlemmar();
        }

        /// <summary>
        /// Kallar på metoderna taBortGruppmedlem, hamtaEjGruppmedlemmar och hamtaGruppmedlemmar
        /// Det som händer är att en medlem tas bort som gruppmedlem från en grupp.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFran_Click(object sender, EventArgs e)
        {
            taBortGruppmedlem();
            hamtaEjGruppmedlemmar();
            hamtaGruppmedlemmar();
        }
        # endregion
    }
}
