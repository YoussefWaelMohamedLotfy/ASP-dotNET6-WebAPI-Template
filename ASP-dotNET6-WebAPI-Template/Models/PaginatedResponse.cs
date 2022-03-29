namespace ASP_dotNET6_WebAPI_Template.Models;

public class PaginatedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = default!;

    public int? PageNumber { get; set; }

    public int? PageSize { get; set; }

    public string? NextPage { get; set; }

    public string? PreviousPage { get; set; }

    public PaginatedResponse() {}

    public PaginatedResponse(IEnumerable<T> data)
    {
        Data = data;
    }
    
}
