namespace ASP_dotNET6_WebAPI_Template.Models;

public class RedisCacheSettings
{
    public bool IsEnabled { get; set; }

    public string ConnectionString { get; set; } = default!;
}
