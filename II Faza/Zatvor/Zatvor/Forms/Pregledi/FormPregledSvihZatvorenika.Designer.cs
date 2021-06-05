
namespace Zatvor.Forms
{
    partial class FormPregledSvihZatvorenika
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
            this.groupBoxZatvorenici = new System.Windows.Forms.GroupBox();
            this.listViewZatvorenici = new System.Windows.Forms.ListView();
            this.buttonDodajZatvorenika = new System.Windows.Forms.Button();
            this.buttonIzmeniZatvorenika = new System.Windows.Forms.Button();
            this.buttonObrisi = new System.Windows.Forms.Button();
            this.zatvorenikViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxZatvorenici.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxZatvorenici
            // 
            this.groupBoxZatvorenici.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxZatvorenici.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxZatvorenici.Controls.Add(this.listViewZatvorenici);
            this.groupBoxZatvorenici.Location = new System.Drawing.Point(13, 69);
            this.groupBoxZatvorenici.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxZatvorenici.Name = "groupBoxZatvorenici";
            this.groupBoxZatvorenici.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxZatvorenici.Size = new System.Drawing.Size(1174, 399);
            this.groupBoxZatvorenici.TabIndex = 0;
            this.groupBoxZatvorenici.TabStop = false;
            this.groupBoxZatvorenici.Text = "Zatvorenici";
            // 
            // listViewZatvorenici
            // 
            this.listViewZatvorenici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewZatvorenici.HideSelection = false;
            this.listViewZatvorenici.Location = new System.Drawing.Point(4, 23);
            this.listViewZatvorenici.Name = "listViewZatvorenici";
            this.listViewZatvorenici.Size = new System.Drawing.Size(1166, 372);
            this.listViewZatvorenici.TabIndex = 0;
            this.listViewZatvorenici.UseCompatibleStateImageBehavior = false;
            this.listViewZatvorenici.SelectedIndexChanged += new System.EventHandler(this.listViewZatvorenici_SelectedIndexChanged);
            this.listViewZatvorenici.DoubleClick += new System.EventHandler(this.listViewZatvorenici_DoubleClick);
            // 
            // buttonDodajZatvorenika
            // 
            this.buttonDodajZatvorenika.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDodajZatvorenika.Location = new System.Drawing.Point(13, 13);
            this.buttonDodajZatvorenika.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDodajZatvorenika.Name = "buttonDodajZatvorenika";
            this.buttonDodajZatvorenika.Size = new System.Drawing.Size(114, 52);
            this.buttonDodajZatvorenika.TabIndex = 0;
            this.buttonDodajZatvorenika.Text = "Dodaj zatvorenika";
            this.buttonDodajZatvorenika.UseVisualStyleBackColor = true;
            this.buttonDodajZatvorenika.Click += new System.EventHandler(this.buttonDodajZatvorenika_Click);
            // 
            // buttonIzmeniZatvorenika
            // 
            this.buttonIzmeniZatvorenika.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonIzmeniZatvorenika.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeniZatvorenika.Location = new System.Drawing.Point(4, 4);
            this.buttonIzmeniZatvorenika.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIzmeniZatvorenika.Name = "buttonIzmeniZatvorenika";
            this.buttonIzmeniZatvorenika.Size = new System.Drawing.Size(121, 53);
            this.buttonIzmeniZatvorenika.TabIndex = 1;
            this.buttonIzmeniZatvorenika.Text = "Izmeni zatvorenika";
            this.buttonIzmeniZatvorenika.UseVisualStyleBackColor = true;
            this.buttonIzmeniZatvorenika.Click += new System.EventHandler(this.buttonIzmeniZatvorenika_Click);
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
            this.buttonObrisi.Text = "Obriši zatvorenike";
            this.buttonObrisi.UseVisualStyleBackColor = true;
            this.buttonObrisi.Click += new System.EventHandler(this.buttonObrisi_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonIzmeniZatvorenika, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonObrisi, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(929, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 61);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // FormPregledSvihZatvorenika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 481);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonDodajZatvorenika);
            this.Controls.Add(this.groupBoxZatvorenici);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1216, 520);
            this.Name = "FormPregledSvihZatvorenika";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Zatvorenici";
            this.Load += new System.EventHandler(this.FormPregledZatvorenika_Load);
            this.groupBoxZatvorenici.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.zatvorenikViewBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxZatvorenici;
        private System.Windows.Forms.BindingSource zatvorenikViewBindingSource;
        private System.Windows.Forms.Button buttonDodajZatvorenika;
        private System.Windows.Forms.Button buttonIzmeniZatvorenika;
        private System.Windows.Forms.Button buttonObrisi;
        private System.Windows.Forms.ListView listViewZatvorenici;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}