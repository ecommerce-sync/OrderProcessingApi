using OrderProcessingApi.Domain.Integrations;

namespace OrderProcessingApi.Domain;

public class UserQueryDto
{
    public int Id { get; init; }
    public string? Auth0Id { get; init; }
    public DateTime? DateLastModifiedFrom { get; init; }
    public DateTime? DateLastModifiedTo { get; init; }
    public DateTime? DateCreatedFrom { get; init; }
    public DateTime? DateCreatedTo { get; init; }
}