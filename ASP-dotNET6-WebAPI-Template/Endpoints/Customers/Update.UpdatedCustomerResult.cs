namespace ASP_dotNET6_WebAPI_Template.Endpoints.Customers
{
    public record UpdatedCustomerResult : UpdateCustomerCommand
    {
        public string Address { get; init; }

        public DateTimeOffset DateOfBirth { get; init; }
    }
}
