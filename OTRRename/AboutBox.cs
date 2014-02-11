﻿/**
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
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace OTRRename
	{
	partial class AboutBox : Form
		{
		public AboutBox()
			{
			InitializeComponent();
			/*
			this.Text = String.Format("Info über {0} {0}", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("Version {0} {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
			this.labelCompanyName.Text = AssemblyCompany;
			this.textBoxDescription.Text = AssemblyDescription;
			 * */
			}

		#region Assemblyattributaccessoren

		public string AssemblyTitle
			{
			get
				{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
					{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "")
						{
						return titleAttribute.Title;
						}
					}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
				}
			}

		public string AssemblyVersion
			{
			get
				{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
				}
			}

		public string AssemblyDescription
			{
			get
				{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
					{
					return "";
					}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
				}
			}

		public string AssemblyProduct
			{
			get
				{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
					{
					return "";
					}
				return ((AssemblyProductAttribute)attributes[0]).Product;
				}
			}

		public string AssemblyCopyright
			{
			get
				{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
					{
					return "";
					}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
				}
			}

		public string AssemblyCompany
			{
			get
				{
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
					{
					return "";
					}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
				}
			}
		#endregion

		private void okButton_Click(object sender, EventArgs e)
			{
			this.Close();
			}

		private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
			{

			}

		}
	}
