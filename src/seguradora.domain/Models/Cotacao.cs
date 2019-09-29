using seguradora.domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace seguradora.domain.Models
{

    public class Cotacao : Base<Cotacao>
    {

        public decimal Premio { get; private set; }
        public int Parcelas { get; private set; }
        public decimal Valor_Parcelas { get; private set; }
        public DateTime Primeiro_Vencimento { get; private set; }
        public decimal Cobertura_Total { get; private set; }
        
        public Cotacao()
        {
        }

        public override bool Validar()
        {            
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }       

        public void CalcularPremio(DateTime nascimento, List<Cobertura> coberturas)
        {
            var valorPremioLimpo = coberturas.Sum(x => x.Premio);

            int idade = calculaIdade(nascimento);

            if (idade == 30)
                this.Premio = valorPremioLimpo;

            if (idade <= 29 && idade >= 18)
            {
                int percentual = 0;
                for (int i = 29; i >= idade; i--)
                {
                    percentual = percentual + 8;
                }
                this.Premio = valorPremioLimpo + (valorPremioLimpo * ((decimal) percentual / 100 ));
            }

            if (idade >= 31 && idade <= 45)
            {
                int percentual = 0;
                for (int i = 31; i <= idade; i++)
                {
                    percentual = percentual + 2;
                }
                this.Premio = valorPremioLimpo - (valorPremioLimpo * ((decimal) percentual / 100) );
            }
        }

        public void CalcularParcelas(decimal premio)
        {
            if (premio < 500) this.Parcelas = 1;
            if (premio >= 501 && premio < 1000) this.Parcelas = 2;
            if (premio >= 1001 && premio < 2000) this.Parcelas = 3;
            if (premio >= 2001) this.Parcelas = 4;
        }

        public void CalcularValorParcelas() => 
            this.Valor_Parcelas = Math.Round(this.Premio / this.Parcelas,2);
        
        public void CalcularPrimeiroVencimento(int diaUtil)
        {
            this.Primeiro_Vencimento = DiaUtil.ObtemDiaUtil(diaUtil);
        }

        public void CalcularCoberturaTotal(List<Cobertura> coberturas) =>      
            this.Cobertura_Total = (from cobert in coberturas select cobert.Valor ).Sum();
               
        private int calculaIdade(DateTime dataNascimento)
        {
            int anos = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento.Month > DateTime.Today.Month || dataNascimento.Month == DateTime.Today.Month && dataNascimento.Day > DateTime.Today.Day)
                anos--;

            return anos;
        }
    }
}