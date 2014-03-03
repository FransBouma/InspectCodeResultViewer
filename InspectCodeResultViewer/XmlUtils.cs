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
	/// Simple set of XML utility methods / extension methods which make it easier to load the XML file. 
	/// </summary>
	/// <remarks>From LLBLGen Pro v4.x designer sourcecode</remarks>
	public static class XmlUtils
	{
		/// <summary>
		/// Prepares the reader for first read. This means that if the reader is in the initial state, a Read is executed. If the first read then sees an
		/// XML declaration, it's skipped as well
		/// </summary>
		/// <param name="reader">The reader.</param>
		public static bool PrepareReaderForFirstRead(this XmlReader reader)
		{
			bool toReturn = false;
			if((reader == null) || reader.EOF)
			{
				return toReturn;
			}
			try
			{
				if(reader.ReadState == ReadState.Initial)
				{
					reader.Read();
				}
				if(reader.NodeType == XmlNodeType.XmlDeclaration)
				{
					reader.Read();
				}
				toReturn = true;
			}
			catch
			{
				// ignore.
			}
			return toReturn;
		}
		

		/// <summary>
		/// Gets the value of an optional attribute. If the attribute isn't present, string.Empty is returned.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader">The reader.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="conversionFunc">The conversion func.</param>
		/// <returns></returns>
		public static T GetOptionalAttribute<T>(this XmlReader reader, string attributeName, Func<string, T> conversionFunc)
		{
			return GetOptionalAttribute(reader, attributeName, conversionFunc, default(T));
		}


		/// <summary>
		/// Gets the value of an optional attribute. If the attribute isn't present, defaultValue is returned.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="reader">The reader.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="conversionFunc">The conversion func.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns></returns>
		public static T GetOptionalAttribute<T>(this XmlReader reader, string attributeName, Func<string, T> conversionFunc, T defaultValue)
		{
			T toReturn = defaultValue;
			string attributeValue = reader.GetAttribute(attributeName);
			if(attributeValue != null)
			{
				toReturn = conversionFunc(attributeValue);
			}
			return toReturn;
		}


		/// <summary>
		/// Gets the mandatory attribute. if it's not found, an XmlException is thrown
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <returns></returns>
		public static string GetMandatoryAttribute(this XmlReader reader, string attributeName)
		{
			string attributeValue = reader.GetAttribute(attributeName);
			if(attributeValue == null)
			{
				throw new XmlException(string.Format("Attribute '{0}' not found", attributeName));
			}
			return attributeValue;
		}


		/// <summary>
		/// Gets a new subtree reader which is prepared and is positioned at the same node the passed in reader is on, so any subsequential read moves automatically
		/// to any subelements available
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns></returns>
		public static XmlReader GetSubtreeReader(this XmlReader reader)
		{
			while(!reader.EOF && (reader.NodeType != XmlNodeType.Element))
			{
				reader.Read();
			}
			XmlReader toReturn = reader.ReadSubtree();
			toReturn.PrepareReaderForFirstRead();
			return toReturn;
		}


		/// <summary>
		/// Reads the next element. This routine is similar to Read() but it returns false on EOF and when reader is on an end element and the element isn't
		/// an empty element. Read() only returns false when it's hit EOF. Use this on a reader created with GetSubtreeReader.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>true if there are elements left to read, false if EOF is reached or the reader is positioned on an end element which isn't an empty element.</returns>
		public static bool ReadNext(this XmlReader reader)
		{
			bool toReturn = reader.Read();
			toReturn &= !((reader.NodeType == XmlNodeType.EndElement) && !reader.IsEmptyElement);
			return toReturn;
		}


		/// <summary>
		/// Reads a CData element. It assumes reader is positioned on the start element of the CData element
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns></returns>
		/// <remarks>Advances the reader to the next element following the CData element.</remarks>
		public static string ReadCDataElement(this XmlReader reader)
		{
			var toReturn = string.Empty;
			if(!reader.IsEmptyElement)
			{
				reader.Read();	// move to CData value
				toReturn = reader.Value;
				reader.Read();	// move to end element
			}
			return toReturn;
		}
		

		/// <summary>
		/// Creates a new XML text reader. It creates an XmlTextReader, as the XmlReader.Create() routine creates always a normalizing reader which always converts
		/// CRLFs into \n.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns>
		/// ready to use xmlreader. This reader is in its initial state
		/// </returns>
		public static XmlReader CreateXmlReader(string filename)
		{
			return new XmlTextReader(filename) { WhitespaceHandling = WhitespaceHandling.None };
		}
	}
}
