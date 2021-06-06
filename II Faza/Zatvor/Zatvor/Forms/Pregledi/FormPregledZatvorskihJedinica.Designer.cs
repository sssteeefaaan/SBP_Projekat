
namespace Zatvor.Forms
{
    partial class FormPregledZatvorskihJedinica
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
            this.groupBoxZatvorskeJedinice = new System.Windows.Forms.GroupBox();
            this.listViewZatvorskeJedinice = new System.Windows.Forms.ListView();
            this.buttonDodaj = new System.Windows.Forms.Button();
            this.buttonIzmeni = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxOtvoren = new System.Windows.Forms.CheckBox();
            this.checkBoxPoluotvoren = new System.Windows.Forms.CheckBox();
            this.checkBoxStrogi = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zatvorenikViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxZatvorskeJedinice.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxZatvorskeJedinice
            // 
            this.groupBoxZatvorskeJedinice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZatvorskeJedinice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxZatvorskeJedinice.Controls.Add(this.listViewZatvorskeJedinice);
            this.groupBoxZatvorskeJedinice.Location = new System.Drawing.Point(13, 77);
            this.groupBoxZatvorskeJedinice.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxZatvorskeJedinice.Name = "groupBoxZatvorskeJedinice";
            this.groupBoxZatvorskeJedinice.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxZatvorskeJedinice.Size = new System.Drawing.Size(1117, 440);
            this.groupBoxZatvorskeJedinice.TabIndex = 8;
            this.groupBoxZatvorskeJedinice.TabStop = false;
            this.groupBoxZatvorskeJedinice.Text = "Zatvorske jedinice";
            // 
            // listViewZatvorskeJedinice
            // 
            this.listViewZatvorskeJedinice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewZatvorskeJedinice.FullRowSelect = true;
            this.listViewZatvorskeJedinice.GridLines = true;
            this.listViewZatvorskeJedinice.HideSelection = false;
            this.listViewZatvorskeJedinice.Location = new System.Drawing.Point(4, 23);
            this.listViewZatvorskeJedinice.Name = "listViewZatvorskeJedinice";
            this.listViewZatvorskeJedinice.ShowItemToolTips = true;
            this.listViewZatvorskeJedinice.Size = new System.Drawing.Size(1109, 413);
            this.listViewZatvorskeJedinice.TabIndex = 0;
            this.listViewZatvorskeJedinice.UseCompatibleStateImageBehavior = false;
            this.listViewZatvorskeJedinice.View = System.Windows.Forms.View.Details;
            this.listViewZatvorskeJedinice.SelectedIndexChanged += new System.EventHandler(this.listViewZatvorskeJedinice_SelectedIndexChanged);
            this.listViewZatvorskeJedinice.DoubleClick += new System.EventHandler(this.listViewZatvorskeJedinice_DoubleClick);
            // 
            // buttonDodaj
            // 
            this.buttonDodaj.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDodaj.Location = new System.Drawing.Point(13, 13);
            this.buttonDodaj.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDodaj.Name = "buttonDodaj";
            this.buttonDodaj.Size = new System.Drawing.Size(134, 56);
            this.buttonDodaj.TabIndex = 9;
            this.buttonDodaj.Text = "Dodaj zatvorsku jedinicu";
            this.buttonDodaj.UseVisualStyleBackColor = true;
            this.buttonDodaj.Click += new System.EventHandler(this.buttonDodaj_Click);
            // 
            // buttonIzmeni
            // 
            this.buttonIzmeni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonIzmeni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeni.Location = new System.Drawing.Point(4, 4);
            this.buttonIzmeni.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIzmeni.Name = "buttonIzmeni";
            this.buttonIzmeni.Size = new System.Drawing.Size(121, 53);
            this.buttonIzmeni.TabIndex = 1;
            this.buttonIzmeni.Text = "Izmeni zatvorsku jedinicu";
            this.buttonIzmeni.UseVisualStyleBackColor = true;
            this.buttonIzmeni.Click += new System.EventHandler(this.buttonIzmeni_Click);
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
            this.buttonObrisi.Text = "Obriši zatvorsku jedinicu";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.checkBoxOtvoren, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxPoluotvoren, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxStrogi, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(353, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(388, 61);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // checkBoxOtvoren
            // 
            this.checkBoxOtvoren.AutoSize = true;
            this.checkBoxOtvoren.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxOtvoren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxOtvoren.Location = new System.Drawing.Point(3, 3);
            this.checkBoxOtvoren.Name = "checkBoxOtvoren";
            this.checkBoxOtvoren.Size = new System.Drawing.Size(123, 55);
            this.checkBoxOtvoren.TabIndex = 0;
            this.checkBoxOtvoren.Text = "Otvoren režim";
            this.checkBoxOtvoren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxOtvoren.UseVisualStyleBackColor = true;
            this.checkBoxOtvoren.CheckedChanged += new System.EventHandler(this.checkBoxOtvoren_CheckedChanged);
            // 
            // checkBoxPoluotvoren
            // 
            this.checkBoxPoluotvoren.AutoSize = true;
            this.checkBoxPoluotvoren.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxPoluotvoren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxPoluotvoren.Location = new System.Drawing.Point(132, 3);
            this.checkBoxPoluotvoren.Name = "checkBoxPoluotvoren";
            this.checkBoxPoluotvoren.Size = new System.Drawing.Size(123, 55);
            this.checkBoxPoluotvoren.TabIndex = 1;
            this.checkBoxPoluotvoren.Text = "Poluotvoren režim";
            this.checkBoxPoluotvoren.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxPoluotvoren.UseVisualStyleBackColor = true;
            this.checkBoxPoluotvoren.CheckedChanged += new System.EventHandler(this.checkBoxPoluotvoren_CheckedChanged);
            // 
            // checkBoxStrogi
            // 
            this.checkBoxStrogi.AutoSize = true;
            this.checkBoxStrogi.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBoxStrogi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxStrogi.Location = new System.Drawing.Point(261, 3);
            this.checkBoxStrogi.Name = "checkBoxStrogi";
            this.checkBoxStrogi.Size = new System.Drawing.Size(124, 55);
            this.checkBoxStrogi.TabIndex = 2;
            this.checkBoxStrogi.Text = "Strogi režim";
            this.checkBoxStrogi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxStrogi.UseVisualStyleBackColor = true;
            this.checkBoxStrogi.CheckedChanged += new System.EventHandler(this.checkBoxStrogi_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonIzmeni, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonObrisi, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(872, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 61);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // FormPregledZatvorskihJedinica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 530);
            this.Controls.Add(this.groupBoxZatvorskeJedinice);
            this.Controls.Add(this.buttonDodaj);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1159, 569);
            this.Name = "FormPregledZatvorskihJedinica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled zatvorskih jedinica";
            this.Load += new System.EventHandler(this.FormPregledZatvorskihJedinica_Load);
            this.groupBoxZatvorskeJedinice.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxZatvorskeJedinice;
        private System.Windows.Forms.ListView listViewZatvorskeJedinice;
        private System.Windows.Forms.Button buttonDodaj;
        private System.Windows.Forms.Button buttonIzmeni;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBoxOtvoren;
        private System.Windows.Forms.CheckBox checkBoxPoluotvoren;
        private System.Windows.Forms.CheckBox checkBoxStrogi;
    }
}