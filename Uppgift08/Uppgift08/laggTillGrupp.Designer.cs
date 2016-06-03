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
            this.lbGrupp = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPlats = new System.Windows.Forms.ListBox();
            this.btnTaBortGrp = new System.Windows.Forms.Button();
            this.btnUppdBeskrivning = new System.Windows.Forms.Button();
            this.btnUppdPlats = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbBeskrivning = new System.Windows.Forms.TextBox();
            this.lblGrpNamn = new System.Windows.Forms.Label();
            this.lblBeskrivning = new System.Windows.Forms.Label();
            this.lbValjPlats = new System.Windows.Forms.ListBox();
            this.lblPlats = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbInputBeskrivning = new System.Windows.Forms.TextBox();
            this.tbInputGrupp = new System.Windows.Forms.TextBox();
            this.btnLäggTillGrp = new System.Windows.Forms.Button();
            this.btnKlar = new System.Windows.Forms.Button();
            this.tbFeedback = new System.Windows.Forms.TextBox();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblForening = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbGrpLedare
            // 
            this.lbGrpLedare.FormattingEnabled = true;
            this.lbGrpLedare.Location = new System.Drawing.Point(176, 59);
            this.lbGrpLedare.Name = "lbGrpLedare";
            this.lbGrpLedare.Size = new System.Drawing.Size(120, 147);
            this.lbGrpLedare.TabIndex = 0;
            // 
            // lbMedlemmar
            // 
            this.lbMedlemmar.FormattingEnabled = true;
            this.lbMedlemmar.Location = new System.Drawing.Point(26, 59);
            this.lbMedlemmar.Name = "lbMedlemmar";
            this.lbMedlemmar.Size = new System.Drawing.Size(120, 147);
            this.lbMedlemmar.TabIndex = 1;
            // 
            // lblGraphics
            // 
            this.lblGraphics.AutoSize = true;
            this.lblGraphics.Location = new System.Drawing.Point(152, 125);
            this.lblGraphics.Name = "lblGraphics";
            this.lblGraphics.Size = new System.Drawing.Size(19, 13);
            this.lblGraphics.TabIndex = 2;
            this.lblGraphics.Text = "=>";
            // 
            // lblLaggTillMM
            // 
            this.lblLaggTillMM.Location = new System.Drawing.Point(26, 213);
            this.lblLaggTillMM.Name = "lblLaggTillMM";
            this.lblLaggTillMM.Size = new System.Drawing.Size(75, 23);
            this.lblLaggTillMM.TabIndex = 3;
            this.lblLaggTillMM.Text = "Lägg till";
            this.lblLaggTillMM.UseVisualStyleBackColor = true;
            this.lblLaggTillMM.Click += new System.EventHandler(this.lblLaggTillMM_Click);
            // 
            // taBortMM
            // 
            this.taBortMM.Location = new System.Drawing.Point(176, 213);
            this.taBortMM.Name = "taBortMM";
            this.taBortMM.Size = new System.Drawing.Size(75, 23);
            this.taBortMM.TabIndex = 4;
            this.taBortMM.Text = "Ta bort";
            this.taBortMM.UseVisualStyleBackColor = true;
            this.taBortMM.Click += new System.EventHandler(this.taBortMM_Click);
            // 
            // lbGrupp
            // 
            this.lbGrupp.FormattingEnabled = true;
            this.lbGrupp.Location = new System.Drawing.Point(29, 59);
            this.lbGrupp.Name = "lbGrupp";
            this.lbGrupp.Size = new System.Drawing.Size(200, 147);
            this.lbGrupp.TabIndex = 7;
            this.lbGrupp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbGrupp_MouseClick);
            this.lbGrupp.SelectedIndexChanged += new System.EventHandler(this.lbGrupp_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbGrpLedare);
            this.groupBox1.Controls.Add(this.lbMedlemmar);
            this.groupBox1.Controls.Add(this.taBortMM);
            this.groupBox1.Controls.Add(this.lblGraphics);
            this.groupBox1.Controls.Add(this.lblLaggTillMM);
            this.groupBox1.Location = new System.Drawing.Point(729, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 242);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hantera gruppledare";
            // 
            // lbPlats
            // 
            this.lbPlats.FormattingEnabled = true;
            this.lbPlats.Location = new System.Drawing.Point(462, 59);
            this.lbPlats.Name = "lbPlats";
            this.lbPlats.Size = new System.Drawing.Size(200, 147);
            this.lbPlats.TabIndex = 10;
            // 
            // btnTaBortGrp
            // 
            this.btnTaBortGrp.Location = new System.Drawing.Point(29, 213);
            this.btnTaBortGrp.Name = "btnTaBortGrp";
            this.btnTaBortGrp.Size = new System.Drawing.Size(75, 23);
            this.btnTaBortGrp.TabIndex = 12;
            this.btnTaBortGrp.Text = "Ta bort";
            this.btnTaBortGrp.UseVisualStyleBackColor = true;
            this.btnTaBortGrp.Click += new System.EventHandler(this.btnTaBortGrp_Click);
            // 
            // btnUppdBeskrivning
            // 
            this.btnUppdBeskrivning.Location = new System.Drawing.Point(244, 213);
            this.btnUppdBeskrivning.Name = "btnUppdBeskrivning";
            this.btnUppdBeskrivning.Size = new System.Drawing.Size(75, 23);
            this.btnUppdBeskrivning.TabIndex = 13;
            this.btnUppdBeskrivning.Text = "Uppdatera";
            this.btnUppdBeskrivning.UseVisualStyleBackColor = true;
            this.btnUppdBeskrivning.Click += new System.EventHandler(this.btnUppdBeskrivning_Click);
            // 
            // btnUppdPlats
            // 
            this.btnUppdPlats.Location = new System.Drawing.Point(462, 213);
            this.btnUppdPlats.Name = "btnUppdPlats";
            this.btnUppdPlats.Size = new System.Drawing.Size(75, 23);
            this.btnUppdPlats.TabIndex = 14;
            this.btnUppdPlats.Text = "Byt plats";
            this.btnUppdPlats.UseVisualStyleBackColor = true;
            this.btnUppdPlats.Click += new System.EventHandler(this.btnUppdPlats_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbBeskrivning);
            this.groupBox2.Controls.Add(this.btnUppdPlats);
            this.groupBox2.Controls.Add(this.lbGrupp);
            this.groupBox2.Controls.Add(this.btnUppdBeskrivning);
            this.groupBox2.Controls.Add(this.btnTaBortGrp);
            this.groupBox2.Controls.Add(this.lbPlats);
            this.groupBox2.Location = new System.Drawing.Point(12, 37);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(711, 242);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hantera grupper";
            // 
            // tbBeskrivning
            // 
            this.tbBeskrivning.Location = new System.Drawing.Point(244, 59);
            this.tbBeskrivning.Multiline = true;
            this.tbBeskrivning.Name = "tbBeskrivning";
            this.tbBeskrivning.Size = new System.Drawing.Size(203, 147);
            this.tbBeskrivning.TabIndex = 15;
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
            this.groupBox3.Controls.Add(this.tbInputBeskrivning);
            this.groupBox3.Controls.Add(this.tbInputGrupp);
            this.groupBox3.Controls.Add(this.btnLäggTillGrp);
            this.groupBox3.Controls.Add(this.lbValjPlats);
            this.groupBox3.Controls.Add(this.lblPlats);
            this.groupBox3.Controls.Add(this.lblBeskrivning);
            this.groupBox3.Controls.Add(this.lblGrpNamn);
            this.groupBox3.Location = new System.Drawing.Point(240, 285);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(483, 236);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lägg till grupp";
            // 
            // tbInputBeskrivning
            // 
            this.tbInputBeskrivning.Location = new System.Drawing.Point(76, 59);
            this.tbInputBeskrivning.Name = "tbInputBeskrivning";
            this.tbInputBeskrivning.Size = new System.Drawing.Size(368, 20);
            this.tbInputBeskrivning.TabIndex = 23;
            // 
            // tbInputGrupp
            // 
            this.tbInputGrupp.Location = new System.Drawing.Point(76, 33);
            this.tbInputGrupp.Name = "tbInputGrupp";
            this.tbInputGrupp.Size = new System.Drawing.Size(368, 20);
            this.tbInputGrupp.TabIndex = 22;
            // 
            // btnLäggTillGrp
            // 
            this.btnLäggTillGrp.Location = new System.Drawing.Point(369, 206);
            this.btnLäggTillGrp.Name = "btnLäggTillGrp";
            this.btnLäggTillGrp.Size = new System.Drawing.Size(75, 23);
            this.btnLäggTillGrp.TabIndex = 22;
            this.btnLäggTillGrp.Text = "Lägg till";
            this.btnLäggTillGrp.UseVisualStyleBackColor = true;
            this.btnLäggTillGrp.Click += new System.EventHandler(this.btnLäggTillGrp_Click);
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
            // tbFeedback
            // 
            this.tbFeedback.BackColor = System.Drawing.SystemColors.Info;
            this.tbFeedback.Location = new System.Drawing.Point(814, 369);
            this.tbFeedback.Multiline = true;
            this.tbFeedback.Name = "tbFeedback";
            this.tbFeedback.Size = new System.Drawing.Size(206, 104);
            this.tbFeedback.TabIndex = 22;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(814, 350);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(58, 13);
            this.lblFeedback.TabIndex = 23;
            this.lblFeedback.Text = "Feedback:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Grupper:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Beskrivning:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Plats för aktivitet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Medlemmar:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Ledare:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 24);
            this.label6.TabIndex = 25;
            this.label6.Text = "Hantera grupper";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(974, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Cirkus Kul och Bus";
            // 
            // lblForening
            // 
            this.lblForening.AutoSize = true;
            this.lblForening.Location = new System.Drawing.Point(974, 4);
            this.lblForening.Name = "lblForening";
            this.lblForening.Size = new System.Drawing.Size(51, 13);
            this.lblForening.TabIndex = 26;
            this.lblForening.Text = "Förening:";
            // 
            // laggTillGrupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 529);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblForening);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.tbFeedback);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGrpLedare;
        private System.Windows.Forms.ListBox lbMedlemmar;
        private System.Windows.Forms.Label lblGraphics;
        private System.Windows.Forms.Button lblLaggTillMM;
        private System.Windows.Forms.Button taBortMM;
        private System.Windows.Forms.ListBox lbGrupp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbPlats;
        private System.Windows.Forms.Button btnTaBortGrp;
        private System.Windows.Forms.Button btnUppdBeskrivning;
        private System.Windows.Forms.Button btnUppdPlats;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblGrpNamn;
        private System.Windows.Forms.Label lblBeskrivning;
        private System.Windows.Forms.ListBox lbValjPlats;
        private System.Windows.Forms.Label lblPlats;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKlar;
        private System.Windows.Forms.Button btnLäggTillGrp;
        private System.Windows.Forms.TextBox tbBeskrivning;
        private System.Windows.Forms.TextBox tbInputBeskrivning;
        private System.Windows.Forms.TextBox tbInputGrupp;
        private System.Windows.Forms.TextBox tbFeedback;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblForening;
    }
}