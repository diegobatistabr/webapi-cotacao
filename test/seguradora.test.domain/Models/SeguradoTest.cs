using FluentValidation.Results;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace seguradora.test.domain.Models
{
    public class SeguradoTest
    {
        
        [Fact]
        public void Test_MaiorIdade_Invalido()
        {
            Segurado _segurado;
            _segurado = new Segurado("XXXXX", new DateTime(2005, 9, 29), "XXX", "XXXX", "XXXXX", "XXXXX");
            _segurado.Validar();
            var message =  _segurado.ValidationResult.Errors.Where(d => d.ErrorMessage == "É Preciso ser Maior de 18!").Select(e => e.ErrorMessage).FirstOrDefault();
            Assert.Equal("É Preciso ser Maior de 18!", message);
        }

        [Fact]
        public void Test_MaiorIdade_Valido()
        {
            Segurado _segurado;
            _segurado = new Segurado("XXXXX", new DateTime(1988, 9, 29), "XXX", "XXXX", "XXXXX", "XXXXX");
            _segurado.Validar();
            var message = _segurado.ValidationResult.Errors.Where(d => d.ErrorMessage == "É Preciso ser Maior de 18!").Select(e => e.ErrorMessage).FirstOrDefault();
            Assert.Null(message);
        }

    }
}
