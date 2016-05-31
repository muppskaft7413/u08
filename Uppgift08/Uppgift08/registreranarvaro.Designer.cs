namespace Uppgift08
{
    partial class registreranarvaro
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
            this.dgvRegistreraNarvaro = new System.Windows.Forms.DataGridView();
            this.lbxGrupper = new System.Windows.Forms.ListBox();
            this.tbFel = new System.Windows.Forms.TextBox();
            this.gbSokSlutdatum = new System.Windows.Forms.GroupBox();
            this.cbAktivSlutDatum = new System.Windows.Forms.CheckBox();
            this.dtpSlutDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFran = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForening = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpGrupp = new System.Windows.Forms.GroupBox();
            this.lbxLedare = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).BeginInit();
            this.gbSokSlutdatum.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpGrupp.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegistreraNarvaro
            // 
            this.dgvRegistreraNarvaro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistreraNarvaro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistreraNarvaro.Location = new System.Drawing.Point(39, 248);
            this.dgvRegistreraNarvaro.Name = "dgvRegistreraNarvaro";
            this.dgvRegistreraNarvaro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistreraNarvaro.Size = new System.Drawing.Size(859, 315);
            this.dgvRegistreraNarvaro.TabIndex = 9;
            this.dgvRegistreraNarvaro.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistreraNarvaro_CellValueChanged);
            this.dgvRegistreraNarvaro.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRegistreraNarvaro_CurrentCellDirtyStateChanged);
            this.dgvRegistreraNarvaro.SelectionChanged += new System.EventHandler(this.dgvRegistreraNarvaro_SelectionChanged);
            // 
            // lbxGrupper
            // 
            this.lbxGrupper.FormattingEnabled = true;
            this.lbxGrupper.Location = new System.Drawing.Point(6, 21);
            this.lbxGrupper.Name = "lbxGrupper";
            this.lbxGrupper.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxGrupper.Size = new System.Drawing.Size(120, 108);
            this.lbxGrupper.TabIndex = 15;
            this.lbxGrupper.Click += new System.EventHandler(this.lbxGrupper_Click);
            // 
            // tbFel
            // 
            this.tbFel.Location = new System.Drawing.Point(39, 569);
            this.tbFel.Name = "tbFel";
            this.tbFel.Size = new System.Drawing.Size(368, 20);
            this.tbFel.TabIndex = 20;
            // 
            // gbSokSlutdatum
            // 
            this.gbSokSlutdatum.Controls.Add(this.cbAktivSlutDatum);
            this.gbSokSlutdatum.Controls.Add(this.dtpSlutDatum);
            this.gbSokSlutdatum.Location = new System.Drawing.Point(39, 137);
            this.gbSokSlutdatum.Name = "gbSokSlutdatum";
            this.gbSokSlutdatum.Size = new System.Drawing.Size(289, 64);
            this.gbSokSlutdatum.TabIndex = 22;
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
            // dtpSlutDatum
            // 
            this.dtpSlutDatum.Enabled = false;
            this.dtpSlutDatum.Location = new System.Drawing.Point(83, 31);
            this.dtpSlutDatum.Name = "dtpSlutDatum";
            this.dtpSlutDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpSlutDatum.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFran);
            this.groupBox1.Location = new System.Drawing.Point(39, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 135);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sök datum";
            // 
            // dtpFran
            // 
            this.dtpFran.Location = new System.Drawing.Point(83, 34);
            this.dtpFran.Name = "dtpFran";
            this.dtpFran.Size = new System.Drawing.Size(200, 20);
            this.dtpFran.TabIndex = 10;
            this.dtpFran.ValueChanged += new System.EventHandler(this.dtpFran_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(204, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Akrobatik/cirkushallen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Idrott:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cirkus Kul och Bus";
            // 
            // lblForening
            // 
            this.lblForening.AutoSize = true;
            this.lblForening.Location = new System.Drawing.Point(36, 16);
            this.lblForening.Name = "lblForening";
            this.lblForening.Size = new System.Drawing.Size(51, 13);
            this.lblForening.TabIndex = 23;
            this.lblForening.Text = "Förening:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(363, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 27;
            // 
            // gpGrupp
            // 
            this.gpGrupp.Controls.Add(this.lbxGrupper);
            this.gpGrupp.Location = new System.Drawing.Point(334, 66);
            this.gpGrupp.Name = "gpGrupp";
            this.gpGrupp.Size = new System.Drawing.Size(306, 135);
            this.gpGrupp.TabIndex = 28;
            this.gpGrupp.TabStop = false;
            this.gpGrupp.Text = "Grupp";
            // 
            // lbxLedare
            // 
            this.lbxLedare.FormattingEnabled = true;
            this.lbxLedare.Location = new System.Drawing.Point(646, 77);
            this.lbxLedare.Name = "lbxLedare";
            this.lbxLedare.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxLedare.Size = new System.Drawing.Size(168, 108);
            this.lbxLedare.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 29;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // registreranarvaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbxLedare);
            this.Controls.Add(this.gpGrupp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForening);
            this.Controls.Add(this.gbSokSlutdatum);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbFel);
            this.Controls.Add(this.dgvRegistreraNarvaro);
            this.Name = "registreranarvaro";
            this.Text = "registreranarvaro";
            this.Load += new System.EventHandler(this.registreranarvaro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).EndInit();
            this.gbSokSlutdatum.ResumeLayout(false);
            this.gbSokSlutdatum.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gpGrupp.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvRegistreraNarvaro_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistreraNarvaro;
        private System.Windows.Forms.ListBox lbxGrupper;
        private System.Windows.Forms.TextBox tbFel;
        private System.Windows.Forms.GroupBox gbSokSlutdatum;
        private System.Windows.Forms.CheckBox cbAktivSlutDatum;
        private System.Windows.Forms.DateTimePicker dtpSlutDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFran;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForening;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpGrupp;
        private System.Windows.Forms.ListBox lbxLedare;
        private System.Windows.Forms.Button button1;
    }
}