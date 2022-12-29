namespace RegisterPersons.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string PhicalAddress { get; set; } = null!;
        public virtual Person? Person { get; set; }
    }
}
