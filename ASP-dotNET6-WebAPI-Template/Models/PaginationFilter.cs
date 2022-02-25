namespace ASP_dotNET6_WebAPI_Template.Models
{
    public record PaginationFilter
    {
        public int PageNumber { get; init; }

        public int PageSize { get; init; }
    }
}
