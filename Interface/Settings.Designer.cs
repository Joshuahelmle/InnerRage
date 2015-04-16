using InnerRage;
using System.ComponentModel;
using System.Windows.Forms;

namespace InnerRage.Interface {
	partial class Settings {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components=null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing&&( components!=null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.FormHeader = new System.Windows.Forms.Label();
            this.FormHeaderClose = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.tooltipHandler = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.vt = new InnerRage.Interface.VerticalTabs();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtfAbout = new System.Windows.Forms.RichTextBox();
            this.saveBTN = new System.Windows.Forms.Button();
            this.loadBTN = new System.Windows.Forms.Button();
            this.useSettingsBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.RallyingCryHP = new System.Windows.Forms.TextBox();
            this.DBTSHP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.RallyingCryCB = new System.Windows.Forms.CheckBox();
            this.DieByTheSwordCB = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.BerserkerBreakFearCB = new System.Windows.Forms.CheckBox();
            this.Racials = new System.Windows.Forms.GroupBox();
            this.RacialBloodElfCB = new System.Windows.Forms.CheckBox();
            this.RacialHumanCB = new System.Windows.Forms.CheckBox();
            this.RacialTrollCB = new System.Windows.Forms.CheckBox();
            this.RacialOrcCB = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LoCDelay = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.InterruptDelay = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Trinket2BurstCb = new System.Windows.Forms.CheckBox();
            this.Trinket2LoCCB = new System.Windows.Forms.CheckBox();
            this.Trinket2CB = new System.Windows.Forms.CheckBox();
            this.Trinket1BurstCB = new System.Windows.Forms.CheckBox();
            this.Trinket1LoCCB = new System.Windows.Forms.CheckBox();
            this.Trinket1CB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.InterruptStormBoltCB = new System.Windows.Forms.CheckBox();
            this.InterruptShockWaveCB = new System.Windows.Forms.CheckBox();
            this.InterruptPummelCB = new System.Windows.Forms.CheckBox();
            this.Buffs = new System.Windows.Forms.GroupBox();
            this.checkBuffs = new System.Windows.Forms.CheckBox();
            this.BuffComboBox = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EnragedRegenerationCB = new System.Windows.Forms.CheckBox();
            this.TalentRavagerCB = new System.Windows.Forms.CheckBox();
            this.TalentBladeStormCB = new System.Windows.Forms.CheckBox();
            this.TalentAvatarCB = new System.Windows.Forms.CheckBox();
            this.TalentDragonRoarCB = new System.Windows.Forms.CheckBox();
            this.TalentShockWaveCB = new System.Windows.Forms.CheckBox();
            this.TalentStormBoltCB = new System.Windows.Forms.CheckBox();
            this.TalentsBloodBathCB = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.DragonRoarAoECount = new System.Windows.Forms.TextBox();
            this.DragonRoarAoECountCB = new System.Windows.Forms.CheckBox();
            this.DragonRoarOnlyOnBossCB = new System.Windows.Forms.CheckBox();
            this.TalentSyncDragonRoar = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RecklessnessOnlyOnBossCB = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TrinketAura = new System.Windows.Forms.TextBox();
            this.TalentsRecklessnessCondition = new System.Windows.Forms.ComboBox();
            this.TalentSyncAvatar = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TalentsBloodBathCondition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.BladestormAoECount = new System.Windows.Forms.TextBox();
            this.BladestormOnlyAoECountCB = new System.Windows.Forms.CheckBox();
            this.BladestormOnlyBossCB = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.RavagerAoeCount = new System.Windows.Forms.TextBox();
            this.RavagerOnlyAoECountCB = new System.Windows.Forms.CheckBox();
            this.RavagerOnlyBossCB = new System.Windows.Forms.CheckBox();
            this.TalentSyncRavager = new System.Windows.Forms.CheckBox();
            this.vt.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.Racials.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Buffs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormHeader
            // 
            this.FormHeader.BackColor = System.Drawing.Color.Firebrick;
            this.FormHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormHeader.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormHeader.ForeColor = System.Drawing.Color.White;
            this.FormHeader.Location = new System.Drawing.Point(0, 0);
            this.FormHeader.Name = "FormHeader";
            this.FormHeader.Size = new System.Drawing.Size(1030, 30);
            this.FormHeader.TabIndex = 0;
            this.FormHeader.Text = "InnerRage Settings";
            this.FormHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormHeaderClose
            // 
            this.FormHeaderClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FormHeaderClose.AutoSize = true;
            this.FormHeaderClose.BackColor = System.Drawing.Color.Black;
            this.FormHeaderClose.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormHeaderClose.ForeColor = System.Drawing.Color.MistyRose;
            this.FormHeaderClose.Location = new System.Drawing.Point(1007, 7);
            this.FormHeaderClose.Name = "FormHeaderClose";
            this.FormHeaderClose.Size = new System.Drawing.Size(19, 17);
            this.FormHeaderClose.TabIndex = 1;
            this.FormHeaderClose.Text = "X";
            this.FormHeaderClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tooltipHandler.SetToolTip(this.FormHeaderClose, "Close Window");
            this.FormHeaderClose.Click += new System.EventHandler(this.FormHeaderClose_Click_1);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblVersion.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblVersion.Location = new System.Drawing.Point(8, 468);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(190, 26);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version 1.0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vt
            // 
            this.vt.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.vt.Controls.Add(this.tabAbout);
            this.vt.Controls.Add(this.tabSettings);
            this.vt.Controls.Add(this.tabPage1);
            this.vt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vt.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.vt.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vt.ItemSize = new System.Drawing.Size(30, 200);
            this.vt.Location = new System.Drawing.Point(0, 30);
            this.vt.Margin = new System.Windows.Forms.Padding(0);
            this.vt.Multiline = true;
            this.vt.MyBackColor = System.Drawing.Color.Transparent;
            this.vt.Name = "vt";
            this.vt.Padding = new System.Drawing.Point(0, 0);
            this.vt.SelectedIndex = 0;
            this.vt.Size = new System.Drawing.Size(1030, 471);
            this.vt.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.vt.TabBackgroundColor = System.Drawing.Color.Silver;
            this.vt.TabFont = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.vt.TabFontColor = System.Drawing.Color.SteelBlue;
            this.vt.TabIndex = 2;
            this.vt.TabSelectedBackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.vt.TabSelectedFontColor = System.Drawing.Color.Silver;
            this.vt.TabTextHAlign = System.Drawing.StringAlignment.Near;
            this.vt.TabTextVAlign = System.Drawing.StringAlignment.Center;
            // 
            // tabAbout
            // 
            this.tabAbout.BackColor = System.Drawing.Color.DarkGray;
            this.tabAbout.Controls.Add(this.tableLayoutPanel1);
            this.tabAbout.Controls.Add(this.label3);
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Location = new System.Drawing.Point(204, 4);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(822, 463);
            this.tabAbout.TabIndex = 1;
            this.tabAbout.Text = "About";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.rtfAbout, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveBTN, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.loadBTN, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.useSettingsBTN, 2, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(292, 77);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(487, 378);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // rtfAbout
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rtfAbout, 3);
            this.rtfAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfAbout.Location = new System.Drawing.Point(3, 3);
            this.rtfAbout.Name = "rtfAbout";
            this.rtfAbout.ReadOnly = true;
            this.rtfAbout.Size = new System.Drawing.Size(481, 324);
            this.rtfAbout.TabIndex = 0;
            this.rtfAbout.Text = "";
            // 
            // saveBTN
            // 
            this.saveBTN.AutoSize = true;
            this.saveBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveBTN.Location = new System.Drawing.Point(3, 333);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(115, 42);
            this.saveBTN.TabIndex = 1;
            this.saveBTN.Text = "Save to File\r\n";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // loadBTN
            // 
            this.loadBTN.AutoSize = true;
            this.loadBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.loadBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadBTN.Location = new System.Drawing.Point(124, 333);
            this.loadBTN.Name = "loadBTN";
            this.loadBTN.Size = new System.Drawing.Size(115, 42);
            this.loadBTN.TabIndex = 2;
            this.loadBTN.Text = "Load from File";
            this.loadBTN.UseVisualStyleBackColor = true;
            this.loadBTN.Click += new System.EventHandler(this.loadBTN_Click);
            // 
            // useSettingsBTN
            // 
            this.useSettingsBTN.AutoSize = true;
            this.useSettingsBTN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.useSettingsBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.useSettingsBTN.Location = new System.Drawing.Point(245, 333);
            this.useSettingsBTN.Name = "useSettingsBTN";
            this.useSettingsBTN.Size = new System.Drawing.Size(239, 42);
            this.useSettingsBTN.TabIndex = 3;
            this.useSettingsBTN.Text = "Use Settings";
            this.useSettingsBTN.UseVisualStyleBackColor = true;
            this.useSettingsBTN.Click += new System.EventHandler(this.useSettingsBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(494, 39);
            this.label3.TabIndex = 11;
            this.label3.Text = "Inner Rage : Let the Rampage begin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 463);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // tabSettings
            // 
            this.tabSettings.BackColor = System.Drawing.Color.DarkGray;
            this.tabSettings.Controls.Add(this.groupBox10);
            this.tabSettings.Controls.Add(this.groupBox9);
            this.tabSettings.Controls.Add(this.Racials);
            this.tabSettings.Controls.Add(this.groupBox5);
            this.tabSettings.Controls.Add(this.groupBox4);
            this.tabSettings.Controls.Add(this.groupBox1);
            this.tabSettings.Controls.Add(this.Buffs);
            this.tabSettings.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabSettings.Location = new System.Drawing.Point(204, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(822, 463);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Global";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.RallyingCryHP);
            this.groupBox10.Controls.Add(this.DBTSHP);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.label7);
            this.groupBox10.Controls.Add(this.RallyingCryCB);
            this.groupBox10.Controls.Add(this.DieByTheSwordCB);
            this.groupBox10.Location = new System.Drawing.Point(399, 237);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(415, 86);
            this.groupBox10.TabIndex = 10;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Defensives";
            // 
            // RallyingCryHP
            // 
            this.RallyingCryHP.Location = new System.Drawing.Point(271, 53);
            this.RallyingCryHP.Name = "RallyingCryHP";
            this.RallyingCryHP.Size = new System.Drawing.Size(100, 26);
            this.RallyingCryHP.TabIndex = 5;
            // 
            // DBTSHP
            // 
            this.DBTSHP.Location = new System.Drawing.Point(271, 24);
            this.DBTSHP.Name = "DBTSHP";
            this.DBTSHP.Size = new System.Drawing.Size(100, 26);
            this.DBTSHP.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 18);
            this.label8.TabIndex = 3;
            this.label8.Text = "on HP percentage:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "on HP percentage:";
            // 
            // RallyingCryCB
            // 
            this.RallyingCryCB.AutoSize = true;
            this.RallyingCryCB.Location = new System.Drawing.Point(7, 55);
            this.RallyingCryCB.Name = "RallyingCryCB";
            this.RallyingCryCB.Size = new System.Drawing.Size(99, 22);
            this.RallyingCryCB.TabIndex = 1;
            this.RallyingCryCB.Text = "Rallying Cry";
            this.RallyingCryCB.UseVisualStyleBackColor = true;
            // 
            // DieByTheSwordCB
            // 
            this.DieByTheSwordCB.AutoSize = true;
            this.DieByTheSwordCB.Location = new System.Drawing.Point(7, 26);
            this.DieByTheSwordCB.Name = "DieByTheSwordCB";
            this.DieByTheSwordCB.Size = new System.Drawing.Size(131, 22);
            this.DieByTheSwordCB.TabIndex = 0;
            this.DieByTheSwordCB.Text = "Die by the sword";
            this.DieByTheSwordCB.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.BerserkerBreakFearCB);
            this.groupBox9.Location = new System.Drawing.Point(6, 237);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(387, 86);
            this.groupBox9.TabIndex = 9;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Berserker Rage";
            // 
            // BerserkerBreakFearCB
            // 
            this.BerserkerBreakFearCB.AutoSize = true;
            this.BerserkerBreakFearCB.Location = new System.Drawing.Point(7, 24);
            this.BerserkerBreakFearCB.Name = "BerserkerBreakFearCB";
            this.BerserkerBreakFearCB.Size = new System.Drawing.Size(230, 22);
            this.BerserkerBreakFearCB.TabIndex = 0;
            this.BerserkerBreakFearCB.Text = "Use Berserker Rage to break Fear";
            this.BerserkerBreakFearCB.UseVisualStyleBackColor = true;
            // 
            // Racials
            // 
            this.Racials.Controls.Add(this.RacialBloodElfCB);
            this.Racials.Controls.Add(this.RacialHumanCB);
            this.Racials.Controls.Add(this.RacialTrollCB);
            this.Racials.Controls.Add(this.RacialOrcCB);
            this.Racials.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Racials.Location = new System.Drawing.Point(399, 6);
            this.Racials.Name = "Racials";
            this.Racials.Size = new System.Drawing.Size(157, 225);
            this.Racials.TabIndex = 8;
            this.Racials.TabStop = false;
            this.Racials.Text = "Racials";
            // 
            // RacialBloodElfCB
            // 
            this.RacialBloodElfCB.AutoSize = true;
            this.RacialBloodElfCB.Location = new System.Drawing.Point(6, 110);
            this.RacialBloodElfCB.Name = "RacialBloodElfCB";
            this.RacialBloodElfCB.Size = new System.Drawing.Size(121, 22);
            this.RacialBloodElfCB.TabIndex = 3;
            this.RacialBloodElfCB.Text = "Blood Elf Racial";
            this.RacialBloodElfCB.UseVisualStyleBackColor = true;
            // 
            // RacialHumanCB
            // 
            this.RacialHumanCB.AutoSize = true;
            this.RacialHumanCB.Location = new System.Drawing.Point(6, 82);
            this.RacialHumanCB.Name = "RacialHumanCB";
            this.RacialHumanCB.Size = new System.Drawing.Size(110, 22);
            this.RacialHumanCB.TabIndex = 2;
            this.RacialHumanCB.Text = "Human Racial";
            this.RacialHumanCB.UseVisualStyleBackColor = true;
            // 
            // RacialTrollCB
            // 
            this.RacialTrollCB.AutoSize = true;
            this.RacialTrollCB.Location = new System.Drawing.Point(6, 52);
            this.RacialTrollCB.Name = "RacialTrollCB";
            this.RacialTrollCB.Size = new System.Drawing.Size(93, 22);
            this.RacialTrollCB.TabIndex = 1;
            this.RacialTrollCB.Text = "Troll Racial";
            this.RacialTrollCB.UseVisualStyleBackColor = true;
            // 
            // RacialOrcCB
            // 
            this.RacialOrcCB.AutoSize = true;
            this.RacialOrcCB.Location = new System.Drawing.Point(6, 26);
            this.RacialOrcCB.Name = "RacialOrcCB";
            this.RacialOrcCB.Size = new System.Drawing.Size(87, 22);
            this.RacialOrcCB.TabIndex = 0;
            this.RacialOrcCB.Text = "Orc Racial";
            this.RacialOrcCB.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LoCDelay);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.InterruptDelay);
            this.groupBox5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(562, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 225);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Timer";
            // 
            // LoCDelay
            // 
            this.LoCDelay.Location = new System.Drawing.Point(69, 124);
            this.LoCDelay.Name = "LoCDelay";
            this.LoCDelay.Size = new System.Drawing.Size(100, 26);
            this.LoCDelay.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Loss of control clear delay in ms";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Interrupt delay in ms";
            // 
            // InterruptDelay
            // 
            this.InterruptDelay.Location = new System.Drawing.Point(69, 47);
            this.InterruptDelay.Name = "InterruptDelay";
            this.InterruptDelay.Size = new System.Drawing.Size(100, 26);
            this.InterruptDelay.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Trinket2BurstCb);
            this.groupBox4.Controls.Add(this.Trinket2LoCCB);
            this.groupBox4.Controls.Add(this.Trinket2CB);
            this.groupBox4.Controls.Add(this.Trinket1BurstCB);
            this.groupBox4.Controls.Add(this.Trinket1LoCCB);
            this.groupBox4.Controls.Add(this.Trinket1CB);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(177, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(216, 225);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trinkets";
            // 
            // Trinket2BurstCb
            // 
            this.Trinket2BurstCb.AutoSize = true;
            this.Trinket2BurstCb.Location = new System.Drawing.Point(27, 168);
            this.Trinket2BurstCb.Name = "Trinket2BurstCb";
            this.Trinket2BurstCb.Size = new System.Drawing.Size(75, 22);
            this.Trinket2BurstCb.TabIndex = 5;
            this.Trinket2BurstCb.Text = "to Burst";
            this.Trinket2BurstCb.UseVisualStyleBackColor = true;
            // 
            // Trinket2LoCCB
            // 
            this.Trinket2LoCCB.AutoSize = true;
            this.Trinket2LoCCB.Location = new System.Drawing.Point(27, 140);
            this.Trinket2LoCCB.Name = "Trinket2LoCCB";
            this.Trinket2LoCCB.Size = new System.Drawing.Size(137, 22);
            this.Trinket2LoCCB.TabIndex = 4;
            this.Trinket2LoCCB.Text = "on Loss of Control";
            this.Trinket2LoCCB.UseVisualStyleBackColor = true;
            // 
            // Trinket2CB
            // 
            this.Trinket2CB.AutoSize = true;
            this.Trinket2CB.Location = new System.Drawing.Point(7, 112);
            this.Trinket2CB.Name = "Trinket2CB";
            this.Trinket2CB.Size = new System.Drawing.Size(106, 22);
            this.Trinket2CB.TabIndex = 3;
            this.Trinket2CB.Text = "Use Trinket 2";
            this.Trinket2CB.UseVisualStyleBackColor = true;
            // 
            // Trinket1BurstCB
            // 
            this.Trinket1BurstCB.AutoSize = true;
            this.Trinket1BurstCB.Location = new System.Drawing.Point(27, 80);
            this.Trinket1BurstCB.Name = "Trinket1BurstCB";
            this.Trinket1BurstCB.Size = new System.Drawing.Size(75, 22);
            this.Trinket1BurstCB.TabIndex = 2;
            this.Trinket1BurstCB.Text = "to Burst";
            this.Trinket1BurstCB.UseVisualStyleBackColor = true;
            // 
            // Trinket1LoCCB
            // 
            this.Trinket1LoCCB.AutoSize = true;
            this.Trinket1LoCCB.Location = new System.Drawing.Point(27, 52);
            this.Trinket1LoCCB.Name = "Trinket1LoCCB";
            this.Trinket1LoCCB.Size = new System.Drawing.Size(135, 22);
            this.Trinket1LoCCB.TabIndex = 1;
            this.Trinket1LoCCB.Text = "on Loss of control";
            this.Trinket1LoCCB.UseVisualStyleBackColor = true;
            // 
            // Trinket1CB
            // 
            this.Trinket1CB.AutoSize = true;
            this.Trinket1CB.Location = new System.Drawing.Point(7, 24);
            this.Trinket1CB.Name = "Trinket1CB";
            this.Trinket1CB.Size = new System.Drawing.Size(106, 22);
            this.Trinket1CB.TabIndex = 0;
            this.Trinket1CB.Text = "Use Trinket 1";
            this.Trinket1CB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.InterruptStormBoltCB);
            this.groupBox1.Controls.Add(this.InterruptShockWaveCB);
            this.groupBox1.Controls.Add(this.InterruptPummelCB);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 140);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interrupts";
            // 
            // InterruptStormBoltCB
            // 
            this.InterruptStormBoltCB.AutoSize = true;
            this.InterruptStormBoltCB.Enabled = false;
            this.InterruptStormBoltCB.Location = new System.Drawing.Point(6, 82);
            this.InterruptStormBoltCB.Name = "InterruptStormBoltCB";
            this.InterruptStormBoltCB.Size = new System.Drawing.Size(89, 22);
            this.InterruptStormBoltCB.TabIndex = 3;
            this.InterruptStormBoltCB.Text = "StormBolt";
            this.InterruptStormBoltCB.UseVisualStyleBackColor = true;
            // 
            // InterruptShockWaveCB
            // 
            this.InterruptShockWaveCB.AutoSize = true;
            this.InterruptShockWaveCB.Enabled = false;
            this.InterruptShockWaveCB.Location = new System.Drawing.Point(6, 54);
            this.InterruptShockWaveCB.Name = "InterruptShockWaveCB";
            this.InterruptShockWaveCB.Size = new System.Drawing.Size(97, 22);
            this.InterruptShockWaveCB.TabIndex = 2;
            this.InterruptShockWaveCB.Text = "ShockWave";
            this.InterruptShockWaveCB.UseVisualStyleBackColor = true;
            // 
            // InterruptPummelCB
            // 
            this.InterruptPummelCB.AutoSize = true;
            this.InterruptPummelCB.Location = new System.Drawing.Point(6, 24);
            this.InterruptPummelCB.Name = "InterruptPummelCB";
            this.InterruptPummelCB.Size = new System.Drawing.Size(79, 22);
            this.InterruptPummelCB.TabIndex = 0;
            this.InterruptPummelCB.Text = "Pummel";
            this.InterruptPummelCB.UseVisualStyleBackColor = true;
            // 
            // Buffs
            // 
            this.Buffs.Controls.Add(this.checkBuffs);
            this.Buffs.Controls.Add(this.BuffComboBox);
            this.Buffs.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buffs.Location = new System.Drawing.Point(6, 6);
            this.Buffs.Name = "Buffs";
            this.Buffs.Size = new System.Drawing.Size(165, 79);
            this.Buffs.TabIndex = 1;
            this.Buffs.TabStop = false;
            this.Buffs.Text = "Buffs";
            // 
            // checkBuffs
            // 
            this.checkBuffs.AutoSize = true;
            this.checkBuffs.Checked = true;
            this.checkBuffs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBuffs.Location = new System.Drawing.Point(7, 24);
            this.checkBuffs.Name = "checkBuffs";
            this.checkBuffs.Size = new System.Drawing.Size(93, 22);
            this.checkBuffs.TabIndex = 1;
            this.checkBuffs.Text = "Buff Group";
            this.checkBuffs.UseVisualStyleBackColor = true;
            // 
            // BuffComboBox
            // 
            this.BuffComboBox.BackColor = System.Drawing.Color.Silver;
            this.BuffComboBox.ForeColor = System.Drawing.Color.Black;
            this.BuffComboBox.FormattingEnabled = true;
            this.BuffComboBox.Items.AddRange(new object[] {
            "Battle Shout",
            "Commanding Shout"});
            this.BuffComboBox.Location = new System.Drawing.Point(6, 48);
            this.BuffComboBox.Name = "BuffComboBox";
            this.BuffComboBox.Size = new System.Drawing.Size(153, 26);
            this.BuffComboBox.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkGray;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Location = new System.Drawing.Point(204, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 463);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Talents";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.EnragedRegenerationCB);
            this.groupBox2.Controls.Add(this.TalentRavagerCB);
            this.groupBox2.Controls.Add(this.TalentBladeStormCB);
            this.groupBox2.Controls.Add(this.TalentAvatarCB);
            this.groupBox2.Controls.Add(this.TalentDragonRoarCB);
            this.groupBox2.Controls.Add(this.TalentShockWaveCB);
            this.groupBox2.Controls.Add(this.TalentStormBoltCB);
            this.groupBox2.Controls.Add(this.TalentsBloodBathCB);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(183, 298);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Talents";
            // 
            // EnragedRegenerationCB
            // 
            this.EnragedRegenerationCB.AutoSize = true;
            this.EnragedRegenerationCB.Location = new System.Drawing.Point(7, 26);
            this.EnragedRegenerationCB.Name = "EnragedRegenerationCB";
            this.EnragedRegenerationCB.Size = new System.Drawing.Size(163, 22);
            this.EnragedRegenerationCB.TabIndex = 7;
            this.EnragedRegenerationCB.Text = "Enraged Regeneration";
            this.EnragedRegenerationCB.UseVisualStyleBackColor = true;
            // 
            // TalentRavagerCB
            // 
            this.TalentRavagerCB.AutoSize = true;
            this.TalentRavagerCB.Location = new System.Drawing.Point(7, 222);
            this.TalentRavagerCB.Name = "TalentRavagerCB";
            this.TalentRavagerCB.Size = new System.Drawing.Size(76, 22);
            this.TalentRavagerCB.TabIndex = 6;
            this.TalentRavagerCB.Text = "Ravager";
            this.TalentRavagerCB.UseVisualStyleBackColor = true;
            // 
            // TalentBladeStormCB
            // 
            this.TalentBladeStormCB.AutoSize = true;
            this.TalentBladeStormCB.Location = new System.Drawing.Point(6, 194);
            this.TalentBladeStormCB.Name = "TalentBladeStormCB";
            this.TalentBladeStormCB.Size = new System.Drawing.Size(98, 22);
            this.TalentBladeStormCB.TabIndex = 5;
            this.TalentBladeStormCB.Text = "Bladestorm";
            this.TalentBladeStormCB.UseVisualStyleBackColor = true;
            // 
            // TalentAvatarCB
            // 
            this.TalentAvatarCB.AutoSize = true;
            this.TalentAvatarCB.Location = new System.Drawing.Point(7, 138);
            this.TalentAvatarCB.Name = "TalentAvatarCB";
            this.TalentAvatarCB.Size = new System.Drawing.Size(67, 22);
            this.TalentAvatarCB.TabIndex = 4;
            this.TalentAvatarCB.Text = "Avatar";
            this.TalentAvatarCB.UseVisualStyleBackColor = true;
            // 
            // TalentDragonRoarCB
            // 
            this.TalentDragonRoarCB.AutoSize = true;
            this.TalentDragonRoarCB.Location = new System.Drawing.Point(6, 110);
            this.TalentDragonRoarCB.Name = "TalentDragonRoarCB";
            this.TalentDragonRoarCB.Size = new System.Drawing.Size(96, 22);
            this.TalentDragonRoarCB.TabIndex = 3;
            this.TalentDragonRoarCB.Text = "Dragonroar";
            this.TalentDragonRoarCB.UseVisualStyleBackColor = true;
            // 
            // TalentShockWaveCB
            // 
            this.TalentShockWaveCB.AutoSize = true;
            this.TalentShockWaveCB.Location = new System.Drawing.Point(6, 82);
            this.TalentShockWaveCB.Name = "TalentShockWaveCB";
            this.TalentShockWaveCB.Size = new System.Drawing.Size(96, 22);
            this.TalentShockWaveCB.TabIndex = 2;
            this.TalentShockWaveCB.Text = "Shockwave";
            this.TalentShockWaveCB.UseVisualStyleBackColor = true;
            // 
            // TalentStormBoltCB
            // 
            this.TalentStormBoltCB.AutoSize = true;
            this.TalentStormBoltCB.Location = new System.Drawing.Point(7, 54);
            this.TalentStormBoltCB.Name = "TalentStormBoltCB";
            this.TalentStormBoltCB.Size = new System.Drawing.Size(89, 22);
            this.TalentStormBoltCB.TabIndex = 1;
            this.TalentStormBoltCB.Text = "Stormbolt";
            this.TalentStormBoltCB.UseVisualStyleBackColor = true;
            // 
            // TalentsBloodBathCB
            // 
            this.TalentsBloodBathCB.AutoSize = true;
            this.TalentsBloodBathCB.Location = new System.Drawing.Point(6, 166);
            this.TalentsBloodBathCB.Name = "TalentsBloodBathCB";
            this.TalentsBloodBathCB.Size = new System.Drawing.Size(91, 22);
            this.TalentsBloodBathCB.TabIndex = 0;
            this.TalentsBloodBathCB.Text = "Bloodbath";
            this.TalentsBloodBathCB.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.DragonRoarAoECount);
            this.groupBox8.Controls.Add(this.DragonRoarAoECountCB);
            this.groupBox8.Controls.Add(this.DragonRoarOnlyOnBossCB);
            this.groupBox8.Controls.Add(this.TalentSyncDragonRoar);
            this.groupBox8.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(521, 9);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(293, 142);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Dragonroar";
            // 
            // DragonRoarAoECount
            // 
            this.DragonRoarAoECount.Location = new System.Drawing.Point(7, 80);
            this.DragonRoarAoECount.Name = "DragonRoarAoECount";
            this.DragonRoarAoECount.Size = new System.Drawing.Size(100, 26);
            this.DragonRoarAoECount.TabIndex = 4;
            // 
            // DragonRoarAoECountCB
            // 
            this.DragonRoarAoECountCB.AutoSize = true;
            this.DragonRoarAoECountCB.Location = new System.Drawing.Point(7, 49);
            this.DragonRoarAoECountCB.Name = "DragonRoarAoECountCB";
            this.DragonRoarAoECountCB.Size = new System.Drawing.Size(207, 22);
            this.DragonRoarAoECountCB.TabIndex = 1;
            this.DragonRoarAoECountCB.Text = "only on Enemies surrounding";
            this.DragonRoarAoECountCB.UseVisualStyleBackColor = true;
            // 
            // DragonRoarOnlyOnBossCB
            // 
            this.DragonRoarOnlyOnBossCB.AutoSize = true;
            this.DragonRoarOnlyOnBossCB.Location = new System.Drawing.Point(7, 21);
            this.DragonRoarOnlyOnBossCB.Name = "DragonRoarOnlyOnBossCB";
            this.DragonRoarOnlyOnBossCB.Size = new System.Drawing.Size(104, 22);
            this.DragonRoarOnlyOnBossCB.TabIndex = 0;
            this.DragonRoarOnlyOnBossCB.Text = "only on Boss";
            this.DragonRoarOnlyOnBossCB.UseVisualStyleBackColor = true;
            // 
            // TalentSyncDragonRoar
            // 
            this.TalentSyncDragonRoar.AutoSize = true;
            this.TalentSyncDragonRoar.Checked = true;
            this.TalentSyncDragonRoar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TalentSyncDragonRoar.Location = new System.Drawing.Point(7, 106);
            this.TalentSyncDragonRoar.Name = "TalentSyncDragonRoar";
            this.TalentSyncDragonRoar.Size = new System.Drawing.Size(225, 22);
            this.TalentSyncDragonRoar.TabIndex = 3;
            this.TalentSyncDragonRoar.Text = "Sync Dragonroar with Bloodbath";
            this.TalentSyncDragonRoar.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RecklessnessOnlyOnBossCB);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TrinketAura);
            this.groupBox3.Controls.Add(this.TalentsRecklessnessCondition);
            this.groupBox3.Controls.Add(this.TalentSyncAvatar);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.TalentsBloodBathCondition);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(195, 162);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(619, 298);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Talents - Advanced Options";
            // 
            // RecklessnessOnlyOnBossCB
            // 
            this.RecklessnessOnlyOnBossCB.AutoSize = true;
            this.RecklessnessOnlyOnBossCB.Location = new System.Drawing.Point(389, 69);
            this.RecklessnessOnlyOnBossCB.Name = "RecklessnessOnlyOnBossCB";
            this.RecklessnessOnlyOnBossCB.Size = new System.Drawing.Size(106, 22);
            this.RecklessnessOnlyOnBossCB.TabIndex = 10;
            this.RecklessnessOnlyOnBossCB.Text = "Only on Boss";
            this.RecklessnessOnlyOnBossCB.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "On Trinket Aura";
            // 
            // TrinketAura
            // 
            this.TrinketAura.Location = new System.Drawing.Point(513, 29);
            this.TrinketAura.Name = "TrinketAura";
            this.TrinketAura.Size = new System.Drawing.Size(100, 26);
            this.TrinketAura.TabIndex = 8;
            // 
            // TalentsRecklessnessCondition
            // 
            this.TalentsRecklessnessCondition.BackColor = System.Drawing.Color.Silver;
            this.TalentsRecklessnessCondition.ForeColor = System.Drawing.Color.Black;
            this.TalentsRecklessnessCondition.FormattingEnabled = true;
            this.TalentsRecklessnessCondition.Items.AddRange(new object[] {
            "On Cooldown",
            "On Bloodbath",
            "Never"});
            this.TalentsRecklessnessCondition.Location = new System.Drawing.Point(157, 66);
            this.TalentsRecklessnessCondition.Name = "TalentsRecklessnessCondition";
            this.TalentsRecklessnessCondition.Size = new System.Drawing.Size(222, 26);
            this.TalentsRecklessnessCondition.TabIndex = 7;
            // 
            // TalentSyncAvatar
            // 
            this.TalentSyncAvatar.AutoSize = true;
            this.TalentSyncAvatar.Location = new System.Drawing.Point(11, 109);
            this.TalentSyncAvatar.Name = "TalentSyncAvatar";
            this.TalentSyncAvatar.Size = new System.Drawing.Size(196, 22);
            this.TalentSyncAvatar.TabIndex = 4;
            this.TalentSyncAvatar.Text = "Sync Avatar with Bloodbath";
            this.TalentSyncAvatar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Recklessness :";
            // 
            // TalentsBloodBathCondition
            // 
            this.TalentsBloodBathCondition.BackColor = System.Drawing.Color.Silver;
            this.TalentsBloodBathCondition.ForeColor = System.Drawing.Color.Black;
            this.TalentsBloodBathCondition.FormattingEnabled = true;
            this.TalentsBloodBathCondition.Items.AddRange(new object[] {
            "Everytime avaiable",
            "On Trinket Proc "});
            this.TalentsBloodBathCondition.Location = new System.Drawing.Point(157, 29);
            this.TalentsBloodBathCondition.Name = "TalentsBloodBathCondition";
            this.TalentsBloodBathCondition.Size = new System.Drawing.Size(222, 26);
            this.TalentsBloodBathCondition.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bloodbath :";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.BladestormAoECount);
            this.groupBox7.Controls.Add(this.BladestormOnlyAoECountCB);
            this.groupBox7.Controls.Add(this.BladestormOnlyBossCB);
            this.groupBox7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(263, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(251, 142);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Bladestorm";
            // 
            // BladestormAoECount
            // 
            this.BladestormAoECount.Location = new System.Drawing.Point(7, 80);
            this.BladestormAoECount.Name = "BladestormAoECount";
            this.BladestormAoECount.Size = new System.Drawing.Size(100, 26);
            this.BladestormAoECount.TabIndex = 2;
            // 
            // BladestormOnlyAoECountCB
            // 
            this.BladestormOnlyAoECountCB.AutoSize = true;
            this.BladestormOnlyAoECountCB.Location = new System.Drawing.Point(7, 52);
            this.BladestormOnlyAoECountCB.Name = "BladestormOnlyAoECountCB";
            this.BladestormOnlyAoECountCB.Size = new System.Drawing.Size(207, 22);
            this.BladestormOnlyAoECountCB.TabIndex = 1;
            this.BladestormOnlyAoECountCB.Text = "only on Enemies surrounding";
            this.BladestormOnlyAoECountCB.UseVisualStyleBackColor = true;
            // 
            // BladestormOnlyBossCB
            // 
            this.BladestormOnlyBossCB.AutoSize = true;
            this.BladestormOnlyBossCB.Location = new System.Drawing.Point(7, 24);
            this.BladestormOnlyBossCB.Name = "BladestormOnlyBossCB";
            this.BladestormOnlyBossCB.Size = new System.Drawing.Size(104, 22);
            this.BladestormOnlyBossCB.TabIndex = 0;
            this.BladestormOnlyBossCB.Text = "only on Boss";
            this.BladestormOnlyBossCB.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.RavagerAoeCount);
            this.groupBox6.Controls.Add(this.RavagerOnlyAoECountCB);
            this.groupBox6.Controls.Add(this.RavagerOnlyBossCB);
            this.groupBox6.Controls.Add(this.TalentSyncRavager);
            this.groupBox6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(6, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(251, 145);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ravager";
            // 
            // RavagerAoeCount
            // 
            this.RavagerAoeCount.Location = new System.Drawing.Point(7, 79);
            this.RavagerAoeCount.Name = "RavagerAoeCount";
            this.RavagerAoeCount.Size = new System.Drawing.Size(100, 26);
            this.RavagerAoeCount.TabIndex = 2;
            // 
            // RavagerOnlyAoECountCB
            // 
            this.RavagerOnlyAoECountCB.AutoSize = true;
            this.RavagerOnlyAoECountCB.Location = new System.Drawing.Point(7, 52);
            this.RavagerOnlyAoECountCB.Name = "RavagerOnlyAoECountCB";
            this.RavagerOnlyAoECountCB.Size = new System.Drawing.Size(207, 22);
            this.RavagerOnlyAoECountCB.TabIndex = 1;
            this.RavagerOnlyAoECountCB.Text = "only on Enemies surrounding";
            this.RavagerOnlyAoECountCB.UseVisualStyleBackColor = true;
            // 
            // RavagerOnlyBossCB
            // 
            this.RavagerOnlyBossCB.AutoSize = true;
            this.RavagerOnlyBossCB.Location = new System.Drawing.Point(7, 24);
            this.RavagerOnlyBossCB.Name = "RavagerOnlyBossCB";
            this.RavagerOnlyBossCB.Size = new System.Drawing.Size(104, 22);
            this.RavagerOnlyBossCB.TabIndex = 0;
            this.RavagerOnlyBossCB.Text = "only on Boss";
            this.RavagerOnlyBossCB.UseVisualStyleBackColor = true;
            // 
            // TalentSyncRavager
            // 
            this.TalentSyncRavager.AutoSize = true;
            this.TalentSyncRavager.Checked = true;
            this.TalentSyncRavager.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TalentSyncRavager.Location = new System.Drawing.Point(7, 109);
            this.TalentSyncRavager.Name = "TalentSyncRavager";
            this.TalentSyncRavager.Size = new System.Drawing.Size(205, 22);
            this.TalentSyncRavager.TabIndex = 6;
            this.TalentSyncRavager.Text = "Sync Ravager with Bloodbath";
            this.TalentSyncRavager.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1030, 501);
            this.ControlBox = false;
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.vt);
            this.Controls.Add(this.FormHeaderClose);
            this.Controls.Add(this.FormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.vt.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.Racials.ResumeLayout(false);
            this.Racials.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Buffs.ResumeLayout(false);
            this.Buffs.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private Label FormHeader;
        private Label FormHeaderClose;
		private Label lblVersion;
        private ToolTip tooltipHandler;
        private TabPage tabSettings;
        private TabPage tabAbout;
        private VerticalTabs vt;
        private GroupBox groupBox1;
        private CheckBox InterruptStormBoltCB;
        private CheckBox InterruptShockWaveCB;
        private CheckBox InterruptPummelCB;
        private GroupBox Buffs;
        private CheckBox checkBuffs;
        private ComboBox BuffComboBox;
        private PictureBox pictureBox1;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private RichTextBox rtfAbout;
        private Button saveBTN;
        private Button loadBTN;
        private Button useSettingsBTN;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private GroupBox groupBox4;
        private CheckBox Trinket2BurstCb;
        private CheckBox Trinket2LoCCB;
        private CheckBox Trinket2CB;
        private CheckBox Trinket1BurstCB;
        private CheckBox Trinket1LoCCB;
        private CheckBox Trinket1CB;
        private GroupBox groupBox5;
        private TextBox LoCDelay;
        private Label label6;
        private Label label5;
        private TextBox InterruptDelay;
        private GroupBox groupBox9;
        private CheckBox BerserkerBreakFearCB;
        private GroupBox Racials;
        private CheckBox RacialBloodElfCB;
        private CheckBox RacialHumanCB;
        private CheckBox RacialTrollCB;
        private CheckBox RacialOrcCB;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private CheckBox TalentRavagerCB;
        private CheckBox TalentBladeStormCB;
        private CheckBox TalentAvatarCB;
        private CheckBox TalentDragonRoarCB;
        private CheckBox TalentShockWaveCB;
        private CheckBox TalentStormBoltCB;
        private CheckBox TalentsBloodBathCB;
        private GroupBox groupBox8;
        private TextBox DragonRoarAoECount;
        private CheckBox DragonRoarAoECountCB;
        private CheckBox DragonRoarOnlyOnBossCB;
        private CheckBox TalentSyncDragonRoar;
        private GroupBox groupBox3;
        private CheckBox RecklessnessOnlyOnBossCB;
        private Label label4;
        private TextBox TrinketAura;
        private ComboBox TalentsRecklessnessCondition;
        private CheckBox TalentSyncAvatar;
        private Label label2;
        private ComboBox TalentsBloodBathCondition;
        private Label label1;
        private GroupBox groupBox7;
        private TextBox BladestormAoECount;
        private CheckBox BladestormOnlyAoECountCB;
        private CheckBox BladestormOnlyBossCB;
        private GroupBox groupBox6;
        private TextBox RavagerAoeCount;
        private CheckBox RavagerOnlyAoECountCB;
        private CheckBox RavagerOnlyBossCB;
        private CheckBox TalentSyncRavager;
        private GroupBox groupBox10;
        private CheckBox EnragedRegenerationCB;
        private TextBox RallyingCryHP;
        private TextBox DBTSHP;
        private Label label8;
        private Label label7;
        private CheckBox RallyingCryCB;
        private CheckBox DieByTheSwordCB;
	}
}