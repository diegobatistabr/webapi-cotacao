using FluentValidation;
using FluentValidation.Results;

namespace seguradora.domain.Models
{
    public abstract class Base<T> : AbstractValidator<T>
    {
        public Base()
        {
            ValidationResult = new ValidationResult();
        }

        public string Id { get; set; }

        public abstract bool Validar();

        public ValidationResult ValidationResult { get; set; }
    }
}
