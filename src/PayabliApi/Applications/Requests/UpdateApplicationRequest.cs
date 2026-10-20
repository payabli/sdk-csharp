using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateApplicationRequest
{
    /// <summary>
    /// An optional identifier from your own system.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The type of entity being boarded.
    /// </summary>
    [JsonPropertyName("entityType")]
    public string? EntityType { get; set; }

    /// <summary>
    /// The reference of the boarding template to apply.
    /// </summary>
    [JsonPropertyName("requestTemplate")]
    public string? RequestTemplate { get; set; }

    /// <summary>
    /// Optional labels for the application.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// The sales or service representatives assigned to the application.
    /// </summary>
    [JsonPropertyName("representatives")]
    public IEnumerable<RepresentativeInput>? Representatives { get; set; }

    /// <summary>
    /// Opaque application-level configuration.
    /// </summary>
    [JsonPropertyName("configurations")]
    public Dictionary<string, object?>? Configurations { get; set; }

    /// <summary>
    /// The services to request on the application. Replaces the whole `services` object, so send every service you want to keep. Leave it out to keep the current services.
    /// </summary>
    [JsonPropertyName("services")]
    public RequestedServices? Services { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
