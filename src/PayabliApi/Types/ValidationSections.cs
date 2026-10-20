using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The validation result for each section of the application.
/// </summary>
[Serializable]
public record ValidationSections : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The business's details.
    /// </summary>
    [JsonPropertyName("business")]
    public required ValidationSection Business { get; set; }

    /// <summary>
    /// The business's processing details, such as volumes and transaction sizes.
    /// </summary>
    [JsonPropertyName("salesAndPayments")]
    public required ValidationSection SalesAndPayments { get; set; }

    /// <summary>
    /// The business's payment methods.
    /// </summary>
    [JsonPropertyName("banking")]
    public required ValidationSection Banking { get; set; }

    /// <summary>
    /// The business's owners and officers.
    /// </summary>
    [JsonPropertyName("people")]
    public required ValidationSection People { get; set; }

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
