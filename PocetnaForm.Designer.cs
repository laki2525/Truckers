namespace Truckers
{
    partial class PocetnaForm
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager();
            this.btnAddDelete = new MetroFramework.Controls.MetroButton();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.btnManage = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.OwnerForm = this;
            this.metroStyleManager1.Style = MetroFramework.MetroColorStyle.Red;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnAddDelete
            // 
            this.btnAddDelete.Highlight = false;
            this.btnAddDelete.Location = new System.Drawing.Point(141, 241);
            this.btnAddDelete.Name = "btnAddDelete";
            this.btnAddDelete.Size = new System.Drawing.Size(168, 42);
            this.btnAddDelete.Style = MetroFramework.MetroColorStyle.Red;
            this.btnAddDelete.StyleManager = this.metroStyleManager1;
            this.btnAddDelete.TabIndex = 0;
            this.btnAddDelete.Text = "DODAJ/OBRISI";
            this.btnAddDelete.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnAddDelete.Click += new System.EventHandler(this.btnAddDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Highlight = false;
            this.btnSearch.Location = new System.Drawing.Point(141, 289);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(168, 42);
            this.btnSearch.Style = MetroFramework.MetroColorStyle.Red;
            this.btnSearch.StyleManager = this.metroStyleManager1;
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "PRETRAGA";
            this.btnSearch.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnManage
            // 
            this.btnManage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnManage.Highlight = false;
            this.btnManage.Location = new System.Drawing.Point(141, 337);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(168, 42);
            this.btnManage.Style = MetroFramework.MetroColorStyle.Red;
            this.btnManage.StyleManager = this.metroStyleManager1;
            this.btnManage.TabIndex = 2;
            this.btnManage.Text = "UPRAVLJANJE";
            this.btnManage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // PocetnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 450);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddDelete);
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "PocetnaForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.StyleManager = this.metroStyleManager1;
            this.Text = "TRUCKERS";
            this.TextAlign = MetroFramework.Forms.TextAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton btnManage;
        private MetroFramework.Controls.MetroButton btnSearch;
        private MetroFramework.Controls.MetroButton btnAddDelete;
    }
}