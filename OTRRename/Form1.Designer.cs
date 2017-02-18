/**
 *  OTRRename - small tool to rename video files recieved from onlinetvrecorder.com
 *  Copyright (C) 2009-2014, Christian Schulte zu Berge
 *  
 *  This program is free software; you can redistribute it and/or modify it under the 
 *  terms of the GNU General Public License as published by the Free Software 
 *  Foundation; either version 3 of the License, or (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY 
 *  WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A 
 *  PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along with this 
 *  program; if not, see <http://www.gnu.org/licenses/>.
 * 
 *  Web:  http://www.cszb.net
 *  Mail: software@cszb.net
 */

namespace OTRRename
	{
	partial class Form1
		{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
			{
			if (disposing && (components != null))
				{
				components.Dispose();
				}
			base.Dispose(disposing);
			}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
			{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.chooseDirButton = new System.Windows.Forms.Button();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.isHDCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addition1TextBox = new System.Windows.Forms.TextBox();
            this.addition2TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isTopTippCheckBox = new System.Windows.Forms.CheckBox();
            this.isHQCheckBox = new System.Windows.Forms.CheckBox();
            this.channelTextBox = new System.Windows.Forms.TextBox();
            this.durationSpinEdit = new System.Windows.Forms.NumericUpDown();
            this.dateLabel = new System.Windows.Forms.Label();
            this.uebernehmenButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.readDirButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.removeRenameSchemeFromListButton = new System.Windows.Forms.Button();
            this.renameSchemeComboBox = new System.Windows.Forms.ComboBox();
            this.renameFilesButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.htmlExportButton = new System.Windows.Forms.Button();
            this.autosaveCheckBox = new System.Windows.Forms.CheckBox();
            this.saveLocalCheckBox = new System.Windows.Forms.CheckBox();
            this.saveGlobalCheckBox = new System.Windows.Forms.CheckBox();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.recoverOriginalFilenameButton = new System.Windows.Forms.Button();
            this.renameSelectedButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.aboutButton = new System.Windows.Forms.Button();
            this.selectAllButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationSpinEdit)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verzeichnis:";
            // 
            // dirTextBox
            // 
            this.dirTextBox.Location = new System.Drawing.Point(82, 9);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.Size = new System.Drawing.Size(618, 20);
            this.dirTextBox.TabIndex = 1;
            this.dirTextBox.Text = "C:\\";
            this.dirTextBox.TextChanged += new System.EventHandler(this.dirTextBox_TextChanged);
            // 
            // chooseDirButton
            // 
            this.chooseDirButton.Location = new System.Drawing.Point(706, 7);
            this.chooseDirButton.Name = "chooseDirButton";
            this.chooseDirButton.Size = new System.Drawing.Size(124, 23);
            this.chooseDirButton.TabIndex = 2;
            this.chooseDirButton.Text = "Verzeichnis wählen";
            this.chooseDirButton.UseVisualStyleBackColor = true;
            this.chooseDirButton.Click += new System.EventHandler(this.chooseDirButton_Click);
            // 
            // fileListBox
            // 
            this.fileListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.Location = new System.Drawing.Point(4, 4);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.fileListBox.Size = new System.Drawing.Size(596, 582);
            this.fileListBox.TabIndex = 3;
            this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.isHDCheckBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.addition1TextBox);
            this.groupBox1.Controls.Add(this.addition2TextBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.timeDateTimePicker);
            this.groupBox1.Controls.Add(this.dateDateTimePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.isTopTippCheckBox);
            this.groupBox1.Controls.Add(this.isHQCheckBox);
            this.groupBox1.Controls.Add(this.channelTextBox);
            this.groupBox1.Controls.Add(this.durationSpinEdit);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.uebernehmenButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.titleTextBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 236);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metadaten:";
            // 
            // isHDCheckBox
            // 
            this.isHDCheckBox.AutoSize = true;
            this.isHDCheckBox.Location = new System.Drawing.Point(159, 123);
            this.isHDCheckBox.Name = "isHDCheckBox";
            this.isHDCheckBox.Size = new System.Drawing.Size(77, 17);
            this.isHDCheckBox.TabIndex = 17;
            this.isHDCheckBox.Text = "HD Format";
            this.isHDCheckBox.UseVisualStyleBackColor = true;
            this.isHDCheckBox.CheckedChanged += new System.EventHandler(this.isHDCheckBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Zusatz #1:";
            // 
            // addition1TextBox
            // 
            this.addition1TextBox.Location = new System.Drawing.Point(76, 155);
            this.addition1TextBox.Name = "addition1TextBox";
            this.addition1TextBox.Size = new System.Drawing.Size(256, 20);
            this.addition1TextBox.TabIndex = 7;
            this.addition1TextBox.Leave += new System.EventHandler(this.settingsChanged);
            // 
            // addition2TextBox
            // 
            this.addition2TextBox.Location = new System.Drawing.Point(76, 181);
            this.addition2TextBox.Name = "addition2TextBox";
            this.addition2TextBox.Size = new System.Drawing.Size(256, 20);
            this.addition2TextBox.TabIndex = 8;
            this.addition2TextBox.Leave += new System.EventHandler(this.settingsChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Zusatz #2:";
            // 
            // timeDateTimePicker
            // 
            this.timeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeDateTimePicker.Location = new System.Drawing.Point(233, 45);
            this.timeDateTimePicker.Name = "timeDateTimePicker";
            this.timeDateTimePicker.ShowUpDown = true;
            this.timeDateTimePicker.Size = new System.Drawing.Size(99, 20);
            this.timeDateTimePicker.TabIndex = 2;
            this.timeDateTimePicker.ValueChanged += new System.EventHandler(this.settingsChanged);
            // 
            // dateDateTimePicker
            // 
            this.dateDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDateTimePicker.Location = new System.Drawing.Point(76, 45);
            this.dateDateTimePicker.Name = "dateDateTimePicker";
            this.dateDateTimePicker.Size = new System.Drawing.Size(151, 20);
            this.dateDateTimePicker.TabIndex = 1;
            this.dateDateTimePicker.ValueChanged += new System.EventHandler(this.settingsChanged);
            this.dateDateTimePicker.Leave += new System.EventHandler(this.settingsChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Dauer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sender:";
            // 
            // isTopTippCheckBox
            // 
            this.isTopTippCheckBox.AutoSize = true;
            this.isTopTippCheckBox.Location = new System.Drawing.Point(242, 123);
            this.isTopTippCheckBox.Name = "isTopTippCheckBox";
            this.isTopTippCheckBox.Size = new System.Drawing.Size(69, 17);
            this.isTopTippCheckBox.TabIndex = 6;
            this.isTopTippCheckBox.Text = "Top Tipp";
            this.isTopTippCheckBox.UseVisualStyleBackColor = true;
            this.isTopTippCheckBox.CheckedChanged += new System.EventHandler(this.settingsChanged);
            // 
            // isHQCheckBox
            // 
            this.isHQCheckBox.AutoSize = true;
            this.isHQCheckBox.Location = new System.Drawing.Point(76, 123);
            this.isHQCheckBox.Name = "isHQCheckBox";
            this.isHQCheckBox.Size = new System.Drawing.Size(77, 17);
            this.isHQCheckBox.TabIndex = 5;
            this.isHQCheckBox.Text = "HQ Format";
            this.isHQCheckBox.UseVisualStyleBackColor = true;
            this.isHQCheckBox.CheckedChanged += new System.EventHandler(this.settingsChanged);
            // 
            // channelTextBox
            // 
            this.channelTextBox.Location = new System.Drawing.Point(76, 71);
            this.channelTextBox.Name = "channelTextBox";
            this.channelTextBox.Size = new System.Drawing.Size(256, 20);
            this.channelTextBox.TabIndex = 3;
            this.channelTextBox.TextChanged += new System.EventHandler(this.settingsChanged);
            // 
            // durationSpinEdit
            // 
            this.durationSpinEdit.Location = new System.Drawing.Point(76, 97);
            this.durationSpinEdit.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.durationSpinEdit.Name = "durationSpinEdit";
            this.durationSpinEdit.Size = new System.Drawing.Size(256, 20);
            this.durationSpinEdit.TabIndex = 4;
            this.durationSpinEdit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.durationSpinEdit.ValueChanged += new System.EventHandler(this.settingsChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(6, 49);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(64, 13);
            this.dateLabel.TabIndex = 4;
            this.dateLabel.Text = "Datum/Zeit:";
            // 
            // uebernehmenButton
            // 
            this.uebernehmenButton.Location = new System.Drawing.Point(214, 207);
            this.uebernehmenButton.Name = "uebernehmenButton";
            this.uebernehmenButton.Size = new System.Drawing.Size(118, 23);
            this.uebernehmenButton.TabIndex = 9;
            this.uebernehmenButton.Text = "Übernehmen";
            this.uebernehmenButton.UseVisualStyleBackColor = true;
            this.uebernehmenButton.Click += new System.EventHandler(this.uebernehmenButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titel:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(76, 19);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(256, 20);
            this.titleTextBox.TabIndex = 0;
            this.titleTextBox.Leave += new System.EventHandler(this.settingsChanged);
            // 
            // readDirButton
            // 
            this.readDirButton.Location = new System.Drawing.Point(836, 7);
            this.readDirButton.Name = "readDirButton";
            this.readDirButton.Size = new System.Drawing.Size(124, 23);
            this.readDirButton.TabIndex = 5;
            this.readDirButton.Text = "Verzeichnis auslesen";
            this.readDirButton.UseVisualStyleBackColor = true;
            this.readDirButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.removeRenameSchemeFromListButton);
            this.groupBox2.Controls.Add(this.renameSchemeComboBox);
            this.groupBox2.Controls.Add(this.renameFilesButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 248);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 206);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Umbenennungsschema:";
            // 
            // removeRenameSchemeFromListButton
            // 
            this.removeRenameSchemeFromListButton.Location = new System.Drawing.Point(214, 74);
            this.removeRenameSchemeFromListButton.Name = "removeRenameSchemeFromListButton";
            this.removeRenameSchemeFromListButton.Size = new System.Drawing.Size(118, 23);
            this.removeRenameSchemeFromListButton.TabIndex = 12;
            this.removeRenameSchemeFromListButton.Text = "löschen";
            this.removeRenameSchemeFromListButton.UseVisualStyleBackColor = true;
            this.removeRenameSchemeFromListButton.Click += new System.EventHandler(this.removeRenameSchemeFromListButton_Click);
            // 
            // renameSchemeComboBox
            // 
            this.renameSchemeComboBox.FormattingEnabled = true;
            this.renameSchemeComboBox.Location = new System.Drawing.Point(6, 18);
            this.renameSchemeComboBox.Name = "renameSchemeComboBox";
            this.renameSchemeComboBox.Size = new System.Drawing.Size(326, 21);
            this.renameSchemeComboBox.TabIndex = 10;
            this.renameSchemeComboBox.Text = "<Title><HQ? [HQ]:>.<ext>";
            this.renameSchemeComboBox.Leave += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // renameFilesButton
            // 
            this.renameFilesButton.Location = new System.Drawing.Point(214, 45);
            this.renameFilesButton.Name = "renameFilesButton";
            this.renameFilesButton.Size = new System.Drawing.Size(118, 23);
            this.renameFilesButton.TabIndex = 11;
            this.renameFilesButton.Text = "auf alle anwenden";
            this.renameFilesButton.UseVisualStyleBackColor = true;
            this.renameFilesButton.Click += new System.EventHandler(this.renameFilesButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(326, 161);
            this.label5.TabIndex = 1;
            this.label5.Text = resources.GetString("label5.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.htmlExportButton);
            this.groupBox3.Controls.Add(this.autosaveCheckBox);
            this.groupBox3.Controls.Add(this.saveLocalCheckBox);
            this.groupBox3.Controls.Add(this.saveGlobalCheckBox);
            this.groupBox3.Controls.Add(this.saveDataButton);
            this.groupBox3.Location = new System.Drawing.Point(6, 523);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 90);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Metadaten Speichern/Laden:";
            // 
            // htmlExportButton
            // 
            this.htmlExportButton.Location = new System.Drawing.Point(214, 32);
            this.htmlExportButton.Name = "htmlExportButton";
            this.htmlExportButton.Size = new System.Drawing.Size(118, 23);
            this.htmlExportButton.TabIndex = 4;
            this.htmlExportButton.Text = "in HTML exportieren";
            this.htmlExportButton.UseVisualStyleBackColor = true;
            this.htmlExportButton.Click += new System.EventHandler(this.htmlExportButton_Click);
            // 
            // autosaveCheckBox
            // 
            this.autosaveCheckBox.AutoSize = true;
            this.autosaveCheckBox.Checked = true;
            this.autosaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autosaveCheckBox.Location = new System.Drawing.Point(6, 65);
            this.autosaveCheckBox.Name = "autosaveCheckBox";
            this.autosaveCheckBox.Size = new System.Drawing.Size(132, 17);
            this.autosaveCheckBox.TabIndex = 3;
            this.autosaveCheckBox.Text = "automatisch speichern";
            this.autosaveCheckBox.UseVisualStyleBackColor = true;
            this.autosaveCheckBox.CheckedChanged += new System.EventHandler(this.autosaveCheckBox_CheckedChanged);
            // 
            // saveLocalCheckBox
            // 
            this.saveLocalCheckBox.AutoSize = true;
            this.saveLocalCheckBox.Checked = true;
            this.saveLocalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveLocalCheckBox.Location = new System.Drawing.Point(6, 42);
            this.saveLocalCheckBox.Name = "saveLocalCheckBox";
            this.saveLocalCheckBox.Size = new System.Drawing.Size(181, 17);
            this.saveLocalCheckBox.TabIndex = 2;
            this.saveLocalCheckBox.Text = "im zugehörigen Ordner speichern";
            this.saveLocalCheckBox.UseVisualStyleBackColor = true;
            this.saveLocalCheckBox.CheckedChanged += new System.EventHandler(this.saveLocalCheckBox_CheckedChanged);
            // 
            // saveGlobalCheckBox
            // 
            this.saveGlobalCheckBox.AutoSize = true;
            this.saveGlobalCheckBox.Checked = true;
            this.saveGlobalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveGlobalCheckBox.Location = new System.Drawing.Point(6, 19);
            this.saveGlobalCheckBox.Name = "saveGlobalCheckBox";
            this.saveGlobalCheckBox.Size = new System.Drawing.Size(103, 17);
            this.saveGlobalCheckBox.TabIndex = 1;
            this.saveGlobalCheckBox.Text = "global speichern";
            this.saveGlobalCheckBox.UseVisualStyleBackColor = true;
            this.saveGlobalCheckBox.CheckedChanged += new System.EventHandler(this.saveInGlobalFolderCheckBox_CheckedChanged);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(214, 61);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(118, 23);
            this.saveDataButton.TabIndex = 0;
            this.saveDataButton.Text = "Metadaten speichern";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.readDirButton);
            this.panel1.Controls.Add(this.chooseDirButton);
            this.panel1.Controls.Add(this.dirTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(968, 37);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(604, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 616);
            this.panel2.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.recoverOriginalFilenameButton);
            this.groupBox4.Controls.Add(this.renameSelectedButton);
            this.groupBox4.Location = new System.Drawing.Point(6, 460);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 57);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ausgewählte Einträge umbenennen:";
            // 
            // recoverOriginalFilenameButton
            // 
            this.recoverOriginalFilenameButton.Location = new System.Drawing.Point(214, 28);
            this.recoverOriginalFilenameButton.Name = "recoverOriginalFilenameButton";
            this.recoverOriginalFilenameButton.Size = new System.Drawing.Size(118, 23);
            this.recoverOriginalFilenameButton.TabIndex = 2;
            this.recoverOriginalFilenameButton.Text = "wiederherstellen";
            this.recoverOriginalFilenameButton.UseVisualStyleBackColor = true;
            this.recoverOriginalFilenameButton.Click += new System.EventHandler(this.recoverOriginalFilenameButton_Click);
            // 
            // renameSelectedButton
            // 
            this.renameSelectedButton.Location = new System.Drawing.Point(90, 28);
            this.renameSelectedButton.Name = "renameSelectedButton";
            this.renameSelectedButton.Size = new System.Drawing.Size(118, 23);
            this.renameSelectedButton.TabIndex = 0;
            this.renameSelectedButton.Text = "umbenennen";
            this.renameSelectedButton.UseVisualStyleBackColor = true;
            this.renameSelectedButton.Click += new System.EventHandler(this.renameSelectedButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.aboutButton);
            this.panel3.Controls.Add(this.selectAllButton);
            this.panel3.Controls.Add(this.fileListBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 37);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 30);
            this.panel3.Size = new System.Drawing.Size(604, 616);
            this.panel3.TabIndex = 10;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(7, 586);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(118, 23);
            this.aboutButton.TabIndex = 5;
            this.aboutButton.Text = "Über OTRRename";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // selectAllButton
            // 
            this.selectAllButton.Location = new System.Drawing.Point(482, 586);
            this.selectAllButton.Name = "selectAllButton";
            this.selectAllButton.Size = new System.Drawing.Size(118, 23);
            this.selectAllButton.TabIndex = 4;
            this.selectAllButton.Text = "Alles markieren";
            this.selectAllButton.UseVisualStyleBackColor = true;
            this.selectAllButton.Click += new System.EventHandler(this.selectAllButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 653);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "OTR Rename";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.durationSpinEdit)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox dirTextBox;
		private System.Windows.Forms.Button chooseDirButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button uebernehmenButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox titleTextBox;
		private System.Windows.Forms.Button readDirButton;
		private System.Windows.Forms.NumericUpDown durationSpinEdit;
		private System.Windows.Forms.Label dateLabel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox isTopTippCheckBox;
		private System.Windows.Forms.CheckBox isHQCheckBox;
		private System.Windows.Forms.TextBox channelTextBox;
		private System.Windows.Forms.DateTimePicker timeDateTimePicker;
		private System.Windows.Forms.DateTimePicker dateDateTimePicker;
		private System.Windows.Forms.ListBox fileListBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button saveDataButton;
		private System.Windows.Forms.Button renameFilesButton;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ComboBox renameSchemeComboBox;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button renameSelectedButton;
		private System.Windows.Forms.Button recoverOriginalFilenameButton;
		private System.Windows.Forms.CheckBox saveLocalCheckBox;
		private System.Windows.Forms.CheckBox saveGlobalCheckBox;
		private System.Windows.Forms.Button selectAllButton;
		private System.Windows.Forms.CheckBox autosaveCheckBox;
		private System.Windows.Forms.Button aboutButton;
		private System.Windows.Forms.Button htmlExportButton;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox addition1TextBox;
		private System.Windows.Forms.TextBox addition2TextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button removeRenameSchemeFromListButton;
		private System.Windows.Forms.CheckBox isHDCheckBox;
		}
	}

