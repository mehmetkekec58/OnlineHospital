using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public class DiseaseValidator: AbstractValidator<Disease>
    {
        public DiseaseValidator()
        {
            RuleFor(p => p.Text).NotEmpty().MinimumLength(10);
            RuleFor(p => p.Title).NotEmpty();
        }
    }
}
