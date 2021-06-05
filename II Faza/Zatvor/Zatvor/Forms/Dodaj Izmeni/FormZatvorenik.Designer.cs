
namespace Zatvor.Forms
{
    partial class FormZatvorenik
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxPol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.textBoxPrezime = new System.Windows.Forms.TextBox();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.textBoxJMBG = new System.Windows.Forms.TextBox();
            this.textBoxBroj = new System.Windows.Forms.TextBox();
            this.dateTimePickerInkarceracija = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerSledeceSaslusanje = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxStatusUslovnogOtpusta = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonOdustani = new System.Windows.Forms.Button();
            this.comboBoxZatvorskaJedinica = new System.Windows.Forms.ComboBox();
            this.buttonDodajZatvorenika = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxPol);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxIme);
            this.groupBox1.Controls.Add(this.textBoxPrezime);
            this.groupBox1.Controls.Add(this.textBoxAdresa);
            this.groupBox1.Controls.Add(this.textBoxJMBG);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(465, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Osnovni podaci o zatvoreniku";
            // 
            // comboBoxPol
            // 
            this.comboBoxPol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPol.FormattingEnabled = true;
            this.comboBoxPol.Location = new System.Drawing.Point(135, 166);
            this.comboBoxPol.Name = "comboBoxPol";
            this.comboBoxPol.Size = new System.Drawing.Size(257, 27);
            this.comboBoxPol.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Adresa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 169);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pol:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "Prezime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 72);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ime:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "JMBG:";
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(135, 65);
            this.textBoxIme.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(257, 26);
            this.textBoxIme.TabIndex = 2;
            // 
            // textBoxPrezime
            // 
            this.textBoxPrezime.Location = new System.Drawing.Point(135, 99);
            this.textBoxPrezime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPrezime.Name = "textBoxPrezime";
            this.textBoxPrezime.Size = new System.Drawing.Size(257, 26);
            this.textBoxPrezime.TabIndex = 1;
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(135, 130);
            this.textBoxAdresa.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(257, 26);
            this.textBoxAdresa.TabIndex = 4;
            // 
            // textBoxJMBG
            // 
            this.textBoxJMBG.Location = new System.Drawing.Point(135, 31);
            this.textBoxJMBG.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxJMBG.MaxLength = 13;
            this.textBoxJMBG.Name = "textBoxJMBG";
            this.textBoxJMBG.Size = new System.Drawing.Size(257, 26);
            this.textBoxJMBG.TabIndex = 0;
            // 
            // textBoxBroj
            // 
            this.textBoxBroj.Location = new System.Drawing.Point(187, 38);
            this.textBoxBroj.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxBroj.MaxLength = 5;
            this.textBoxBroj.Name = "textBoxBroj";
            this.textBoxBroj.Size = new System.Drawing.Size(256, 26);
            this.textBoxBroj.TabIndex = 5;
            // 
            // dateTimePickerInkarceracija
            // 
            this.dateTimePickerInkarceracija.Location = new System.Drawing.Point(187, 72);
            this.dateTimePickerInkarceracija.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerInkarceracija.Name = "dateTimePickerInkarceracija";
            this.dateTimePickerInkarceracija.Size = new System.Drawing.Size(256, 26);
            this.dateTimePickerInkarceracija.TabIndex = 6;
            // 
            // dateTimePickerSledeceSaslusanje
            // 
            this.dateTimePickerSledeceSaslusanje.Location = new System.Drawing.Point(187, 106);
            this.dateTimePickerSledeceSaslusanje.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerSledeceSaslusanje.Name = "dateTimePickerSledeceSaslusanje";
            this.dateTimePickerSledeceSaslusanje.Size = new System.Drawing.Size(256, 26);
            this.dateTimePickerSledeceSaslusanje.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxStatusUslovnogOtpusta);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxBroj);
            this.groupBox2.Controls.Add(this.dateTimePickerSledeceSaslusanje);
            this.groupBox2.Controls.Add(this.dateTimePickerInkarceracija);
            this.groupBox2.Location = new System.Drawing.Point(13, 245);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(465, 191);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o privođenju";
            // 
            // comboBoxStatusUslovnogOtpusta
            // 
            this.comboBoxStatusUslovnogOtpusta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusUslovnogOtpusta.FormattingEnabled = true;
            this.comboBoxStatusUslovnogOtpusta.Location = new System.Drawing.Point(186, 139);
            this.comboBoxStatusUslovnogOtpusta.Name = "comboBoxStatusUslovnogOtpusta";
            this.comboBoxStatusUslovnogOtpusta.Size = new System.Drawing.Size(257, 27);
            this.comboBoxStatusUslovnogOtpusta.TabIndex = 34;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 147);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 19);
            this.label9.TabIndex = 17;
            this.label9.Text = "Status uslovnog otpusta:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 112);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "Datum sledećeg saslušanja:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 78);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Datum inkarceracije:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "Broj zatvorenika:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 461);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 19);
            this.label10.TabIndex = 12;
            this.label10.Text = "Zatvorska jedinica:";
            // 
            // buttonOdustani
            // 
            this.buttonOdustani.Location = new System.Drawing.Point(382, 503);
            this.buttonOdustani.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOdustani.Name = "buttonOdustani";
            this.buttonOdustani.Size = new System.Drawing.Size(96, 33);
            this.buttonOdustani.TabIndex = 16;
            this.buttonOdustani.Text = "Odustani";
            this.buttonOdustani.UseVisualStyleBackColor = true;
            this.buttonOdustani.Click += new System.EventHandler(this.buttonOdustani_Click);
            // 
            // comboBoxZatvorskaJedinica
            // 
            this.comboBoxZatvorskaJedinica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxZatvorskaJedinica.FormattingEnabled = true;
            this.comboBoxZatvorskaJedinica.Location = new System.Drawing.Point(161, 458);
            this.comboBoxZatvorskaJedinica.Name = "comboBoxZatvorskaJedinica";
            this.comboBoxZatvorskaJedinica.Size = new System.Drawing.Size(295, 27);
            this.comboBoxZatvorskaJedinica.TabIndex = 33;
            // 
            // buttonDodajZatvorenika
            // 
            this.buttonDodajZatvorenika.Location = new System.Drawing.Point(238, 503);
            this.buttonDodajZatvorenika.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDodajZatvorenika.Name = "buttonDodajZatvorenika";
            this.buttonDodajZatvorenika.Size = new System.Drawing.Size(136, 33);
            this.buttonDodajZatvorenika.TabIndex = 15;
            this.buttonDodajZatvorenika.Text = "Dodaj zatvorenika";
            this.buttonDodajZatvorenika.UseVisualStyleBackColor = true;
            this.buttonDodajZatvorenika.Click += new System.EventHandler(this.buttonDodajZatvorenika_Click);
            // 
            // FormZatvorenik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(499, 550);
            this.Controls.Add(this.comboBoxZatvorskaJedinica);
            this.Controls.Add(this.buttonOdustani);
            this.Controls.Add(this.buttonDodajZatvorenika);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(515, 589);
            this.MinimumSize = new System.Drawing.Size(515, 589);
            this.Name = "FormZatvorenik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zatvorenik";
            this.Load += new System.EventHandler(this.FormDodajZatvorenika_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBroj;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.TextBox textBoxPrezime;
        private System.Windows.Forms.TextBox textBoxJMBG;
        private System.Windows.Forms.DateTimePicker dateTimePickerSledeceSaslusanje;
        private System.Windows.Forms.DateTimePicker dateTimePickerInkarceracija;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonOdustani;
        private System.Windows.Forms.ComboBox comboBoxPol;
        private System.Windows.Forms.ComboBox comboBoxStatusUslovnogOtpusta;
        private System.Windows.Forms.ComboBox comboBoxZatvorskaJedinica;
        private System.Windows.Forms.Button buttonDodajZatvorenika;
    }
}