
namespace Zatvor.Forms.Dodavanja
{
    partial class FormCelijskiPeriod
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
            this.buttonZatvori = new System.Windows.Forms.Button();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxDoMinuti = new System.Windows.Forms.ComboBox();
            this.comboBoxDoSati = new System.Windows.Forms.ComboBox();
            this.comboBoxOdMinuti = new System.Windows.Forms.ComboBox();
            this.comboBoxOdSati = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonZatvori
            // 
            this.buttonZatvori.Location = new System.Drawing.Point(342, 156);
            this.buttonZatvori.Name = "buttonZatvori";
            this.buttonZatvori.Size = new System.Drawing.Size(96, 29);
            this.buttonZatvori.TabIndex = 6;
            this.buttonZatvori.Text = "Otkaži";
            this.buttonZatvori.UseVisualStyleBackColor = true;
            this.buttonZatvori.Click += new System.EventHandler(this.buttonZatvori_Click);
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Location = new System.Drawing.Point(76, 156);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(96, 29);
            this.buttonDodaj.TabIndex = 5;
            this.buttonDodaj.Text = "Dodaj termin";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(62, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "od";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = ":";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "do";
            // 
            // comboBoxDoMinuti
            // 
            this.comboBoxDoMinuti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoMinuti.FormattingEnabled = true;
            this.comboBoxDoMinuti.Location = new System.Drawing.Point(277, 88);
            this.comboBoxDoMinuti.MaxDropDownItems = 12;
            this.comboBoxDoMinuti.Name = "comboBoxDoMinuti";
            this.comboBoxDoMinuti.Size = new System.Drawing.Size(127, 27);
            this.comboBoxDoMinuti.TabIndex = 17;
            // 
            // comboBoxDoSati
            // 
            this.comboBoxDoSati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoSati.FormattingEnabled = true;
            this.comboBoxDoSati.Location = new System.Drawing.Point(126, 88);
            this.comboBoxDoSati.MaxDropDownItems = 24;
            this.comboBoxDoSati.Name = "comboBoxDoSati";
            this.comboBoxDoSati.Size = new System.Drawing.Size(127, 27);
            this.comboBoxDoSati.TabIndex = 16;
            // 
            // comboBoxOdMinuti
            // 
            this.comboBoxOdMinuti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOdMinuti.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxOdMinuti.FormattingEnabled = true;
            this.comboBoxOdMinuti.Location = new System.Drawing.Point(277, 55);
            this.comboBoxOdMinuti.MaxDropDownItems = 12;
            this.comboBoxOdMinuti.Name = "comboBoxOdMinuti";
            this.comboBoxOdMinuti.Size = new System.Drawing.Size(127, 27);
            this.comboBoxOdMinuti.TabIndex = 15;
            // 
            // comboBoxOdSati
            // 
            this.comboBoxOdSati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOdSati.FormattingEnabled = true;
            this.comboBoxOdSati.Location = new System.Drawing.Point(126, 55);
            this.comboBoxOdSati.MaxDropDownItems = 24;
            this.comboBoxOdSati.Name = "comboBoxOdSati";
            this.comboBoxOdSati.Size = new System.Drawing.Size(127, 27);
            this.comboBoxOdSati.TabIndex = 14;
            // 
            // FormCelijskiPeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 210);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxDoMinuti);
            this.Controls.Add(this.comboBoxDoSati);
            this.Controls.Add(this.comboBoxOdMinuti);
            this.Controls.Add(this.comboBoxOdSati);
            this.Controls.Add(this.buttonZatvori);
            this.Controls.Add(this.buttonDodaj);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(518, 249);
            this.MinimumSize = new System.Drawing.Size(518, 249);
            this.Name = "FormCelijskiPeriod";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ćelijski period";
            this.Load += new System.EventHandler(this.FormDodajCelijskiPeriod_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonZatvori;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxDoMinuti;
        private System.Windows.Forms.ComboBox comboBoxDoSati;
        private System.Windows.Forms.ComboBox comboBoxOdMinuti;
        private System.Windows.Forms.ComboBox comboBoxOdSati;
    }
}