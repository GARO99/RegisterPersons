namespace RegisterPersons.Models
{
    public class Person
    {
        public string Id { get; set; } = null!;
        public string Names { get; set; } = null!;
        public string Surnames { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Phone> Phones { get; } = new List<Phone>();
        public virtual ICollection<Email> Emails { get; } = new List<Email>();
        public virtual ICollection<Address> Address { get;} = new List<Address>();
    }
}
