/**
 *  OTRRename - small tool to rename video files recieved from onlinetvrecorder.com
 *  Copyright (C) 2009, Christian Schulte zu Berge
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;


namespace OTRRename
	{
	public partial class Form1 : Form
		{
		/// <summary>
		/// darf ich die Settings von rechts nach links schreiben?
		/// </summary>
		private bool doUpdateSettings = false;

		/// <summary>
		/// Liste von RenameJobs
		/// </summary>
		private List<RenameJob> jobs = new List<RenameJob>();

		/// <summary>
		/// Liste von RenameJobs in der XML Datei
		/// </summary>
		Dictionary<int, RenameJob> globalJobs = new Dictionary<int, RenameJob>();

		/// <summary>
		/// 
		/// </summary>
		private string appDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\OTRRename";

		public Form1()
			{
			InitializeComponent();

			fileListBox.DataSource = jobs;
			CurrencyManager cm = BindingContext[jobs] as CurrencyManager;
			cm.Refresh();

			CreateAppDir();
			LoadProgramSettings();
			doUpdateSettings = true;

			if (saveGlobalCheckBox.Checked)
				{
				ReadIntoGlobalJobs(appDir + @"\OTRRenameMetadata.xml");
				}

			}

		/// <summary>
		/// Erstellt das 
		/// </summary>
		private void CreateAppDir()
			{
			if (! Directory.Exists(appDir))
				{
				Directory.CreateDirectory(appDir);
				}
			}

		private void chooseDirButton_Click(object sender, EventArgs e)
			{
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			if (Directory.Exists(dirTextBox.Text))
				{
				fbd.SelectedPath = dirTextBox.Text;
				}

			if (fbd.ShowDialog() == DialogResult.OK)
				{
				dirTextBox.Text = fbd.SelectedPath;
				button1_Click(this, e);
				}
			}



		/// <summary>
		/// Liest die XML Datei filename ein und fügt die noch nicht vorhandenen Einträge in globalJobs ein
		/// </summary>
		/// <param name="filename">Dateiname der einzulesenden XML-Datei</param>
		private void ReadIntoGlobalJobs(string filename)
			{
			int XmlVersion = 1;

			// XML Datei lesen, falls vorhanden
			if (File.Exists(filename))
				{
				try
					{
					XmlSerializer xs = new XmlSerializer(typeof(RenameJob));

					// Dokument laden
					XmlDocument doc = new XmlDocument();
					doc.Load(filename);

					XmlNode mainNode = doc.SelectSingleNode("//OTRRenameMetadata");
					XmlVersion = Int32.Parse(mainNode.Attributes.GetNamedItem("version").Value);

					XmlNodeList xnlJobs = doc.SelectNodes("//OTRRenameMetadata/RenameJob");
					foreach (XmlNode xnJob in xnlJobs)
						{
						// Node in einen TextReader packen
						using (TextReader tr = new StringReader(xnJob.OuterXml))
							{
							// und Deserializen
							RenameJob rj = xs.Deserialize(tr) as RenameJob;

							// ab in die Liste
							if (!globalJobs.ContainsKey(rj.GetHashCode()))
								{
								globalJobs.Add(rj.GetHashCode(), rj);
								}
							}
						}

					}
				catch (Exception ex)
					{
					MessageBox.Show("Beim Einlesen von '" + filename + "' ist leider ein Fehler aufgetreten: " + ex.Message);
					}
				}
			}

		private void UpdateGlobalJobs()
			{
			}

		/// <summary>
		/// List das Verzeichnis dir ein und füllt die fileListBox
		/// </summary>
		/// <param name="dir">einzulesendes Verzeichnis</param>
		private void ReadDir(string dir)
			{
			bool allFilesOK = true;

			jobs.Clear();

			string[] files = Directory.GetFiles(dir, @"*.avi");
			foreach (string f in files)
				{
				FileInfo fi = new FileInfo(f);
				RenameJob rj = new RenameJob(dir, fi.Name);

				RenameJob XmlRj; 
				bool found = globalJobs.TryGetValue(rj.GetHashCode(), out XmlRj);
				if (found)
					{
					rj = XmlRj;
					rj.path = dirTextBox.Text;
					}
				else
					{
					if (rj.currentFilename.Contains("_TVOON_DE"))
						{
						rj.originalOTRFilename = rj.currentFilename;
						rj.ParseFileInfos();
						}
					else
						{
						rj.originalOTRFilename = rj.currentFilename;
						rj.title = fi.Name.Substring(0, fi.Name.Length - 4);
						allFilesOK = false;
						}
					}

				rj.CreateNachher();

				jobs.Add(rj);
				}

			if (! allFilesOK)
				{
				MessageBox.Show("Einige Dateien sind nicht nach dem OTR-Schema benannt auch nicht in den XML-Metadaten-Dateien referenziert. Bitte geben Sie die Daten manuell ein.");
				}

			UpdateListBox();
			}


		/// <summary>
		/// Schmeißt den CurrencyManager an, um die Inhalte von fileListBox zu erneuern
		/// </summary>
		private void UpdateListBox()
			{
			CurrencyManager cm = BindingContext[jobs] as CurrencyManager;
			cm.Refresh();
			}

		private void button1_Click(object sender, EventArgs e)
			{
			if (dirTextBox.Text != "")
				{
				ReadIntoGlobalJobs(dirTextBox.Text + @"\OTRRenameMetadata.xml");
				ReadDir(dirTextBox.Text);
				SaveProgramSettings();
				}
			}

		/// <summary>
		/// Aktualisiert das SelectedItem der fileListBox auf die Daten der Einstellungen
		/// </summary>
		private void UpdateListFromSettings()
			{
			if ((fileListBox.SelectedItems.Count == 1) && (doUpdateSettings))
				{
				RenameJob rj = fileListBox.SelectedItem as RenameJob;
				if (rj != null)
					{
					rj.title = titleTextBox.Text;
					rj.date = new DateTime(
						dateDateTimePicker.Value.Year,
						dateDateTimePicker.Value.Month,
						dateDateTimePicker.Value.Day,
						timeDateTimePicker.Value.Hour,
						timeDateTimePicker.Value.Minute,
						timeDateTimePicker.Value.Second);
					rj.channel = channelTextBox.Text;
					rj.duration = durationSpinEdit.Value;
					rj.isHQ = isHQCheckBox.Checked;
					rj.isHD = isHDCheckBox.Checked;
					rj.isTopTipp = isTopTippCheckBox.Checked;

					rj.additionalData1 = addition1TextBox.Text;
					rj.additionalData2 = addition2TextBox.Text;

					rj.CreateNachher();

					// häßlicher Workaround um die Anzeige zu aktualisieren (Invalidate() funzt nicht)
					UpdateListBox();

					if (autosaveCheckBox.Checked)
						{
						SaveMetadata();
						}
					}
				}
			}

		/// <summary>
		/// Event, welches beim Ändern der Selektierung der fileListBox aufgerufen wird
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
			{
			doUpdateSettings = false;

			if (fileListBox.SelectedItems.Count == 1)
				{
				RenameJob rj = fileListBox.SelectedItem as RenameJob;
				if (rj != null)
					{
					titleTextBox.Text = rj.title;
					dateDateTimePicker.Value = rj.date;
					timeDateTimePicker.Value = rj.date;
					channelTextBox.Text = rj.channel;
					durationSpinEdit.Value = rj.duration;
					isHQCheckBox.Checked = rj.isHQ;
					isHDCheckBox.Checked = rj.isHD;
					isTopTippCheckBox.Checked = rj.isTopTipp;
					addition1TextBox.Text = rj.additionalData1;
					addition2TextBox.Text = rj.additionalData2;
					}
				}
			else //if (fileListBox.SelectedItems.Count > 1)
				{
				titleTextBox.Text = "";
				channelTextBox.Text = "";
				durationSpinEdit.Value = 0;
				isHQCheckBox.Checked = false;
				isTopTippCheckBox.Checked = false;
				addition1TextBox.Text = "";
				addition2TextBox.Text = "";
				}

			doUpdateSettings = true;
			}

		/// <summary>
		/// Event welches beim Ändern von Einstellungen aufgerufen wird
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void settingsChanged(object sender, EventArgs e)
			{
			UpdateListFromSettings();
			}


		/// <summary>
		/// fügt die in jobs geänderten Daten zu globalJobs hinzu
		/// </summary>
		private void MergeJobs()
			{
			foreach (RenameJob rj in jobs)
				{
				int hash = rj.GetHashCode();
				if (globalJobs.ContainsKey(hash))
					{
					globalJobs.Remove(hash);
					globalJobs.Add(hash, rj);
					}
				else
					{
					globalJobs.Add(hash, rj);
					}
				}
			}


		/// <summary>
		/// speichert jobs in eine XML-Datei
		/// </summary>
		public void SaveMetadata()
			{
			MergeJobs();

			if (saveGlobalCheckBox.Checked)
				{
				SaveMetadata(appDir + @"\OTRRenameMetadata.xml", true);
				}
			if (saveLocalCheckBox.Checked)
				{
				SaveMetadata(dirTextBox.Text + @"\OTRRenameMetadata.xml", false);
				}
			}


		/// <summary>
		/// speichert jobs in eine XML-Datei
		/// </summary>
		/// <param name="filename">Dateiname der XML Datei</param>
		/// <param name="allFiles">sollen sämltiche Metadaten gespeichert werden, oder lediglich die des ausgewählten Verzeichnisses</param>
		/// <returns>true</returns>
		private bool SaveMetadata(string filename, bool allFiles)
			{
			// TODO: feststellen, ob Vorgang erfolgreich und demnach true/false zurückgeben

			XmlWriter xw = XmlWriter.Create(filename);

			try
				{
				// leeren XmlSerializerNamespaces Namespace erstellen
				XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
				xsn.Add("", "");

				xw.WriteComment("This file saves all information about renamed OTR files and is needed to undo changes. To not delete or modify unless you know what you are doing!");

				xw.WriteStartElement("OTRRenameMetadata");

				xw.WriteStartAttribute("version");
				xw.WriteString("3");
				xw.WriteEndAttribute();

				XmlSerializer jobSerializer = new XmlSerializer(typeof(RenameJob));
				foreach (RenameJob rj in globalJobs.Values)
					{
					if (allFiles || rj.path == dirTextBox.Text)
						{
						jobSerializer.Serialize(xw, rj, xsn);
						}
					}

				xw.WriteEndElement();
				}
			catch (Exception ex)
				{
				MessageBox.Show("Beim Speichern der Metadaten ist leider ein Fehler aufgetreten: " + ex.Message);
				}
			finally
				{
				xw.Close();
				}

			return true;
			}


		/// <summary>
		/// speichert jobs in eine XML-Datei
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void saveDataButton_Click(object sender, EventArgs e)
			{
			SaveMetadata();
			}


		private void renameFilesButton_Click(object sender, EventArgs e)
			{
			RenameJob.renameScheme = renameSchemeComboBox.Text;
			foreach (RenameJob rj in jobs)
				{
				rj.CreateNachher();
				}
			UpdateListBox();
			
			SaveProgramSettings();
			}

		private void Form1_Resize(object sender, EventArgs e)
			{
			dirTextBox.Width = this.ClientSize.Width - 354;
			chooseDirButton.Left = this.ClientSize.Width - 266;
			readDirButton.Left = this.ClientSize.Width - 136;
			selectAllButton.Top = panel3.ClientSize.Height - 27;
			selectAllButton.Left = panel3.ClientSize.Width - 122;
			aboutButton.Top = selectAllButton.Top;
			}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
			{
			if (renameSchemeComboBox.Text != "")
				{
				bool exists = false;
				foreach (Object o in renameSchemeComboBox.Items)
					{
					if (renameSchemeComboBox.Text.Equals(o.ToString()))
						{
						exists = true;
						}
					}

				if (!exists)
					{
					renameSchemeComboBox.Items.Add(renameSchemeComboBox.Text);
					renameSchemeComboBox.SelectedItem = renameSchemeComboBox.Text;
					}
				}

			RenameJob.renameScheme = renameSchemeComboBox.Text;
			SaveProgramSettings();
			}

		private void renameSelectedButton_Click(object sender, EventArgs e)
			{
			if (fileListBox.SelectedItem != null)
				{
				foreach (Object obj in fileListBox.SelectedItems)
					{
					RenameJob rj = obj as RenameJob;
					if (rj != null)
						{
						globalJobs.Remove(rj.GetHashCode());
						rj.RenameFile();
						globalJobs.Add(rj.GetHashCode(), rj);
						}
					}
				SaveMetadata();
				UpdateListBox();
				}
			}

		private void recoverOriginalFilenameButton_Click(object sender, EventArgs e)
			{
			if (fileListBox.SelectedItems.Count > 0)
				{
				foreach (Object obj in fileListBox.SelectedItems)
					{
					RenameJob rj = obj as RenameJob;
					if (rj != null)
						{
						globalJobs.Remove(rj.GetHashCode());
						rj.RecoverOriginalFilename();
						globalJobs.Add(rj.GetHashCode(), rj);
						}
					}
				SaveMetadata();
				UpdateListBox();
				}
			}

		private void selectAllButton_Click(object sender, EventArgs e)
			{
			for (int i = 0; i < fileListBox.Items.Count; i++)
				{
				fileListBox.SetSelected(i, true);
				}			
			}


		/// <summary>
		/// Speichert die Programmeinstellungen
		/// </summary>
		private void SaveProgramSettings()
			{
			if (doUpdateSettings)
				{
				XmlWriter xw = XmlWriter.Create(appDir + @"\" + "OTRRenameSettings.xml");

				// leeren XmlSerializerNamespaces Namespace erstellen
				XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
				xsn.Add("", "");

				xw.WriteStartElement("OTRRenameSettings");

				xw.WriteStartAttribute("version");
				xw.WriteString("1");
				xw.WriteEndAttribute();

				xw.WriteStartElement("SaveGlobal");
				xw.WriteString((saveGlobalCheckBox.Checked ? "1" : "0"));
				xw.WriteEndElement();
				xw.WriteStartElement("SaveLocal");
				xw.WriteString((saveLocalCheckBox.Checked ? "1" : "0"));
				xw.WriteEndElement();
				xw.WriteStartElement("Autosave");
				xw.WriteString((autosaveCheckBox.Checked ? "1" : "0"));
				xw.WriteEndElement();

				xw.WriteStartElement("CurrentDir");
				xw.WriteString(dirTextBox.Text);
				xw.WriteEndElement();

				for (int i = 0; i < renameSchemeComboBox.Items.Count; i++)
					{
					xw.WriteStartElement("RenameScheme");
					if (i == renameSchemeComboBox.SelectedIndex)
						{
						xw.WriteStartAttribute("selected");
						xw.WriteString("1");
						xw.WriteEndAttribute();
						}
					xw.WriteString(renameSchemeComboBox.Items[i].ToString());
					xw.WriteEndElement();
					}

				xw.WriteEndElement();
				xw.Close();
				}
			}

		/// <summary>
		/// Läd die Programmeinstellungen
		/// </summary>
		public void LoadProgramSettings()
			{
			int XmlVersion = 1;

			// XML Datei lesen, falls vorhanden
			if (File.Exists(appDir + @"\OTRRenameSettings.xml"))
				{
				// Dokument laden
				XmlDocument doc = new XmlDocument();
				doc.Load(appDir + @"\OTRRenameSettings.xml");

				XmlNode mainNode = doc.SelectSingleNode("//OTRRenameSettings");
				XmlVersion = Int32.Parse(mainNode.Attributes.GetNamedItem("version").Value);

				foreach (XmlNode child in mainNode.ChildNodes)
					{
					if (child.Name == "SaveGlobal")
						{
						saveGlobalCheckBox.Checked = (child.InnerText == "1") ? true : false;
						}
					else if (child.Name == "SaveLocal")
						{
						saveLocalCheckBox.Checked = (child.InnerText == "1") ? true : false;
						}
					else if (child.Name == "Autosave")
						{
						autosaveCheckBox.Checked = (child.InnerText == "1") ? true : false;
						}
					else if (child.Name == "CurrentDir")
						{
						dirTextBox.Text = child.InnerText;
						}
					else if (child.Name == "RenameScheme")
						{
						string text = child.InnerText;
						renameSchemeComboBox.Items.Add(text);

						XmlNode foo = child.Attributes.GetNamedItem("selected");
						if (foo != null && foo.Value.Equals("1"))
							{
							renameSchemeComboBox.SelectedItem = text;
							RenameJob.renameScheme = text;
							}
						}
					}
				}
			}

		private void saveInGlobalFolderCheckBox_CheckedChanged(object sender, EventArgs e)
			{
			if (saveGlobalCheckBox.Checked)
				{
				ReadIntoGlobalJobs(appDir + @"\OTRRenameMetadata.xml");
				}
			SaveProgramSettings();
			}

		private void saveLocalCheckBox_CheckedChanged(object sender, EventArgs e)
			{
			SaveProgramSettings();
			}

		private void autosaveCheckBox_CheckedChanged(object sender, EventArgs e)
			{
			SaveProgramSettings();
			}

		private void dirTextBox_TextChanged(object sender, EventArgs e)
			{
			while (dirTextBox.Text.Substring(dirTextBox.Text.Length-1) == @"\")
				{
				dirTextBox.Text = dirTextBox.Text.Substring(0, dirTextBox.Text.Length - 1);
				}
			}

		private void aboutButton_Click(object sender, EventArgs e)
			{
			AboutBox ab = new AboutBox();
			ab.Show();
			}

		private void htmlExportButton_Click(object sender, EventArgs e)
			{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.Filter = "HTML-Dateien|*.html";
			sfd.AddExtension = true;
			sfd.DefaultExt = "html";

			if (sfd.ShowDialog() == DialogResult.OK)
				{
				ExportGlobalJobsToHTMLFile(sfd.FileName);
				}
			}

		/// <summary>
		/// exportiert alle Daten in globalJobs in eine HTML Datei
		/// </summary>
		/// <param name="p">Dateiname, wodrunter gespeichert werden soll</param>
		private void ExportGlobalJobsToHTMLFile(string filename)
			{
			MergeJobs();
			try
				{
				TextWriter tw = File.CreateText(filename);
				tw.Write(@"
<html>
<head>
	<title>OTR-Video-Sammlung</title>
	<style>
	table {
		font-family: Calibri, Verdana;
		font-size: 10pt;
		color: black;
	}

	table.filme {
		width: 90%;
		border: 2px solid #6080A9;
		align: center;
	}

	th.filme {
		border: 1px solid #6080A9;
		font-weigth: bold;
		color: #0D3553;
		padding: 1px;
	}

	td.filme {
		border: 1px solid #6080A9;
		padding: 1px;
		text-align: center;
	}
	</style>
</head>
<body bgcolor=""#EEEEEE"" link=""#0D3553"" vlink=""#0D3553"" alink=""#FF0000"" hover=""#FF0000"">
<h1>OTR-Video-Sammlung</h1>

<center>
	<table cellspacing=""0"" cellpadding=""0"" class=""filme"">
	<tr>
		<th class=""filme"">Titel</th>
		<th class=""filme"">Datum/Zeit</th>
		<th class=""filme"">Sender</th>
		<th class=""filme"">Dauer</th>
		<th class=""filme"">sonstiges</th>
	</tr>");

				// global Jobs sortieren
				List<RenameJob> foo = new List<RenameJob>();
				foreach (RenameJob rj in globalJobs.Values)
					{
					foo.Add(rj);
					}
				foo.Sort(delegate(RenameJob a, RenameJob b) { return a.title.CompareTo(b.title); });

				foreach (RenameJob rj in foo)
					{
					tw.Write(@"
	<tr>
		<td class=""filme"">" + rj.title + @"</td>
		<td class=""filme"">" + rj.date.ToString("dd.MM.yy, hh:mm") + @"</td>
		<td class=""filme"">" + rj.channel + @"</td>
		<td class=""filme"">" + rj.duration.ToString() + @" min</td>
		<td class=""filme"">" + (rj.isHQ ? "HQ" : "") + (rj.isTopTipp ? " TopTipp" : "") + @"</td>
	</tr>
");
					}

				tw.Write(@"
	</table>
</center>
</body>
</html>");

				tw.Close();
				}

			catch (Exception e)
				{
				MessageBox.Show("Ein Fehler ist aufgetreten: " + e.Message);
				}
			}

		private void uebernehmenButton_Click(object sender, EventArgs e)
			{
			settingsChanged(this, e);
			}

		private void removeRenameSchemeFromListButton_Click(object sender, EventArgs e)
			{
			if (renameSchemeComboBox.SelectedItem != null)
				{
				renameSchemeComboBox.Items.Remove(renameSchemeComboBox.SelectedItem);
				SaveProgramSettings();
				}
			}

		private void isHDCheckBox_CheckedChanged(object sender, EventArgs e)
			{
			UpdateListFromSettings();
			}
		}
	}
