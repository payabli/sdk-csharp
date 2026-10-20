using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A certification held by the business.
/// </summary>
[Serializable]
public record CertificationDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of certification.
    /// </summary>
    [JsonPropertyName("certificationType")]
    public string? CertificationType { get; set; }

    /// <summary>
    /// The organization that issued the certification.
    /// </summary>
    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    /// <summary>
    /// The certificate identifier.
    /// </summary>
    [JsonPropertyName("certificateNumber")]
    public string? CertificateNumber { get; set; }

    /// <summary>
    /// The date the certification was issued.
    /// </summary>
    [JsonPropertyName("issuedDate")]
    public DateOnly? IssuedDate { get; set; }

    /// <summary>
    /// The date the certification expires.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public DateOnly? ExpirationDate { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
