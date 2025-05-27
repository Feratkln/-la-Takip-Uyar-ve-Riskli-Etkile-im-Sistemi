using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace IlacTakipSistemi
{
    partial class Form1
    {
        private IContainer components = null;
        private Guna2HtmlLabel lblIlacAdi;
        private Guna2HtmlLabel lblDoz;
        private Guna2HtmlLabel lblSaat;
        private Guna2HtmlLabel lblBaslangic;
        private Guna2HtmlLabel lblBitis;
        private Guna2ComboBox cmbIlaclar;
        private Guna2NumericUpDown numDoz;
        private Guna2DateTimePicker dtpSaat;
        private Guna2DateTimePicker dtpBaslangic;
        private Guna2DateTimePicker dtpBitis;
        private Guna2Button btnIlacEkle;
        private Guna2Button btnIlacSil;


        /// <summary>
        /// Required method for Designer support
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblIlacAdi = new Guna2HtmlLabel();
            lblDoz = new Guna2HtmlLabel();
            lblSaat = new Guna2HtmlLabel();
            lblBaslangic = new Guna2HtmlLabel();
            lblBitis = new Guna2HtmlLabel();
            cmbIlaclar = new Guna2ComboBox();
            numDoz = new Guna2NumericUpDown();
            dtpSaat = new Guna2DateTimePicker();
            dtpBaslangic = new Guna2DateTimePicker();
            dtpBitis = new Guna2DateTimePicker();
            btnIlacEkle = new Guna2Button();
            btnIlacSil = new Guna2Button();
            dgvIlaclar = new Guna2DataGridView();
            ((ISupportInitialize)numDoz).BeginInit();
            ((ISupportInitialize)dgvIlaclar).BeginInit();
            SuspendLayout();
            // 
            // lblIlacAdi
            // 
            lblIlacAdi.BackColor = Color.Transparent;
            lblIlacAdi.Font = new Font("Segoe UI", 10F);
            lblIlacAdi.Location = new Point(30, 38);
            lblIlacAdi.Margin = new Padding(3, 4, 3, 4);
            lblIlacAdi.Name = "lblIlacAdi";
            lblIlacAdi.Size = new Size(63, 25);
            lblIlacAdi.TabIndex = 0;
            lblIlacAdi.Text = "İlaç Adı:";
            // 
            // lblDoz
            // 
            lblDoz.BackColor = Color.Transparent;
            lblDoz.Font = new Font("Segoe UI", 10F);
            lblDoz.Location = new Point(30, 100);
            lblDoz.Margin = new Padding(3, 4, 3, 4);
            lblDoz.Name = "lblDoz";
            lblDoz.Size = new Size(37, 25);
            lblDoz.TabIndex = 1;
            lblDoz.Text = "Doz:";
            // 
            // lblSaat
            // 
            lblSaat.BackColor = Color.Transparent;
            lblSaat.Font = new Font("Segoe UI", 10F);
            lblSaat.Location = new Point(30, 162);
            lblSaat.Margin = new Padding(3, 4, 3, 4);
            lblSaat.Name = "lblSaat";
            lblSaat.Size = new Size(88, 25);
            lblSaat.TabIndex = 2;
            lblSaat.Text = "Alma Saati:";
            // 
            // lblBaslangic
            // 
            lblBaslangic.BackColor = Color.Transparent;
            lblBaslangic.Font = new Font("Segoe UI", 10F);
            lblBaslangic.Location = new Point(30, 225);
            lblBaslangic.Margin = new Padding(3, 4, 3, 4);
            lblBaslangic.Name = "lblBaslangic";
            lblBaslangic.Size = new Size(125, 25);
            lblBaslangic.TabIndex = 3;
            lblBaslangic.Text = "Başlangıç Tarihi:";
            // 
            // lblBitis
            // 
            lblBitis.BackColor = Color.Transparent;
            lblBitis.Font = new Font("Segoe UI", 10F);
            lblBitis.Location = new Point(30, 288);
            lblBitis.Margin = new Padding(3, 4, 3, 4);
            lblBitis.Name = "lblBitis";
            lblBitis.Size = new Size(85, 25);
            lblBitis.TabIndex = 4;
            lblBitis.Text = "Bitiş Tarihi:";
            // 
            // cmbIlaclar
            // 
            cmbIlaclar.BackColor = Color.Transparent;
            cmbIlaclar.BorderRadius = 10;
            cmbIlaclar.CustomizableEdges = customizableEdges1;
            cmbIlaclar.DrawMode = DrawMode.OwnerDrawFixed;
            cmbIlaclar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlaclar.FocusedColor = Color.Empty;
            cmbIlaclar.Font = new Font("Segoe UI", 10F);
            cmbIlaclar.ForeColor = Color.FromArgb(68, 88, 112);
            cmbIlaclar.ItemHeight = 30;
            cmbIlaclar.Location = new Point(180, 31);
            cmbIlaclar.Margin = new Padding(3, 4, 3, 4);
            cmbIlaclar.Name = "cmbIlaclar";
            cmbIlaclar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbIlaclar.Size = new Size(260, 36);
            cmbIlaclar.TabIndex = 5;
            // 
            // numDoz
            // 
            numDoz.BackColor = Color.Transparent;
            numDoz.BorderRadius = 10;
            numDoz.CustomizableEdges = customizableEdges3;
            numDoz.Font = new Font("Segoe UI", 10F);
            numDoz.Increment = new decimal(new int[] { 50, 0, 0, 0 });
            numDoz.Location = new Point(180, 94);
            numDoz.Margin = new Padding(3, 5, 3, 5);
            numDoz.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numDoz.Name = "numDoz";
            numDoz.ShadowDecoration.CustomizableEdges = customizableEdges4;
            numDoz.Size = new Size(260, 45);
            numDoz.TabIndex = 6;
            numDoz.UpDownButtonFillColor = Color.FromArgb(74, 105, 189);
            // 
            // dtpSaat
            // 
            dtpSaat.BorderRadius = 10;
            dtpSaat.Checked = true;
            dtpSaat.CustomFormat = "HH:mm";
            dtpSaat.CustomizableEdges = customizableEdges5;
            dtpSaat.Font = new Font("Segoe UI", 10F);
            dtpSaat.Format = DateTimePickerFormat.Custom;
            dtpSaat.Location = new Point(180, 156);
            dtpSaat.Margin = new Padding(3, 4, 3, 4);
            dtpSaat.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpSaat.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpSaat.Name = "dtpSaat";
            dtpSaat.ShadowDecoration.CustomizableEdges = customizableEdges6;
            dtpSaat.ShowUpDown = true;
            dtpSaat.Size = new Size(260, 45);
            dtpSaat.TabIndex = 7;
            dtpSaat.TabStop = false;
            dtpSaat.Value = new DateTime(2025, 5, 26, 11, 22, 49, 962);
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.BorderRadius = 10;
            dtpBaslangic.Checked = true;
            dtpBaslangic.CustomizableEdges = customizableEdges7;
            dtpBaslangic.Font = new Font("Segoe UI", 10F);
            dtpBaslangic.Format = DateTimePickerFormat.Long;
            dtpBaslangic.Location = new Point(180, 219);
            dtpBaslangic.Margin = new Padding(3, 4, 3, 4);
            dtpBaslangic.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBaslangic.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.ShadowDecoration.CustomizableEdges = customizableEdges8;
            dtpBaslangic.Size = new Size(260, 45);
            dtpBaslangic.TabIndex = 8;
            dtpBaslangic.Value = new DateTime(2025, 5, 26, 11, 22, 49, 975);
            // 
            // dtpBitis
            // 
            dtpBitis.BorderRadius = 10;
            dtpBitis.Checked = true;
            dtpBitis.CustomizableEdges = customizableEdges9;
            dtpBitis.Font = new Font("Segoe UI", 10F);
            dtpBitis.Format = DateTimePickerFormat.Long;
            dtpBitis.Location = new Point(180, 281);
            dtpBitis.Margin = new Padding(3, 4, 3, 4);
            dtpBitis.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpBitis.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.ShadowDecoration.CustomizableEdges = customizableEdges10;
            dtpBitis.Size = new Size(260, 45);
            dtpBitis.TabIndex = 9;
            dtpBitis.Value = new DateTime(2025, 5, 26, 11, 22, 49, 997);
            // 
            // btnIlacEkle
            // 
            btnIlacEkle.BorderRadius = 15;
            btnIlacEkle.CustomizableEdges = customizableEdges11;
            btnIlacEkle.FillColor = Color.FromArgb(72, 219, 251);
            btnIlacEkle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIlacEkle.ForeColor = Color.White;
            btnIlacEkle.Location = new Point(180, 362);
            btnIlacEkle.Margin = new Padding(3, 4, 3, 4);
            btnIlacEkle.Name = "btnIlacEkle";
            btnIlacEkle.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnIlacEkle.Size = new Size(120, 50);
            btnIlacEkle.TabIndex = 10;
            btnIlacEkle.Text = "İlaç Ekle";
            btnIlacEkle.Click += btnIlacEkle_Click;
            // 
            // btnIlacSil
            // 
            btnIlacSil.BorderRadius = 15;
            btnIlacSil.CustomizableEdges = customizableEdges13;
            btnIlacSil.FillColor = Color.FromArgb(255, 107, 107);
            btnIlacSil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIlacSil.ForeColor = Color.White;
            btnIlacSil.Location = new Point(320, 362);
            btnIlacSil.Margin = new Padding(3, 4, 3, 4);
            btnIlacSil.Name = "btnIlacSil";
            btnIlacSil.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnIlacSil.Size = new Size(120, 50);
            btnIlacSil.TabIndex = 11;
            btnIlacSil.Text = "İlaç Sil";
            btnIlacSil.Click += btnIlacSil_Click;
            // 
            // dgvIlaclar
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvIlaclar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvIlaclar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvIlaclar.ColumnHeadersHeight = 4;
            dgvIlaclar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvIlaclar.DefaultCellStyle = dataGridViewCellStyle3;
            dgvIlaclar.GridColor = Color.FromArgb(231, 229, 255);
            dgvIlaclar.Location = new Point(488, 38);
            dgvIlaclar.Name = "dgvIlaclar";
            dgvIlaclar.RowHeadersVisible = false;
            dgvIlaclar.RowHeadersWidth = 51;
            dgvIlaclar.Size = new Size(564, 374);
            dgvIlaclar.TabIndex = 13;
            dgvIlaclar.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvIlaclar.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvIlaclar.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvIlaclar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvIlaclar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvIlaclar.ThemeStyle.BackColor = Color.White;
            dgvIlaclar.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvIlaclar.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvIlaclar.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvIlaclar.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvIlaclar.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvIlaclar.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvIlaclar.ThemeStyle.HeaderStyle.Height = 4;
            dgvIlaclar.ThemeStyle.ReadOnly = false;
            dgvIlaclar.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvIlaclar.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvIlaclar.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvIlaclar.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvIlaclar.ThemeStyle.RowsStyle.Height = 29;
            dgvIlaclar.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvIlaclar.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvIlaclar.CellContentClick += dgvIlaclar_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 456);
            Controls.Add(dgvIlaclar);
            Controls.Add(lblIlacAdi);
            Controls.Add(lblDoz);
            Controls.Add(lblSaat);
            Controls.Add(lblBaslangic);
            Controls.Add(lblBitis);
            Controls.Add(cmbIlaclar);
            Controls.Add(numDoz);
            Controls.Add(dtpSaat);
            Controls.Add(dtpBaslangic);
            Controls.Add(dtpBitis);
            Controls.Add(btnIlacEkle);
            Controls.Add(btnIlacSil);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Load += Form1_Load_1;
            ((ISupportInitialize)numDoz).EndInit();
            ((ISupportInitialize)dgvIlaclar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Guna2ToggleSwitch guna2ToggleSwitch1;
        private Guna2DataGridView dgvIlaclar;
    }
}
