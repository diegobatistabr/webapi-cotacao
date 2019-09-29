using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.domain.Models
{
    
    public class Cobertura : Base<Cobertura>
    {
        
        public string Nome { get; private set; }
        public decimal Premio { get; private set; }
        public decimal Valor { get; private set; }
        public char Obrigatorio { get; private set; }

        public Cobertura(string id, string nome, decimal premio, decimal valor, char obrigatorio )
        {
            Id = id;
            Nome = nome;
            Premio = premio;
            Valor = valor;
            Obrigatorio = obrigatorio;
        }

        public override bool Validar()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
