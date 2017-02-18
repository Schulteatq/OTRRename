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

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace OTRRename
	{
	/// <summary>
	/// Ein Umbenennungsauftrag
	/// </summary>
	[Serializable]
	public class RenameJob
		{
		#region statische Felder/Methoden

		/// <summary>
		/// Umbenennungsschema
		/// </summary>
		private static string m_renameScheme = @"<Title><HQ? [HQ]:>.<ext>";
		/// <summary>
		/// Umbenennungsschema
		/// </summary>
		[XmlIgnore]
		public static string renameScheme
			{
			get { return m_renameScheme; }
			set { m_renameScheme = value; }
			}


		/// <summary>
		/// Dictionairy welches den OTR Senderstrings die richtigen Namen zuordnet
		/// z.B.: kabel1 => Kabel 1
		/// </summary>
		private static Dictionary<string, string> channelsDict = new Dictionary<string, string>();

		/// <summary>
		/// wurde channels schon initialisiert?
		/// </summary>
		private static bool channelsDictInitialized = false;

		/// <summary>
		/// initialisiert channelsDict, falls nötig
		/// </summary>
		private static void initializeChannelsDict()
			{
			if (! channelsDictInitialized)
				{
				channelsDict.Add("ard", "ARD");
				channelsDict.Add("zdf", "ZDF");
				channelsDict.Add("pro7", "Pro7");
				channelsDict.Add("rtl", "RTL");
				channelsDict.Add("rtl2", "RTL 2");
				channelsDict.Add("vox", "VOX");
				channelsDict.Add("arte", "ARTE");
				channelsDict.Add("kabel1", "Kabel 1");
				channelsDict.Add("sat1", "SAT.1");
				channelsDict.Add("wdr", "WDR");
				channelsDict.Add("3sat", "3sat");
				channelsDict.Add("das4", "Das Vierte");
				channelsDict.Add("srtl", "Super RTL");
				channelsDict.Add("ndr", "NDR");
				channelsDict.Add("bay3", "Bayern 3");
				channelsDict.Add("tele5", "Tele 5");

				channelsDictInitialized = true;
				}
			}

		#endregion

		#region Felder für Infos rund um die konkrete Datei
		/// <summary>
		/// Pfad zur Datei ohne abschließenden Slash
		/// </summary>
		private string m_path = String.Empty;
		/// <summary>
		/// Pfad zur Datei ohne abschließenden Slash
		/// </summary>
		public string path
			{
			get { return m_path; }
			set { m_path = value; }
			}

		/// <summary>
		/// Original Dateiname, wie ihn OTR vergeben hat
		/// </summary>
		private string m_originalOTRFilename = String.Empty;
		/// <summary>
		/// Original Dateiname, wie ihn OTR vergeben hat
		/// </summary>
		public string originalOTRFilename
			{
			get { return m_originalOTRFilename; }
			set { m_originalOTRFilename = value; }
			}

		/// <summary>
		/// Dateiname nach den aktuellen Umbenennungsschema
		/// </summary>
		private string m_renamedFilename = String.Empty;
		/// <summary>
		/// Dateiname nach den aktuellen Umbenennungsschema
		/// </summary>
		[XmlIgnore]
		public string renamedFilename
			{
			get { return m_renamedFilename; }
			set { m_renamedFilename = value; }
			}

		/// <summary>
		/// Dateiname unter der das Video aktuell gespeichert ist
		/// </summary>
		private string m_currentFilename = String.Empty;
		/// <summary>
		/// Dateiname unter der das Video aktuell gespeichert ist
		/// </summary>
		public string currentFilename
			{
			get { return m_currentFilename; }
			set { m_currentFilename = value; }
			}

		/// <summary>
		/// Dateigröße
		/// </summary>
		private long m_filesize;
		/// <summary>
		/// Dateigröße
		/// </summary>
		public long filesize
			{
			get { return m_filesize; }
			set { m_filesize = value; }
			}

		#endregion


		#region Metadaten

        /// <summary>
        /// Filmtitel
        /// </summary>
        private string m_title = String.Empty;
        /// <summary>
        /// Filmtitel
        /// </summary>
        public string title
            {
            get { return m_title; }
            set { m_title = value; }
            }

        /// <summary>
        /// Filmtitel
        /// </summary>
        private string m_extension = String.Empty;
        /// <summary>
        /// Filmtitel
        /// </summary>
        public string extension
            {
            get { return m_extension; }
            set { m_extension = value; }
            }

		/// <summary>
		/// Datum und Zeit des Films
		/// </summary>
		private DateTime m_date = new DateTime(2000, 1,1);
		/// <summary>
		/// Datum und Zeit des Films
		/// </summary>
		public DateTime date
			{
			get { return m_date; }
			set { m_date = value; }
			}

		/// <summary>
		/// Sender
		/// </summary>
		private string m_channel = String.Empty;
		/// <summary>
		/// Sender
		/// </summary>
		public string channel
			{
			get { return m_channel; }
			set { m_channel = value; }
			}

		/// <summary>
		/// Dauer in Minuten (uncut)
		/// </summary>
		private decimal m_duration = 0;
		/// <summary>
		/// Dauer in Minuten (uncut)
		/// </summary>
		public decimal duration
			{
			get { return m_duration; }
			set { m_duration = value; }
			}


		/// <summary>
		/// HQ Aufnahme?
		/// </summary>
		private bool m_isHQ = false;
		/// <summary>
		/// HQ Aufname?
		/// </summary>
		public bool isHQ
			{
			get { return m_isHQ; }
			set { m_isHQ = value; }
			}

		/// <summary>
		/// HD Aufnahme?
		/// </summary>
		private bool m_isHD = false;
		/// <summary>
		/// HD Aufnahme?
		/// </summary>
		public bool isHD
			{
			get { return m_isHD; }
			set { m_isHD = value; }
			}


		/// <summary>
		/// ists angeblich ein Top Tipp?
		/// </summary>
		private bool m_isTopTipp = false;
		/// <summary>
		/// ists angeblich ein Top Tipp?
		/// </summary>
		public bool isTopTipp
			{
			get { return m_isTopTipp; }
			set { m_isTopTipp = value; }
			}


		/// <summary>
		/// Zusatzdaten #1
		/// </summary>
		private string m_additionalData1 = "";
		/// <summary>
		/// Zusatzdaten #1
		/// </summary>
		public string additionalData1
			{
			get { return m_additionalData1; }
			set { m_additionalData1 = value; }
			}

		/// <summary>
		/// Zusatzdaten #2
		/// </summary>
		private string m_additionalData2 = "";
		/// <summary>
		/// Zusatzdaten #2
		/// </summary>
		public string additionalData2
			{
			get { return m_additionalData2; }
			set { m_additionalData2 = value; }
			}


		#endregion

		/// <summary>
		/// leerer Standardkonstruktor für XML Serialisierung
		/// </summary>
		public RenameJob()
			{
			initializeChannelsDict();
			}

		/// <summary>
		/// Standardkonstruktor, erstellt einen neuen RenameJob
		/// </summary>
		/// <param name="path">Pfad zur Datei ohne abschließenden Slash</param>
		/// <param name="currentFilename">aktueller Dateiname ohne Pfad</param>
		public RenameJob(string path, string currentFilename)
			{
			initializeChannelsDict();

			this.path = path;
			this.currentFilename = currentFilename;

			FileInfo fi = new FileInfo(Path.Combine(path,currentFilename));
			this.filesize = fi.Length;
			}


		/// <summary>
		/// Gibt diesen RenameJob als String zurück
		/// </summary>
		/// <returns>"vorher -> nachher"</returns>
		public override string ToString()
			{
			return currentFilename  + " -> " + renamedFilename;
			}


		/// <summary>
		/// Versucht aus originalOTRFilename die Dateiinfos zu parsen
		/// <pre>originalOTRFilename != ""</pre>
		/// </summary>
		public void ParseFileInfos()
			{
			FileInfo fi = new FileInfo(originalOTRFilename);
			string oldName = fi.Name;

			string[] separated = oldName.Split('_');

			int i = 0;
			while (i+1 < separated.Length)
				{
				// Datum und Zeit
				if ((Regex.IsMatch(separated[i], @"\d\d\.\d\d\.\d\d") && Regex.IsMatch(separated[i+1], @"\d\d\-\d\d")))
					{
					date = new DateTime(
						2000 + Int32.Parse(separated[i].Substring(0, 2)),
						Int32.Parse(separated[i].Substring(3, 2)),
						Int32.Parse(separated[i].Substring(6, 2)),
						Int32.Parse(separated[i + 1].Substring(0, 2)),
						Int32.Parse(separated[i + 1].Substring(3, 2)),
						0);
					i += 2;
					break;
					}

				// Bei Top Tipp
				else if (separated[i].Equals("Top") && separated[i + 1].Equals("Tipp"))
					{
					isTopTipp = true;
					i++;
					}

				// sonst an den Titel ranhängen
				else
					{
					title += " " + separated[i];
					}

				i++;
				}

			// Titel trimmen
			title = title.Trim();
            // Remove int prefix 
            title = Regex.Replace(title, @"^\d{5} ", String.Empty);

			if (i+1 < separated.Length)
				{
				// nun noch Sender, Zeit und HQ parsen
				channel = separated[i];
				if (channelsDict.ContainsKey(channel))
					{
					channelsDict.TryGetValue(channel, out m_channel);
					}
				duration = Int32.Parse(separated[i + 1]);
				isHQ = Regex.IsMatch(separated[separated.Length - 1], @"mpg\.HQ\.");
				isHD = Regex.IsMatch(separated[separated.Length - 1], @"mpg\.HD\.");
				}

            extension = Path.GetExtension(oldName);

			// doppelt gemoppelt: CreateNachher();
			}


		/// <summary>
		/// berechnet den neuen Dateinamen
		/// </summary>
		/// 
		/// Ersetzungsmuster:
		/// <Title> - Titel
		/// <YY>, <YYYY> - Jahr (kurz, lang)
		/// <M>, <MM>, <MMM> - Monat
		/// <D>, <DD>, <DDD> - Tag
		/// <H>, <HH> - Stunde
		/// <N>, <NN> - Minute
		/// <S>, <SS> - Sekunde
		/// <Duration> - Dauer
		/// <HQ?Text1:Text2> - Text1 falls HQ, Text2 falls kein HQ
		/// <TopTipp?Text1:Text2> - Text1 falls Top Tipp, Text2 falls nicht
		public void CreateNachher()
			{
			renamedFilename = renameScheme;
            renamedFilename = Regex.Replace(renamedFilename, @"<Title>", title);
            renamedFilename = Regex.Replace(renamedFilename, @".<ext>", extension);

			renamedFilename = Regex.Replace(renamedFilename, @"<YY>", date.ToString("yy"));
			renamedFilename = Regex.Replace(renamedFilename, @"<YYYY>", date.ToString("yyyy"));
			renamedFilename = Regex.Replace(renamedFilename, @"<M>", date.ToString("M"));
			renamedFilename = Regex.Replace(renamedFilename, @"<MM>", date.ToString("MM"));
			renamedFilename = Regex.Replace(renamedFilename, @"<MMM>", date.ToString("MMM"));
			renamedFilename = Regex.Replace(renamedFilename, @"<MMMM>", date.ToString("MMMM"));
			renamedFilename = Regex.Replace(renamedFilename, @"<D>", date.ToString("d"));
			renamedFilename = Regex.Replace(renamedFilename, @"<DD>", date.ToString("dd"));
			renamedFilename = Regex.Replace(renamedFilename, @"<DDD>", date.ToString("ddd"));

			//nachher = Regex.Replace(nachher, @"<H>", date.ToString("h"));
			//renamedFilename = Regex.Replace(renamedFilename, @"<h>", date.ToString("h"));
			renamedFilename = Regex.Replace(renamedFilename, @"<HH>", date.ToString("HH"));
			renamedFilename = Regex.Replace(renamedFilename, @"<hh>", date.ToString("hh"));
			renamedFilename = Regex.Replace(renamedFilename, @"<m>", date.ToString("m"));
			renamedFilename = Regex.Replace(renamedFilename, @"<mm>", date.ToString("mm"));
			renamedFilename = Regex.Replace(renamedFilename, @"<s>", date.ToString("s"));
			renamedFilename = Regex.Replace(renamedFilename, @"<ss>", date.ToString("ss"));

			renamedFilename = Regex.Replace(renamedFilename, @"<Channel>", channel);

			renamedFilename = Regex.Replace(renamedFilename, @"<Duration>", duration.ToString());

			if (isHQ)
				renamedFilename = Regex.Replace(renamedFilename, @"\<HQ\?(?<yes>[^:]*):(?<no>[^>]*?)?\>", "${yes}");
			else
				renamedFilename = Regex.Replace(renamedFilename, @"\<HQ\?(?<yes>[^:]*):(?<no>[^>]*?)?\>", "${no}");

			if (isHD)
				renamedFilename = Regex.Replace(renamedFilename, @"\<HD\?(?<yes>[^:]*):(?<no>[^>]*?)\>", "${yes}");
			else
				renamedFilename = Regex.Replace(renamedFilename, @"\<HD\?(?<yes>[^:]*):(?<no>[^>]*?)\>", "${no}");

			if (isTopTipp)
				renamedFilename = Regex.Replace(renamedFilename, @"\<TopTipp\?(?<yes>[^:]*):(?<no>[^>]*?)\>", "${yes}");
			else
				renamedFilename = Regex.Replace(renamedFilename, @"\<TopTipp\?(?<yes>[^:]*):(?<no>[^>]*?)\>", "${no}");

			renamedFilename = Regex.Replace(renamedFilename, @"<Add1>", additionalData1);
			renamedFilename = Regex.Replace(renamedFilename, @"<Add2>", additionalData2);

			//renamedFilename = path + @"\" + renamedFilename;
			}


		/// <summary>
		/// Führt den Umbenennungsvorgang aus
		/// </summary>
		public void RenameFile()
			{
			try
				{
				File.Move(Path.Combine(path,currentFilename), Path.Combine(path,renamedFilename));
				currentFilename = renamedFilename;
				}
			catch (Exception ex)
				{
				System.Windows.Forms.MessageBox.Show("Beim Umbenennen von '" + currentFilename + "' zu '" + renamedFilename + "' ist ein Fehler aufgetreten: " + ex.Message);
				}
			}

		/// <summary>
		/// stellt den originalOTRFilename wieder her
		/// </summary>
		public void RecoverOriginalFilename()
			{
			try
				{
				File.Move(Path.Combine(path,currentFilename), Path.Combine(path,originalOTRFilename));
				currentFilename = originalOTRFilename;
				}
			catch (Exception ex)
				{
				System.Windows.Forms.MessageBox.Show("Beim Umbenennen von '" + currentFilename + "' ist ein Fehler aufgetreten: " + ex.Message);
				}
			}


		#region Hashes/Equals

		public override int GetHashCode()
			{
			return 3 * currentFilename.GetHashCode() + 5 * filesize.GetHashCode();
			}

		public override bool Equals(object obj)
			{
			if (obj == null)
				{
				return false;
				}
			if (this == obj)
				{
				return true;
				}
			RenameJob rj = obj as RenameJob;
			if ((rj != null)
					&& (rj.currentFilename == this.currentFilename)
					&& (rj.filesize == this.filesize))
				{
				return true;
				}

			return false;
			}

		public int hashcode
			{
			get { return GetHashCode(); }
			}
		#endregion
		}
	}
