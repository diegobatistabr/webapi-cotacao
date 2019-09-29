using System;
using System.Collections.Generic;
using System.Text;
using static seguradora.domain.ExternalServices.Cidades;

namespace seguradora.domain.ExternalServices
{
    public interface ICidades
    {
        CidadesAPI ObterTodas();
    }
}
