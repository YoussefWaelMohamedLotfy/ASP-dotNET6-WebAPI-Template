namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers
{
    public record UpdateCustomerCommand
    {
        public int ID { get; init; }

        public string Name { get; init; }
    }
}
