using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTestFluentValidation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Empresa empresa = new Empresa()
            //{
            //    Id = null,
            //    Estabelecimento = null,
            //    Endereco = null
            //};
            //Property Id failed validation. Error was: Id é Obrigatório
            //Property Estabelecimento failed validation. Error was: Estabelecimento é Obrigatório

            //Empresa empresa = new Empresa()
            //{
            //    Id = 1,
            //    Estabelecimento = "teste",
            //    Endereco = new Endereco() { Cep = null}
            //};
            // Property Endereco.Cep failed validation.Error was: 'Cep' must not be empty.
            
            Empresa empresa = new Empresa();

            EmpresaValidator validator = new EmpresaValidator();

            ValidationResult results = validator.Validate(empresa);

            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            Console.ReadKey();
        }
    }

    public class Empresa
    {
        public int? Id { get; set; }
        public string Estabelecimento { get; set; }
        public DateTime DataInclusao { get; set; }
        public ICollection<string> Emails { get; set; }
        public Endereco Endereco { get; set; }
    }

    public class Endereco
    {
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }
    }

    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(emp => emp.Id).NotNull().WithMessage("Id é Obrigatório");
            RuleFor(emp => emp.Estabelecimento).NotNull().WithMessage("Estabelecimento é Obrigatório");
            RuleFor(emp => emp.Endereco).SetValidator(new EnderecoValidator());
        }

    }

    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(end => end.Cep).NotNull().When(end => end != null);
        }
    }
}
