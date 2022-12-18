using AdminStaff.DomainModels;
using AdminStaff.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminStaff.Validators
{
    public class AddAdherentRequestValidators : AbstractValidator<AddAdherent>
    {
        public AddAdherentRequestValidators(IAdherentRepository adherentRepository)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(10000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = adherentRepository.GetGendersAsync().Result.ToList().FirstOrDefault(x => x.Id == id);

                if (gender != null)
                {
                    return true;
                }
                return false;

            }).WithMessage("Please select a valid Gender");

            RuleFor(x => x.PhysicalAdresse).NotEmpty();
            RuleFor(x => x.PostalAdresse).NotEmpty();
        }
      
    }
}
