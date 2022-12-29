namespace RegisterPersons.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
    }
}
