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
            this.g = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.g.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxMedlemmar
            // 
            this.lbxMedlemmar.FormattingEnabled = true;
            this.lbxMedlemmar.Location = new System.Drawing.Point(22, 54);
            this.lbxMedlemmar.Name = "lbxMedlemmar";
            this.lbxMedlemmar.Size = new System.Drawing.Size(199, 134);
            this.lbxMedlemmar.TabIndex = 0;
            // 
            // lbxGruppmedlemmar
            // 
            this.lbxGruppmedlemmar.FormattingEnabled = true;
            this.lbxGruppmedlemmar.Location = new System.Drawing.Point(335, 54);
            this.lbxGruppmedlemmar.Name = "lbxGruppmedlemmar";
            this.lbxGruppmedlemmar.Size = new System.Drawing.Size(199, 134);
            this.lbxGruppmedlemmar.TabIndex = 1;
            // 
            // lbxTraningsgrupper
            // 
            this.lbxTraningsgrupper.FormattingEnabled = true;
            this.lbxTraningsgrupper.Location = new System.Drawing.Point(77, 46);
            this.lbxTraningsgrupper.Name = "lbxTraningsgrupper";
            this.lbxTraningsgrupper.Size = new System.Drawing.Size(250, 95);
            this.lbxTraningsgrupper.TabIndex = 2;
            // 
            // btnTill
            // 
            this.btnTill.Location = new System.Drawing.Point(265, 123);
            this.btnTill.Name = "btnTill";
            this.btnTill.Size = new System.Drawing.Size(31, 23);
            this.btnTill.TabIndex = 3;
            this.btnTill.Text = "->";
            this.btnTill.UseVisualStyleBackColor = true;
            // 
            // btnFran
            // 
            this.btnFran.Location = new System.Drawing.Point(265, 94);
            this.btnFran.Name = "btnFran";
            this.btnFran.Size = new System.Drawing.Size(31, 23);
            this.btnFran.TabIndex = 4;
            this.btnFran.Text = "<-";
            this.btnFran.UseVisualStyleBackColor = true;
            this.btnFran.Click += new System.EventHandler(this.button2_Click);
            // 
            // g
            // 
            this.g.Controls.Add(this.label1);
            this.g.Controls.Add(this.label2);
            this.g.Controls.Add(this.lbxMedlemmar);
            this.g.Controls.Add(this.btnTill);
            this.g.Controls.Add(this.btnFran);
            this.g.Controls.Add(this.lbxGruppmedlemmar);
            this.g.Location = new System.Drawing.Point(77, 178);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(552, 210);
            this.g.TabIndex = 5;
            this.g.TabStop = false;
            this.g.Text = "Medlemmar";
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
            this.label2.Location = new System.Drawing.Point(332, 38);
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
            // laggTillMedlem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 416);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.g);
            this.Controls.Add(this.lbxTraningsgrupper);
            this.Name = "laggTillMedlem";
            this.Text = "laggTillMedlem";
            this.g.ResumeLayout(false);
            this.g.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedlemmar;
        private System.Windows.Forms.ListBox lbxGruppmedlemmar;
        private System.Windows.Forms.ListBox lbxTraningsgrupper;
        private System.Windows.Forms.Button btnTill;
        private System.Windows.Forms.Button btnFran;
        private System.Windows.Forms.GroupBox g;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}