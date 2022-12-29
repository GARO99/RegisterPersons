using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using RegisterPersons.Util.Request;

namespace RegisterPersons.Util.Validator
{
    public class PersonValidator : AbstractValidator<PersonRequest>
    {
        public PersonValidator()
        {
            RuleFor(p => p.Id).Must(i => !i.IsNullOrEmpty()).WithMessage("Person id cannot be null or empty");
            RuleFor(p => p.Id).Matches("^[aA-zZ0-9]*$").WithMessage("Person id cannot contain different characters other than alphanumeric characters.");
            RuleFor(p => p.Names).Must(n => !n.IsNullOrEmpty()).WithMessage("Person name cannot be null or empty");
            RuleFor(p => p.Names).Matches("^[aA-zZñ\\s]*$").WithMessage("Person name cannot contain contain different characters other than latin alpahbet characters");
            RuleFor(p => p.Surnames).Must(s => !s.IsNullOrEmpty()).WithMessage("Person surnames cannot be null or empty");
            RuleFor(p => p.Surnames).Matches("^[aA-zZñ\\s]*$").WithMessage("Person surnames cannot contain contain different characters other than latin alpahbet characters");
            RuleFor(p => p.BirthDate).Must(b => !b.Equals(default)).WithMessage("Person birth date cannot be null");
            RuleFor(p => p).Must(p => (p.Phones != null && p.Phones.Length > 0) || (p.Emails != null && p.Emails.Length > 0)
                || (p.Address != null && p.Address.Length > 0)).WithMessage("At least add one type of contect info is required");
            RuleFor(p => p.Phones).Must(ph => ph.Length <= 2).When(p => p.Phones != null).WithMessage("Person cannot have more than two phones");
            RuleFor(p => p.Emails).Must(e => e.Length <= 2).When(p => p.Emails != null).WithMessage("Person cannot have more than two eamils");
            RuleFor(p => p.Address).Must(a => a.Length <= 2).When(p => p.Address != null).WithMessage("Person cannot have more than two Addresses");
            RuleForEach(p => p.Phones).Must(ph => !ph.IsNullOrEmpty()).When(p => p.Phones != null).WithMessage("Phone index: {CollectionIndex}, cannot be null or empty");
            RuleForEach(p => p.Emails).Must(e => !e.IsNullOrEmpty()).When(p => p.Emails != null).WithMessage("Email index: {CollectionIndex}, cannot be null or empty");
            RuleForEach(p => p.Address).Must(a => !a.IsNullOrEmpty()).When(p => p.Address != null).WithMessage("Address index: {CollectionIndex}, cannot be null or empty");
        }
    }
}
