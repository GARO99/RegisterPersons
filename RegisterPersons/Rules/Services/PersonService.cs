using RegisterPersons.Data;
using RegisterPersons.Models;
using RegisterPersons.Rules.Contracts;
using RegisterPersons.Util.Exceptions;
using RegisterPersons.Util.Request;

namespace RegisterPersons.Rules.Services
{
    public class PersonService : IPersonService
    {
        private readonly RegisterPersonsContext DbContext;

        public PersonService(RegisterPersonsContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public Person Create(PersonRequest personRequest)
        {
            if (this.DbContext.People.FirstOrDefault(p => p.Id == personRequest.Id) != null)
            {
                throw new ConflictException("Person allready exist");
            }
            Person person = new() 
            {
                Id = personRequest.Id,
                Names = personRequest.Names,
                Surnames = personRequest.Surnames,
                BirthDate = personRequest.BirthDate
            };
            this.DbContext.People.Add(person);
            this.DbContext.SaveChanges();
            this.SavePhones(personRequest.Id, personRequest.Phones);
            this.SaveEmails(personRequest.Id, personRequest.Emails);
            this.SaveAddress(personRequest.Id, personRequest.Address);
            person = this.DbContext.People.First(p => p.Id == personRequest.Id);
            this.DbContext.Entry(person).Collection(c => c.Phones).Load();
            this.DbContext.Entry(person).Collection(c => c.Emails).Load();
            this.DbContext.Entry(person).Collection(c => c.Address).Load();

            return person;
        }

        private void SavePhones(string personId, string[]? phones)
        {
            if (phones != null)
            {
                ICollection<Phone> phoneList = new List<Phone>();
                foreach (string phone in phones)
                {
                    phoneList.Add(new Phone
                    {
                        PersonId = personId,
                        PhoneNumber = phone
                    });
                }
                this.DbContext.Phones.AddRange(phoneList);
                this.DbContext.SaveChanges();
            }            
        }

        private void SaveEmails(string personId, string[]? emails)
        {
            if (emails != null)
            {
                ICollection<Email> emailList = new List<Email>();
                foreach (string email in emails)
                {
                    emailList.Add(new Email
                    {
                        PersonId = personId,
                        EmailAddress = email
                    });
                }
                this.DbContext.Emails.AddRange(emailList);
                this.DbContext.SaveChanges();
            }           
        }

        private void SaveAddress(string personId, string[]? addresses)
        {
            if (addresses != null)
            {
                ICollection<Address> addressList = new List<Address>();
                foreach (string address in addresses)
                {
                    addressList.Add(new Address
                    {
                        PersonId = personId,
                        PhicalAddress = address
                    });
                }
                this.DbContext.Addresses.AddRange(addressList);
                this.DbContext.SaveChanges();
            }
        }

        public ICollection<Person> GetAll()
        {
            ICollection<Person> personList = this.DbContext.People.ToList();
            foreach (Person person in personList)
            {
                this.DbContext.Entry(person).Collection(c => c.Phones).Load();
                this.DbContext.Entry(person).Collection(c => c.Emails).Load();
                this.DbContext.Entry(person).Collection(c => c.Address).Load();
            }

            return personList;
        }

        public Person GetById(string id)
        {
            Person? person = this.DbContext.People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                throw new ConflictException("Person not exist");
            }
            this.DbContext.Entry(person).Collection(c => c.Phones).Load();
            this.DbContext.Entry(person).Collection(c => c.Emails).Load();
            this.DbContext.Entry(person).Collection(c => c.Address).Load();

            return person;
        }
    }
}
