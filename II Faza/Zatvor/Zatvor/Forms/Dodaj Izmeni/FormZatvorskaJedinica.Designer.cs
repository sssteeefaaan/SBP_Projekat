
namespace Zatvor.Forms.Dodavanja
{
    partial class FormZatvorskaJedinica
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
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.buttonZatvori = new System.Windows.Forms.Button();
            this.groupBoxPodaci = new System.Windows.Forms.GroupBox();
            this.numericUpDownKapacitet = new System.Windows.Forms.NumericUpDown();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.textBoxNaziv = new System.Windows.Forms.TextBox();
            this.textBoxSifra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxRezimRada = new System.Windows.Forms.GroupBox();
            this.checkBoxStrogi = new System.Windows.Forms.CheckBox();
            this.checkBoxPoluotvoren = new System.Windows.Forms.CheckBox();
            this.checkBoxOtvoren = new System.Windows.Forms.CheckBox();
            this.groupBoxPodaci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKapacitet)).BeginInit();
            this.groupBoxRezimRada.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.Location = new System.Drawing.Point(203, 309);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(86, 36);
            this.buttonDodaj.TabIndex = 0;
            this.buttonDodaj.Text = "Dodaj";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // buttonZatvori
            // 
            this.buttonZatvori.Location = new System.Drawing.Point(295, 309);
            this.buttonZatvori.Name = "buttonZatvori";
            this.buttonZatvori.Size = new System.Drawing.Size(86, 36);
            this.buttonZatvori.TabIndex = 1;
            this.buttonZatvori.Text = "Otkaži";
            this.buttonZatvori.UseVisualStyleBackColor = true;
            this.buttonZatvori.Click += new System.EventHandler(this.buttonZatvori_Click);
            // 
            // groupBoxPodaci
            // 
            this.groupBoxPodaci.Controls.Add(this.numericUpDownKapacitet);
            this.groupBoxPodaci.Controls.Add(this.textBoxAdresa);
            this.groupBoxPodaci.Controls.Add(this.textBoxNaziv);
            this.groupBoxPodaci.Controls.Add(this.textBoxSifra);
            this.groupBoxPodaci.Controls.Add(this.label4);
            this.groupBoxPodaci.Controls.Add(this.label3);
            this.groupBoxPodaci.Controls.Add(this.label2);
            this.groupBoxPodaci.Controls.Add(this.label1);
            this.groupBoxPodaci.Location = new System.Drawing.Point(13, 13);
            this.groupBoxPodaci.Name = "groupBoxPodaci";
            this.groupBoxPodaci.Size = new System.Drawing.Size(368, 176);
            this.groupBoxPodaci.TabIndex = 2;
            this.groupBoxPodaci.TabStop = false;
            this.groupBoxPodaci.Text = "Podaci";
            // 
            // numericUpDownKapacitet
            // 
            this.numericUpDownKapacitet.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownKapacitet.Location = new System.Drawing.Point(83, 128);
            this.numericUpDownKapacitet.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownKapacitet.Name = "numericUpDownKapacitet";
            this.numericUpDownKapacitet.Size = new System.Drawing.Size(257, 26);
            this.numericUpDownKapacitet.TabIndex = 7;
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.Location = new System.Drawing.Point(83, 96);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(257, 26);
            this.textBoxAdresa.TabIndex = 6;
            // 
            // textBoxNaziv
            // 
            this.textBoxNaziv.Location = new System.Drawing.Point(83, 64);
            this.textBoxNaziv.Name = "textBoxNaziv";
            this.textBoxNaziv.Size = new System.Drawing.Size(257, 26);
            this.textBoxNaziv.TabIndex = 5;
            // 
            // textBoxSifra
            // 
            this.textBoxSifra.Location = new System.Drawing.Point(83, 32);
            this.textBoxSifra.MaxLength = 5;
            this.textBoxSifra.Name = "textBoxSifra";
            this.textBoxSifra.Size = new System.Drawing.Size(257, 26);
            this.textBoxSifra.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kapacitet:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adresa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Naziv:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Šifra:";
            // 
            // groupBoxRezimRada
            // 
            this.groupBoxRezimRada.Controls.Add(this.checkBoxStrogi);
            this.groupBoxRezimRada.Controls.Add(this.checkBoxPoluotvoren);
            this.groupBoxRezimRada.Controls.Add(this.checkBoxOtvoren);
            this.groupBoxRezimRada.Location = new System.Drawing.Point(13, 195);
            this.groupBoxRezimRada.Name = "groupBoxRezimRada";
            this.groupBoxRezimRada.Size = new System.Drawing.Size(368, 108);
            this.groupBoxRezimRada.TabIndex = 3;
            this.groupBoxRezimRada.TabStop = false;
            this.groupBoxRezimRada.Text = "Režim rada";
            // 
            // checkBoxStrogi
            // 
            this.checkBoxStrogi.AutoSize = true;
            this.checkBoxStrogi.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxStrogi.Location = new System.Drawing.Point(264, 36);
            this.checkBoxStrogi.Name = "checkBoxStrogi";
            this.checkBoxStrogi.Size = new System.Drawing.Size(76, 56);
            this.checkBoxStrogi.TabIndex = 2;
            this.checkBoxStrogi.Text = "Strogi\r\nrežim rada";
            this.checkBoxStrogi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxStrogi.UseVisualStyleBackColor = true;
            // 
            // checkBoxPoluotvoren
            // 
            this.checkBoxPoluotvoren.AutoSize = true;
            this.checkBoxPoluotvoren.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxPoluotvoren.Location = new System.Drawing.Point(144, 36);
            this.checkBoxPoluotvoren.Name = "checkBoxPoluotvoren";
            this.checkBoxPoluotvoren.Size = new System.Drawing.Size(86, 56);
            this.checkBoxPoluotvoren.TabIndex = 1;
            this.checkBoxPoluotvoren.Text = "Poluotvoren\r\nrežim rada";
            this.checkBoxPoluotvoren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPoluotvoren.UseVisualStyleBackColor = true;
            // 
            // checkBoxOtvoren
            // 
            this.checkBoxOtvoren.AutoSize = true;
            this.checkBoxOtvoren.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxOtvoren.Location = new System.Drawing.Point(31, 36);
            this.checkBoxOtvoren.Name = "checkBoxOtvoren";
            this.checkBoxOtvoren.Size = new System.Drawing.Size(76, 56);
            this.checkBoxOtvoren.TabIndex = 0;
            this.checkBoxOtvoren.Text = "Otvoren\r\nrežim rada";
            this.checkBoxOtvoren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxOtvoren.UseVisualStyleBackColor = true;
            // 
            // FormZatvorskaJedinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 357);
            this.Controls.Add(this.groupBoxRezimRada);
            this.Controls.Add(this.groupBoxPodaci);
            this.Controls.Add(this.buttonZatvori);
            this.Controls.Add(this.buttonDodaj);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(415, 396);
            this.MinimumSize = new System.Drawing.Size(415, 396);
            this.Name = "FormZatvorskaJedinica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zatvorska jedinica";
            this.Load += new System.EventHandler(this.FormZatvorskaJedinica_Load);
            this.groupBoxPodaci.ResumeLayout(false);
            this.groupBoxPodaci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKapacitet)).EndInit();
            this.groupBoxRezimRada.ResumeLayout(false);
            this.groupBoxRezimRada.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Button buttonZatvori;
        private System.Windows.Forms.GroupBox groupBoxPodaci;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxRezimRada;
        private System.Windows.Forms.CheckBox checkBoxStrogi;
        private System.Windows.Forms.CheckBox checkBoxPoluotvoren;
        private System.Windows.Forms.CheckBox checkBoxOtvoren;
        private System.Windows.Forms.NumericUpDown numericUpDownKapacitet;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.TextBox textBoxNaziv;
        private System.Windows.Forms.TextBox textBoxSifra;
    }
}