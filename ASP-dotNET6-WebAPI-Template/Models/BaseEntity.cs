namespace ASP_dotNET6_WebAPI_Template.Models;

/// <summary>
/// The base class for any unique entity in the application
/// </summary>
/// <typeparam name="T">The type of the ID</typeparam>
public abstract class BaseEntity<T>
{
    public T ID { get; set; } = default!;
}
