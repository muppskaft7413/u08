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
            this.lblForening = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbSokDatum = new System.Windows.Forms.GroupBox();
            this.dtpStartDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpSlutDatum = new System.Windows.Forms.DateTimePicker();
            this.btn_klar = new System.Windows.Forms.Button();
            this.gbSokSlutdatum = new System.Windows.Forms.GroupBox();
            this.cbAktivSlutDatum = new System.Windows.Forms.CheckBox();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.lbxGrupper = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapport)).BeginInit();
            this.gbSokDatum.SuspendLayout();
            this.gbSokSlutdatum.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRapport
            // 
            this.dgvRapport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRapport.Location = new System.Drawing.Point(38, 267);
            this.dgvRapport.Name = "dgvRapport";
            this.dgvRapport.Size = new System.Drawing.Size(859, 315);
            this.dgvRapport.TabIndex = 0;
            // 
            // lblForening
            // 
            this.lblForening.AutoSize = true;
            this.lblForening.Location = new System.Drawing.Point(35, 20);
            this.lblForening.Name = "lblForening";
            this.lblForening.Size = new System.Drawing.Size(51, 13);
            this.lblForening.TabIndex = 1;
            this.lblForening.Text = "Förening:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cirkus Kul och Bus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Idrott:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Akrobatik/cirkushallen";
            // 
            // gbSokDatum
            // 
            this.gbSokDatum.Controls.Add(this.dtpStartDatum);
            this.gbSokDatum.Location = new System.Drawing.Point(38, 80);
            this.gbSokDatum.Name = "gbSokDatum";
            this.gbSokDatum.Size = new System.Drawing.Size(289, 135);
            this.gbSokDatum.TabIndex = 8;
            this.gbSokDatum.TabStop = false;
            this.gbSokDatum.Text = "Sök datum";
            // 
            // dtpStartDatum
            // 
            this.dtpStartDatum.Location = new System.Drawing.Point(73, 30);
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
            this.btn_klar.Location = new System.Drawing.Point(822, 590);
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
            this.gbSokSlutdatum.Location = new System.Drawing.Point(38, 151);
            this.gbSokSlutdatum.Name = "gbSokSlutdatum";
            this.gbSokSlutdatum.Size = new System.Drawing.Size(289, 64);
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
            this.tbFeedback.Location = new System.Drawing.Point(38, 592);
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(454, 20);
            this.tbFeedback.TabIndex = 15;
            // 
            // lbxGrupper
            // 
            this.lbxGrupper.FormattingEnabled = true;
            this.lbxGrupper.Location = new System.Drawing.Point(411, 110);
            this.lbxGrupper.Name = "lbxGrupper";
            this.lbxGrupper.Size = new System.Drawing.Size(120, 95);
            this.lbxGrupper.TabIndex = 16;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(631, 110);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 95);
            this.listBox2.TabIndex = 17;
            // 
            // hamtarapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 625);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.lbxGrupper);
            this.Controls.Add(this.tbFeedback);
            this.Controls.Add(this.gbSokSlutdatum);
            this.Controls.Add(this.btn_klar);
            this.Controls.Add(this.gbSokDatum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForening);
            this.Controls.Add(this.dgvRapport);
            this.Name = "hamtarapport";
            this.Text = "hamtarapport";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRapport)).EndInit();
            this.gbSokDatum.ResumeLayout(false);
            this.gbSokSlutdatum.ResumeLayout(false);
            this.gbSokSlutdatum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRapport;
        private System.Windows.Forms.Label lblForening;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbSokDatum;
        private System.Windows.Forms.DateTimePicker dtpStartDatum;
        private System.Windows.Forms.DateTimePicker dtpSlutDatum;
        private System.Windows.Forms.Button btn_klar;
        private System.Windows.Forms.GroupBox gbSokSlutdatum;
        private System.Windows.Forms.CheckBox cbAktivSlutDatum;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.ListBox lbxGrupper;
        private System.Windows.Forms.ListBox listBox2;
    }
}