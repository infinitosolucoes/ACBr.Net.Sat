// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 05-07-2016
//
// Last Modified By : RFTD
// Last Modified On : 05-07-2016
// ***********************************************************************
// <copyright file="CancInfCFe.cs" company="ACBr.Net">
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
using System;
using ACBr.Net.Core.Extensions;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class CancInfCFe. This class cannot be inherited.
	/// </summary>
	public sealed class CancInfCFe
	{
		#region Fields

		private string id;

		#endregion Fields

		#region Propriedades

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[DFeAttribute(TipoCampo.Str, "Id", Id = "A04", Ocorrencias = 1)]
		public string Id
		{
			get { return id; }
			set
			{
				id = value.SafeReplace("CFe", string.Empty);
			}
		}

		/// <summary>
		/// Gets the versao.
		/// </summary>
		/// <value>The versao.</value>
		[DFeAttribute(TipoCampo.De2, "versao", Id = "A05", Min = 4, Max = 9, Ocorrencias = 1)]
		public decimal Versao { get; set; }

		/// <summary>
		/// Gets or sets the ch canc.
		/// </summary>
		/// <value>The ch canc.</value>
		[DFeAttribute(TipoCampo.Str, "chCanc", Id = "A06", Ocorrencias = 1)]
		public string ChCanc { get; set; }

		/// <summary>
		/// Gets or sets the dh emissao.
		/// </summary>
		/// <value>The dh emissao.</value>
		[DFeIgnore]
		public DateTime? DhEmissao { get; set; }

		/// <summary>
		/// Gets or sets the d emi.
		/// </summary>
		/// <value>The d emi.</value>
		[DFeElement(TipoCampo.DatCFe, "dEmi", Id = "A07", Min = 8, Max = 8, Ocorrencias = 0)]
		public DateTime DEmi
		{
			get { return DhEmissao ?? DateTime.MinValue; }
			set
			{
				DhEmissao = value.Date + (DhEmissao?.TimeOfDay ?? DateTime.MinValue.TimeOfDay);
			}
		}

		/// <summary>
		/// Gets or sets the h emi.
		/// </summary>
		/// <value>The h emi.</value>
		[DFeElement(TipoCampo.HorCFe, "hEmi", Id = "A08", Min = 6, Max = 6, Ocorrencias = 0)]
		public DateTime HEmi
		{
			get { return DhEmissao ?? DateTime.MinValue; }
			set
			{
				DhEmissao = (DhEmissao?.Date ?? DateTime.MinValue.Date) + value.TimeOfDay;
			}
		}

		#endregion Propriedades

		#region Methods

		private bool ShouldSerializeId()
		{
			return !Id.IsEmpty();
		}

		private bool ShouldSerializeVersao()
		{
			return Versao > 0;
		}

		private bool ShouldSerializeDEmi()
		{
			return DhEmissao.HasValue;
		}

		private bool ShouldSerializeHEmi()
		{
			return DhEmissao.HasValue;
		}

		#endregion Methods
	}
}