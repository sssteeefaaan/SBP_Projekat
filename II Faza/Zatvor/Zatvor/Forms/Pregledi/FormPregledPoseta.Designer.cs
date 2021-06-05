
namespace Zatvor.Forms
{
    partial class FormPregledPoseta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonObrisiPosetu = new System.Windows.Forms.Button();
            this.buttonIzmeniPosetu = new System.Windows.Forms.Button();
            this.dateTimePickerPocetak = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerKraj = new System.Windows.Forms.DateTimePicker();
            this.buttonDodajPosetu = new System.Windows.Forms.Button();
            this.listViewPosete = new System.Windows.Forms.ListView();
            this.labelAdvokat = new System.Windows.Forms.Label();
            this.buttonUcitajPosete = new System.Windows.Forms.Button();
            this.labelZatvorenik = new System.Windows.Forms.Label();
            this.comboBoxAdvokat = new System.Windows.Forms.ComboBox();
            this.comboBoxZatvorenik = new System.Windows.Forms.ComboBox();
            this.buttonSacuvajIzmene = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Vreme odlaska:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 22;
            this.label1.Text = "Vreme dolaska:";
            // 
            // buttonObrisiPosetu
            // 
            this.buttonObrisiPosetu.Location = new System.Drawing.Point(423, 237);
            this.buttonObrisiPosetu.Name = "buttonObrisiPosetu";
            this.buttonObrisiPosetu.Size = new System.Drawing.Size(122, 42);
            this.buttonObrisiPosetu.TabIndex = 21;
            this.buttonObrisiPosetu.Text = "Obriši posetu";
            this.buttonObrisiPosetu.UseVisualStyleBackColor = true;
            this.buttonObrisiPosetu.Click += new System.EventHandler(this.buttonObrisiPosetu_Click);
            // 
            // buttonIzmeniPosetu
            // 
            this.buttonIzmeniPosetu.Location = new System.Drawing.Point(295, 237);
            this.buttonIzmeniPosetu.Name = "buttonIzmeniPosetu";
            this.buttonIzmeniPosetu.Size = new System.Drawing.Size(122, 42);
            this.buttonIzmeniPosetu.TabIndex = 20;
            this.buttonIzmeniPosetu.Text = "Izmeni posetu";
            this.buttonIzmeniPosetu.UseVisualStyleBackColor = true;
            this.buttonIzmeniPosetu.Click += new System.EventHandler(this.buttonIzmeniPosetu_Click);
            // 
            // dateTimePickerPocetak
            // 
            this.dateTimePickerPocetak.Location = new System.Drawing.Point(18, 188);
            this.dateTimePickerPocetak.Name = "dateTimePickerPocetak";
            this.dateTimePickerPocetak.Size = new System.Drawing.Size(251, 26);
            this.dateTimePickerPocetak.TabIndex = 19;
            // 
            // dateTimePickerKraj
            // 
            this.dateTimePickerKraj.Location = new System.Drawing.Point(289, 188);
            this.dateTimePickerKraj.Name = "dateTimePickerKraj";
            this.dateTimePickerKraj.Size = new System.Drawing.Size(250, 26);
            this.dateTimePickerKraj.TabIndex = 18;
            // 
            // buttonDodajPosetu
            // 
            this.buttonDodajPosetu.Location = new System.Drawing.Point(12, 237);
            this.buttonDodajPosetu.Name = "buttonDodajPosetu";
            this.buttonDodajPosetu.Size = new System.Drawing.Size(122, 42);
            this.buttonDodajPosetu.TabIndex = 17;
            this.buttonDodajPosetu.Text = "Dodaj posetu";
            this.buttonDodajPosetu.UseVisualStyleBackColor = true;
            this.buttonDodajPosetu.Click += new System.EventHandler(this.buttonDodajPosetu_Click);
            // 
            // listViewPosete
            // 
            this.listViewPosete.HideSelection = false;
            this.listViewPosete.Location = new System.Drawing.Point(11, 285);
            this.listViewPosete.Name = "listViewPosete";
            this.listViewPosete.Size = new System.Drawing.Size(534, 211);
            this.listViewPosete.TabIndex = 16;
            this.listViewPosete.UseCompatibleStateImageBehavior = false;
            this.listViewPosete.SelectedIndexChanged += new System.EventHandler(this.listViewPosete_SelectedIndexChanged);
            // 
            // labelAdvokat
            // 
            this.labelAdvokat.AutoSize = true;
            this.labelAdvokat.Location = new System.Drawing.Point(369, 26);
            this.labelAdvokat.Name = "labelAdvokat";
            this.labelAdvokat.Size = new System.Drawing.Size(62, 19);
            this.labelAdvokat.TabIndex = 12;
            this.labelAdvokat.Text = "Advokat";
            // 
            // buttonUcitajPosete
            // 
            this.buttonUcitajPosete.Location = new System.Drawing.Point(203, 82);
            this.buttonUcitajPosete.Name = "buttonUcitajPosete";
            this.buttonUcitajPosete.Size = new System.Drawing.Size(122, 42);
            this.buttonUcitajPosete.TabIndex = 13;
            this.buttonUcitajPosete.Text = "Učitaj posete";
            this.buttonUcitajPosete.UseVisualStyleBackColor = true;
            this.buttonUcitajPosete.Click += new System.EventHandler(this.buttonUcitajPosete_Click);
            // 
            // labelZatvorenik
            // 
            this.labelZatvorenik.AutoSize = true;
            this.labelZatvorenik.Location = new System.Drawing.Point(93, 26);
            this.labelZatvorenik.Name = "labelZatvorenik";
            this.labelZatvorenik.Size = new System.Drawing.Size(74, 19);
            this.labelZatvorenik.TabIndex = 11;
            this.labelZatvorenik.Text = "Zatvorenik";
            // 
            // comboBoxAdvokat
            // 
            this.comboBoxAdvokat.FormattingEnabled = true;
            this.comboBoxAdvokat.Location = new System.Drawing.Point(277, 48);
            this.comboBoxAdvokat.Name = "comboBoxAdvokat";
            this.comboBoxAdvokat.Size = new System.Drawing.Size(250, 27);
            this.comboBoxAdvokat.TabIndex = 9;
            this.comboBoxAdvokat.SelectedIndexChanged += new System.EventHandler(this.comboBoxAdvokat_SelectedIndexChanged);
            // 
            // comboBoxZatvorenik
            // 
            this.comboBoxZatvorenik.FormattingEnabled = true;
            this.comboBoxZatvorenik.Location = new System.Drawing.Point(6, 48);
            this.comboBoxZatvorenik.Name = "comboBoxZatvorenik";
            this.comboBoxZatvorenik.Size = new System.Drawing.Size(251, 27);
            this.comboBoxZatvorenik.TabIndex = 8;
            this.comboBoxZatvorenik.SelectedIndexChanged += new System.EventHandler(this.comboBoxZatvorenik_SelectedIndexChanged);
            // 
            // buttonSacuvajIzmene
            // 
            this.buttonSacuvajIzmene.Location = new System.Drawing.Point(12, 285);
            this.buttonSacuvajIzmene.Name = "buttonSacuvajIzmene";
            this.buttonSacuvajIzmene.Size = new System.Drawing.Size(122, 42);
            this.buttonSacuvajIzmene.TabIndex = 25;
            this.buttonSacuvajIzmene.Text = "Sačuvaj izmene";
            this.buttonSacuvajIzmene.UseVisualStyleBackColor = true;
            this.buttonSacuvajIzmene.Click += new System.EventHandler(this.buttonSacuvajIzmene_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelAdvokat);
            this.groupBox1.Controls.Add(this.buttonUcitajPosete);
            this.groupBox1.Controls.Add(this.labelZatvorenik);
            this.groupBox1.Controls.Add(this.comboBoxAdvokat);
            this.groupBox1.Controls.Add(this.comboBoxZatvorenik);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(533, 130);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Odabir posetioca";
            // 
            // FormPregledPoseta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonObrisiPosetu);
            this.Controls.Add(this.buttonIzmeniPosetu);
            this.Controls.Add(this.dateTimePickerPocetak);
            this.Controls.Add(this.dateTimePickerKraj);
            this.Controls.Add(this.buttonDodajPosetu);
            this.Controls.Add(this.listViewPosete);
            this.Controls.Add(this.buttonSacuvajIzmene);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 544);
            this.MinimumSize = new System.Drawing.Size(571, 544);
            this.Name = "FormPregledPoseta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pregled poseta";
            this.Load += new System.EventHandler(this.FormPregledPoseta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonObrisiPosetu;
        private System.Windows.Forms.Button buttonIzmeniPosetu;
        private System.Windows.Forms.DateTimePicker dateTimePickerPocetak;
        private System.Windows.Forms.DateTimePicker dateTimePickerKraj;
        private System.Windows.Forms.Button buttonDodajPosetu;
        private System.Windows.Forms.ListView listViewPosete;
        private System.Windows.Forms.Label labelAdvokat;
        private System.Windows.Forms.Button buttonUcitajPosete;
        private System.Windows.Forms.Label labelZatvorenik;
        private System.Windows.Forms.ComboBox comboBoxAdvokat;
        private System.Windows.Forms.ComboBox comboBoxZatvorenik;
        private System.Windows.Forms.Button buttonSacuvajIzmene;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}