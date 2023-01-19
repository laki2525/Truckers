namespace Truckers.Forms
{
    partial class SearchForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbxSearchTruckResult = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.btnSearchTruck = new MetroFramework.Controls.MetroButton();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager();
            this.tbxSearchTruck = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbxSearchDeliveryResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.btnSearchDelivery = new MetroFramework.Controls.MetroButton();
            this.tbxSearchDelivery = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Controls.Add(this.tabPage2);
            this.metroTabControl1.CustomBackground = false;
            this.metroTabControl1.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            this.metroTabControl1.Location = new System.Drawing.Point(-1, 22);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.Padding = new System.Drawing.Point(6, 8);
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(648, 501);
            this.metroTabControl1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTabControl1.StyleManager = this.metroStyleManager1;
            this.metroTabControl1.TabIndex = 1;
            this.metroTabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.UseStyleColors = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage1.Controls.Add(this.lbxSearchTruckResult);
            this.tabPage1.Controls.Add(this.btnSearchTruck);
            this.tabPage1.Controls.Add(this.tbxSearchTruck);
            this.tabPage1.Controls.Add(this.metroLabel18);
            this.tabPage1.Location = new System.Drawing.Point(4, 35);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(640, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PRETRAGA KAMIONA";
            // 
            // lbxSearchTruckResult
            // 
            this.lbxSearchTruckResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lbxSearchTruckResult.FullRowSelect = true;
            this.lbxSearchTruckResult.GridLines = true;
            this.lbxSearchTruckResult.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lbxSearchTruckResult.Location = new System.Drawing.Point(20, 72);
            this.lbxSearchTruckResult.Name = "lbxSearchTruckResult";
            this.lbxSearchTruckResult.Size = new System.Drawing.Size(604, 375);
            this.lbxSearchTruckResult.TabIndex = 2;
            this.lbxSearchTruckResult.UseCompatibleStateImageBehavior = false;
            this.lbxSearchTruckResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "NAZIV";
            this.columnHeader4.Width = 190;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "GRAD U KOME SE NALAZI";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "DA LI NOSI POSILJKU?";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 200;
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.Highlight = false;
            this.btnSearchTruck.Location = new System.Drawing.Point(394, 20);
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(228, 29);
            this.btnSearchTruck.Style = MetroFramework.MetroColorStyle.Red;
            this.btnSearchTruck.StyleManager = this.metroStyleManager1;
            this.btnSearchTruck.TabIndex = 6;
            this.btnSearchTruck.Text = "PRETRAZI KAMIONE";
            this.btnSearchTruck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSearchTruck.Click += new System.EventHandler(this.btnSearchTruck_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tbxSearchTruck
            // 
            this.tbxSearchTruck.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.tbxSearchTruck.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.tbxSearchTruck.Location = new System.Drawing.Point(150, 20);
            this.tbxSearchTruck.Multiline = false;
            this.tbxSearchTruck.Name = "tbxSearchTruck";
            this.tbxSearchTruck.SelectedText = "";
            this.tbxSearchTruck.Size = new System.Drawing.Size(228, 29);
            this.tbxSearchTruck.Style = MetroFramework.MetroColorStyle.Red;
            this.tbxSearchTruck.StyleManager = this.metroStyleManager1;
            this.tbxSearchTruck.TabIndex = 5;
            this.tbxSearchTruck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbxSearchTruck.UseStyleColors = false;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.CustomBackground = false;
            this.metroLabel18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel18.Location = new System.Drawing.Point(20, 22);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(132, 25);
            this.metroLabel18.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel18.StyleManager = this.metroStyleManager1;
            this.metroLabel18.TabIndex = 4;
            this.metroLabel18.Text = "Naziv kamiona:";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel18.UseStyleColors = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.tabPage2.Controls.Add(this.lbxSearchDeliveryResult);
            this.tabPage2.Controls.Add(this.btnSearchDelivery);
            this.tabPage2.Controls.Add(this.tbxSearchDelivery);
            this.tabPage2.Controls.Add(this.metroLabel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 35);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(640, 462);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PRETRAGA POSILJKI";
            // 
            // lbxSearchDeliveryResult
            // 
            this.lbxSearchDeliveryResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader7});
            this.lbxSearchDeliveryResult.FullRowSelect = true;
            this.lbxSearchDeliveryResult.GridLines = true;
            this.lbxSearchDeliveryResult.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lbxSearchDeliveryResult.Location = new System.Drawing.Point(20, 72);
            this.lbxSearchDeliveryResult.Name = "lbxSearchDeliveryResult";
            this.lbxSearchDeliveryResult.Size = new System.Drawing.Size(604, 375);
            this.lbxSearchDeliveryResult.TabIndex = 11;
            this.lbxSearchDeliveryResult.UseCompatibleStateImageBehavior = false;
            this.lbxSearchDeliveryResult.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "NAZIV";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SADRZAJ";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "TRENUTNA LOKACIJA";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "STATUS";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // btnSearchDelivery
            // 
            this.btnSearchDelivery.Highlight = false;
            this.btnSearchDelivery.Location = new System.Drawing.Point(396, 20);
            this.btnSearchDelivery.Name = "btnSearchDelivery";
            this.btnSearchDelivery.Size = new System.Drawing.Size(228, 29);
            this.btnSearchDelivery.Style = MetroFramework.MetroColorStyle.Red;
            this.btnSearchDelivery.StyleManager = this.metroStyleManager1;
            this.btnSearchDelivery.TabIndex = 10;
            this.btnSearchDelivery.Text = "PRETRAZI POSILJKE";
            this.btnSearchDelivery.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSearchDelivery.Click += new System.EventHandler(this.btnSearchDelivery_Click);
            // 
            // tbxSearchDelivery
            // 
            this.tbxSearchDelivery.FontSize = MetroFramework.MetroTextBoxSize.Small;
            this.tbxSearchDelivery.FontWeight = MetroFramework.MetroTextBoxWeight.Regular;
            this.tbxSearchDelivery.Location = new System.Drawing.Point(150, 20);
            this.tbxSearchDelivery.Multiline = false;
            this.tbxSearchDelivery.Name = "tbxSearchDelivery";
            this.tbxSearchDelivery.SelectedText = "";
            this.tbxSearchDelivery.Size = new System.Drawing.Size(228, 29);
            this.tbxSearchDelivery.Style = MetroFramework.MetroColorStyle.Red;
            this.tbxSearchDelivery.StyleManager = this.metroStyleManager1;
            this.tbxSearchDelivery.TabIndex = 9;
            this.tbxSearchDelivery.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tbxSearchDelivery.UseStyleColors = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(20, 22);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(124, 25);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroLabel1.StyleManager = this.metroStyleManager1;
            this.metroLabel1.TabIndex = 8;
            this.metroLabel1.Text = "Naziv posiljke:";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.UseStyleColors = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 523);
            this.Controls.Add(this.metroTabControl1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.StyleManager = this.metroStyleManager1;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroTextBox tbxSearchTruck;
        private MetroFramework.Controls.MetroButton btnSearchDelivery;
        private MetroFramework.Controls.MetroTextBox tbxSearchDelivery;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnSearchTruck;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private ListView lbxSearchTruckResult;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ListView lbxSearchDeliveryResult;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader7;
    }
}