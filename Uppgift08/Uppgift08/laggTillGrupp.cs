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
    public partial class laggTillGrupp : Form
    {

        #region VARIABLAR OCH PROPERTIES
        private traningsgrupp traningsgrupp;
        private plats plats;
        private List<traningsgrupp> trnGrpLst = new List<traningsgrupp>();
        private List<plats> platsLst = new List<plats>();
        public traningsgrupp nuvarandeGrupp = new traningsgrupp();                      // håller koll på vilken post som är markerad i gruppboxen
        public plats nuvarandePlats = new plats();                                      // håller koll på vilken post som är markerad i platsboxen
        public plats nuvarandePlats2 = new plats();                                      // håller koll på vilken post som är markerad nedre platsboxen
        #endregion

        #region CONTROLS SOM ÄR KOPPLADE TILL VARIABLAR
        private ListBox _gruppBox;
        private TextBox _beskrivningsBox;
        private ListBox _platsBox;
        private ListBox _platsBox2;
        private TextBox _tbInputGrupp;
        private TextBox _tbBeskrivning;
        #endregion

        /// <summary>
        /// ########## CONSTRUCTOR ########## 
        /// </summary>
        public laggTillGrupp()
        {
            InitializeComponent();

            _gruppBox = lbGrupp;                         // grupplistboxen knyts till variabel
            _beskrivningsBox = tbBeskrivning;            // beskrivningsboxen knyts till variabel
            _platsBox = lbPlats;                         // platsboxen knyts till variabel
            _platsBox2 = lbValjPlats;
            _tbInputGrupp = tbInputGrupp;                //
            _tbBeskrivning = tbInputBeskrivning;
            uppdLbGrupp();                               // uppdatera grupplistboxen
            uppdLbPlats(_platsBox, "bygg");                      // populerar den ena platsboxen med info
            uppdLbPlats(_platsBox2, "bygg inte");                     // populerar den andra platsboxen med info
            _platsBox.SelectedIndex = -1;
            _platsBox2.SelectedIndex = -1;
            _gruppBox.SelectedIndex = -1;
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

        /// <summary>
        /// uppdaterar Grupplistan
        /// </summary>
        private void uppdLbGrupp()
        {
            DataTable sokGrupper;
            postgres s = startaPostgres();
            sokGrupper = s.sqlFråga("uppdLbGrupp", "hanteraGrp");

            for (int i = 0; i < sokGrupper.Rows.Count; i++)
            {
                traningsgrupp = new traningsgrupp();
                traningsgrupp.grupp_id = (int)sokGrupper.Rows[i]["grupp_id"];
                traningsgrupp.namn = sokGrupper.Rows[i]["namn"].ToString();
                traningsgrupp.beskrivning = sokGrupper.Rows[i]["beskrivning"].ToString();
                traningsgrupp.plats = (int)sokGrupper.Rows[i]["plats"];
                trnGrpLst.Add(traningsgrupp);
            }
            _gruppBox.DataSource = null;
            _gruppBox.DataSource = trnGrpLst;
            _gruppBox.DisplayMember = "namn";
            
        }

        /// <summary>
        /// populerar Platslistan
        /// </summary>
        private void uppdLbPlats(ListBox platsbox, string toByggOrNotToBygg)
        {
            DataTable sokPlats;
            postgres s = startaPostgres();
            sokPlats = s.sqlFråga("uppdLbPlats", "hanteraGrp");

            if (toByggOrNotToBygg == "bygg")
            {
                for (int i = 0; i < sokPlats.Rows.Count; i++)
                {
                    plats = new plats();
                    plats.plats_id = (int)sokPlats.Rows[i]["plats_id"];
                    plats.namn = sokPlats.Rows[i]["namn"].ToString();
                    platsLst.Add(plats);
                }
            }
            
            
            uppdateraPlatsbox(platsbox);
        }


        /// <summary>
        /// markerar den plats i platsboxen som tillhör nuvarande markerade Grupp
        /// </summary>
        private void autoselectPlats(ListBox pb)
        {
            int nuvarandeGruppsPlatsID = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].plats;
            string orginalPlats;
            bool pass = false;
            foreach (plats item in platsLst)
            {
                pass = (item.plats_id.Equals(nuvarandeGruppsPlatsID)) ? true : false;
                if (pass)
                {
                    orginalPlats = item.namn;
                    for (int i = 0; i < platsLst.Count; i++)
                    {

                        if (platsLst[i].plats_id == nuvarandeGruppsPlatsID)
                        {
                            pb.SelectedIndex = i;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// uppdaterar en av de två platsboxarna
        /// Input till metoden är variabeln för en av de två platsboxarna.
        /// </summary>
        /// <param name="plts"></param>
        private void uppdateraPlatsbox(ListBox inputListbox)
        {
            inputListbox.DataSource = null;
            inputListbox.DataSource = platsLst;
            inputListbox.DisplayMember = "namn";
        }


        /// <summary>
        /// Uppdaterar alla listboxar
        /// </summary>
        private void refreshaLbVal()
        {
            nuvarandeGrupp = (traningsgrupp)_gruppBox.SelectedItem;
            nuvarandePlats = (plats)_platsBox.SelectedItem;
            nuvarandePlats2 = (plats)_platsBox2.SelectedItem;
        }



        // ################## VANLIGA METODER SKALL VARA OVANFÖR DENNA RAD

        #region EVENT HANDLERS

        /// <summary>
        /// stänger fönstret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKlar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// uppdaterar platslistboxen till senaste status och väljer
        /// den post som tillhör nuvarande markerad grupp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGrupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (_gruppBox.SelectedIndex != -1 && _platsBox.SelectedIndex != -1)
            if (_gruppBox.SelectedIndex != -1)
            {
                refreshaLbVal();
                _beskrivningsBox.Text = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].beskrivning.ToString();
                autoselectPlats(_platsBox);
                _platsBox2.SelectedIndex = -1;
            }
            
        }

        private void btnLäggTillGrp_Click(object sender, EventArgs e)
        {
            postgres s = startaPostgres();
            s.gNamn = _tbInputGrupp.Text;
            s.gBeskrivning = _tbBeskrivning.Text;
            s.gPlats = _platsBox2.SelectedIndex + 1;
            string hej = s.sqlNonQuery("adderaGrupp", "hanteraGrp");
            trnGrpLst.Clear();
            uppdLbGrupp();
        }

                

        #endregion



        

        
    }
}
