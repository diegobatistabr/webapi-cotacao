using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using seguradora.domain.Abstractions.Service;
using seguradora.domain.ExternalServices;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace seguradora.domain.Services
{
    public class SeguradoService : ISeguradoService
    {
        IServiceProvider _provider;
        Segurado _segurado;

        public SeguradoService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void CarregarDados(string nome, DateTime nascimento, string Logradouro, string Bairro, string CEP, string Cidade)
        {
            _segurado = new Segurado(nome, nascimento, Logradouro, Bairro, CEP, Cidade);
        }

        private void ValidarCidade()
        {
            var cidades = _provider.GetService<ICidades>().ObterTodas();

            // TODO: Podemos Colocar a Lista de Cidades em um Cache distribuido para evitar requests desnecessarios.

            var citQtd = (from cidade in cidades.cities
                          where cidade.name == _segurado.Endereco.Cidade
                          select new { Name = cidades.cities }).Count();

            if (citQtd == 0)
                _segurado.ValidationResult.Errors.Add(new ValidationFailure("Cidade", "Cidade não existente!"));
        }

        public bool EhValido()
        {
            _segurado.Validar();
            ValidarCidade();
            return _segurado.ValidationResult.IsValid;
        }

        public IList<ValidationFailure> ObterErrosDeValidacao()
        {
            return _segurado.ValidationResult.Errors;
        }

    }
}
