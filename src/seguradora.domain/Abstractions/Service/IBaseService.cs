using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace seguradora.domain.Abstractions.Service
{
    public interface IBaseService
    {
        bool EhValido();
        IList<ValidationFailure> ObterErrosDeValidacao();

    }
}
