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
	/// Class which contains the information for a found issue. 
	/// </summary>
	public class Issue
	{
		#region Members
		private Project _containingProject;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Issue" /> class.
		/// </summary>
		/// <param name="containingProject">The containing project.</param>
		public Issue(Project containingProject)
		{
			_containingProject = containingProject;
		}


		/// <summary>
		/// Loads the issue data referenced by the specified local reader into this issue.
		/// </summary>
		/// <param name="localReader">The local reader.</param>
		internal void Load(XmlReader localReader)
		{
			this.TypeInstance = _containingProject.ContainingReport.GetKnownIssueType(localReader.GetMandatoryAttribute("TypeId"));
			this.File = localReader.GetMandatoryAttribute("File");
			string offsetRange = localReader.GetMandatoryAttribute("Offset");
			var offsetFragments = offsetRange.Split('-');
			this.StartOffset = XmlConvert.ToInt32(offsetFragments[0]);
			this.EndOffset = XmlConvert.ToInt32(offsetFragments[1]);
			this.Line = localReader.GetOptionalAttribute("Line", s=>XmlConvert.ToInt32(s), 1);
			this.Message = localReader.GetMandatoryAttribute("Message");
		}


		#region Properties
		public IssueType TypeInstance { get; private set; }
		public string File { get; private set; }
		public int StartOffset { get; private set; }
		public int EndOffset { get; private set; }
		public int Line { get; private set; }
		public string Message { get; private set; }
		#endregion

	}
}
