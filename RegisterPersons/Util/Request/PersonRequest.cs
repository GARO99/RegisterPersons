using System.Text.Json.Serialization;

namespace RegisterPersons.Util.Request
{
    public class PersonRequest
    {
        [JsonRequired]
        public string Id { get; set; } = null!;
        [JsonRequired]
        public string Names { get; set; } = null!;
        [JsonRequired]
        public string Surnames { get; set; } = null!;
        [JsonRequired]
        public DateTime BirthDate { get; set; }
        public string[]? Phones { get; set; }
        public string[]? Emails { get; set; }
        public string[]? Address { get; set; }
    }
}
