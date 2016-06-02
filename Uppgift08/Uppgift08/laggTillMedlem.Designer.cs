namespace Uppgift08
{
    partial class laggTillMedlem
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
            this.lbxMedlemmar = new System.Windows.Forms.ListBox();
            this.lbxGruppmedlemmar = new System.Windows.Forms.ListBox();
            this.lbxTraningsgrupper = new System.Windows.Forms.ListBox();
            this.btnTill = new System.Windows.Forms.Button();
            this.btnFran = new System.Windows.Forms.Button();
            this.gbMedlemmar = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSvar = new System.Windows.Forms.TextBox();
            this.btnKlar = new System.Windows.Forms.Button();
            this.gbMedlemmar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxMedlemmar
            // 
            this.lbxMedlemmar.FormattingEnabled = true;
            this.lbxMedlemmar.Location = new System.Drawing.Point(22, 54);
            this.lbxMedlemmar.Name = "lbxMedlemmar";
            this.lbxMedlemmar.Size = new System.Drawing.Size(223, 134);
            this.lbxMedlemmar.TabIndex = 0;
            // 
            // lbxGruppmedlemmar
            // 
            this.lbxGruppmedlemmar.FormattingEnabled = true;
            this.lbxGruppmedlemmar.Location = new System.Drawing.Point(371, 54);
            this.lbxGruppmedlemmar.Name = "lbxGruppmedlemmar";
            this.lbxGruppmedlemmar.Size = new System.Drawing.Size(223, 134);
            this.lbxGruppmedlemmar.TabIndex = 1;
            // 
            // lbxTraningsgrupper
            // 
            this.lbxTraningsgrupper.FormattingEnabled = true;
            this.lbxTraningsgrupper.Location = new System.Drawing.Point(77, 46);
            this.lbxTraningsgrupper.Name = "lbxTraningsgrupper";
            this.lbxTraningsgrupper.Size = new System.Drawing.Size(250, 95);
            this.lbxTraningsgrupper.TabIndex = 2;
            this.lbxTraningsgrupper.Click += new System.EventHandler(this.lbxTraningsgrupper_Click);
            // 
            // btnTill
            // 
            this.btnTill.Location = new System.Drawing.Point(289, 127);
            this.btnTill.Name = "btnTill";
            this.btnTill.Size = new System.Drawing.Size(31, 23);
            this.btnTill.TabIndex = 3;
            this.btnTill.Text = "->";
            this.btnTill.UseVisualStyleBackColor = true;
            this.btnTill.Click += new System.EventHandler(this.btnTill_Click);
            // 
            // btnFran
            // 
            this.btnFran.Enabled = false;
            this.btnFran.Location = new System.Drawing.Point(289, 98);
            this.btnFran.Name = "btnFran";
            this.btnFran.Size = new System.Drawing.Size(31, 23);
            this.btnFran.TabIndex = 4;
            this.btnFran.Text = "<-";
            this.btnFran.UseVisualStyleBackColor = true;
            this.btnFran.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbMedlemmar
            // 
            this.gbMedlemmar.Controls.Add(this.label1);
            this.gbMedlemmar.Controls.Add(this.label2);
            this.gbMedlemmar.Controls.Add(this.lbxMedlemmar);
            this.gbMedlemmar.Controls.Add(this.btnTill);
            this.gbMedlemmar.Controls.Add(this.btnFran);
            this.gbMedlemmar.Controls.Add(this.lbxGruppmedlemmar);
            this.gbMedlemmar.Location = new System.Drawing.Point(77, 178);
            this.gbMedlemmar.Name = "gbMedlemmar";
            this.gbMedlemmar.Size = new System.Drawing.Size(625, 210);
            this.gbMedlemmar.TabIndex = 5;
            this.gbMedlemmar.TabStop = false;
            this.gbMedlemmar.Text = "Medlemmar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Medlemmar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gruppmedlemmar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Träningsgrupper";
            // 
            // tbSvar
            // 
            this.tbSvar.Location = new System.Drawing.Point(77, 394);
            this.tbSvar.Name = "tbSvar";
            this.tbSvar.Size = new System.Drawing.Size(331, 20);
            this.tbSvar.TabIndex = 7;
            // 
            // btnKlar
            // 
            this.btnKlar.Location = new System.Drawing.Point(627, 391);
            this.btnKlar.Name = "btnKlar";
            this.btnKlar.Size = new System.Drawing.Size(75, 23);
            this.btnKlar.TabIndex = 22;
            this.btnKlar.Text = "Klar";
            this.btnKlar.UseVisualStyleBackColor = true;
            this.btnKlar.Click += new System.EventHandler(this.btnKlar_Click);
            // 
            // laggTillMedlem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 431);
            this.Controls.Add(this.btnKlar);
            this.Controls.Add(this.tbSvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbMedlemmar);
            this.Controls.Add(this.lbxTraningsgrupper);
            this.Name = "laggTillMedlem";
            this.Text = "laggTillMedlem";
            this.Load += new System.EventHandler(this.laggTillMedlem_Load);
            this.gbMedlemmar.ResumeLayout(false);
            this.gbMedlemmar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedlemmar;
        private System.Windows.Forms.ListBox lbxGruppmedlemmar;
        private System.Windows.Forms.ListBox lbxTraningsgrupper;
        private System.Windows.Forms.Button btnTill;
        private System.Windows.Forms.Button btnFran;
        private System.Windows.Forms.GroupBox gbMedlemmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSvar;
        private System.Windows.Forms.Button btnKlar;
    }
}