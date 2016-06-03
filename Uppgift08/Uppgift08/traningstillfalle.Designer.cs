namespace Uppgift08
{
    partial class traningstillfalle
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
            this.lbxGruppmedlemmar = new System.Windows.Forms.ListBox();
            this.lbxTraningsgrupper = new System.Windows.Forms.ListBox();
            this.lbxTrantillfalle = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbSvar = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gruppaktiviter = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxGruppmedlemmar
            // 
            this.lbxGruppmedlemmar.FormattingEnabled = true;
            this.lbxGruppmedlemmar.Location = new System.Drawing.Point(724, 98);
            this.lbxGruppmedlemmar.Name = "lbxGruppmedlemmar";
            this.lbxGruppmedlemmar.Size = new System.Drawing.Size(292, 160);
            this.lbxGruppmedlemmar.TabIndex = 0;
            // 
            // lbxTraningsgrupper
            // 
            this.lbxTraningsgrupper.FormattingEnabled = true;
            this.lbxTraningsgrupper.Location = new System.Drawing.Point(578, 98);
            this.lbxTraningsgrupper.Name = "lbxTraningsgrupper";
            this.lbxTraningsgrupper.Size = new System.Drawing.Size(140, 160);
            this.lbxTraningsgrupper.TabIndex = 1;
            this.lbxTraningsgrupper.Click += new System.EventHandler(this.lbxGrupper_Click);
            // 
            // lbxTrantillfalle
            // 
            this.lbxTrantillfalle.FormattingEnabled = true;
            this.lbxTrantillfalle.Location = new System.Drawing.Point(151, 98);
            this.lbxTrantillfalle.Name = "lbxTrantillfalle";
            this.lbxTrantillfalle.Size = new System.Drawing.Size(170, 160);
            this.lbxTrantillfalle.TabIndex = 2;
            this.lbxTrantillfalle.Click += new System.EventHandler(this.lbxTrantillfalle_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(925, 405);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Klar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbSvar
            // 
            this.tbSvar.Location = new System.Drawing.Point(598, 338);
            this.tbSvar.Name = "tbSvar";
            this.tbSvar.Size = new System.Drawing.Size(100, 20);
            this.tbSvar.TabIndex = 5;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(497, 146);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(52, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = ">>";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(497, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(52, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "<<";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // gruppaktiviter
            // 
            this.gruppaktiviter.FormattingEnabled = true;
            this.gruppaktiviter.Location = new System.Drawing.Point(327, 98);
            this.gruppaktiviter.Name = "gruppaktiviter";
            this.gruppaktiviter.Size = new System.Drawing.Size(140, 160);
            this.gruppaktiviter.TabIndex = 8;
            // 
            // traningstillfalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 440);
            this.Controls.Add(this.gruppaktiviter);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbSvar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbxTrantillfalle);
            this.Controls.Add(this.lbxTraningsgrupper);
            this.Controls.Add(this.lbxGruppmedlemmar);
            this.Name = "traningstillfalle";
            this.Text = "traningstillfalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxGruppmedlemmar;
        private System.Windows.Forms.ListBox lbxTraningsgrupper;
        private System.Windows.Forms.ListBox lbxTrantillfalle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbSvar;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox gruppaktiviter;
    }
}