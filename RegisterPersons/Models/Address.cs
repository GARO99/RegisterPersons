namespace RegisterPersons.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string PhicalAddress { get; set; } = null!;
    }
}
