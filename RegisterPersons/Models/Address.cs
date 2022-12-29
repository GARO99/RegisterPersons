using System.Text.Json.Serialization;

namespace RegisterPersons.Models
{
    public class Address
    {
        [JsonIgnore]
        public long Id { get; set; }
        [JsonIgnore]
        public string PersonId { get; set; } = null!;
        public string PhicalAddress { get; set; } = null!;
        [JsonIgnore]
        public virtual Person? Person { get; set; }
    }
}
