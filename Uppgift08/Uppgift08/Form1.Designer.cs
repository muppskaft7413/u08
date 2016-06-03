namespace Uppgift08
{
    partial class Form1
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
            this.btn_rapport = new System.Windows.Forms.Button();
            this.btn_narvaro = new System.Windows.Forms.Button();
            this.btnLaggTillmdlm = new System.Windows.Forms.Button();
            this.btnHantGrp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_rapport
            // 
            this.btn_rapport.Location = new System.Drawing.Point(94, 66);
            this.btn_rapport.Name = "btn_rapport";
            this.btn_rapport.Size = new System.Drawing.Size(75, 34);
            this.btn_rapport.TabIndex = 0;
            this.btn_rapport.Text = "Hämta rapport";
            this.btn_rapport.UseVisualStyleBackColor = true;
            this.btn_rapport.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_narvaro
            // 
            this.btn_narvaro.Location = new System.Drawing.Point(94, 120);
            this.btn_narvaro.Name = "btn_narvaro";
            this.btn_narvaro.Size = new System.Drawing.Size(75, 34);
            this.btn_narvaro.TabIndex = 1;
            this.btn_narvaro.Text = "Registrera närvaro";
            this.btn_narvaro.UseVisualStyleBackColor = true;
            this.btn_narvaro.Click += new System.EventHandler(this.btn_narvaro_Click);
            // 
            // btnLaggTillmdlm
            // 
            this.btnLaggTillmdlm.Location = new System.Drawing.Point(94, 177);
            this.btnLaggTillmdlm.Name = "btnLaggTillmdlm";
            this.btnLaggTillmdlm.Size = new System.Drawing.Size(75, 34);
            this.btnLaggTillmdlm.TabIndex = 2;
            this.btnLaggTillmdlm.Text = "Lägg till medlem";
            this.btnLaggTillmdlm.UseVisualStyleBackColor = true;
            this.btnLaggTillmdlm.Click += new System.EventHandler(this.btnLaggTillmdlm_Click);
            // 
            // btnHantGrp
            // 
            this.btnHantGrp.Location = new System.Drawing.Point(94, 235);
            this.btnHantGrp.Name = "btnHantGrp";
            this.btnHantGrp.Size = new System.Drawing.Size(75, 34);
            this.btnHantGrp.TabIndex = 3;
            this.btnHantGrp.Text = "Hantera grupp";
            this.btnHantGrp.UseVisualStyleBackColor = true;
            this.btnHantGrp.Click += new System.EventHandler(this.btnHantGrp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Cirkus Kul och Bus";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnHantGrp);
            this.Controls.Add(this.btnLaggTillmdlm);
            this.Controls.Add(this.btn_narvaro);
            this.Controls.Add(this.btn_rapport);
            this.Name = "Form1";
            this.Text = "Uppgift08";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_rapport;
        private System.Windows.Forms.Button btn_narvaro;
        private System.Windows.Forms.Button btnLaggTillmdlm;
        private System.Windows.Forms.Button btnHantGrp;
        private System.Windows.Forms.Label label2;
    }
}

