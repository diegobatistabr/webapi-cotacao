using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace seguradora.test.domain.Models
{
    public class CotacaoTest
    {
        [Fact]
        public void Test_CalculoPremio_30_18_Valido()
        {
            List<Cobertura> coberturas = new List<Cobertura>();
            coberturas.Add(new Cobertura("01", "Morte Acidental", 100, 50000, 'S'));
            coberturas.Add(new Cobertura("02", "Quebra de Ossos", 30, 5000, 'N'));

            DateTime dataNascimento = new DateTime(1995, 9, 29);
            
            Cotacao _segurado;
            _segurado = new Cotacao();
            _segurado.CalcularPremio(dataNascimento, coberturas);
            
            Assert.True(((decimal)192.40 == _segurado.Premio));
        }

        [Fact]
        public void Test_CalculoPremio_Igual_30_Valido()
        {
            List<Cobertura> coberturas = new List<Cobertura>();
            coberturas.Add(new Cobertura("01", "Morte Acidental", 100, 50000, 'S'));
            coberturas.Add(new Cobertura("02", "Quebra de Ossos", 30, 5000, 'N'));

            DateTime dataNascimento = new DateTime(1989, 9, 29);

            Cotacao _segurado;
            _segurado = new Cotacao();
            _segurado.CalcularPremio(dataNascimento, coberturas);

            Assert.True(((decimal)130 == _segurado.Premio));
        }

        [Fact]
        public void Test_CalculoPremio_31_45_Valido()
        {
            List<Cobertura> coberturas = new List<Cobertura>();
            coberturas.Add(new Cobertura("01", "Morte Acidental", 100, 50000, 'S'));
            coberturas.Add(new Cobertura("02", "Quebra de Ossos", 30, 5000, 'N'));

            DateTime dataNascimento = new DateTime(1986, 9, 29);

            Cotacao _segurado;
            _segurado = new Cotacao();
            _segurado.CalcularPremio(dataNascimento, coberturas);
            var teste = _segurado.Premio;
            Assert.True(((decimal)122.20 == _segurado.Premio));
        }



    }
}
