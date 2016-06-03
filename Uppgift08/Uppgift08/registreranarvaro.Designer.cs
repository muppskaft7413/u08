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
            this.tbSvar = new System.Windows.Forms.TextBox();
            this.gbSokSlutdatum = new System.Windows.Forms.GroupBox();
            this.cbAktivSlutDatum = new System.Windows.Forms.CheckBox();
            this.dtpSlutDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpFran = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblForening = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpGrupp = new System.Windows.Forms.GroupBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_klar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).BeginInit();
            this.gbSokSlutdatum.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpGrupp.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRegistreraNarvaro
            // 
            this.dgvRegistreraNarvaro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRegistreraNarvaro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistreraNarvaro.Location = new System.Drawing.Point(40, 284);
            this.dgvRegistreraNarvaro.Name = "dgvRegistreraNarvaro";
            this.dgvRegistreraNarvaro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistreraNarvaro.Size = new System.Drawing.Size(859, 315);
            this.dgvRegistreraNarvaro.TabIndex = 9;
            this.dgvRegistreraNarvaro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistreraNarvaro_CellClick);
            this.dgvRegistreraNarvaro.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvRegistreraNarvaro_CurrentCellDirtyStateChanged);
            // 
            // lbxGrupper
            // 
            this.lbxGrupper.FormattingEnabled = true;
            this.lbxGrupper.Location = new System.Drawing.Point(6, 21);
            this.lbxGrupper.Name = "lbxGrupper";
            this.lbxGrupper.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxGrupper.Size = new System.Drawing.Size(294, 108);
            this.lbxGrupper.TabIndex = 15;
            this.lbxGrupper.Click += new System.EventHandler(this.lbxGrupper_Click);
            // 
            // tbSvar
            // 
            this.tbSvar.Location = new System.Drawing.Point(40, 605);
            this.tbSvar.Name = "tbSvar";
            this.tbSvar.Size = new System.Drawing.Size(368, 20);
            this.tbSvar.TabIndex = 20;
            // 
            // gbSokSlutdatum
            // 
            this.gbSokSlutdatum.Controls.Add(this.cbAktivSlutDatum);
            this.gbSokSlutdatum.Controls.Add(this.dtpSlutDatum);
            this.gbSokSlutdatum.Location = new System.Drawing.Point(40, 173);
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
            this.dtpSlutDatum.ValueChanged += new System.EventHandler(this.dtpSlutDatum_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpFran);
            this.groupBox1.Location = new System.Drawing.Point(40, 102);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Cirkus Kul och Bus";
            // 
            // lblForening
            // 
            this.lblForening.AutoSize = true;
            this.lblForening.Location = new System.Drawing.Point(832, 7);
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
            this.gpGrupp.Location = new System.Drawing.Point(335, 102);
            this.gpGrupp.Name = "gpGrupp";
            this.gpGrupp.Size = new System.Drawing.Size(306, 135);
            this.gpGrupp.TabIndex = 28;
            this.gpGrupp.TabStop = false;
            this.gpGrupp.Text = "Grupp";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.textBox1);
            this.gbInfo.Location = new System.Drawing.Point(730, 52);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(169, 100);
            this.gbInfo.TabIndex = 29;
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
            this.textBox1.Text = "CTRL + musklick kan användas för att markera eller avmarkera flera rader i gruppl" +
    "istan.";
            // 
            // btn_klar
            // 
            this.btn_klar.Location = new System.Drawing.Point(824, 605);
            this.btn_klar.Name = "btn_klar";
            this.btn_klar.Size = new System.Drawing.Size(75, 23);
            this.btn_klar.TabIndex = 30;
            this.btn_klar.Text = "Klar";
            this.btn_klar.UseVisualStyleBackColor = true;
            this.btn_klar.Click += new System.EventHandler(this.btn_klar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "Registrera närvaro";
            // 
            // registreranarvaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.gbSokSlutdatum);
            this.Controls.Add(this.btn_klar);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.gpGrupp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblForening);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbSvar);
            this.Controls.Add(this.dgvRegistreraNarvaro);
            this.Name = "registreranarvaro";
            this.Text = "registreranarvaro";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).EndInit();
            this.gbSokSlutdatum.ResumeLayout(false);
            this.gbSokSlutdatum.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.gpGrupp.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
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
        private System.Windows.Forms.TextBox tbSvar;
        private System.Windows.Forms.GroupBox gbSokSlutdatum;
        private System.Windows.Forms.CheckBox cbAktivSlutDatum;
        private System.Windows.Forms.DateTimePicker dtpSlutDatum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFran;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblForening;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpGrupp;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_klar;
        private System.Windows.Forms.Label label5;
    }
}