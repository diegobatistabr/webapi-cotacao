using FluentValidation.Results;
using seguradora.domain.Abstractions.Repository;
using seguradora.domain.Abstractions.Service;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace seguradora.domain.Services
{
    public class CoberturaService : ICoberturaService
    {
        ICoberturaRepository _coberturaRepository;

        public CoberturaService(ICoberturaRepository coberturaRepository)
        {
            _coberturaRepository = coberturaRepository;
        }
                
        public List<Cobertura> ObterTodos()
        {
            return _coberturaRepository.ObterTodos().ToList();
        } 

        public bool EhValido()
        {
            throw new NotImplementedException();
        }

        public IList<ValidationFailure> ObterErrosDeValidacao()
        {
            throw new NotImplementedException();
        }
    }
}
