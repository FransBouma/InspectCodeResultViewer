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
	/// Class which contains all reported issues for a given project
	/// </summary>
	public class Project
	{
		#region Members
		private List<Issue> _issues;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="Project" /> class.
		/// </summary>
		/// <param name="containingReport">The containing report.</param>
		public Project(Report containingReport)
		{
			_issues = new List<Issue>();
			this.ContainingReport = containingReport;
		}


		/// <summary>
		/// Loads the issues for the project referenced by the specified reader into this instance.
		/// </summary>
		/// <param name="reader">The reader.</param>
		internal void Load(XmlReader reader)
		{
			using(var localReader = reader.GetSubtreeReader())
			{
				this.Name = localReader.GetMandatoryAttribute("Name");
				while(localReader.ReadNext())
				{
					// contains solely issue elements
					var issue = new Issue(this);
					issue.Load(localReader);
					_issues.Add(issue);
				}
			}
		}
		

		#region Properties
		public Report ContainingReport { get; private set; }
		public string Name { get; private set; }

		public List<Issue> KnownIssues 
		{
			get { return _issues; }
		}
		#endregion

	}
}
