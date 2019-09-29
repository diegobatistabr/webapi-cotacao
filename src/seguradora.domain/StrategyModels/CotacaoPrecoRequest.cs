using seguradora.domain.Models;
using System;
using System.Collections.Generic;

namespace seguradora.domain.StrategyModels
{
    public class CotacaoPrecoRequest
    {
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public EnderecoS Endereco { get; set; }
        public IList<string> coberturas { get; set; }
        
        public class EnderecoS
        {
            public string Logradouro { get; set; }
            public string Bairro { get; set; }
            public string CEP { get; set; }
            public string Cidade { get; set; }
        }

    }
}
