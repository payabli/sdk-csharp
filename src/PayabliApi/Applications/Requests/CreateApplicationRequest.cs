using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record CreateApplicationRequest
{
    /// <summary>
    /// The reference of the business to board. The business must have a paypoint.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public required string BusinessReference { get; set; }

    /// <summary>
    /// The reference of the paypoint to board. Defaults to the business's paypoint when omitted.
    /// </summary>
    [JsonPropertyName("paypointReference")]
    public string? PaypointReference { get; set; }

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
    /// The reference of the boarding template to apply. Send one on every application. Payabli assigns the underwriting policy from the template, so a submitted application without one fails in review.
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
    /// Opaque application-level configuration. Null when not supplied.
    /// </summary>
    [JsonPropertyName("configurations")]
    public Dictionary<string, object?>? Configurations { get; set; }

    /// <summary>
    /// The services to request on the application.
    /// </summary>
    [JsonPropertyName("services")]
    public RequestedServices? Services { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
