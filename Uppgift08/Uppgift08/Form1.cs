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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // ############### EVENT HANDLERS  ############### 

        /// <summary>
        /// Öppnar upp ett nytt fönster för att ta fram närvarorapport
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            hamtarapport nyRapport = new hamtarapport();   
            //newWin.Owner = this;
            nyRapport.ShowDialog();
        }

        private void btn_narvaro_Click(object sender, EventArgs e)
        {
            registreranarvaro nyNarvaro = new registreranarvaro();
            nyNarvaro.ShowDialog();
        }
    }
}
