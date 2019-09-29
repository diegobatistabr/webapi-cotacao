using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using seguradora.domain.Abstractions.Repository;
using seguradora.domain.Abstractions.Service;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace seguradora.domain.Services
{
    public class CotacaoService : ICotacaoService
    {
        private DateTime _nascimento;
        private List<Cobertura> _coberturasSelecionadas;

        IServiceProvider _provider;
        Cotacao _cotacao;

        public CotacaoService(IServiceProvider provider)
        {
            _provider = provider;
            _cotacao = new Cotacao(); 
        }

        public void CarregaDados(IList<string> coberturas, DateTime dataNascimento)
        {     
            _nascimento = dataNascimento;
            _coberturasSelecionadas = _provider.GetService<ICoberturaRepository>().ObterTodos().Where(x => coberturas.Contains(x.Id)).ToList();
        }

        public Cotacao Calcular()
        {
            _cotacao.CalcularPremio(_nascimento, _coberturasSelecionadas);
            _cotacao.CalcularParcelas(_cotacao.Premio);
            _cotacao.CalcularValorParcelas();
            _cotacao.CalcularPrimeiroVencimento(5);
            _cotacao.CalcularCoberturaTotal(_coberturasSelecionadas);

            // TODO: Gravar no repositório a cotação finalizada.

            return _cotacao;
        }

        private void ValidarQtdCoberturas(List<Cobertura> coberturas)
        {
            if (coberturas.Distinct().Count() < 1)
                _cotacao.ValidationResult.Errors.Add(new ValidationFailure("Coberturas", "É obrigatório que seja enviada pelo menos um item para cobertura!"));

            if (coberturas.Distinct().Count() > 4)
                _cotacao.ValidationResult.Errors.Add(new ValidationFailure("Coberturas", "Não pode ser enviado mais de 4 itens para coberura do seguro!"));
            
            // Valida Item Obrigatório
            if (coberturas.Where(x => x.Obrigatorio == 'S').Count() <= 0)
                _cotacao.ValidationResult.Errors.Add(new ValidationFailure("Coberturas", "É necessario pelo menos ter um item Obrigatório na cotação!"));
        }

        public bool EhValido()
        {
            _cotacao.Validar();
            ValidarQtdCoberturas(_coberturasSelecionadas);
            return _cotacao.ValidationResult.IsValid;
        }

        public IList<ValidationFailure> ObterErrosDeValidacao()
        {
            return _cotacao.ValidationResult.Errors;
        }
    }
}
