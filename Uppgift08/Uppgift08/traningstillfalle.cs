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
    public partial class traningstillfalle : Form
    {

        gruppmedlemmar nuvarandeGruppMdlm = new gruppmedlemmar();
        trantillfInfo nuvarandeTrantillf = new trantillfInfo();
        traningsgrupp nuvarandeTranGrp = new traningsgrupp();
        gruppaktiviter nuvarandeGruppAktivitet = new gruppaktiviter();

        ListBox _lbxTrantillfalle;
        ListBox _lbxGruppmedlemmar;
        ListBox _lbxTraningsgrupper;
        ListBox _gruppaktiviter;
        
        private traningsgrupp traningsgrupp;
        private List<traningsgrupp> trnGrpLst = new List<traningsgrupp>();              // lista som användas för att populera gruppboxen
        private ListBox _gruppBox;
        string sokOk = "";

        public traningstillfalle()
        {
            InitializeComponent();

            _lbxTrantillfalle = lbxTrantillfalle;
            _lbxGruppmedlemmar = lbxGruppmedlemmar;
            _lbxTraningsgrupper = lbxTraningsgrupper;
            _gruppaktiviter = gruppaktiviter;
            
            _gruppBox = lbxTraningsgrupper;                                                      // grupplistboxen knyts till variabel
            hamtaTranTillf();
            uppdLbGrupp();
        }

        


        /// <summary>
        /// objekt av postgres skapas för att göra sökning mot db
        /// </summary>
        /// <returns>postgres datatyp</returns>
        private postgres startaPostgres()
        {
            postgres s = new postgres();
            return s;
        }

        private void uppdateraGruppbox()
        {
            postgres s = startaPostgres();


        }

        /// <summary>
        /// Populerar Grupplistan
        /// </summary>
        private void uppdLbGrupp()
        {
            DataTable sokGrupper;
            postgres s = startaPostgres();
            sokGrupper = s.sqlFråga("datEnk", "gruppNy");

            for (int i = 0; i < sokGrupper.Rows.Count; i++)
            {
                traningsgrupp = new traningsgrupp();
                traningsgrupp.grupp_id = (int)sokGrupper.Rows[i]["grupp_id"];
                traningsgrupp.namn = sokGrupper.Rows[i]["namn"].ToString();
                trnGrpLst.Add(traningsgrupp);
            }
            _gruppBox.DataSource = null;
            _gruppBox.DataSource = trnGrpLst;
            _gruppBox.DisplayMember = "namn";
        }

        /// <summary>
        /// populerar träningstillfälleslistan
        /// </summary>
        private void hamtaTranTillf()
        {
            DataTable sokning;
            postgres s = startaPostgres();
            sokning = s.sqlFråga("hamtaTillf", "tranTillfalle");

            if (sokning.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = sokning.Rows[0][1].ToString();
            }
            else
            {
                List<trantillfInfo> trantillfLista = new List<trantillfInfo>();
                for (int i = 0; i < sokning.Rows.Count; i++)
                {

                    trantillfInfo tillfalle = new trantillfInfo()
                    {
                        
                        narvarolistaID = (int)sokning.Rows[i]["narvarolista_id"],
                        datum = sokning.Rows[i]["datum"].ToString(),
                        sluttid = (DateTime)sokning.Rows[i]["sluttid"],
                        starttid = (DateTime)sokning.Rows[i]["starttid"]
                    };


                    trantillfLista.Add(tillfalle);
                    tbSvar.Text = sokOk;
                }

                lbxTrantillfalle.DataSource = trantillfLista;
                lbxTrantillfalle.DisplayMember = "trantillfalle";
            }
        }
        
        
        /// <summary>
        /// hämtar gruppmedlemmar till medlemslistboxen
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


            svarNarvaro = sokning.sqlFråga(sokning.vilkenSokning(false, false, false), "hamtaGruppmedlemmar");     // hämtar sökning efter träningsgrupper

            if (svarNarvaro.Columns[0].ColumnName.Equals("error"))
            {
                tbSvar.Text = svarNarvaro.Rows[0][1].ToString();
            }
            else
            {
                // här får man lägga in kod för att reda ut vilken typ av objekt o lista man vill lägga resultatet i och var datan sedan spottas ut
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

        private void koppladeGrupper()
        {
            
        }

        /// <summary>
        /// läser av vilka poster som är markerade 
        /// i samtliga listboxar och hämtar ut objektet till variablarna.
        /// </summary>
        private void lasAvListboxarna()
        {
            nuvarandeGruppMdlm = (gruppmedlemmar)_lbxGruppmedlemmar.SelectedItem;
            nuvarandeTrantillf = (trantillfInfo)_lbxTrantillfalle.SelectedItem;
            nuvarandeTranGrp = (traningsgrupp)_lbxTraningsgrupper.SelectedItem;
            nuvarandeGruppAktivitet = (gruppaktiviter)_gruppaktiviter.SelectedItem;
        }


        // ############ EVENT HANDLERS
        #region
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void lbxGrupper_Click(object sender, EventArgs e)
        {
            hamtaGruppmedlemmar();
        }

        private void lbxTrantillfalle_Click(object sender, EventArgs e)
        {
            koppladeGrupper();
        }


        #endregion





    }
}
