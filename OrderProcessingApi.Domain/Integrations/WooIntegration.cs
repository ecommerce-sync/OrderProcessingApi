namespace OrderProcessingApi.Domain.Integrations;

public class WooIntegration : Integration
{
    public int Id { get; set; }
    public string ConsumerKey { get; set; }
    public string ConsumerSecret { get; set; }
    public string Url { get; set; }
    public DateTime DateLastModified { get; set; }
    public DateTime DateCreated { get; set; }
    public User User { get; set; }
}