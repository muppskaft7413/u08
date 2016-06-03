namespace Uppgift08
{
    partial class hamtarapport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRapport = new System.Windows.Forms.DataGridView();
            this.gbSokDatum = new System.Windows.Forms.GroupBox();
            this.dtpStartDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpSlutDatum = new System.Windows.Forms.DateTimePicker();
            this.btn_klar = new System.Windows.Forms.Button();
            this.gbSokSlutdatum = new System.Windows.Forms.GroupBox();
            this.cbAktivSlutDatum = new System.Windows.Forms.CheckBox();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.lbxGrupper = new System.Windows.Forms.ListBox();
            this.lbxLedare = new System.Windows.Forms.ListBox();
            this.lbxSummering = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblForening = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapport)).BeginInit();
            this.gbSokDatum.SuspendLayout();
            this.gbSokSlutdatum.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRapport
            // 
            this.dgvRapport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRapport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapport.Location = new System.Drawing.Point(338, 80);
            this.dgvRapport.Name = "dgvRapport";
            this.dgvRapport.Size = new System.Drawing.Size(998, 341);
            this.dgvRapport.TabIndex = 0;
            // 
            // gbSokDatum
            // 
            this.gbSokDatum.Controls.Add(this.dtpStartDatum);
            this.gbSokDatum.Controls.Add(this.gbSokSlutdatum);
            this.gbSokDatum.Location = new System.Drawing.Point(12, 80);
            this.gbSokDatum.Name = "gbSokDatum";
            this.gbSokDatum.Size = new System.Drawing.Size(300, 135);
            this.gbSokDatum.TabIndex = 8;
            this.gbSokDatum.TabStop = false;
            this.gbSokDatum.Text = "Sök datum";
            // 
            // dtpStartDatum
            // 
            this.dtpStartDatum.Location = new System.Drawing.Point(83, 30);
            this.dtpStartDatum.Name = "dtpStartDatum";
            this.dtpStartDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDatum.TabIndex = 10;
            this.dtpStartDatum.ValueChanged += new System.EventHandler(this.dtpStartDatum_ValueChanged);
            // 
            // dtpSlutDatum
            // 
            this.dtpSlutDatum.Enabled = false;
            this.dtpSlutDatum.Location = new System.Drawing.Point(83, 31);
            this.dtpSlutDatum.Name = "dtpSlutDatum";
            this.dtpSlutDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpSlutDatum.TabIndex = 11;
            this.dtpSlutDatum.ValueChanged += new System.EventHandler(this.dtpSlutDatum_ValueChanged);
            // 
            // btn_klar
            // 
            this.btn_klar.Location = new System.Drawing.Point(1261, 571);
            this.btn_klar.Name = "btn_klar";
            this.btn_klar.Size = new System.Drawing.Size(75, 23);
            this.btn_klar.TabIndex = 9;
            this.btn_klar.Text = "Klar";
            this.btn_klar.UseVisualStyleBackColor = true;
            this.btn_klar.Click += new System.EventHandler(this.btn_klar_Click);
            // 
            // gbSokSlutdatum
            // 
            this.gbSokSlutdatum.Controls.Add(this.cbAktivSlutDatum);
            this.gbSokSlutdatum.Controls.Add(this.dtpSlutDatum);
            this.gbSokSlutdatum.Location = new System.Drawing.Point(0, 71);
            this.gbSokSlutdatum.Name = "gbSokSlutdatum";
            this.gbSokSlutdatum.Size = new System.Drawing.Size(300, 64);
            this.gbSokSlutdatum.TabIndex = 14;
            this.gbSokSlutdatum.TabStop = false;
            this.gbSokSlutdatum.Text = "Sök slutdatum (valfritt)";
            // 
            // cbAktivSlutDatum
            // 
            this.cbAktivSlutDatum.AutoSize = true;
            this.cbAktivSlutDatum.Location = new System.Drawing.Point(12, 31);
            this.cbAktivSlutDatum.Name = "cbAktivSlutDatum";
            this.cbAktivSlutDatum.Size = new System.Drawing.Size(65, 17);
            this.cbAktivSlutDatum.TabIndex = 15;
            this.cbAktivSlutDatum.Text = "Aktivera";
            this.cbAktivSlutDatum.UseVisualStyleBackColor = true;
            this.cbAktivSlutDatum.CheckedChanged += new System.EventHandler(this.cbAktivSlutDatum_CheckedChanged);
            // 
            // tbFeedback
            // 
            this.tbFeedback.BackColor = System.Drawing.SystemColors.Info;
            this.tbFeedback.Enabled = false;
            this.tbFeedback.Location = new System.Drawing.Point(971, 487);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(365, 65);
            this.tbFeedback.TabIndex = 15;
            // 
            // lbxGrupper
            // 
            this.lbxGrupper.FormattingEnabled = true;
            this.lbxGrupper.Location = new System.Drawing.Point(168, 248);
            this.lbxGrupper.Name = "lbxGrupper";
            this.lbxGrupper.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxGrupper.Size = new System.Drawing.Size(144, 134);
            this.lbxGrupper.TabIndex = 17;
            this.lbxGrupper.Click += new System.EventHandler(this.lbxGrupper_Click);
            // 
            // lbxLedare
            // 
            this.lbxLedare.FormattingEnabled = true;
            this.lbxLedare.Location = new System.Drawing.Point(12, 248);
            this.lbxLedare.Name = "lbxLedare";
            this.lbxLedare.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxLedare.Size = new System.Drawing.Size(144, 134);
            this.lbxLedare.TabIndex = 16;
            this.lbxLedare.Click += new System.EventHandler(this.lbxLedare_Click);
            // 
            // lbxSummering
            // 
            this.lbxSummering.FormattingEnabled = true;
            this.lbxSummering.Location = new System.Drawing.Point(338, 431);
            this.lbxSummering.Name = "lbxSummering";
            this.lbxSummering.ScrollAlwaysVisible = true;
            this.lbxSummering.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxSummering.Size = new System.Drawing.Size(627, 121);
            this.lbxSummering.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ledare:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(165, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Grupper:";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.textBox1);
            this.gbInfo.Location = new System.Drawing.Point(77, 414);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(169, 100);
            this.gbInfo.TabIndex = 21;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Tips!";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Info;
            this.textBox1.Location = new System.Drawing.Point(7, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 74);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "CTRL + musklick kan användas för att markera eller avmarkera flera rader i grupp-" +
    " och ledarlistan.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(971, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Feedback";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Traningsrapport:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 24);
            this.label2.TabIndex = 24;
            this.label2.Text = "Närvarorapport";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1240, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Cirkus Kul och Bus";
            // 
            // lblForening
            // 
            this.lblForening.AutoSize = true;
            this.lblForening.Location = new System.Drawing.Point(1240, 7);
            this.lblForening.Name = "lblForening";
            this.lblForening.Size = new System.Drawing.Size(51, 13);
            this.lblForening.TabIndex = 25;
            this.lblForening.Text = "Förening:";
            // 
            // hamtarapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 610);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblForening);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxSummering);
            this.Controls.Add(this.lbxLedare);
            this.Controls.Add(this.lbxGrupper);
            this.Controls.Add(this.tbFeedback);
            this.Controls.Add(this.btn_klar);
            this.Controls.Add(this.gbSokDatum);
            this.Controls.Add(this.dgvRapport);
            this.Name = "hamtarapport";
            this.Text = "hamtarapport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapport)).EndInit();
            this.gbSokDatum.ResumeLayout(false);
            this.gbSokSlutdatum.ResumeLayout(false);
            this.gbSokSlutdatum.PerformLayout();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRapport;
        private System.Windows.Forms.GroupBox gbSokDatum;
        private System.Windows.Forms.DateTimePicker dtpStartDatum;
        private System.Windows.Forms.DateTimePicker dtpSlutDatum;
        private System.Windows.Forms.Button btn_klar;
        private System.Windows.Forms.GroupBox gbSokSlutdatum;
        private System.Windows.Forms.CheckBox cbAktivSlutDatum;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.ListBox lbxGrupper;
        private System.Windows.Forms.ListBox lbxLedare;
        private System.Windows.Forms.ListBox lbxSummering;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblForening;
    }
}