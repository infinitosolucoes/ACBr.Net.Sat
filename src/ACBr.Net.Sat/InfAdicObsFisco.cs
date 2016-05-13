// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 04-29-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-02-2016
// ***********************************************************************
// <copyright file="InfAdicObsFisco.cs" company="ACBr.Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2016 Grupo ACBr.Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining 
// a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the 
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be 
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using ACBr.Net.DFe.Core.Attributes;
using PropertyChanged;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class InfAdicObsFisco. This class cannot be inherited.
	/// </summary>
	[ImplementPropertyChanged]
	public sealed class InfAdicObsFisco
	{
		/// <summary>
		/// Gets or sets the x campo.
		/// </summary>
		/// <value>The x campo.</value>
		[DFeAttribute("xCampo", Id = "Z04", Min = 1, Max = 20, Ocorrencias = 1)]
		public string XCampo { get; set; }

		/// <summary>
		/// Gets or sets the x texto.
		/// </summary>
		/// <value>The x texto.</value>
		[DFeAttribute("xTexto", Id = "Z05", Min = 1, Max = 60, Ocorrencias = 1)]
		public string XTexto { get; set; }
	}
}