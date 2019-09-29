using FluentValidation.Results;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;

namespace seguradora.domain.Abstractions.Service
{
    public interface ISeguradoService : IBaseService
    {
        void CarregarDados(string nome, DateTime nascimento, string Logradouro, string Bairro, string CEP, string Cidade);
    }
}
