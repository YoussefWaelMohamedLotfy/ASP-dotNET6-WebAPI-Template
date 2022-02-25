namespace ASP_dotNET6_WebAPI_Template.Endpoints.V1.Customers
{
    public record PaginationQuery
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }

        public PaginationQuery()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
