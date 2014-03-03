//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2014 Solutions Design. All rights reserved.
// 
// This InspectCode result viewer is released under the following license: (BSD2)
// -------------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace InspectCodeResultViewer
{
	/// <summary>
	/// Represents an issue type as defined in the results xml file. 
	/// </summary>
	public class IssueType
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="IssueType" /> class.
		/// </summary>
		public IssueType()
		{
		}


		/// <summary>
		/// Loads the data for this issuetype from the specified local reader.
		/// </summary>
		/// <param name="localReader">The xml reader which is positioned on the IssueType element.</param>
		internal void Load(XmlReader localReader)
		{
			this.Id = localReader.GetMandatoryAttribute("Id");
			this.Category = localReader.GetMandatoryAttribute("Category");
			this.Description = localReader.GetMandatoryAttribute("Description");
			this.Severity = (SeverityType)Enum.Parse(typeof(SeverityType), localReader.GetMandatoryAttribute("Severity"), ignoreCase: true);
			this.Global = localReader.GetOptionalAttribute("Global", s => XmlConvert.ToBoolean(s.ToLowerInvariant()), false);
			this.WikiUrl = localReader.GetOptionalAttribute("WikiUrl", s => s, string.Empty);
			this.SubCategory = localReader.GetOptionalAttribute("SubCategory", s => s, string.Empty);
		}


		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return this.Id;
		}


		#region Properties
		public string Id { get; private set; }
		public string Category { get; private set; }
		public string Description { get; private set; }
		public string SubCategory { get; private set; }
		public SeverityType Severity { get; private set; }
		public bool Global { get; private set; }
		public string WikiUrl { get; private set; }
		#endregion
	}
}
