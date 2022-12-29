using RegisterPersons.Models;
using RegisterPersons.Util.Request;

namespace RegisterPersons.Rules.Contracts
{
    public interface IPersonService
    {
        ICollection<Person> GetAll();
        Person GetById(string id);

        Person Create(PersonRequest personRequest);
    }
}
