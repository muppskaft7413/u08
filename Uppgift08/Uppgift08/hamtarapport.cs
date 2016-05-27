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
    public partial class hamtarapport : Form
    {
        public hamtarapport()
        {
            InitializeComponent();
            dtpSlutDatum.Enabled = false;

        }

        
        
        // ############# EVENT HANDLERS ##############
        private void btn_klar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSok_Click(object sender, EventArgs e)
        {

        }

        private void cbAktivSlutDatum_CheckedChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Enabled == false)
            {
                dtpSlutDatum.Enabled = true;
            }
            else
            {
                dtpSlutDatum.Enabled = false;
            }
        }

        private void dtpSlutDatum_ValueChanged(object sender, EventArgs e)
        {
            if(dtpSlutDatum.Value <= dtpStartDatum.Value)
            {
                dtpSlutDatum.Value = dtpStartDatum.Value.AddHours(24);
                tbFeedback.Text = "Slutdatumet måste vara minst en dag mer än startdatumet.";
            }
        }
    }
}
