namespace ASP_dotNET6_WebAPI_Template.Models
{
    public class Customer : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }
    }
}
