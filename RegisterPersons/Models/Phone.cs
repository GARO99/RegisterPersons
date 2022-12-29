namespace RegisterPersons.Models
{
    public class Phone
    {
        public long Id { get; set; }
        public string PersonId { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public virtual Person? Person { get; set; }
    }
}
