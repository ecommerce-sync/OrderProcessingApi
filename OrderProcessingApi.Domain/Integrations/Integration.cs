﻿namespace OrderProcessingApi.Domain.Integrations;

public class Integration
{
    public string? WooConsumerKey { get; set; }
    public string? WooConsumerSecret { get; set; }
    public string? WooUrl { get; set; }
}