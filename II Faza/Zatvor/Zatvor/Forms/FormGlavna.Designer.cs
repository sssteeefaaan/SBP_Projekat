
namespace Zatvor
{
    partial class FormGlavna
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
            this.buttonZatvorskeJedinice = new System.Windows.Forms.Button();
            this.buttonZaposleni = new System.Windows.Forms.Button();
            this.buttonZatvorenici = new System.Windows.Forms.Button();
            this.labelMain = new System.Windows.Forms.Label();
            this.buttonAdvokati = new System.Windows.Forms.Button();
            this.buttonFirme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonZatvorskeJedinice
            // 
            this.buttonZatvorskeJedinice.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZatvorskeJedinice.Location = new System.Drawing.Point(30, 171);
            this.buttonZatvorskeJedinice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonZatvorskeJedinice.Name = "buttonZatvorskeJedinice";
            this.buttonZatvorskeJedinice.Size = new System.Drawing.Size(450, 50);
            this.buttonZatvorskeJedinice.TabIndex = 0;
            this.buttonZatvorskeJedinice.Text = "Zatvorske jedinice";
            this.buttonZatvorskeJedinice.UseVisualStyleBackColor = true;
            this.buttonZatvorskeJedinice.Click += new System.EventHandler(this.buttonZatvorskeJedinice_Click);
            // 
            // buttonZaposleni
            // 
            this.buttonZaposleni.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZaposleni.Location = new System.Drawing.Point(30, 231);
            this.buttonZaposleni.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonZaposleni.Name = "buttonZaposleni";
            this.buttonZaposleni.Size = new System.Drawing.Size(220, 50);
            this.buttonZaposleni.TabIndex = 1;
            this.buttonZaposleni.Text = "Zaposleni";
            this.buttonZaposleni.UseVisualStyleBackColor = true;
            this.buttonZaposleni.Click += new System.EventHandler(this.buttonZaposleni_Click);
            // 
            // buttonZatvorenici
            // 
            this.buttonZatvorenici.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZatvorenici.Location = new System.Drawing.Point(260, 231);
            this.buttonZatvorenici.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonZatvorenici.Name = "buttonZatvorenici";
            this.buttonZatvorenici.Size = new System.Drawing.Size(220, 50);
            this.buttonZatvorenici.TabIndex = 2;
            this.buttonZatvorenici.Text = "Zatvorenici";
            this.buttonZatvorenici.UseVisualStyleBackColor = true;
            this.buttonZatvorenici.Click += new System.EventHandler(this.buttonZatvorenici_Click);
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.Location = new System.Drawing.Point(83, 37);
            this.labelMain.Name = "labelMain";
            this.labelMain.Padding = new System.Windows.Forms.Padding(2);
            this.labelMain.Size = new System.Drawing.Size(352, 68);
            this.labelMain.TabIndex = 3;
            this.labelMain.Text = "LANAC SISTEMA\r\nZATVORSKIH JEDINICA";
            this.labelMain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAdvokati
            // 
            this.buttonAdvokati.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdvokati.Location = new System.Drawing.Point(30, 291);
            this.buttonAdvokati.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdvokati.Name = "buttonAdvokati";
            this.buttonAdvokati.Size = new System.Drawing.Size(450, 50);
            this.buttonAdvokati.TabIndex = 4;
            this.buttonAdvokati.Text = "Advokati";
            this.buttonAdvokati.UseVisualStyleBackColor = true;
            this.buttonAdvokati.Click += new System.EventHandler(this.buttonAdvokati_Click);
            // 
            // buttonFirme
            // 
            this.buttonFirme.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFirme.Location = new System.Drawing.Point(30, 351);
            this.buttonFirme.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonFirme.Name = "buttonFirme";
            this.buttonFirme.Size = new System.Drawing.Size(450, 50);
            this.buttonFirme.TabIndex = 5;
            this.buttonFirme.Text = "Firme";
            this.buttonFirme.UseVisualStyleBackColor = true;
            this.buttonFirme.Click += new System.EventHandler(this.buttonFirme_Click);
            // 
            // FormGlavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 415);
            this.Controls.Add(this.buttonFirme);
            this.Controls.Add(this.buttonAdvokati);
            this.Controls.Add(this.labelMain);
            this.Controls.Add(this.buttonZatvorenici);
            this.Controls.Add(this.buttonZaposleni);
            this.Controls.Add(this.buttonZatvorskeJedinice);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormGlavna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Baza Podataka \'Zatvor\'";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonZatvorskeJedinice;
        private System.Windows.Forms.Button buttonZaposleni;
        private System.Windows.Forms.Button buttonZatvorenici;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Button buttonAdvokati;
        private System.Windows.Forms.Button buttonFirme;
    }
}

