
namespace Zatvor
{
    partial class ZatvorskaJedinicaForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zatvorskaJedinicaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sifraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nazivDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upravnikDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.kapacitetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frezimODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frezimSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frezimPODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminiSetnjeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.terminiPoseteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.celijskiPeriodiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorskaJedinicaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1281, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1154, 2);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(125, 76);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sifraDataGridViewTextBoxColumn,
            this.nazivDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn,
            this.upravnikDataGridViewTextBoxColumn,
            this.kapacitetDataGridViewTextBoxColumn,
            this.frezimODataGridViewTextBoxColumn,
            this.frezimSDataGridViewTextBoxColumn,
            this.frezimPODataGridViewTextBoxColumn,
            this.terminiSetnjeDataGridViewTextBoxColumn,
            this.terminiPoseteDataGridViewTextBoxColumn,
            this.celijskiPeriodiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.zatvorskaJedinicaBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1148, 446);
            this.dataGridView1.TabIndex = 1;
            // 
            // zatvorskaJedinicaBindingSource
            // 
            this.zatvorskaJedinicaBindingSource.DataSource = typeof(Zatvor.Entiteti.ZatvorskaJedinica);
            // 
            // sifraDataGridViewTextBoxColumn
            // 
            this.sifraDataGridViewTextBoxColumn.DataPropertyName = "Sifra";
            this.sifraDataGridViewTextBoxColumn.HeaderText = "Sifra";
            this.sifraDataGridViewTextBoxColumn.Name = "sifraDataGridViewTextBoxColumn";
            this.sifraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nazivDataGridViewTextBoxColumn
            // 
            this.nazivDataGridViewTextBoxColumn.DataPropertyName = "Naziv";
            this.nazivDataGridViewTextBoxColumn.HeaderText = "Naziv";
            this.nazivDataGridViewTextBoxColumn.Name = "nazivDataGridViewTextBoxColumn";
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "Adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            // 
            // upravnikDataGridViewTextBoxColumn
            // 
            this.upravnikDataGridViewTextBoxColumn.DataPropertyName = "Upravnik";
            this.upravnikDataGridViewTextBoxColumn.HeaderText = "Upravnik";
            this.upravnikDataGridViewTextBoxColumn.Name = "upravnikDataGridViewTextBoxColumn";
            this.upravnikDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.upravnikDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // kapacitetDataGridViewTextBoxColumn
            // 
            this.kapacitetDataGridViewTextBoxColumn.DataPropertyName = "Kapacitet";
            this.kapacitetDataGridViewTextBoxColumn.HeaderText = "Kapacitet";
            this.kapacitetDataGridViewTextBoxColumn.Name = "kapacitetDataGridViewTextBoxColumn";
            // 
            // frezimODataGridViewTextBoxColumn
            // 
            this.frezimODataGridViewTextBoxColumn.DataPropertyName = "FrezimO";
            this.frezimODataGridViewTextBoxColumn.HeaderText = "FrezimO";
            this.frezimODataGridViewTextBoxColumn.Name = "frezimODataGridViewTextBoxColumn";
            // 
            // frezimSDataGridViewTextBoxColumn
            // 
            this.frezimSDataGridViewTextBoxColumn.DataPropertyName = "FrezimS";
            this.frezimSDataGridViewTextBoxColumn.HeaderText = "FrezimS";
            this.frezimSDataGridViewTextBoxColumn.Name = "frezimSDataGridViewTextBoxColumn";
            // 
            // frezimPODataGridViewTextBoxColumn
            // 
            this.frezimPODataGridViewTextBoxColumn.DataPropertyName = "FrezimPO";
            this.frezimPODataGridViewTextBoxColumn.HeaderText = "FrezimPO";
            this.frezimPODataGridViewTextBoxColumn.Name = "frezimPODataGridViewTextBoxColumn";
            // 
            // terminiSetnjeDataGridViewTextBoxColumn
            // 
            this.terminiSetnjeDataGridViewTextBoxColumn.DataPropertyName = "TerminiSetnje";
            this.terminiSetnjeDataGridViewTextBoxColumn.HeaderText = "TerminiSetnje";
            this.terminiSetnjeDataGridViewTextBoxColumn.Name = "terminiSetnjeDataGridViewTextBoxColumn";
            // 
            // terminiPoseteDataGridViewTextBoxColumn
            // 
            this.terminiPoseteDataGridViewTextBoxColumn.DataPropertyName = "TerminiPosete";
            this.terminiPoseteDataGridViewTextBoxColumn.HeaderText = "TerminiPosete";
            this.terminiPoseteDataGridViewTextBoxColumn.Name = "terminiPoseteDataGridViewTextBoxColumn";
            // 
            // celijskiPeriodiDataGridViewTextBoxColumn
            // 
            this.celijskiPeriodiDataGridViewTextBoxColumn.DataPropertyName = "CelijskiPeriodi";
            this.celijskiPeriodiDataGridViewTextBoxColumn.HeaderText = "CelijskiPeriodi";
            this.celijskiPeriodiDataGridViewTextBoxColumn.Name = "celijskiPeriodiDataGridViewTextBoxColumn";
            // 
            // ZatvorskaJedinicaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ZatvorskaJedinicaForm";
            this.Text = "Zatvorska Jedinica Info";
            this.Load += new System.EventHandler(this.ZatvorskaJedinicaForm_Load_1);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorskaJedinicaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource zatvorskaJedinicaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn sifraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nazivDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewLinkColumn upravnikDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kapacitetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frezimODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frezimSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn frezimPODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminiSetnjeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn terminiPoseteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn celijskiPeriodiDataGridViewTextBoxColumn;
    }
}