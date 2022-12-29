namespace RegisterPersons.Models
{
    public class Email
    {
        public long Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public virtual Person? Person { get; set; }
    }
}
