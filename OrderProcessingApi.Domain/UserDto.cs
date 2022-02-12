using OrderProcessingApi.Domain.Integrations;
using Swashbuckle.AspNetCore.Annotations;

namespace OrderProcessingApi.Domain;

public class UserDto
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; init; }
    public string? Auth0Id { get; init; }
    public DateTime? DateLastModified { get; init; }
    public DateTime? DateCreated { get; init; }
}

public class UserUpdateDto
{
    public int Id { get; set; }
    public IntegrationDto Integration { get; set; }
}

public class UserResultDto
{
    public int Id { get; init; }
    public string? Auth0Id { get; init; }
    public DateTime? DateLastModified { get; init; }
    public DateTime? DateCreated { get; init; }
    public IEnumerable<IntegrationDto> Integrations { get; set; }
}

public class IntegrationDto
{
    public string WooConsumerKey { get; set; }
    public string WooConsumerSecret { get; set; }
    public string WooUrl { get; set; }
}