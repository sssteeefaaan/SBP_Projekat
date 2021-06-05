
namespace Zatvor.Forms.Dodaj_Izmeni
{
    partial class FormPregledZatvorenika
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
            this.buttonDodajPrestup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonUkloniPrestup = new System.Windows.Forms.Button();
            this.buttonIzmeniPrestup = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPunNaziv = new System.Windows.Forms.TextBox();
            this.textBoxKategorija = new System.Windows.Forms.TextBox();
            this.textBoxMestoPrestupa = new System.Windows.Forms.TextBox();
            this.numericUpDownMinKazna = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMaxKazna = new System.Windows.Forms.NumericUpDown();
            this.dateTimePickerDatumPrestupa = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxOpis = new System.Windows.Forms.RichTextBox();
            this.listViewPrestupi = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxAdvokati = new System.Windows.Forms.ComboBox();
            this.dateTimePickerDatumPocetkaSaradnje = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDatumPoslednjegKontakta = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonIzaberiAdvokata = new System.Windows.Forms.Button();
            this.buttonPregledPoseta = new System.Windows.Forms.Button();
            this.buttonIzmeniAdvokata = new System.Windows.Forms.Button();
            this.buttonUkloniAdvokata = new System.Windows.Forms.Button();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonEvidentirajAdvokata = new System.Windows.Forms.Button();
            this.listViewAdvokati = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinKazna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxKazna)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDodajPrestup, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 290);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(115, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1117, 529);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prestupi";
            // 
            // buttonDodajPrestup
            // 
            this.buttonDodajPrestup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDodajPrestup.Location = new System.Drawing.Point(3, 3);
            this.buttonDodajPrestup.Name = "buttonDodajPrestup";
            this.buttonDodajPrestup.Size = new System.Drawing.Size(109, 36);
            this.buttonDodajPrestup.TabIndex = 2;
            this.buttonDodajPrestup.Text = "Dodaj prestup";
            this.buttonDodajPrestup.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.richTextBoxOpis);
            this.groupBox2.Location = new System.Drawing.Point(6, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 177);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opis prestupa";
            // 
            // buttonUkloniPrestup
            // 
            this.buttonUkloniPrestup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUkloniPrestup.Location = new System.Drawing.Point(118, 3);
            this.buttonUkloniPrestup.Name = "buttonUkloniPrestup";
            this.buttonUkloniPrestup.Size = new System.Drawing.Size(109, 36);
            this.buttonUkloniPrestup.TabIndex = 4;
            this.buttonUkloniPrestup.Text = "Ukloni prestup";
            this.buttonUkloniPrestup.UseVisualStyleBackColor = true;
            // 
            // buttonIzmeniPrestup
            // 
            this.buttonIzmeniPrestup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeniPrestup.Location = new System.Drawing.Point(3, 3);
            this.buttonIzmeniPrestup.Name = "buttonIzmeniPrestup";
            this.buttonIzmeniPrestup.Size = new System.Drawing.Size(109, 36);
            this.buttonIzmeniPrestup.TabIndex = 3;
            this.buttonIzmeniPrestup.Text = "Izmeni prestup";
            this.buttonIzmeniPrestup.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonIzmeniPrestup, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonUkloniPrestup, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(878, 293);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 42);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.259259F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.07407F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.259259F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.07407F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.259259F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.07407F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownMinKazna, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownMaxKazna, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxMestoPrestupa, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxPunNaziv, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.textBoxKategorija, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerDatumPrestupa, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 22);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1111, 82);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // textBoxPunNaziv
            // 
            this.textBoxPunNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPunNaziv.Location = new System.Drawing.Point(105, 3);
            this.textBoxPunNaziv.Name = "textBoxPunNaziv";
            this.textBoxPunNaziv.Size = new System.Drawing.Size(261, 26);
            this.textBoxPunNaziv.TabIndex = 8;
            // 
            // textBoxKategorija
            // 
            this.textBoxKategorija.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxKategorija.Location = new System.Drawing.Point(105, 44);
            this.textBoxKategorija.Name = "textBoxKategorija";
            this.textBoxKategorija.Size = new System.Drawing.Size(261, 26);
            this.textBoxKategorija.TabIndex = 9;
            // 
            // textBoxMestoPrestupa
            // 
            this.textBoxMestoPrestupa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMestoPrestupa.Location = new System.Drawing.Point(474, 3);
            this.textBoxMestoPrestupa.Name = "textBoxMestoPrestupa";
            this.textBoxMestoPrestupa.Size = new System.Drawing.Size(261, 26);
            this.textBoxMestoPrestupa.TabIndex = 9;
            // 
            // numericUpDownMinKazna
            // 
            this.numericUpDownMinKazna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMinKazna.Location = new System.Drawing.Point(843, 3);
            this.numericUpDownMinKazna.Name = "numericUpDownMinKazna";
            this.numericUpDownMinKazna.Size = new System.Drawing.Size(265, 26);
            this.numericUpDownMinKazna.TabIndex = 10;
            // 
            // numericUpDownMaxKazna
            // 
            this.numericUpDownMaxKazna.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMaxKazna.Location = new System.Drawing.Point(843, 44);
            this.numericUpDownMaxKazna.Name = "numericUpDownMaxKazna";
            this.numericUpDownMaxKazna.Size = new System.Drawing.Size(265, 26);
            this.numericUpDownMaxKazna.TabIndex = 11;
            // 
            // dateTimePickerDatumPrestupa
            // 
            this.dateTimePickerDatumPrestupa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDatumPrestupa.Location = new System.Drawing.Point(474, 44);
            this.dateTimePickerDatumPrestupa.Name = "dateTimePickerDatumPrestupa";
            this.dateTimePickerDatumPrestupa.Size = new System.Drawing.Size(261, 26);
            this.dateTimePickerDatumPrestupa.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 41);
            this.label1.TabIndex = 10;
            this.label1.Text = "Pun naziv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 41);
            this.label2.TabIndex = 11;
            this.label2.Text = "Kategorija:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(372, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 41);
            this.label3.TabIndex = 12;
            this.label3.Text = "Mesto prestupa:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(372, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 41);
            this.label4.TabIndex = 12;
            this.label4.Text = "Datum prestupa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(741, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 41);
            this.label5.TabIndex = 12;
            this.label5.Text = "Minimalna kazna:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(741, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 41);
            this.label6.TabIndex = 12;
            this.label6.Text = "Maksimalna kazna:";
            // 
            // richTextBoxOpis
            // 
            this.richTextBoxOpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOpis.Location = new System.Drawing.Point(3, 22);
            this.richTextBoxOpis.Name = "richTextBoxOpis";
            this.richTextBoxOpis.Size = new System.Drawing.Size(1099, 152);
            this.richTextBoxOpis.TabIndex = 10;
            this.richTextBoxOpis.Text = "";
            // 
            // listViewPrestupi
            // 
            this.listViewPrestupi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPrestupi.HideSelection = false;
            this.listViewPrestupi.Location = new System.Drawing.Point(3, 22);
            this.listViewPrestupi.Name = "listViewPrestupi";
            this.listViewPrestupi.Size = new System.Drawing.Size(1105, 166);
            this.listViewPrestupi.TabIndex = 7;
            this.listViewPrestupi.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewPrestupi);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 335);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1111, 191);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Lista prestupa";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Controls.Add(this.tableLayoutPanel6);
            this.groupBox4.Location = new System.Drawing.Point(12, 549);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1116, 477);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.comboBoxAdvokati, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePickerDatumPocetkaSaradnje, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePickerDatumPoslednjegKontakta, 1, 2);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(210, 28);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(661, 100);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 33);
            this.label7.TabIndex = 0;
            this.label7.Text = "Advokat:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 33);
            this.label8.TabIndex = 1;
            this.label8.Text = "Datum početka saradnje:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 34);
            this.label9.TabIndex = 2;
            this.label9.Text = "Datum poslednjeg kontakta:";
            // 
            // comboBoxAdvokati
            // 
            this.comboBoxAdvokati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxAdvokati.FormattingEnabled = true;
            this.comboBoxAdvokati.Location = new System.Drawing.Point(201, 3);
            this.comboBoxAdvokati.Name = "comboBoxAdvokati";
            this.comboBoxAdvokati.Size = new System.Drawing.Size(457, 27);
            this.comboBoxAdvokati.TabIndex = 3;
            // 
            // dateTimePickerDatumPocetkaSaradnje
            // 
            this.dateTimePickerDatumPocetkaSaradnje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDatumPocetkaSaradnje.Location = new System.Drawing.Point(201, 36);
            this.dateTimePickerDatumPocetkaSaradnje.Name = "dateTimePickerDatumPocetkaSaradnje";
            this.dateTimePickerDatumPocetkaSaradnje.Size = new System.Drawing.Size(457, 26);
            this.dateTimePickerDatumPocetkaSaradnje.TabIndex = 4;
            // 
            // dateTimePickerDatumPoslednjegKontakta
            // 
            this.dateTimePickerDatumPoslednjegKontakta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerDatumPoslednjegKontakta.Location = new System.Drawing.Point(201, 69);
            this.dateTimePickerDatumPoslednjegKontakta.Name = "dateTimePickerDatumPoslednjegKontakta";
            this.dateTimePickerDatumPoslednjegKontakta.Size = new System.Drawing.Size(457, 26);
            this.dateTimePickerDatumPoslednjegKontakta.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel5.Controls.Add(this.buttonPregledPoseta, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonIzmeniAdvokata, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.buttonUkloniAdvokata, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(748, 151);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(360, 55);
            this.tableLayoutPanel5.TabIndex = 4;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.buttonIzaberiAdvokata, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(6, 154);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(115, 52);
            this.tableLayoutPanel6.TabIndex = 5;
            // 
            // buttonIzaberiAdvokata
            // 
            this.buttonIzaberiAdvokata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzaberiAdvokata.Location = new System.Drawing.Point(3, 3);
            this.buttonIzaberiAdvokata.Name = "buttonIzaberiAdvokata";
            this.buttonIzaberiAdvokata.Size = new System.Drawing.Size(109, 46);
            this.buttonIzaberiAdvokata.TabIndex = 0;
            this.buttonIzaberiAdvokata.Text = "Izaberi advokata";
            this.buttonIzaberiAdvokata.UseVisualStyleBackColor = true;
            // 
            // buttonPregledPoseta
            // 
            this.buttonPregledPoseta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPregledPoseta.Location = new System.Drawing.Point(3, 3);
            this.buttonPregledPoseta.Name = "buttonPregledPoseta";
            this.buttonPregledPoseta.Size = new System.Drawing.Size(113, 49);
            this.buttonPregledPoseta.TabIndex = 0;
            this.buttonPregledPoseta.Text = "Pregled poseta";
            this.buttonPregledPoseta.UseVisualStyleBackColor = true;
            // 
            // buttonIzmeniAdvokata
            // 
            this.buttonIzmeniAdvokata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIzmeniAdvokata.Location = new System.Drawing.Point(122, 3);
            this.buttonIzmeniAdvokata.Name = "buttonIzmeniAdvokata";
            this.buttonIzmeniAdvokata.Size = new System.Drawing.Size(114, 49);
            this.buttonIzmeniAdvokata.TabIndex = 1;
            this.buttonIzmeniAdvokata.Text = "Izmeni advokata";
            this.buttonIzmeniAdvokata.UseVisualStyleBackColor = true;
            // 
            // buttonUkloniAdvokata
            // 
            this.buttonUkloniAdvokata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonUkloniAdvokata.Location = new System.Drawing.Point(242, 3);
            this.buttonUkloniAdvokata.Name = "buttonUkloniAdvokata";
            this.buttonUkloniAdvokata.Size = new System.Drawing.Size(115, 49);
            this.buttonUkloniAdvokata.TabIndex = 2;
            this.buttonUkloniAdvokata.Text = "Ukloni advokata";
            this.buttonUkloniAdvokata.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.buttonEvidentirajAdvokata, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(977, 25);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(128, 54);
            this.tableLayoutPanel7.TabIndex = 6;
            // 
            // buttonEvidentirajAdvokata
            // 
            this.buttonEvidentirajAdvokata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEvidentirajAdvokata.Location = new System.Drawing.Point(3, 3);
            this.buttonEvidentirajAdvokata.Name = "buttonEvidentirajAdvokata";
            this.buttonEvidentirajAdvokata.Size = new System.Drawing.Size(122, 48);
            this.buttonEvidentirajAdvokata.TabIndex = 0;
            this.buttonEvidentirajAdvokata.Text = "Evidentiraj\r\nnovog advokata";
            this.buttonEvidentirajAdvokata.UseVisualStyleBackColor = true;
            // 
            // listViewAdvokati
            // 
            this.listViewAdvokati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewAdvokati.HideSelection = false;
            this.listViewAdvokati.Location = new System.Drawing.Point(3, 22);
            this.listViewAdvokati.Name = "listViewAdvokati";
            this.listViewAdvokati.Size = new System.Drawing.Size(1098, 240);
            this.listViewAdvokati.TabIndex = 7;
            this.listViewAdvokati.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.listViewAdvokati);
            this.groupBox5.Location = new System.Drawing.Point(6, 212);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1104, 265);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1186, 665);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled zatvorenika";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMinKazna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxKazna)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonDodajPrestup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonUkloniPrestup;
        private System.Windows.Forms.Button buttonIzmeniPrestup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox richTextBoxOpis;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMinKazna;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxKazna;
        private System.Windows.Forms.TextBox textBoxMestoPrestupa;
        private System.Windows.Forms.TextBox textBoxPunNaziv;
        private System.Windows.Forms.TextBox textBoxKategorija;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumPrestupa;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listViewPrestupi;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listViewAdvokati;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button buttonEvidentirajAdvokata;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxAdvokati;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumPocetkaSaradnje;
        private System.Windows.Forms.DateTimePicker dateTimePickerDatumPoslednjegKontakta;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button buttonPregledPoseta;
        private System.Windows.Forms.Button buttonIzmeniAdvokata;
        private System.Windows.Forms.Button buttonUkloniAdvokata;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button buttonIzaberiAdvokata;
    }
}