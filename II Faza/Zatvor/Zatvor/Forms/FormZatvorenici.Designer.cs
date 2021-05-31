
namespace Zatvor.Forms
{
    partial class FormZatvorenici
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxZatvorenici = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDodajZatvorenika = new System.Windows.Forms.Button();
            this.buttonIzmeniZatvorenika = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jMBGDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brojDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumInkarceracijeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zatvorenikViewBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.zatvorenikViewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.zatvorenikViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxZatvorenici.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.groupBoxZatvorenici, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 657F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1200, 657);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBoxZatvorenici
            // 
            this.groupBoxZatvorenici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZatvorenici.AutoSize = true;
            this.groupBoxZatvorenici.Controls.Add(this.dataGridView1);
            this.groupBoxZatvorenici.Location = new System.Drawing.Point(4, 4);
            this.groupBoxZatvorenici.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxZatvorenici.Name = "groupBoxZatvorenici";
            this.groupBoxZatvorenici.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxZatvorenici.Size = new System.Drawing.Size(1072, 649);
            this.groupBoxZatvorenici.TabIndex = 0;
            this.groupBoxZatvorenici.TabStop = false;
            this.groupBoxZatvorenici.Text = "Zatvorenici";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Controls.Add(this.buttonDodajZatvorenika, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonIzmeniZatvorenika, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonObrisi, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1084, 4);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(112, 127);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonDodajZatvorenika
            // 
            this.buttonDodajZatvorenika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDodajZatvorenika.Location = new System.Drawing.Point(4, 4);
            this.buttonDodajZatvorenika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDodajZatvorenika.Name = "buttonDodajZatvorenika";
            this.buttonDodajZatvorenika.Size = new System.Drawing.Size(104, 34);
            this.buttonDodajZatvorenika.TabIndex = 0;
            this.buttonDodajZatvorenika.Text = "Dodaj zatvorenika";
            this.buttonDodajZatvorenika.UseVisualStyleBackColor = true;
            this.buttonDodajZatvorenika.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonIzmeniZatvorenika
            // 
            this.buttonIzmeniZatvorenika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeniZatvorenika.Location = new System.Drawing.Point(4, 46);
            this.buttonIzmeniZatvorenika.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonIzmeniZatvorenika.Name = "buttonIzmeniZatvorenika";
            this.buttonIzmeniZatvorenika.Size = new System.Drawing.Size(104, 34);
            this.buttonIzmeniZatvorenika.TabIndex = 1;
            this.buttonIzmeniZatvorenika.Text = "Izmeni zatvorenika";
            this.buttonIzmeniZatvorenika.UseVisualStyleBackColor = true;
            this.buttonIzmeniZatvorenika.Click += new System.EventHandler(this.buttonIzmeniZatvorenika_Click);
            // 
            // buttonObrisi
            // 
            this.buttonObrisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonObrisi.Location = new System.Drawing.Point(4, 88);
            this.buttonObrisi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonObrisi.Name = "buttonObrisi";
            this.buttonObrisi.Size = new System.Drawing.Size(104, 35);
            this.buttonObrisi.TabIndex = 2;
            this.buttonObrisi.Text = "Obriši zatvorenike";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jMBGDataGridViewTextBoxColumn,
            this.imeDataGridViewTextBoxColumn,
            this.prezimeDataGridViewTextBoxColumn,
            this.polDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn,
            this.brojDataGridViewTextBoxColumn,
            this.datumInkarceracijeDataGridViewTextBoxColumn,
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn,
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn,
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.zatvorenikViewBindingSource2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1064, 622);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // jMBGDataGridViewTextBoxColumn
            // 
            this.jMBGDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.jMBGDataGridViewTextBoxColumn.DataPropertyName = "JMBG";
            this.jMBGDataGridViewTextBoxColumn.HeaderText = "JMBG";
            this.jMBGDataGridViewTextBoxColumn.Name = "jMBGDataGridViewTextBoxColumn";
            this.jMBGDataGridViewTextBoxColumn.ReadOnly = true;
            this.jMBGDataGridViewTextBoxColumn.Width = 75;
            // 
            // imeDataGridViewTextBoxColumn
            // 
            this.imeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.imeDataGridViewTextBoxColumn.DataPropertyName = "Ime";
            this.imeDataGridViewTextBoxColumn.HeaderText = "Ime";
            this.imeDataGridViewTextBoxColumn.Name = "imeDataGridViewTextBoxColumn";
            this.imeDataGridViewTextBoxColumn.ReadOnly = true;
            this.imeDataGridViewTextBoxColumn.Width = 57;
            // 
            // prezimeDataGridViewTextBoxColumn
            // 
            this.prezimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.prezimeDataGridViewTextBoxColumn.DataPropertyName = "Prezime";
            this.prezimeDataGridViewTextBoxColumn.HeaderText = "Prezime";
            this.prezimeDataGridViewTextBoxColumn.Name = "prezimeDataGridViewTextBoxColumn";
            this.prezimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prezimeDataGridViewTextBoxColumn.Width = 82;
            // 
            // polDataGridViewTextBoxColumn
            // 
            this.polDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.polDataGridViewTextBoxColumn.DataPropertyName = "Pol";
            this.polDataGridViewTextBoxColumn.HeaderText = "Pol";
            this.polDataGridViewTextBoxColumn.Name = "polDataGridViewTextBoxColumn";
            this.polDataGridViewTextBoxColumn.ReadOnly = true;
            this.polDataGridViewTextBoxColumn.Width = 54;
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "Adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            this.adresaDataGridViewTextBoxColumn.ReadOnly = true;
            this.adresaDataGridViewTextBoxColumn.Width = 78;
            // 
            // brojDataGridViewTextBoxColumn
            // 
            this.brojDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.brojDataGridViewTextBoxColumn.DataPropertyName = "Broj";
            this.brojDataGridViewTextBoxColumn.HeaderText = "Broj";
            this.brojDataGridViewTextBoxColumn.Name = "brojDataGridViewTextBoxColumn";
            this.brojDataGridViewTextBoxColumn.ReadOnly = true;
            this.brojDataGridViewTextBoxColumn.Width = 61;
            // 
            // datumInkarceracijeDataGridViewTextBoxColumn
            // 
            this.datumInkarceracijeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datumInkarceracijeDataGridViewTextBoxColumn.DataPropertyName = "DatumInkarceracije";
            this.datumInkarceracijeDataGridViewTextBoxColumn.HeaderText = "DatumInkarceracije";
            this.datumInkarceracijeDataGridViewTextBoxColumn.Name = "datumInkarceracijeDataGridViewTextBoxColumn";
            this.datumInkarceracijeDataGridViewTextBoxColumn.ReadOnly = true;
            this.datumInkarceracijeDataGridViewTextBoxColumn.Width = 153;
            // 
            // datumSledecegSaslusanjaDataGridViewTextBoxColumn
            // 
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.DataPropertyName = "DatumSledecegSaslusanja";
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.HeaderText = "DatumSledecegSaslusanja";
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.Name = "datumSledecegSaslusanjaDataGridViewTextBoxColumn";
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.ReadOnly = true;
            this.datumSledecegSaslusanjaDataGridViewTextBoxColumn.Width = 192;
            // 
            // statusUslovnogOtpustaDataGridViewTextBoxColumn
            // 
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.DataPropertyName = "StatusUslovnogOtpusta";
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.HeaderText = "StatusUslovnogOtpusta";
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.Name = "statusUslovnogOtpustaDataGridViewTextBoxColumn";
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusUslovnogOtpustaDataGridViewTextBoxColumn.Width = 176;
            // 
            // nazivZatvorskeJediniceDataGridViewTextBoxColumn
            // 
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.DataPropertyName = "NazivZatvorskeJedinice";
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.HeaderText = "NazivZatvorskeJedinice";
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.Name = "nazivZatvorskeJediniceDataGridViewTextBoxColumn";
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.ReadOnly = true;
            this.nazivZatvorskeJediniceDataGridViewTextBoxColumn.Width = 178;
            // 
            // zatvorenikViewBindingSource2
            // 
            this.zatvorenikViewBindingSource2.DataSource = typeof(Zatvor.DTO.View.ZatvorenikView);
            // 
            // zatvorenikViewBindingSource1
            // 
            this.zatvorenikViewBindingSource1.DataSource = typeof(Zatvor.DTO.View.ZatvorenikView);
            // 
            // zatvorenikViewBindingSource
            // 
            this.zatvorenikViewBindingSource.DataSource = typeof(Zatvor.DTO.View.ZatvorenikView);
            // 
            // FormZatvorenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 657);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormZatvorenici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zatvorenici";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxZatvorenici.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxZatvorenici;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifraZJDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource1;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonDodajZatvorenika;
        private System.Windows.Forms.Button buttonIzmeniZatvorenika;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jMBGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brojDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumInkarceracijeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datumSledecegSaslusanjaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusUslovnogOtpustaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivZatvorskeJediniceDataGridViewTextBoxColumn;
    }
}