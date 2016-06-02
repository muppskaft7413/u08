namespace Uppgift08
{
    partial class laggTillGrupp
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
            this.lbGrpLedare = new System.Windows.Forms.ListBox();
            this.lbMedlemmar = new System.Windows.Forms.ListBox();
            this.lblGraphics = new System.Windows.Forms.Label();
            this.lblLaggTillMM = new System.Windows.Forms.Button();
            this.taBortMM = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblFiltrera = new System.Windows.Forms.Label();
            this.lbGrupp = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPlats = new System.Windows.Forms.ListBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.btnTaBortGrp = new System.Windows.Forms.Button();
            this.btnUppdBeskrivning = new System.Windows.Forms.Button();
            this.btnUppdPlats = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBeskrivning = new System.Windows.Forms.TextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.lblGrpNamn = new System.Windows.Forms.Label();
            this.lblBeskrivning = new System.Windows.Forms.Label();
            this.lbValjPlats = new System.Windows.Forms.ListBox();
            this.lblPlats = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLäggTillGrp = new System.Windows.Forms.Button();
            this.btnKlar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGrpLedare
            // 
            this.lbGrpLedare.FormattingEnabled = true;
            this.lbGrpLedare.Location = new System.Drawing.Point(203, 35);
            this.lbGrpLedare.Name = "lbGrpLedare";
            this.lbGrpLedare.Size = new System.Drawing.Size(120, 147);
            this.lbGrpLedare.TabIndex = 0;
            // 
            // lbMedlemmar
            // 
            this.lbMedlemmar.FormattingEnabled = true;
            this.lbMedlemmar.Location = new System.Drawing.Point(53, 35);
            this.lbMedlemmar.Name = "lbMedlemmar";
            this.lbMedlemmar.Size = new System.Drawing.Size(120, 147);
            this.lbMedlemmar.TabIndex = 1;
            // 
            // lblGraphics
            // 
            this.lblGraphics.AutoSize = true;
            this.lblGraphics.Location = new System.Drawing.Point(179, 101);
            this.lblGraphics.Name = "lblGraphics";
            this.lblGraphics.Size = new System.Drawing.Size(19, 13);
            this.lblGraphics.TabIndex = 2;
            this.lblGraphics.Text = "=>";
            // 
            // lblLaggTillMM
            // 
            this.lblLaggTillMM.Location = new System.Drawing.Point(53, 212);
            this.lblLaggTillMM.Name = "lblLaggTillMM";
            this.lblLaggTillMM.Size = new System.Drawing.Size(75, 23);
            this.lblLaggTillMM.TabIndex = 3;
            this.lblLaggTillMM.Text = "Lägg till";
            this.lblLaggTillMM.UseVisualStyleBackColor = true;
            // 
            // taBortMM
            // 
            this.taBortMM.Location = new System.Drawing.Point(203, 212);
            this.taBortMM.Name = "taBortMM";
            this.taBortMM.Size = new System.Drawing.Size(75, 23);
            this.taBortMM.TabIndex = 4;
            this.taBortMM.Text = "Ta bort";
            this.taBortMM.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(53, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // lblFiltrera
            // 
            this.lblFiltrera.AutoSize = true;
            this.lblFiltrera.Location = new System.Drawing.Point(6, 189);
            this.lblFiltrera.Name = "lblFiltrera";
            this.lblFiltrera.Size = new System.Drawing.Size(41, 13);
            this.lblFiltrera.TabIndex = 6;
            this.lblFiltrera.Text = "Filtrera:";
            // 
            // lbGrupp
            // 
            this.lbGrupp.FormattingEnabled = true;
            this.lbGrupp.Location = new System.Drawing.Point(29, 35);
            this.lbGrupp.Name = "lbGrupp";
            this.lbGrupp.Size = new System.Drawing.Size(200, 147);
            this.lbGrupp.TabIndex = 7;
            this.lbGrupp.SelectedIndexChanged += new System.EventHandler(this.lbGrupp_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFiltrera);
            this.groupBox1.Controls.Add(this.lbGrpLedare);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lbMedlemmar);
            this.groupBox1.Controls.Add(this.taBortMM);
            this.groupBox1.Controls.Add(this.lblGraphics);
            this.groupBox1.Controls.Add(this.lblLaggTillMM);
            this.groupBox1.Location = new System.Drawing.Point(729, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 242);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hantera gruppledare";
            // 
            // lbPlats
            // 
            this.lbPlats.FormattingEnabled = true;
            this.lbPlats.Location = new System.Drawing.Point(462, 35);
            this.lbPlats.Name = "lbPlats";
            this.lbPlats.Size = new System.Drawing.Size(200, 147);
            this.lbPlats.TabIndex = 10;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(76, 33);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(368, 20);
            this.maskedTextBox1.TabIndex = 11;
            // 
            // btnTaBortGrp
            // 
            this.btnTaBortGrp.Location = new System.Drawing.Point(29, 189);
            this.btnTaBortGrp.Name = "btnTaBortGrp";
            this.btnTaBortGrp.Size = new System.Drawing.Size(75, 23);
            this.btnTaBortGrp.TabIndex = 12;
            this.btnTaBortGrp.Text = "Ta bort";
            this.btnTaBortGrp.UseVisualStyleBackColor = true;
            // 
            // btnUppdBeskrivning
            // 
            this.btnUppdBeskrivning.Location = new System.Drawing.Point(244, 189);
            this.btnUppdBeskrivning.Name = "btnUppdBeskrivning";
            this.btnUppdBeskrivning.Size = new System.Drawing.Size(75, 23);
            this.btnUppdBeskrivning.TabIndex = 13;
            this.btnUppdBeskrivning.Text = "Uppdatera";
            this.btnUppdBeskrivning.UseVisualStyleBackColor = true;
            // 
            // btnUppdPlats
            // 
            this.btnUppdPlats.Location = new System.Drawing.Point(462, 189);
            this.btnUppdPlats.Name = "btnUppdPlats";
            this.btnUppdPlats.Size = new System.Drawing.Size(75, 23);
            this.btnUppdPlats.TabIndex = 14;
            this.btnUppdPlats.Text = "Byt plats";
            this.btnUppdPlats.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbBeskrivning);
            this.groupBox2.Controls.Add(this.btnUppdPlats);
            this.groupBox2.Controls.Add(this.lbGrupp);
            this.groupBox2.Controls.Add(this.btnUppdBeskrivning);
            this.groupBox2.Controls.Add(this.btnTaBortGrp);
            this.groupBox2.Controls.Add(this.lbPlats);
            this.groupBox2.Location = new System.Drawing.Point(12, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 242);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hantera grupper";
            // 
            // tbBeskrivning
            // 
            this.tbBeskrivning.Location = new System.Drawing.Point(244, 35);
            this.tbBeskrivning.Multiline = true;
            this.tbBeskrivning.Name = "tbBeskrivning";
            this.tbBeskrivning.Size = new System.Drawing.Size(203, 147);
            this.tbBeskrivning.TabIndex = 15;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(76, 59);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(368, 20);
            this.maskedTextBox2.TabIndex = 16;
            // 
            // lblGrpNamn
            // 
            this.lblGrpNamn.AutoSize = true;
            this.lblGrpNamn.Location = new System.Drawing.Point(8, 33);
            this.lblGrpNamn.Name = "lblGrpNamn";
            this.lblGrpNamn.Size = new System.Drawing.Size(65, 13);
            this.lblGrpNamn.TabIndex = 17;
            this.lblGrpNamn.Text = "Gruppnamn:";
            // 
            // lblBeskrivning
            // 
            this.lblBeskrivning.AutoSize = true;
            this.lblBeskrivning.Location = new System.Drawing.Point(8, 59);
            this.lblBeskrivning.Name = "lblBeskrivning";
            this.lblBeskrivning.Size = new System.Drawing.Size(65, 13);
            this.lblBeskrivning.TabIndex = 18;
            this.lblBeskrivning.Text = "Beskrivning:";
            // 
            // lbValjPlats
            // 
            this.lbValjPlats.FormattingEnabled = true;
            this.lbValjPlats.Location = new System.Drawing.Point(76, 92);
            this.lbValjPlats.Name = "lbValjPlats";
            this.lbValjPlats.Size = new System.Drawing.Size(368, 108);
            this.lbValjPlats.TabIndex = 15;
            // 
            // lblPlats
            // 
            this.lblPlats.AutoSize = true;
            this.lblPlats.Location = new System.Drawing.Point(37, 92);
            this.lblPlats.Name = "lblPlats";
            this.lblPlats.Size = new System.Drawing.Size(33, 13);
            this.lblPlats.TabIndex = 19;
            this.lblPlats.Text = "Plats:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLäggTillGrp);
            this.groupBox3.Controls.Add(this.lbValjPlats);
            this.groupBox3.Controls.Add(this.lblPlats);
            this.groupBox3.Controls.Add(this.maskedTextBox1);
            this.groupBox3.Controls.Add(this.maskedTextBox2);
            this.groupBox3.Controls.Add(this.lblBeskrivning);
            this.groupBox3.Controls.Add(this.lblGrpNamn);
            this.groupBox3.Location = new System.Drawing.Point(240, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 236);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lägg till grupp";
            // 
            // btnLäggTillGrp
            // 
            this.btnLäggTillGrp.Location = new System.Drawing.Point(369, 206);
            this.btnLäggTillGrp.Name = "btnLäggTillGrp";
            this.btnLäggTillGrp.Size = new System.Drawing.Size(75, 23);
            this.btnLäggTillGrp.TabIndex = 22;
            this.btnLäggTillGrp.Text = "Lägg till";
            this.btnLäggTillGrp.UseVisualStyleBackColor = true;
            // 
            // btnKlar
            // 
            this.btnKlar.Location = new System.Drawing.Point(977, 491);
            this.btnKlar.Name = "btnKlar";
            this.btnKlar.Size = new System.Drawing.Size(75, 23);
            this.btnKlar.TabIndex = 21;
            this.btnKlar.Text = "Klar";
            this.btnKlar.UseVisualStyleBackColor = true;
            this.btnKlar.Click += new System.EventHandler(this.btnKlar_Click);
            // 
            // laggTillGrupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 529);
            this.Controls.Add(this.btnKlar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "laggTillGrupp";
            this.Text = "laggTillGrupp";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGrpLedare;
        private System.Windows.Forms.ListBox lbMedlemmar;
        private System.Windows.Forms.Label lblGraphics;
        private System.Windows.Forms.Button lblLaggTillMM;
        private System.Windows.Forms.Button taBortMM;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFiltrera;
        private System.Windows.Forms.ListBox lbGrupp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbPlats;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button btnTaBortGrp;
        private System.Windows.Forms.Button btnUppdBeskrivning;
        private System.Windows.Forms.Button btnUppdPlats;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label lblGrpNamn;
        private System.Windows.Forms.Label lblBeskrivning;
        private System.Windows.Forms.ListBox lbValjPlats;
        private System.Windows.Forms.Label lblPlats;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKlar;
        private System.Windows.Forms.Button btnLäggTillGrp;
        private System.Windows.Forms.TextBox tbBeskrivning;
    }
}