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
        public traningsgrupp nuvarandeGrupp = new traningsgrupp();                      // håller koll på vilken post som är markerad i gruppboxen
        private plats plats;
        
        private List<traningsgrupp> trnGrpLst = new List<traningsgrupp>();              // lista som användas för att populera gruppboxen
        private List<gruppmedlemmar> medlemslista = new List<gruppmedlemmar>();         // lista som användas för att populera medlemsboxen
        private List<gruppmedlemmar> medlemLedareLista = new List<gruppmedlemmar>();         // lista som användas för att populera ledarboxen
        private List<plats> platsLst = new List<plats>();
        
        public plats nuvarandePlats = new plats();                                      // håller koll på vilken post som är markerad i platsboxen
        public plats nuvarandePlats2 = new plats();                                      // håller koll på vilken post som är markerad nedre platsboxen
        public gruppmedlemmar nuvarandeGruppMedlem = new gruppmedlemmar();           // håller koll på vilken post som är markerad i medlemsboxen
        public gruppmedlemmar nuvarandeLedare = new gruppmedlemmar();                // håller koll på vilken post som är markerad i ledarboxen
        
        private gruppmedlemmar medlem;
        #endregion

        #region CONTROLS SOM ÄR KOPPLADE TILL VARIABLAR
        private ListBox _gruppBox;
        private TextBox _beskrivningsBox;
        private ListBox _platsBox;
        private ListBox _platsBox2;
        private TextBox _tbInputGrupp;
        private TextBox _tbBeskrivning;
        private TextBox _tbFeedback;
        private ListBox _medlemsbox;
        private ListBox _ledarbox;
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
            _tbFeedback = tbFeedback;
            _medlemsbox = lbMedlemmar;                  // medlemsboxen
            _ledarbox = lbGrpLedare;                     // gruppledareboxen
            uppdLbGrupp();                               // uppdatera grupplistboxen
            uppdLbPlats(_platsBox, "bygg");              // populerar den ena platsboxen med info
            uppdLbPlats(_platsBox2, "bygg inte");        // populerar den andra platsboxen med info
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
        /// Populerar Grupplistan
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
        /// Populerar medlemslistan och ledarlistan
        /// </summary>
        private void uppdMedlem()
        {
            medlemslista.Clear();
            medlemLedareLista.Clear();
            refreshaLbVal();
            DataTable sokMedlem;
            postgres s = startaPostgres();
            sokMedlem = s.sqlFråga("uppdMedlem", "hanteraGrp");

            for (int i = 0; i < sokMedlem.Rows.Count; i++)
            {
                medlem = new gruppmedlemmar();
                medlem.medlemId = sokMedlem.Rows[i]["medlem_id"].ToString();
                medlem.Förnamn = sokMedlem.Rows[i]["fnamn"].ToString();
                medlem.Efternamn = sokMedlem.Rows[i]["enamn"].ToString();
                medlemslista.Add(medlem);
            }


            sokMedlem = s.sqlFråga("uppdLedare", "hanteraGrp");

            string grp = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].grupp_id.ToString();

            for (int i = 0; i < sokMedlem.Rows.Count; i++)
            {
                medlem = new gruppmedlemmar();
                medlem.medlemId = sokMedlem.Rows[i]["medlem_id"].ToString();
                medlem.Förnamn = sokMedlem.Rows[i]["fnamn"].ToString();
                medlem.Efternamn = sokMedlem.Rows[i]["enamn"].ToString();
                medlem.gruppId = sokMedlem.Rows[i]["grupp"].ToString();

                if (medlem.gruppId == grp)
                {
                    medlemLedareLista.Add(medlem);    
                }
            }

            uppdateraMedlemLedarbox(_medlemsbox, medlemslista);
            uppdateraMedlemLedarbox(_ledarbox, medlemLedareLista);

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
        /// uppdaterar ledarboxen och medlemsboxen
        /// </summary>
        /// <param name="inputListbox"></param>
        /// <param name="lista"></param>
        private void uppdateraMedlemLedarbox(ListBox inputListbox, List<gruppmedlemmar> lista)
        {
            inputListbox.DataSource = null;
            inputListbox.DataSource = lista;
            inputListbox.DisplayMember = "forEftNamn";
        }



        /// <summary>
        /// Uppdaterar info om vilka poster
        /// som har markerats i varje listbox
        /// </summary>
        private void refreshaLbVal()
        {
            nuvarandeGrupp = (traningsgrupp)_gruppBox.SelectedItem;
            nuvarandePlats = (plats)_platsBox.SelectedItem;
            nuvarandePlats2 = (plats)_platsBox2.SelectedItem;
            nuvarandeGruppMedlem = (gruppmedlemmar)_medlemsbox.SelectedItem;
            nuvarandeLedare = (gruppmedlemmar)_ledarbox.SelectedItem;
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
            if (_gruppBox.SelectedIndex != -1)
            {
                refreshaLbVal();
                _beskrivningsBox.Text = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].beskrivning.ToString();
                autoselectPlats(_platsBox);
                _platsBox2.SelectedIndex = -1;
             
            }
        }

        /// <summary>
        /// lägga till grupp
        /// OBS felhantering ej gjord!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLäggTillGrp_Click(object sender, EventArgs e)
        {
            bool t1 = _platsBox2.SelectedIndex == -1 ? true : false;
            bool t2 = _tbBeskrivning.Text == "" ? true : false;
            bool t3 = _tbInputGrupp.Text == "" ? true : false;
            if (t1 || t2 || t3)
            {
                _tbFeedback.Text = "Samtliga fält måste fyllas i";

                return;
            }

            postgres s = startaPostgres();
            s.gNamn = _tbInputGrupp.Text;
            s.gBeskrivning = _tbBeskrivning.Text;
            s.gPlats = _platsBox2.SelectedIndex + 1;
            _tbFeedback.Text = s.sqlNonQuery("adderaGrupp", "hanteraGrp");
            trnGrpLst.Clear();
            uppdLbGrupp();
            _tbFeedback.Text = "Grupp tillagd";
        }

        /// <summary>
        /// deletar markerad rad i gruppboxen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTaBortGrp_Click(object sender, EventArgs e)
        {
            postgres s = startaPostgres();
            refreshaLbVal();
            s.gId = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].grupp_id;
            _tbFeedback.Text = s.sqlNonQuery("taBortGrupp", "hanteraGrp");
            trnGrpLst.Clear();
            uppdLbGrupp();
            _beskrivningsBox.Clear();
        }

        /// <summary>
        /// uppdatera beskrivning av grupp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUppdBeskrivning_Click(object sender, EventArgs e)
        {
            
            postgres s = startaPostgres();
            refreshaLbVal();
            s.gId = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].grupp_id;
            s.gBeskrivning = _beskrivningsBox.Text;
            s.gPlats = _gruppBox.SelectedIndex;
            s.sqlNonQuery("nyBeskrivning", "hanteraGrp");
            trnGrpLst.Clear();
            uppdLbGrupp();
        }

        /// <summary>
        /// Byter plats för en grupp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUppdPlats_Click(object sender, EventArgs e)
        {
            postgres s = startaPostgres();
            refreshaLbVal();
            s.gId = trnGrpLst[trnGrpLst.IndexOf(nuvarandeGrupp)].grupp_id;
            s.gPlats = platsLst[platsLst.IndexOf(nuvarandePlats)].plats_id;
            s.sqlNonQuery("bytGrupp", "hanteraGrp");
            trnGrpLst.Clear();
            uppdLbGrupp();
        }

        /// <summary>
        /// rensar feedbackfönstret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbGrupp_MouseClick(object sender, MouseEventArgs e)
        {
            _tbFeedback.Clear();
            uppdMedlem();                               // populerar medlemslistan
        }

        /// <summary>
        /// lägger till ledare
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblLaggTillMM_Click(object sender, EventArgs e)
        {
            refreshaLbVal();

            //int max = medlemLedareLista.Count;
            int raknare = 0;
            
            // kollar om den valda medlemmen 
            foreach (gruppmedlemmar item in medlemLedareLista)
            {
                if (nuvarandeGruppMedlem.medlemId == item.medlemId)
                {
                    raknare++;
                }
            }
               
            if (raknare == 0)
            {
                postgres s = startaPostgres();
                s.gId = nuvarandeGrupp.grupp_id;                                    // gruppid
                s.gPlats = Convert.ToInt32(nuvarandeGruppMedlem.medlemId);          //medlemsid
                _tbFeedback.Text = s.sqlNonQuery("nyLedare", "hanteraGrp");
            }

            uppdMedlem();               // refreshar ledarboxen och medlemsboxen

        }

        /// <summary>
        /// tar bort markerad ledare från grupp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void taBortMM_Click(object sender, EventArgs e)
        {
            refreshaLbVal();
            postgres s = startaPostgres();
            s.gId = Convert.ToInt32(nuvarandeLedare.medlemId);                      // medlemsid
            s.gPlats = Convert.ToInt32(nuvarandeGrupp.grupp_id);          //grupp
            _tbFeedback.Text = s.sqlNonQuery("taBortLedare", "hanteraGrp");
            uppdMedlem();
        }
        #endregion







        







        

        
    }
}
