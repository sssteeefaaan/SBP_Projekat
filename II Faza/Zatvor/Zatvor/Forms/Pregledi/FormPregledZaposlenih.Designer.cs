
namespace Zatvor.Forms
{
    partial class FormPregledZaposlenih
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
            this.components = new System.ComponentModel.Container();
            this.groupBoxZaposleni = new System.Windows.Forms.GroupBox();
            this.listViewZaposleni = new System.Windows.Forms.ListView();
            this.buttonDodajZaposlenog = new System.Windows.Forms.Button();
            this.buttonIzmeniZaposlenog = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.zatvorenikViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrikaziObezbedjenje = new System.Windows.Forms.Button();
            this.buttonPrikaziPsihologe = new System.Windows.Forms.Button();
            this.buttonPrikaziAdministraciju = new System.Windows.Forms.Button();
            this.buttonPrikaziSve = new System.Windows.Forms.Button();
            this.groupBoxZaposleni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxZaposleni
            // 
            this.groupBoxZaposleni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZaposleni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxZaposleni.Controls.Add(this.listViewZaposleni);
            this.groupBoxZaposleni.Location = new System.Drawing.Point(13, 76);
            this.groupBoxZaposleni.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxZaposleni.Name = "groupBoxZaposleni";
            this.groupBoxZaposleni.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxZaposleni.Size = new System.Drawing.Size(1174, 400);
            this.groupBoxZaposleni.TabIndex = 4;
            this.groupBoxZaposleni.TabStop = false;
            this.groupBoxZaposleni.Text = "Zaposleni";
            // 
            // listViewZaposleni
            // 
            this.listViewZaposleni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewZaposleni.HideSelection = false;
            this.listViewZaposleni.Location = new System.Drawing.Point(4, 23);
            this.listViewZaposleni.Name = "listViewZaposleni";
            this.listViewZaposleni.Size = new System.Drawing.Size(1166, 373);
            this.listViewZaposleni.TabIndex = 0;
            this.listViewZaposleni.UseCompatibleStateImageBehavior = false;
            this.listViewZaposleni.SelectedIndexChanged += new System.EventHandler(this.listViewZaposleni_SelectedIndexChanged);
            // 
            // buttonDodajZaposlenog
            // 
            this.buttonDodajZaposlenog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDodajZaposlenog.Location = new System.Drawing.Point(13, 12);
            this.buttonDodajZaposlenog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDodajZaposlenog.Name = "buttonDodajZaposlenog";
            this.buttonDodajZaposlenog.Size = new System.Drawing.Size(114, 52);
            this.buttonDodajZaposlenog.TabIndex = 5;
            this.buttonDodajZaposlenog.Text = "Dodaj zaposlenog";
            this.buttonDodajZaposlenog.UseVisualStyleBackColor = true;
            this.buttonDodajZaposlenog.Click += new System.EventHandler(this.buttonDodajZaposlenog_Click);
            // 
            // buttonIzmeniZaposlenog
            // 
            this.buttonIzmeniZaposlenog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonIzmeniZaposlenog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeniZaposlenog.Location = new System.Drawing.Point(4, 4);
            this.buttonIzmeniZaposlenog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIzmeniZaposlenog.Name = "buttonIzmeniZaposlenog";
            this.buttonIzmeniZaposlenog.Size = new System.Drawing.Size(121, 53);
            this.buttonIzmeniZaposlenog.TabIndex = 1;
            this.buttonIzmeniZaposlenog.Text = "Izmeni zaposlenog";
            this.buttonIzmeniZaposlenog.UseVisualStyleBackColor = true;
            this.buttonIzmeniZaposlenog.Click += new System.EventHandler(this.buttonIzmeniZaposlenog_Click);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonObrisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonObrisi.Location = new System.Drawing.Point(133, 4);
            this.buttonObrisi.Margin = new System.Windows.Forms.Padding(4);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(122, 53);
            this.buttonObrisi.TabIndex = 2;
            this.buttonObrisi.Text = "Obriši zaposlenog";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisiZaposlenog_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonIzmeniZaposlenog, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonObrisi, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(929, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 61);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.buttonPrikaziObezbedjenje, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPrikaziPsihologe, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPrikaziAdministraciju, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonPrikaziSve, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(335, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(473, 61);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // buttonPrikaziObezbedjenje
            // 
            this.buttonPrikaziObezbedjenje.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPrikaziObezbedjenje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrikaziObezbedjenje.Location = new System.Drawing.Point(358, 4);
            this.buttonPrikaziObezbedjenje.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrikaziObezbedjenje.Name = "buttonPrikaziObezbedjenje";
            this.buttonPrikaziObezbedjenje.Size = new System.Drawing.Size(111, 53);
            this.buttonPrikaziObezbedjenje.TabIndex = 11;
            this.buttonPrikaziObezbedjenje.Text = "Obezbeđenje";
            this.buttonPrikaziObezbedjenje.UseVisualStyleBackColor = true;
            this.buttonPrikaziObezbedjenje.Click += new System.EventHandler(this.buttonPrikaziObezbedjenje_Click);
            // 
            // buttonPrikaziPsihologe
            // 
            this.buttonPrikaziPsihologe.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPrikaziPsihologe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrikaziPsihologe.Location = new System.Drawing.Point(240, 4);
            this.buttonPrikaziPsihologe.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrikaziPsihologe.Name = "buttonPrikaziPsihologe";
            this.buttonPrikaziPsihologe.Size = new System.Drawing.Size(110, 53);
            this.buttonPrikaziPsihologe.TabIndex = 10;
            this.buttonPrikaziPsihologe.Text = "Psiholozi";
            this.buttonPrikaziPsihologe.UseVisualStyleBackColor = true;
            this.buttonPrikaziPsihologe.Click += new System.EventHandler(this.buttonPrikaziPsihologe_Click);
            // 
            // buttonPrikaziAdministraciju
            // 
            this.buttonPrikaziAdministraciju.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPrikaziAdministraciju.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrikaziAdministraciju.Location = new System.Drawing.Point(122, 4);
            this.buttonPrikaziAdministraciju.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrikaziAdministraciju.Name = "buttonPrikaziAdministraciju";
            this.buttonPrikaziAdministraciju.Size = new System.Drawing.Size(110, 53);
            this.buttonPrikaziAdministraciju.TabIndex = 9;
            this.buttonPrikaziAdministraciju.Text = "Administracija";
            this.buttonPrikaziAdministraciju.UseVisualStyleBackColor = true;
            this.buttonPrikaziAdministraciju.Click += new System.EventHandler(this.buttonPrikaziAdministraciju_Click);
            // 
            // buttonPrikaziSve
            // 
            this.buttonPrikaziSve.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPrikaziSve.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPrikaziSve.Location = new System.Drawing.Point(4, 4);
            this.buttonPrikaziSve.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPrikaziSve.Name = "buttonPrikaziSve";
            this.buttonPrikaziSve.Size = new System.Drawing.Size(110, 53);
            this.buttonPrikaziSve.TabIndex = 8;
            this.buttonPrikaziSve.Text = "Svi";
            this.buttonPrikaziSve.UseVisualStyleBackColor = true;
            this.buttonPrikaziSve.Click += new System.EventHandler(this.buttonPrikaziSve_Click);
            // 
            // FormPregledZaposlenih
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 489);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.groupBoxZaposleni);
            this.Controls.Add(this.buttonDodajZaposlenog);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1216, 528);
            this.Name = "FormPregledZaposlenih";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zaposleni";
            this.Load += new System.EventHandler(this.FormPregledZaposlenih_Load);
            this.Shown += new System.EventHandler(this.FormPregledZaposlenih_Shown);
            this.groupBoxZaposleni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxZaposleni;
        private System.Windows.Forms.ListView listViewZaposleni;
        private System.Windows.Forms.Button buttonDodajZaposlenog;
        private System.Windows.Forms.Button buttonIzmeniZaposlenog;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonPrikaziObezbedjenje;
        private System.Windows.Forms.Button buttonPrikaziPsihologe;
        private System.Windows.Forms.Button buttonPrikaziAdministraciju;
        private System.Windows.Forms.Button buttonPrikaziSve;
    }
}