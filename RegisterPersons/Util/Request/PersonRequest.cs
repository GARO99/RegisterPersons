#nullable disable

namespace RegisterPersons.Util.Request
{
    public class PersonRequest
    {
        public string Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime BirthDate { get; set; }
        public string[] Phones { get; set; }
        public string[] Emails { get; set; }
        public string[] Address { get; set; }
    }
}
