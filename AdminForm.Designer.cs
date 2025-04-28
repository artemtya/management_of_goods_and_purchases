namespace Kalimov_curs
{
    partial class AdminForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminForm));
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.Production = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDedline = new System.Windows.Forms.Label();
            this.DtpStartProduction = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.DtpEndProduction = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.BtnAddProduction = new Guna.UI2.WinForms.Guna2Button();
            this.BtnDeleteProduction = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEditProduction = new Guna.UI2.WinForms.Guna2Button();
            this.BtnCleanProduction = new Guna.UI2.WinForms.Guna2Button();
            this.comboStatusProduction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboStageProduction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.comboProductProduction = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridViewProduction = new System.Windows.Forms.DataGridView();
            this.Product = new System.Windows.Forms.TabPage();
            this.BtnFilterProduct = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ComboSuppliersProduct = new Guna.UI2.WinForms.Guna2ComboBox();
            this.BtnCleanProduct = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEditProduct = new Guna.UI2.WinForms.Guna2Button();
            this.BtnDeleteProduct = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAddProduct = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbNameProducts = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbPriceProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbQuantityProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbMinProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.Purchases = new System.Windows.Forms.TabPage();
            this.BtnCleanPurchases = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEditPurcahses = new Guna.UI2.WinForms.Guna2Button();
            this.BtnDeletePurchases = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAddPurchases = new Guna.UI2.WinForms.Guna2Button();
            this.TbPricePurchases = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbQauntityPurchases = new Guna.UI2.WinForms.Guna2TextBox();
            this.ComboProductPurchases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboContractPurchases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.ComboSupplierPurchases = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dataGridViewPurchases = new System.Windows.Forms.DataGridView();
            this.Supplier = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnCleanSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.BtnAddSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.BtnEditSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.BtnDeleteSupplier = new Guna.UI2.WinForms.Guna2Button();
            this.DtpStartSuppliers = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.DtpEndSuppliers = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.ComboContractSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TbAddressSupplier = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbPhoneSupplier = new Guna.UI2.WinForms.Guna2TextBox();
            this.TbNameSupplier = new Guna.UI2.WinForms.Guna2TextBox();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.guna2TabControl1.SuspendLayout();
            this.Production.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduction)).BeginInit();
            this.Product.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.Purchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).BeginInit();
            this.Supplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.Production);
            this.guna2TabControl1.Controls.Add(this.Product);
            this.guna2TabControl1.Controls.Add(this.Purchases);
            this.guna2TabControl1.Controls.Add(this.Supplier);
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(4, 1);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(882, 581);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(180, 40);
            this.guna2TabControl1.TabIndex = 0;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
           
            // Production
            // 
            this.Production.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.Production.Controls.Add(this.label2);
            this.Production.Controls.Add(this.label1);
            this.Production.Controls.Add(this.lblDedline);
            this.Production.Controls.Add(this.DtpStartProduction);
            this.Production.Controls.Add(this.DtpEndProduction);
            this.Production.Controls.Add(this.BtnAddProduction);
            this.Production.Controls.Add(this.BtnDeleteProduction);
            this.Production.Controls.Add(this.BtnEditProduction);
            this.Production.Controls.Add(this.BtnCleanProduction);
            this.Production.Controls.Add(this.comboStatusProduction);
            this.Production.Controls.Add(this.comboStageProduction);
            this.Production.Controls.Add(this.comboProductProduction);
            this.Production.Controls.Add(this.dataGridViewProduction);
            this.Production.Location = new System.Drawing.Point(184, 4);
            this.Production.Name = "Production";
            this.Production.Padding = new System.Windows.Forms.Padding(3);
            this.Production.Size = new System.Drawing.Size(694, 573);
            this.Production.TabIndex = 0;
            this.Production.Text = "Производство";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.label2.Location = new System.Drawing.Point(448, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 54);
            this.label2.TabIndex = 41;
            this.label2.Text = "Запланированная дата\r\nокончания этапа";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.label1.Location = new System.Drawing.Point(456, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 54);
            this.label1.TabIndex = 40;
            this.label1.Text = "Дата начала \r\nэтапа производства";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDedline
            // 
            this.lblDedline.AutoSize = true;
            this.lblDedline.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDedline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.lblDedline.Location = new System.Drawing.Point(7, 246);
            this.lblDedline.Name = "lblDedline";
            this.lblDedline.Size = new System.Drawing.Size(527, 27);
            this.lblDedline.TabIndex = 39;
            this.lblDedline.Text = "Вы не имеете просроченных этапов на производстве!";

            // 
            // DtpStartProduction
            // 
            this.DtpStartProduction.BorderRadius = 10;
            this.DtpStartProduction.Checked = true;
            this.DtpStartProduction.FillColor = System.Drawing.Color.PaleTurquoise;
            this.DtpStartProduction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DtpStartProduction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.DtpStartProduction.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DtpStartProduction.Location = new System.Drawing.Point(453, 350);
            this.DtpStartProduction.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpStartProduction.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpStartProduction.Name = "DtpStartProduction";
            this.DtpStartProduction.Size = new System.Drawing.Size(205, 60);
            this.DtpStartProduction.TabIndex = 38;
            this.DtpStartProduction.Value = new System.DateTime(2025, 4, 5, 17, 37, 35, 115);
          
            // DtpEndProduction
            // 
            this.DtpEndProduction.BorderRadius = 10;
            this.DtpEndProduction.Checked = true;
            this.DtpEndProduction.FillColor = System.Drawing.Color.PaleTurquoise;
            this.DtpEndProduction.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DtpEndProduction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.DtpEndProduction.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DtpEndProduction.Location = new System.Drawing.Point(453, 483);
            this.DtpEndProduction.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpEndProduction.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpEndProduction.Name = "DtpEndProduction";
            this.DtpEndProduction.Size = new System.Drawing.Size(205, 60);
            this.DtpEndProduction.TabIndex = 37;
            this.DtpEndProduction.Value = new System.DateTime(2025, 4, 5, 17, 37, 35, 115);

            // 
            // BtnAddProduction
            // 
            this.BtnAddProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnAddProduction.BorderRadius = 15;
            this.BtnAddProduction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddProduction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddProduction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAddProduction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAddProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnAddProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAddProduction.Location = new System.Drawing.Point(4, 436);
            this.BtnAddProduction.Name = "BtnAddProduction";
            this.BtnAddProduction.Size = new System.Drawing.Size(215, 61);
            this.BtnAddProduction.TabIndex = 36;
            this.BtnAddProduction.Text = "Добавить";
            this.BtnAddProduction.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // BtnDeleteProduction
            // 
            this.BtnDeleteProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnDeleteProduction.BorderRadius = 15;
            this.BtnDeleteProduction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteProduction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteProduction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDeleteProduction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDeleteProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnDeleteProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnDeleteProduction.Location = new System.Drawing.Point(4, 503);
            this.BtnDeleteProduction.Name = "BtnDeleteProduction";
            this.BtnDeleteProduction.Size = new System.Drawing.Size(215, 61);
            this.BtnDeleteProduction.TabIndex = 35;
            this.BtnDeleteProduction.Text = "Удалить";
            this.BtnDeleteProduction.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // BtnEditProduction
            // 
            this.BtnEditProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnEditProduction.BorderRadius = 15;
            this.BtnEditProduction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditProduction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditProduction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEditProduction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEditProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnEditProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnEditProduction.Location = new System.Drawing.Point(232, 436);
            this.BtnEditProduction.Name = "BtnEditProduction";
            this.BtnEditProduction.Size = new System.Drawing.Size(215, 61);
            this.BtnEditProduction.TabIndex = 34;
            this.BtnEditProduction.Text = "Редактировать";
            this.BtnEditProduction.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // BtnCleanProduction
            // 
            this.BtnCleanProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnCleanProduction.BorderRadius = 15;
            this.BtnCleanProduction.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanProduction.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanProduction.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCleanProduction.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCleanProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnCleanProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCleanProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnCleanProduction.Location = new System.Drawing.Point(232, 503);
            this.BtnCleanProduction.Name = "BtnCleanProduction";
            this.BtnCleanProduction.Size = new System.Drawing.Size(215, 61);
            this.BtnCleanProduction.TabIndex = 33;
            this.BtnCleanProduction.Text = "Очистить заполненные поля";
            this.BtnCleanProduction.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // comboStatusProduction
            // 
            this.comboStatusProduction.BackColor = System.Drawing.Color.Transparent;
            this.comboStatusProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboStatusProduction.BorderRadius = 15;
            this.comboStatusProduction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStatusProduction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatusProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboStatusProduction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboStatusProduction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboStatusProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatusProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.comboStatusProduction.ItemHeight = 30;
            this.comboStatusProduction.Location = new System.Drawing.Point(7, 385);
            this.comboStatusProduction.Name = "comboStatusProduction";
            this.comboStatusProduction.Size = new System.Drawing.Size(440, 36);
            this.comboStatusProduction.TabIndex = 32;
        
            // 
            // comboStageProduction
            // 
            this.comboStageProduction.BackColor = System.Drawing.Color.Transparent;
            this.comboStageProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboStageProduction.BorderRadius = 15;
            this.comboStageProduction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboStageProduction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStageProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboStageProduction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboStageProduction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboStageProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStageProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.comboStageProduction.ItemHeight = 30;
            this.comboStageProduction.Location = new System.Drawing.Point(7, 333);
            this.comboStageProduction.Name = "comboStageProduction";
            this.comboStageProduction.Size = new System.Drawing.Size(440, 36);
            this.comboStageProduction.TabIndex = 31;
           
            // 
            // comboProductProduction
            // 
            this.comboProductProduction.BackColor = System.Drawing.Color.Transparent;
            this.comboProductProduction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboProductProduction.BorderRadius = 15;
            this.comboProductProduction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboProductProduction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProductProduction.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.comboProductProduction.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProductProduction.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboProductProduction.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProductProduction.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.comboProductProduction.ItemHeight = 30;
            this.comboProductProduction.Location = new System.Drawing.Point(4, 276);
            this.comboProductProduction.Name = "comboProductProduction";
            this.comboProductProduction.Size = new System.Drawing.Size(440, 36);
            this.comboProductProduction.TabIndex = 30;
            
            // 
            // dataGridViewProduction
            // 
            this.dataGridViewProduction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProduction.Location = new System.Drawing.Point(7, 3);
            this.dataGridViewProduction.Name = "dataGridViewProduction";
            this.dataGridViewProduction.RowHeadersWidth = 51;
            this.dataGridViewProduction.Size = new System.Drawing.Size(666, 240);
            this.dataGridViewProduction.TabIndex = 1;
            
            // 
            // Product
            // 
            this.Product.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.Product.Controls.Add(this.BtnFilterProduct);
            this.Product.Controls.Add(this.label3);
            this.Product.Controls.Add(this.ComboSuppliersProduct);
            this.Product.Controls.Add(this.BtnCleanProduct);
            this.Product.Controls.Add(this.BtnEditProduct);
            this.Product.Controls.Add(this.BtnDeleteProduct);
            this.Product.Controls.Add(this.BtnAddProduct);
            this.Product.Controls.Add(this.txtSearch);
            this.Product.Controls.Add(this.TbNameProducts);
            this.Product.Controls.Add(this.TbPriceProduct);
            this.Product.Controls.Add(this.TbQuantityProduct);
            this.Product.Controls.Add(this.TbMinProduct);
            this.Product.Controls.Add(this.dataGridViewProducts);
            this.Product.Location = new System.Drawing.Point(184, 4);
            this.Product.Name = "Product";
            this.Product.Padding = new System.Windows.Forms.Padding(3);
            this.Product.Size = new System.Drawing.Size(694, 573);
            this.Product.TabIndex = 1;
            this.Product.Text = "Товары";

            // 
            // BtnFilterProduct
            // 
            this.BtnFilterProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnFilterProduct.BorderRadius = 15;
            this.BtnFilterProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnFilterProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnFilterProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnFilterProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnFilterProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnFilterProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFilterProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnFilterProduct.Location = new System.Drawing.Point(338, 492);
            this.BtnFilterProduct.Name = "BtnFilterProduct";
            this.BtnFilterProduct.Size = new System.Drawing.Size(288, 55);
            this.BtnFilterProduct.TabIndex = 39;
            this.BtnFilterProduct.Text = "Фильтровать товары";
            this.BtnFilterProduct.Click += new System.EventHandler(this.BtnFilterProduct_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.label3.Location = new System.Drawing.Point(318, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(325, 27);
            this.label3.TabIndex = 38;
            this.label3.Text = "Фильтровать данные для поиска";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboSuppliersProduct
            // 
            this.ComboSuppliersProduct.BackColor = System.Drawing.Color.Transparent;
            this.ComboSuppliersProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboSuppliersProduct.BorderRadius = 15;
            this.ComboSuppliersProduct.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboSuppliersProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSuppliersProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboSuppliersProduct.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSuppliersProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSuppliersProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSuppliersProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.ComboSuppliersProduct.ItemHeight = 30;
            this.ComboSuppliersProduct.Location = new System.Drawing.Point(268, 329);
            this.ComboSuppliersProduct.Name = "ComboSuppliersProduct";
            this.ComboSuppliersProduct.Size = new System.Drawing.Size(405, 36);
            this.ComboSuppliersProduct.TabIndex = 37;
            // 
            // BtnCleanProduct
            // 
            this.BtnCleanProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnCleanProduct.BorderRadius = 15;
            this.BtnCleanProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCleanProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCleanProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnCleanProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCleanProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnCleanProduct.Location = new System.Drawing.Point(6, 497);
            this.BtnCleanProduct.Name = "BtnCleanProduct";
            this.BtnCleanProduct.Size = new System.Drawing.Size(256, 70);
            this.BtnCleanProduct.TabIndex = 32;
            this.BtnCleanProduct.Text = "Очистить заполненные поля";
            this.BtnCleanProduct.Click += new System.EventHandler(this.guna2Button6_Click);
            // 
            // BtnEditProduct
            // 
            this.BtnEditProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnEditProduct.BorderRadius = 15;
            this.BtnEditProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEditProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEditProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnEditProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnEditProduct.Location = new System.Drawing.Point(6, 441);
            this.BtnEditProduct.Name = "BtnEditProduct";
            this.BtnEditProduct.Size = new System.Drawing.Size(256, 50);
            this.BtnEditProduct.TabIndex = 31;
            this.BtnEditProduct.Text = "Редактировать товар";
            this.BtnEditProduct.Click += new System.EventHandler(this.BtnEditProduct_Click);
            // 
            // BtnDeleteProduct
            // 
            this.BtnDeleteProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnDeleteProduct.BorderRadius = 15;
            this.BtnDeleteProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDeleteProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDeleteProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnDeleteProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnDeleteProduct.Location = new System.Drawing.Point(7, 385);
            this.BtnDeleteProduct.Name = "BtnDeleteProduct";
            this.BtnDeleteProduct.Size = new System.Drawing.Size(256, 50);
            this.BtnDeleteProduct.TabIndex = 30;
            this.BtnDeleteProduct.Text = "Удалить товар";
            this.BtnDeleteProduct.Click += new System.EventHandler(this.BtnDeleteProduct_Click);
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnAddProduct.BorderRadius = 15;
            this.BtnAddProduct.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddProduct.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAddProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAddProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnAddProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAddProduct.Location = new System.Drawing.Point(6, 329);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(256, 50);
            this.BtnAddProduct.TabIndex = 29;
            this.BtnAddProduct.Text = "Добавить товар";
            this.BtnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Animated = true;
            this.txtSearch.AutoRoundedCorners = true;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.txtSearch.BorderRadius = 27;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.txtSearch.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Location = new System.Drawing.Point(338, 432);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.txtSearch.PlaceholderText = "Введите название товара";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(288, 56);
            this.txtSearch.TabIndex = 28;

            // 
            // TbNameProducts
            // 
            this.TbNameProducts.Animated = true;
            this.TbNameProducts.AutoRoundedCorners = true;
            this.TbNameProducts.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbNameProducts.BorderRadius = 27;
            this.TbNameProducts.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNameProducts.DefaultText = "";
            this.TbNameProducts.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbNameProducts.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbNameProducts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbNameProducts.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbNameProducts.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbNameProducts.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbNameProducts.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbNameProducts.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbNameProducts.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbNameProducts.Location = new System.Drawing.Point(7, 266);
            this.TbNameProducts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbNameProducts.Name = "TbNameProducts";
            this.TbNameProducts.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbNameProducts.PlaceholderText = "Название товара....";
            this.TbNameProducts.SelectedText = "";
            this.TbNameProducts.Size = new System.Drawing.Size(210, 56);
            this.TbNameProducts.TabIndex = 26;

            // 
            // TbPriceProduct
            // 
            this.TbPriceProduct.Animated = true;
            this.TbPriceProduct.AutoRoundedCorners = true;
            this.TbPriceProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbPriceProduct.BorderRadius = 27;
            this.TbPriceProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbPriceProduct.DefaultText = "";
            this.TbPriceProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbPriceProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbPriceProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPriceProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPriceProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbPriceProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPriceProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbPriceProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPriceProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPriceProduct.Location = new System.Drawing.Point(367, 266);
            this.TbPriceProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbPriceProduct.Name = "TbPriceProduct";
            this.TbPriceProduct.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPriceProduct.PlaceholderText = "Цена";
            this.TbPriceProduct.SelectedText = "";
            this.TbPriceProduct.Size = new System.Drawing.Size(84, 56);
            this.TbPriceProduct.TabIndex = 25;

            // 
            // TbQuantityProduct
            // 
            this.TbQuantityProduct.Animated = true;
            this.TbQuantityProduct.AutoRoundedCorners = true;
            this.TbQuantityProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbQuantityProduct.BorderRadius = 27;
            this.TbQuantityProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbQuantityProduct.DefaultText = "";
            this.TbQuantityProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbQuantityProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbQuantityProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbQuantityProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbQuantityProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbQuantityProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbQuantityProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbQuantityProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbQuantityProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbQuantityProduct.Location = new System.Drawing.Point(223, 266);
            this.TbQuantityProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbQuantityProduct.Name = "TbQuantityProduct";
            this.TbQuantityProduct.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbQuantityProduct.PlaceholderText = "Количество....";
            this.TbQuantityProduct.SelectedText = "";
            this.TbQuantityProduct.Size = new System.Drawing.Size(138, 56);
            this.TbQuantityProduct.TabIndex = 24;

            // 
            // TbMinProduct
            // 
            this.TbMinProduct.Animated = true;
            this.TbMinProduct.AutoRoundedCorners = true;
            this.TbMinProduct.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbMinProduct.BorderRadius = 27;
            this.TbMinProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbMinProduct.DefaultText = "";
            this.TbMinProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbMinProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbMinProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbMinProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbMinProduct.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbMinProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbMinProduct.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbMinProduct.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbMinProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbMinProduct.Location = new System.Drawing.Point(457, 266);
            this.TbMinProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbMinProduct.Name = "TbMinProduct";
            this.TbMinProduct.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbMinProduct.PlaceholderText = "Мин кол-во для закупок....";
            this.TbMinProduct.SelectedText = "";
            this.TbMinProduct.Size = new System.Drawing.Size(217, 56);
            this.TbMinProduct.TabIndex = 23;
       
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(7, 6);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.RowHeadersWidth = 51;
            this.dataGridViewProducts.Size = new System.Drawing.Size(667, 253);
            this.dataGridViewProducts.TabIndex = 1;
           
            // 
            // Purchases
            // 
            this.Purchases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.Purchases.Controls.Add(this.BtnCleanPurchases);
            this.Purchases.Controls.Add(this.BtnEditPurcahses);
            this.Purchases.Controls.Add(this.BtnDeletePurchases);
            this.Purchases.Controls.Add(this.BtnAddPurchases);
            this.Purchases.Controls.Add(this.TbPricePurchases);
            this.Purchases.Controls.Add(this.TbQauntityPurchases);
            this.Purchases.Controls.Add(this.ComboProductPurchases);
            this.Purchases.Controls.Add(this.ComboContractPurchases);
            this.Purchases.Controls.Add(this.ComboSupplierPurchases);
            this.Purchases.Controls.Add(this.dataGridViewPurchases);
            this.Purchases.Location = new System.Drawing.Point(184, 4);
            this.Purchases.Name = "Purchases";
            this.Purchases.Padding = new System.Windows.Forms.Padding(3);
            this.Purchases.Size = new System.Drawing.Size(694, 573);
            this.Purchases.TabIndex = 2;
            this.Purchases.Text = "Закупки";

            // 
            // BtnCleanPurchases
            // 
            this.BtnCleanPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnCleanPurchases.BorderRadius = 15;
            this.BtnCleanPurchases.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanPurchases.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanPurchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCleanPurchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCleanPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnCleanPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCleanPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnCleanPurchases.Location = new System.Drawing.Point(319, 502);
            this.BtnCleanPurchases.Name = "BtnCleanPurchases";
            this.BtnCleanPurchases.Size = new System.Drawing.Size(352, 62);
            this.BtnCleanPurchases.TabIndex = 41;
            this.BtnCleanPurchases.Text = "Очистить заполненные поля";
            this.BtnCleanPurchases.Click += new System.EventHandler(this.BtnCleanPurchases_Click);
            // 
            // BtnEditPurcahses
            // 
            this.BtnEditPurcahses.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnEditPurcahses.BorderRadius = 15;
            this.BtnEditPurcahses.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditPurcahses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditPurcahses.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEditPurcahses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEditPurcahses.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnEditPurcahses.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditPurcahses.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnEditPurcahses.Location = new System.Drawing.Point(319, 418);
            this.BtnEditPurcahses.Name = "BtnEditPurcahses";
            this.BtnEditPurcahses.Size = new System.Drawing.Size(352, 62);
            this.BtnEditPurcahses.TabIndex = 40;
            this.BtnEditPurcahses.Text = "Редактировать";
            this.BtnEditPurcahses.Click += new System.EventHandler(this.BtnEditPurcahses_Click);
            // 
            // BtnDeletePurchases
            // 
            this.BtnDeletePurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnDeletePurchases.BorderRadius = 15;
            this.BtnDeletePurchases.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeletePurchases.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeletePurchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDeletePurchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDeletePurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnDeletePurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeletePurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnDeletePurchases.Location = new System.Drawing.Point(9, 502);
            this.BtnDeletePurchases.Name = "BtnDeletePurchases";
            this.BtnDeletePurchases.Size = new System.Drawing.Size(304, 62);
            this.BtnDeletePurchases.TabIndex = 39;
            this.BtnDeletePurchases.Text = "Удалить";
            this.BtnDeletePurchases.Click += new System.EventHandler(this.BtnDeletePurchases_Click);
            // 
            // BtnAddPurchases
            // 
            this.BtnAddPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnAddPurchases.BorderRadius = 15;
            this.BtnAddPurchases.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddPurchases.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddPurchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAddPurchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAddPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnAddPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAddPurchases.Location = new System.Drawing.Point(9, 418);
            this.BtnAddPurchases.Name = "BtnAddPurchases";
            this.BtnAddPurchases.Size = new System.Drawing.Size(304, 62);
            this.BtnAddPurchases.TabIndex = 38;
            this.BtnAddPurchases.Text = "Добавить ";
            this.BtnAddPurchases.Click += new System.EventHandler(this.BtnAddPurchases_Click);
            // 
            // TbPricePurchases
            // 
            this.TbPricePurchases.Animated = true;
            this.TbPricePurchases.AutoRoundedCorners = true;
            this.TbPricePurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbPricePurchases.BorderRadius = 26;
            this.TbPricePurchases.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbPricePurchases.DefaultText = "";
            this.TbPricePurchases.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbPricePurchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbPricePurchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPricePurchases.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPricePurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbPricePurchases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPricePurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbPricePurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPricePurchases.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPricePurchases.Location = new System.Drawing.Point(503, 347);
            this.TbPricePurchases.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbPricePurchases.Name = "TbPricePurchases";
            this.TbPricePurchases.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPricePurchases.PlaceholderText = "Введите цену";
            this.TbPricePurchases.SelectedText = "";
            this.TbPricePurchases.Size = new System.Drawing.Size(168, 55);
            this.TbPricePurchases.TabIndex = 37;
            // 
            // TbQauntityPurchases
            // 
            this.TbQauntityPurchases.Animated = true;
            this.TbQauntityPurchases.AutoRoundedCorners = true;
            this.TbQauntityPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbQauntityPurchases.BorderRadius = 26;
            this.TbQauntityPurchases.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbQauntityPurchases.DefaultText = "";
            this.TbQauntityPurchases.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbQauntityPurchases.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbQauntityPurchases.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbQauntityPurchases.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbQauntityPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbQauntityPurchases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbQauntityPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbQauntityPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbQauntityPurchases.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbQauntityPurchases.Location = new System.Drawing.Point(319, 347);
            this.TbQauntityPurchases.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbQauntityPurchases.Name = "TbQauntityPurchases";
            this.TbQauntityPurchases.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbQauntityPurchases.PlaceholderText = "Введите количество\r\n";
            this.TbQauntityPurchases.SelectedText = "";
            this.TbQauntityPurchases.Size = new System.Drawing.Size(178, 55);
            this.TbQauntityPurchases.TabIndex = 36;
            // 
            // ComboProductPurchases
            // 
            this.ComboProductPurchases.BackColor = System.Drawing.Color.Transparent;
            this.ComboProductPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboProductPurchases.BorderRadius = 15;
            this.ComboProductPurchases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboProductPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboProductPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboProductPurchases.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboProductPurchases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboProductPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboProductPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.ComboProductPurchases.ItemHeight = 30;
            this.ComboProductPurchases.Location = new System.Drawing.Point(319, 293);
            this.ComboProductPurchases.Name = "ComboProductPurchases";
            this.ComboProductPurchases.Size = new System.Drawing.Size(354, 36);
            this.ComboProductPurchases.TabIndex = 34;
            // 
            // ComboContractPurchases
            // 
            this.ComboContractPurchases.BackColor = System.Drawing.Color.Transparent;
            this.ComboContractPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboContractPurchases.BorderRadius = 15;
            this.ComboContractPurchases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboContractPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboContractPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboContractPurchases.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboContractPurchases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboContractPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboContractPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.ComboContractPurchases.ItemHeight = 30;
            this.ComboContractPurchases.Location = new System.Drawing.Point(6, 356);
            this.ComboContractPurchases.Name = "ComboContractPurchases";
            this.ComboContractPurchases.Size = new System.Drawing.Size(307, 36);
            this.ComboContractPurchases.TabIndex = 33;
            // 
            // ComboSupplierPurchases
            // 
            this.ComboSupplierPurchases.BackColor = System.Drawing.Color.Transparent;
            this.ComboSupplierPurchases.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboSupplierPurchases.BorderRadius = 15;
            this.ComboSupplierPurchases.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboSupplierPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboSupplierPurchases.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboSupplierPurchases.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSupplierPurchases.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboSupplierPurchases.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboSupplierPurchases.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.ComboSupplierPurchases.ItemHeight = 30;
            this.ComboSupplierPurchases.Location = new System.Drawing.Point(6, 293);
            this.ComboSupplierPurchases.Name = "ComboSupplierPurchases";
            this.ComboSupplierPurchases.Size = new System.Drawing.Size(307, 36);
            this.ComboSupplierPurchases.TabIndex = 32;
            // 
            // dataGridViewPurchases
            // 
            this.dataGridViewPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPurchases.Location = new System.Drawing.Point(6, 3);
            this.dataGridViewPurchases.Name = "dataGridViewPurchases";
            this.dataGridViewPurchases.RowHeadersWidth = 51;
            this.dataGridViewPurchases.Size = new System.Drawing.Size(665, 256);
            this.dataGridViewPurchases.TabIndex = 1;
            // 
            // Supplier
            // 
            this.Supplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.Supplier.Controls.Add(this.label5);
            this.Supplier.Controls.Add(this.label4);
            this.Supplier.Controls.Add(this.BtnCleanSupplier);
            this.Supplier.Controls.Add(this.BtnAddSupplier);
            this.Supplier.Controls.Add(this.BtnEditSupplier);
            this.Supplier.Controls.Add(this.BtnDeleteSupplier);
            this.Supplier.Controls.Add(this.DtpStartSuppliers);
            this.Supplier.Controls.Add(this.DtpEndSuppliers);
            this.Supplier.Controls.Add(this.ComboContractSupplier);
            this.Supplier.Controls.Add(this.TbAddressSupplier);
            this.Supplier.Controls.Add(this.TbPhoneSupplier);
            this.Supplier.Controls.Add(this.TbNameSupplier);
            this.Supplier.Controls.Add(this.dataGridViewSuppliers);
            this.Supplier.Location = new System.Drawing.Point(184, 4);
            this.Supplier.Name = "Supplier";
            this.Supplier.Padding = new System.Windows.Forms.Padding(3);
            this.Supplier.Size = new System.Drawing.Size(694, 573);
            this.Supplier.TabIndex = 3;
            this.Supplier.Text = "Поставщики";

            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.label5.Location = new System.Drawing.Point(415, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 21);
            this.label5.TabIndex = 51;
            this.label5.Text = "Конец сотрудничества";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.label4.Location = new System.Drawing.Point(42, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 21);
            this.label4.TabIndex = 50;
            this.label4.Text = "Начало сотрудничества";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCleanSupplier
            // 
            this.BtnCleanSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnCleanSupplier.BorderRadius = 15;
            this.BtnCleanSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnCleanSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnCleanSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnCleanSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnCleanSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCleanSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnCleanSupplier.Location = new System.Drawing.Point(363, 508);
            this.BtnCleanSupplier.Name = "BtnCleanSupplier";
            this.BtnCleanSupplier.Size = new System.Drawing.Size(264, 59);
            this.BtnCleanSupplier.TabIndex = 49;
            this.BtnCleanSupplier.Text = "Очистить заполненные поля";
            this.BtnCleanSupplier.Click += new System.EventHandler(this.BtnCleanSupplier_Click_1);
            // 
            // BtnAddSupplier
            // 
            this.BtnAddSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnAddSupplier.BorderRadius = 15;
            this.BtnAddSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAddSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAddSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAddSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnAddSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnAddSupplier.Location = new System.Drawing.Point(363, 394);
            this.BtnAddSupplier.Name = "BtnAddSupplier";
            this.BtnAddSupplier.Size = new System.Drawing.Size(129, 51);
            this.BtnAddSupplier.TabIndex = 48;
            this.BtnAddSupplier.Text = "Добавить";
            this.BtnAddSupplier.Click += new System.EventHandler(this.BtnAddSupplier_Click);
            // 
            // BtnEditSupplier
            // 
            this.BtnEditSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnEditSupplier.BorderRadius = 15;
            this.BtnEditSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnEditSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnEditSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnEditSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnEditSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnEditSupplier.Location = new System.Drawing.Point(363, 451);
            this.BtnEditSupplier.Name = "BtnEditSupplier";
            this.BtnEditSupplier.Size = new System.Drawing.Size(264, 51);
            this.BtnEditSupplier.TabIndex = 47;
            this.BtnEditSupplier.Text = "Редактировать ";
            this.BtnEditSupplier.Click += new System.EventHandler(this.BtnEditSupplier_Click);
            // 
            // BtnDeleteSupplier
            // 
            this.BtnDeleteSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.BtnDeleteSupplier.BorderRadius = 15;
            this.BtnDeleteSupplier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteSupplier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnDeleteSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnDeleteSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnDeleteSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.BtnDeleteSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDeleteSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.BtnDeleteSupplier.Location = new System.Drawing.Point(498, 394);
            this.BtnDeleteSupplier.Name = "BtnDeleteSupplier";
            this.BtnDeleteSupplier.Size = new System.Drawing.Size(129, 51);
            this.BtnDeleteSupplier.TabIndex = 46;
            this.BtnDeleteSupplier.Text = "Удалить";
            this.BtnDeleteSupplier.Click += new System.EventHandler(this.BtnDeleteSupplier_Click);
            // 
            // DtpStartSuppliers
            // 
            this.DtpStartSuppliers.BorderRadius = 10;
            this.DtpStartSuppliers.Checked = true;
            this.DtpStartSuppliers.FillColor = System.Drawing.Color.PaleTurquoise;
            this.DtpStartSuppliers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DtpStartSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.DtpStartSuppliers.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DtpStartSuppliers.Location = new System.Drawing.Point(15, 296);
            this.DtpStartSuppliers.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpStartSuppliers.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpStartSuppliers.Name = "DtpStartSuppliers";
            this.DtpStartSuppliers.Size = new System.Drawing.Size(259, 46);
            this.DtpStartSuppliers.TabIndex = 45;
            this.DtpStartSuppliers.Value = new System.DateTime(2025, 4, 5, 17, 37, 35, 115);
            // 
            // DtpEndSuppliers
            // 
            this.DtpEndSuppliers.BorderRadius = 10;
            this.DtpEndSuppliers.Checked = true;
            this.DtpEndSuppliers.FillColor = System.Drawing.Color.PaleTurquoise;
            this.DtpEndSuppliers.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DtpEndSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.DtpEndSuppliers.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.DtpEndSuppliers.Location = new System.Drawing.Point(368, 296);
            this.DtpEndSuppliers.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DtpEndSuppliers.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DtpEndSuppliers.Name = "DtpEndSuppliers";
            this.DtpEndSuppliers.Size = new System.Drawing.Size(259, 46);
            this.DtpEndSuppliers.TabIndex = 44;
            this.DtpEndSuppliers.Value = new System.DateTime(2025, 4, 5, 17, 37, 35, 115);
            // 
            // ComboContractSupplier
            // 
            this.ComboContractSupplier.BackColor = System.Drawing.Color.Transparent;
            this.ComboContractSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboContractSupplier.BorderRadius = 15;
            this.ComboContractSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ComboContractSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboContractSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.ComboContractSupplier.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboContractSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ComboContractSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboContractSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.ComboContractSupplier.ItemHeight = 30;
            this.ComboContractSupplier.Location = new System.Drawing.Point(359, 352);
            this.ComboContractSupplier.Name = "ComboContractSupplier";
            this.ComboContractSupplier.Size = new System.Drawing.Size(268, 36);
            this.ComboContractSupplier.TabIndex = 43;
            // 
            // TbAddressSupplier
            // 
            this.TbAddressSupplier.Animated = true;
            this.TbAddressSupplier.AutoRoundedCorners = true;
            this.TbAddressSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbAddressSupplier.BorderRadius = 28;
            this.TbAddressSupplier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbAddressSupplier.DefaultText = "";
            this.TbAddressSupplier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbAddressSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbAddressSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbAddressSupplier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbAddressSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbAddressSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbAddressSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbAddressSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbAddressSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbAddressSupplier.Location = new System.Drawing.Point(6, 504);
            this.TbAddressSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbAddressSupplier.Name = "TbAddressSupplier";
            this.TbAddressSupplier.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbAddressSupplier.PlaceholderText = "Введите адрес поставщика...";
            this.TbAddressSupplier.SelectedText = "";
            this.TbAddressSupplier.Size = new System.Drawing.Size(268, 59);
            this.TbAddressSupplier.TabIndex = 42;
            // 
            // TbPhoneSupplier
            // 
            this.TbPhoneSupplier.Animated = true;
            this.TbPhoneSupplier.AutoRoundedCorners = true;
            this.TbPhoneSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbPhoneSupplier.BorderRadius = 28;
            this.TbPhoneSupplier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbPhoneSupplier.DefaultText = "";
            this.TbPhoneSupplier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbPhoneSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbPhoneSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPhoneSupplier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbPhoneSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbPhoneSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPhoneSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbPhoneSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPhoneSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbPhoneSupplier.Location = new System.Drawing.Point(6, 439);
            this.TbPhoneSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbPhoneSupplier.Name = "TbPhoneSupplier";
            this.TbPhoneSupplier.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbPhoneSupplier.PlaceholderText = "Введите телефон поставщика...";
            this.TbPhoneSupplier.SelectedText = "";
            this.TbPhoneSupplier.Size = new System.Drawing.Size(268, 59);
            this.TbPhoneSupplier.TabIndex = 41;
            // 
            // TbNameSupplier
            // 
            this.TbNameSupplier.Animated = true;
            this.TbNameSupplier.AutoRoundedCorners = true;
            this.TbNameSupplier.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.TbNameSupplier.BorderRadius = 28;
            this.TbNameSupplier.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNameSupplier.DefaultText = "";
            this.TbNameSupplier.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TbNameSupplier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TbNameSupplier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbNameSupplier.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TbNameSupplier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.TbNameSupplier.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbNameSupplier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F);
            this.TbNameSupplier.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbNameSupplier.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TbNameSupplier.Location = new System.Drawing.Point(6, 372);
            this.TbNameSupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TbNameSupplier.Name = "TbNameSupplier";
            this.TbNameSupplier.PlaceholderForeColor = System.Drawing.Color.PaleTurquoise;
            this.TbNameSupplier.PlaceholderText = "Введите название поставщика...";
            this.TbNameSupplier.SelectedText = "";
            this.TbNameSupplier.Size = new System.Drawing.Size(268, 59);
            this.TbNameSupplier.TabIndex = 40;
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.RowHeadersWidth = 51;
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(685, 266);
            this.dataGridViewSuppliers.TabIndex = 1;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(163)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(890, 583);
            this.Controls.Add(this.guna2TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добро пожаловать!";
            this.guna2TabControl1.ResumeLayout(false);
            this.Production.ResumeLayout(false);
            this.Production.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProduction)).EndInit();
            this.Product.ResumeLayout(false);
            this.Product.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.Purchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPurchases)).EndInit();
            this.Supplier.ResumeLayout(false);
            this.Supplier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage Production;
        private System.Windows.Forms.TabPage Product;
        private System.Windows.Forms.TabPage Purchases;
        private System.Windows.Forms.DataGridView dataGridViewProduction;
        private Guna.UI2.WinForms.Guna2ComboBox comboStatusProduction;
        private Guna.UI2.WinForms.Guna2ComboBox comboStageProduction;
        private Guna.UI2.WinForms.Guna2ComboBox comboProductProduction;
        private Guna.UI2.WinForms.Guna2Button BtnAddProduction;
        private Guna.UI2.WinForms.Guna2Button BtnDeleteProduction;
        private Guna.UI2.WinForms.Guna2Button BtnEditProduction;
        private Guna.UI2.WinForms.Guna2Button BtnCleanProduction;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpStartProduction;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpEndProduction;
        private System.Windows.Forms.Label lblDedline;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage Supplier;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2TextBox TbNameProducts;
        private Guna.UI2.WinForms.Guna2TextBox TbPriceProduct;
        private Guna.UI2.WinForms.Guna2TextBox TbQuantityProduct;
        private Guna.UI2.WinForms.Guna2TextBox TbMinProduct;
        private Guna.UI2.WinForms.Guna2Button BtnCleanProduct;
        private Guna.UI2.WinForms.Guna2Button BtnEditProduct;
        private Guna.UI2.WinForms.Guna2Button BtnDeleteProduct;
        private Guna.UI2.WinForms.Guna2Button BtnAddProduct;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSuppliersProduct;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button BtnFilterProduct;
        private System.Windows.Forms.DataGridView dataGridViewPurchases;
        private Guna.UI2.WinForms.Guna2ComboBox ComboProductPurchases;
        private Guna.UI2.WinForms.Guna2ComboBox ComboContractPurchases;
        private Guna.UI2.WinForms.Guna2ComboBox ComboSupplierPurchases;
        private Guna.UI2.WinForms.Guna2TextBox TbPricePurchases;
        private Guna.UI2.WinForms.Guna2TextBox TbQauntityPurchases;
        private Guna.UI2.WinForms.Guna2Button BtnCleanPurchases;
        private Guna.UI2.WinForms.Guna2Button BtnEditPurcahses;
        private Guna.UI2.WinForms.Guna2Button BtnDeletePurchases;
        private Guna.UI2.WinForms.Guna2Button BtnAddPurchases;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private Guna.UI2.WinForms.Guna2TextBox TbAddressSupplier;
        private Guna.UI2.WinForms.Guna2TextBox TbPhoneSupplier;
        private Guna.UI2.WinForms.Guna2TextBox TbNameSupplier;
        private Guna.UI2.WinForms.Guna2ComboBox ComboContractSupplier;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpStartSuppliers;
        private Guna.UI2.WinForms.Guna2DateTimePicker DtpEndSuppliers;
        private Guna.UI2.WinForms.Guna2Button BtnCleanSupplier;
        private Guna.UI2.WinForms.Guna2Button BtnAddSupplier;
        private Guna.UI2.WinForms.Guna2Button BtnEditSupplier;
        private Guna.UI2.WinForms.Guna2Button BtnDeleteSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}