using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using seguradora.domain.Abstractions.Service;
using seguradora.domain.Models;
using seguradora.domain.StrategyModels;
using System;
using System.Collections.Generic;

namespace seguradora.api.Controllers
{

    /// <summary>
    /// 
    /// </summary>
    [Route("cotacao")]
    [ApiController]
     public class SeguroController : ControllerBase
    {
        ISeguradoService _seguradoService;
        ICotacaoService _cotacaoService;
        ICoberturaService _coberturaService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seguradoService"></param>
        /// <param name="cotacaoService"></param>
        /// <param name="coberturaService"></param>
        public SeguroController(ISeguradoService seguradoService, ICotacaoService cotacaoService, ICoberturaService coberturaService)
        {
            _seguradoService = seguradoService;
            _cotacaoService = cotacaoService;
            _coberturaService = coberturaService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/price")]
        public IActionResult Post([FromBody] CotacaoPrecoRequest request)
        {
            _seguradoService.CarregarDados(request.Nome, request.Nascimento, request.Endereco.Logradouro, request.Endereco.Bairro, request.Endereco.CEP, request.Endereco.Cidade);

            if (!_seguradoService.EhValido()) return BadRequest(_seguradoService.ObterErrosDeValidacao());

            _cotacaoService.CarregaDados(request.coberturas, request.Nascimento);

            if (!_cotacaoService.EhValido())
            {
                return BadRequest(_cotacaoService.ObterErrosDeValidacao());
            }
            else
            {
                var cotacao = _cotacaoService.Calcular();            

                return Ok(new CotacaoPrecoResponse
                {
                    Premio = cotacao.Premio,
                    Parcelas = cotacao.Parcelas,
                    Primeiro_Vencimento = cotacao.Primeiro_Vencimento,
                    Cobertura_Total = cotacao.Cobertura_Total,
                    Valor_Parcelas = cotacao.Valor_Parcelas
                });
            }
        }

    }
}
