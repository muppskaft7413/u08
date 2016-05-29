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
            this.gbSokDatum = new System.Windows.Forms.GroupBox();
            this.lblTill = new System.Windows.Forms.Label();
            this.lblFran = new System.Windows.Forms.Label();
            this.dtpSlutDatum = new System.Windows.Forms.DateTimePicker();
            this.dtpFran = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvRegistreraNarvaro = new System.Windows.Forms.DataGridView();
            this.lbxGrupper = new System.Windows.Forms.ListBox();
            this.cbAktivSlutDatum = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gbSokDatum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSokDatum
            // 
            this.gbSokDatum.Controls.Add(this.lblTill);
            this.gbSokDatum.Controls.Add(this.lblFran);
            this.gbSokDatum.Controls.Add(this.dtpSlutDatum);
            this.gbSokDatum.Controls.Add(this.dtpFran);
            this.gbSokDatum.Location = new System.Drawing.Point(183, 55);
            this.gbSokDatum.Name = "gbSokDatum";
            this.gbSokDatum.Size = new System.Drawing.Size(289, 117);
            this.gbSokDatum.TabIndex = 14;
            this.gbSokDatum.TabStop = false;
            this.gbSokDatum.Text = "Sök datum";
            // 
            // lblTill
            // 
            this.lblTill.AutoSize = true;
            this.lblTill.Location = new System.Drawing.Point(43, 68);
            this.lblTill.Name = "lblTill";
            this.lblTill.Size = new System.Drawing.Size(23, 13);
            this.lblTill.TabIndex = 12;
            this.lblTill.Text = "Till:";
            // 
            // lblFran
            // 
            this.lblFran.AutoSize = true;
            this.lblFran.Location = new System.Drawing.Point(36, 30);
            this.lblFran.Name = "lblFran";
            this.lblFran.Size = new System.Drawing.Size(31, 13);
            this.lblFran.TabIndex = 9;
            this.lblFran.Text = "Från:";
            // 
            // dtpSlutDatum
            // 
            this.dtpSlutDatum.Location = new System.Drawing.Point(73, 68);
            this.dtpSlutDatum.Name = "dtpSlutDatum";
            this.dtpSlutDatum.Size = new System.Drawing.Size(200, 20);
            this.dtpSlutDatum.TabIndex = 11;
            // 
            // dtpFran
            // 
            this.dtpFran.Location = new System.Drawing.Point(73, 30);
            this.dtpFran.Name = "dtpFran";
            this.dtpFran.Size = new System.Drawing.Size(200, 20);
            this.dtpFran.TabIndex = 10;
            this.dtpFran.ValueChanged += new System.EventHandler(this.dtpFran_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Akrobatik/cirkushallen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Idrott:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cirkus Kul och Bus";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Förening:";
            // 
            // dgvRegistreraNarvaro
            // 
            this.dgvRegistreraNarvaro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistreraNarvaro.Location = new System.Drawing.Point(39, 248);
            this.dgvRegistreraNarvaro.Name = "dgvRegistreraNarvaro";
            this.dgvRegistreraNarvaro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegistreraNarvaro.Size = new System.Drawing.Size(859, 315);
            this.dgvRegistreraNarvaro.TabIndex = 9;
            this.dgvRegistreraNarvaro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistreraNarvaro_CellClick);
            this.dgvRegistreraNarvaro.SelectionChanged += new System.EventHandler(this.dgvRegistreraNarvaro_SelectionChanged);
            // 
            // lbxGrupper
            // 
            this.lbxGrupper.FormattingEnabled = true;
            this.lbxGrupper.Location = new System.Drawing.Point(478, 64);
            this.lbxGrupper.Name = "lbxGrupper";
            this.lbxGrupper.Size = new System.Drawing.Size(120, 108);
            this.lbxGrupper.TabIndex = 15;
            this.lbxGrupper.SelectedIndexChanged += new System.EventHandler(this.lbxGrupper_SelectedIndexChanged);
            // 
            // cbAktivSlutDatum
            // 
            this.cbAktivSlutDatum.AutoSize = true;
            this.cbAktivSlutDatum.Checked = true;
            this.cbAktivSlutDatum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAktivSlutDatum.Location = new System.Drawing.Point(198, 191);
            this.cbAktivSlutDatum.Name = "cbAktivSlutDatum";
            this.cbAktivSlutDatum.Size = new System.Drawing.Size(80, 17);
            this.cbAktivSlutDatum.TabIndex = 17;
            this.cbAktivSlutDatum.Text = "checkBox1";
            this.cbAktivSlutDatum.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(694, 207);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 20;
            // 
            // registreranarvaro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 598);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cbAktivSlutDatum);
            this.Controls.Add(this.lbxGrupper);
            this.Controls.Add(this.gbSokDatum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRegistreraNarvaro);
            this.Name = "registreranarvaro";
            this.Text = "registreranarvaro";
            this.gbSokDatum.ResumeLayout(false);
            this.gbSokDatum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistreraNarvaro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void dgvRegistreraNarvaro_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.GroupBox gbSokDatum;
        private System.Windows.Forms.Label lblTill;
        private System.Windows.Forms.Label lblFran;
        private System.Windows.Forms.DateTimePicker dtpSlutDatum;
        private System.Windows.Forms.DateTimePicker dtpFran;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvRegistreraNarvaro;
        private System.Windows.Forms.ListBox lbxGrupper;
        private System.Windows.Forms.CheckBox cbAktivSlutDatum;
        private System.Windows.Forms.TextBox textBox1;
    }
}