using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TokenizeAch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The type of payment method to tokenize. For ACH, this is always `ach`.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    [JsonPropertyName("achAccount")]
    public required string AchAccount { get; set; }

    [JsonPropertyName("achAccountType")]
    public required Achaccounttype AchAccountType { get; set; }

    [JsonPropertyName("achCode")]
    public string? AchCode { get; set; }

    /// <summary>
    /// Bank account holder. This field is **required** when `method` is `ach`. Only letters, numbers, spaces, hyphens, apostrophes, and periods are allowed.
    /// </summary>
    [JsonPropertyName("achHolder")]
    public required string AchHolder { get; set; }

    [JsonPropertyName("achHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    [JsonPropertyName("achRouting")]
    public required string AchRouting { get; set; }

    [JsonPropertyName("device")]
    public string? Device { get; set; }

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
