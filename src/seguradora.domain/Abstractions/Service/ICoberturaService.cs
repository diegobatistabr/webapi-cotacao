using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.domain.Abstractions.Service
{
    public interface ICoberturaService : IBaseService
    {
        List<Cobertura> ObterTodos();
    }
}
