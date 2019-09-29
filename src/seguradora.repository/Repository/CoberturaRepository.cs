using seguradora.domain.Abstractions.Repository;
using seguradora.domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.repository.Repository
{
    public class CoberturaRepository : ICoberturaRepository
    {
        public IEnumerable<Cobertura> ObterTodos()
        {
            var retorno = new List<Cobertura>();
            retorno.Add(new Cobertura("01", "Morte Acidental", 100, 50000, 'S'));
            retorno.Add(new Cobertura("02", "Quebra de Ossos", 30, 5000, 'N'));
            retorno.Add(new Cobertura("03", "Internação Hospitalar", 50, 10000, 'N'));
            retorno.Add(new Cobertura("04", "Assitencia Funeraria", 10, 2500, 'N'));
            retorno.Add(new Cobertura("05", "Invalidez Permanente", 130, 90000, 'S'));
            retorno.Add(new Cobertura("06", "Assitencia Odontologia Emergencial", 10, 2500, 'N'));
            retorno.Add(new Cobertura("07", "Diária Incapacidade Temporária", 30,5000, 'N'));
            retorno.Add(new Cobertura("08", "Invalidez Funcional", 80, 40000, 'S'));
            retorno.Add(new Cobertura("09", "Doenças Graves", 100, 50000, 'N'));
            retorno.Add(new Cobertura("10", "Diagnostico de Cancer", 50, 10000, 'N'));
            return retorno;   
        }

        public void Adicionar(Cobertura obj)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Cobertura obj)
        {
            throw new NotImplementedException();
        }                      

        public void Remover(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
