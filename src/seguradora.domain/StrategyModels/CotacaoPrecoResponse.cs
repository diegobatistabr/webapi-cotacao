using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.domain.StrategyModels
{
    public class CotacaoPrecoResponse
    {
        public decimal Premio { get; set; }
        public int Parcelas { get; set; }
        public decimal Valor_Parcelas { get; set; }
        public DateTime Primeiro_Vencimento { get; set; }
        public decimal Cobertura_Total { get; set; }
    }
}
