using seguradora.domain.Models;
using seguradora.domain.StrategyModels;
using System;
using System.Collections.Generic;

namespace seguradora.domain.Abstractions.Service
{
    public interface ICotacaoService : IBaseService
    {
        void CarregaDados(IList<string> coberturas, DateTime dataNascimento);
        Cotacao Calcular();
    }
}
