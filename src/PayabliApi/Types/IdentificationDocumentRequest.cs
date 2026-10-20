using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A government-issued identification document included in a person request.
/// </summary>
[Serializable]
public record IdentificationDocumentRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The document type, for example `drivers_license`, `passport`, or `state_id`.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The document number.
    /// </summary>
    [JsonPropertyName("number")]
    public string? Number { get; set; }

    /// <summary>
    /// The two-letter issuing state code.
    /// </summary>
    [JsonPropertyName("issuingState")]
    public string? IssuingState { get; set; }

    /// <summary>
    /// The two-letter ISO 3166-1 alpha-2 issuing country code.
    /// </summary>
    [JsonPropertyName("issuingCountry")]
    public string? IssuingCountry { get; set; }

    /// <summary>
    /// The document expiration date.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

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
