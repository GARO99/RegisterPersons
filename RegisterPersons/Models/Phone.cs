namespace RegisterPersons.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
