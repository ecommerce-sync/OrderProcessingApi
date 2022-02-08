
using OrderProcessingApi.Domain.Integrations;

namespace OrderProcessingApi.Domain;

public class UserDto
{
    public int Id { get; init; }
    public string? Auth0Id { get; init; }
    public string? DateLastModifiedFrom { get; init; }
    public string? DateLastModifiedTo { get; init; }
    public string? DateCreatedFrom { get; init; }
    public string? DateCreatedTo { get; init; }
}