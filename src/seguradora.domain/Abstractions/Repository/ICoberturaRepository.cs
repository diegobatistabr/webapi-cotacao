using seguradora.domain.Models;
using System.Collections.Generic;

namespace seguradora.domain.Abstractions.Repository
{
    public interface ICoberturaRepository
    {
        IEnumerable<Cobertura> ObterTodos();
        void Adicionar(Cobertura cobertura);
        void Atualizar(Cobertura cobertura);
        void Remover(int Id);
    }
}
