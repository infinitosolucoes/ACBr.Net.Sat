﻿// ***********************************************************************
// Assembly         : ACBr.Net.Sat
// Author           : RFTD
// Created          : 03-31-2016
//
// Last Modified By : RFTD
// Last Modified On : 03-31-2016
// ***********************************************************************
// <copyright file="SatResposta.cs" company="ACBr.Net">
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
// <summary>
// Classe feita para tratar o retorno do SAT
// </summary>
// ***********************************************************************
using System.Collections.Generic;
using ACBr.Net.Core.Extensions;

namespace ACBr.Net.Sat
{
	/// <summary>
	/// Class SatResposta.
	/// </summary>
	public class SatResposta
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SatResposta"/> class.
		/// </summary>
		public SatResposta()
		{
			RetornoLst = new List<string>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SatResposta"/> class.
		/// </summary>
		/// <param name="resposta">The resposta.</param>
		public SatResposta(string resposta) : this()
		{
			/*
			***** RETORNOS DO SAT POR COMANDO *****
			AtivarSAT....................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, CSR
			ComunicarCertificadoICPBRASIL: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			EnviarDadosVenda.............: numeroSessao, EEEEE, CCCC, mensagem, cod, mensagemSEFAZ, base64, timeStamp, chaveConsulta, valorTotalCFe, CPFCNPJValue, assinaturaQRCOD
			CancelarUltimaVenda..........: numeroSessao, EEEEE, CCCC, mensagem, cod, mensagemSEFAZ, base64, timeStamp, chaveConsulta, valorTotalCFe, CPFCNPJValue, assinaturaQRCOD
			ConsultarSAT.................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			TesteFimAFim.................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, base64, timeStamp, numDocFiscal, chaveConsulta
			ConsultarStatusOperacional...: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, ConteudoRetorno
			ConsultarNumeroSessao........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ   (ou retorno da Sessão consultada)
			ConfigurarInterfaceDeRede....: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			AssociarAssinatura...........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			AtualizarSoftwareSAT.........: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			ExtrairLogs..................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ, base64
			BloquearSAT..................: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			DesbloquearSAT...............: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ
			TrocarCodigoDeAtivacao.......: numeroSessao, EEEEE, mensagem, cod, mensagemSEFAZ  
			*/

			RetornoStr = resposta;
			RetornoLst.AddRange(resposta.Split('|'));

			if (RetornoLst.Count > 1)
			{
				NumeroSessao = RetornoLst[0].ToInt32();
				CodigoDeRetorno = RetornoLst[1].ToInt32();
			}

			var idx = 2;
			//Enviar e Cancelar venda tem um campo a mais no inicio da resposta(CCCC)
			var value = RetornoLst[idx].Trim();
			if (value.Length == 4 && value.IsNumeric())
			{
				CodigoDeErro = RetornoLst[idx].ToInt32();
				idx++;
			}

			if (RetornoLst.Count > idx + 2)
			{
				MensagemRetorno = RetornoLst[idx];
				CodigoSEFAZ = RetornoLst[idx+1].ToInt32();
				MensagemSEFAZ = RetornoLst[idx+2];
			}
			else
			{
				MensagemRetorno = resposta;
			}
		}

		#endregion Constructors

		#region Propriedades

		/// <summary>
		/// Gets or sets the numero sessao.
		/// </summary>
		/// <value>The numero sessao.</value>
		public int NumeroSessao { get; set; }

		/// <summary>
		/// Gets or sets the codigo de retorno.
		/// </summary>
		/// <value>The codigo de retorno.</value>
		public int CodigoDeRetorno { get; set; }

		/// <summary>
		/// Gets or sets the codigo de erro.
		/// </summary>
		/// <value>The codigo de erro.</value>
		public int CodigoDeErro { get; set; }

		/// <summary>
		/// Gets or sets the mensagem retorno.
		/// </summary>
		/// <value>The mensagem retorno.</value>
		public string MensagemRetorno { get; set; }

		/// <summary>
		/// Gets or sets the codigo sefaz.
		/// </summary>
		/// <value>The codigo sefaz.</value>
		public int CodigoSEFAZ { get; set; }

		/// <summary>
		/// Gets or sets the mensagem sefaz.
		/// </summary>
		/// <value>The mensagem sefaz.</value>
		public string MensagemSEFAZ { get; set; }

		/// <summary>
		/// Gets the retorno LST.
		/// </summary>
		/// <value>The retorno LST.</value>
		public List<string> RetornoLst { get; set; }

		/// <summary>
		/// Gets or sets the retorno string.
		/// </summary>
		/// <value>The retorno string.</value>
		public string RetornoStr { get; set; }

		#endregion Propriedades
	}
}