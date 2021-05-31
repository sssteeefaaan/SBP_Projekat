
namespace Zatvor.Forms
{
    partial class FormDodajAdvokata
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
            this.buttonEvidentiraj = new System.Windows.Forms.Button();
            this.textBoxJMBG = new System.Windows.Forms.TextBox();
            this.textBoxPrezime = new System.Windows.Forms.TextBox();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPol = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewAdvokati = new System.Windows.Forms.ListView();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.buttonIzmeni = new System.Windows.Forms.Button();
            this.buttonSacuvaj = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEvidentiraj
            // 
            this.buttonEvidentiraj.Location = new System.Drawing.Point(426, 112);
            this.buttonEvidentiraj.Name = "buttonEvidentiraj";
            this.buttonEvidentiraj.Size = new System.Drawing.Size(96, 34);
            this.buttonEvidentiraj.TabIndex = 0;
            this.buttonEvidentiraj.Text = "Evidentiraj";
            this.buttonEvidentiraj.UseVisualStyleBackColor = true;
            this.buttonEvidentiraj.Click += new System.EventHandler(this.buttonEvidentiraj_Click);
            // 
            // textBoxJMBG
            // 
            this.textBoxJMBG.Location = new System.Drawing.Point(336, 33);
            this.textBoxJMBG.Name = "textBoxJMBG";
            this.textBoxJMBG.Size = new System.Drawing.Size(186, 26);
            this.textBoxJMBG.TabIndex = 1;
            // 
            // textBoxPrezime
            // 
            this.textBoxPrezime.Location = new System.Drawing.Point(72, 65);
            this.textBoxPrezime.Name = "textBoxPrezime";
            this.textBoxPrezime.Size = new System.Drawing.Size(186, 26);
            this.textBoxPrezime.TabIndex = 2;
            // 
            // textBoxIme
            // 
            this.textBoxIme.Location = new System.Drawing.Point(72, 33);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(186, 26);
            this.textBoxIme.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "JMBG:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ime:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Prezime:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pol:";
            // 
            // comboBoxPol
            // 
            this.comboBoxPol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPol.FormattingEnabled = true;
            this.comboBoxPol.Location = new System.Drawing.Point(336, 69);
            this.comboBoxPol.Name = "comboBoxPol";
            this.comboBoxPol.Size = new System.Drawing.Size(186, 27);
            this.comboBoxPol.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSacuvaj);
            this.groupBox1.Controls.Add(this.comboBoxPol);
            this.groupBox1.Controls.Add(this.buttonEvidentiraj);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxIme);
            this.groupBox1.Controls.Add(this.textBoxPrezime);
            this.groupBox1.Controls.Add(this.textBoxJMBG);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 157);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o advokatu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonIzmeni);
            this.groupBox2.Controls.Add(this.buttonObrisi);
            this.groupBox2.Controls.Add(this.listViewAdvokati);
            this.groupBox2.Location = new System.Drawing.Point(12, 175);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 242);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evidentirani advokati";
            // 
            // listViewAdvokati
            // 
            this.listViewAdvokati.HideSelection = false;
            this.listViewAdvokati.Location = new System.Drawing.Point(6, 65);
            this.listViewAdvokati.Name = "listViewAdvokati";
            this.listViewAdvokati.Size = new System.Drawing.Size(522, 171);
            this.listViewAdvokati.TabIndex = 0;
            this.listViewAdvokati.UseCompatibleStateImageBehavior = false;
            this.listViewAdvokati.SelectedIndexChanged += new System.EventHandler(this.listViewAdvokati_SelectedIndexChanged);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.Location = new System.Drawing.Point(432, 25);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(96, 34);
            this.buttonObrisi.TabIndex = 10;
            this.buttonObrisi.Text = "Obriši";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // buttonIzmeni
            // 
            this.buttonIzmeni.Location = new System.Drawing.Point(330, 25);
            this.buttonIzmeni.Name = "buttonIzmeni";
            this.buttonIzmeni.Size = new System.Drawing.Size(96, 34);
            this.buttonIzmeni.TabIndex = 11;
            this.buttonIzmeni.Text = "Izmeni";
            this.buttonIzmeni.UseVisualStyleBackColor = true;
            this.buttonIzmeni.Click += new System.EventHandler(this.buttonIzmeni_Click);
            // 
            // buttonSacuvaj
            // 
            this.buttonSacuvaj.Location = new System.Drawing.Point(426, 112);
            this.buttonSacuvaj.Name = "buttonSacuvaj";
            this.buttonSacuvaj.Size = new System.Drawing.Size(96, 34);
            this.buttonSacuvaj.TabIndex = 12;
            this.buttonSacuvaj.Text = "Sačuvaj";
            this.buttonSacuvaj.UseVisualStyleBackColor = true;
            this.buttonSacuvaj.Click += new System.EventHandler(this.buttonSacuvaj_Click);
            // 
            // FormDodajAdvokata
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 422);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormDodajAdvokata";
            this.Text = "Evidentiraj advokata";
            this.Load += new System.EventHandler(this.FormDodajAdvokata_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEvidentiraj;
        private System.Windows.Forms.TextBox textBoxJMBG;
        private System.Windows.Forms.TextBox textBoxPrezime;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPol;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonIzmeni;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.ListView listViewAdvokati;
        private System.Windows.Forms.Button buttonSacuvaj;
    }
}