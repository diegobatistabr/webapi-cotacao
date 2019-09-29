using FluentValidation;
using FluentValidation.Results;
using System;

namespace seguradora.domain.Models
{
    public class Segurado : Base<Segurado>
    {
        public string Nome { get; private set; }
        public DateTime Nascimento { get; private set; }
        public EnderecoSeg Endereco { get; private set; }

        public Segurado(string nome, DateTime nascimento, string Logradouro, string Bairro, string CEP, string Cidade)
        {
            Nome = nome;
            Nascimento = nascimento;
            Endereco =  new EnderecoSeg(Logradouro,Bairro,CEP,Cidade);           
        }

        public override bool Validar()
        {
            ValidarModelo();
            return ValidationResult.IsValid;
        }

        public void ValidarModelo()
        {
            ValidarMaiorIdade();
            ValidationResult = Validate(this);
            ValidarEndereco();
        }

        public void ValidarMaiorIdade()
        {
            RuleFor(x => Nascimento).Custom((x, context) => { if (Nascimento.AddYears(18) > DateTime.Now) { context.AddFailure("É Preciso ser Maior de 18!"); } });
        }

        public void ValidarEndereco()
        {
            if (Endereco.Validar()) return;

            foreach (var error in Endereco.ValidationResult.Errors)
            {
                this.ValidationResult.Errors.Add(error);
            }
        }

        public class EnderecoSeg : Base<EnderecoSeg>
        {
            public string Logradouro { get; private set; }
            public string Bairro { get; private set; }
            public string CEP { get; private set; }
            public string Cidade { get; private set; }
            public EnderecoSeg(string logradouro, string bairro, string cep, string cidade)
            {
                Logradouro = logradouro;
                Bairro = bairro;
                CEP = cep;
                Cidade = cidade;
            }
            public override bool Validar()
            {
                ValidarModelo();
                ValidationResult = Validate(this);
                return ValidationResult.IsValid;
            }
            public void ValidarModelo()
            {
                ValidarCEP();
            }
            public void ValidarCEP()
            {
                RuleFor(x => CEP).Custom((x, context) => { if (!ValidaFormatoCep(this.CEP)) { context.AddFailure("CEP Formato Invalido!"); } });
            }
            private bool ValidaFormatoCep(string cep)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}-[0-9]{3}"));
            }
        }

    }
}
