using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The result of removing a business address.
/// </summary>
[Serializable]
public record BusinessAddressDeletedResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Hypermedia links for the business resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required BusinessLinks Links { get; set; }

    /// <summary>
    /// The business reference.
    /// </summary>
    [JsonPropertyName("businessUuid")]
    public required string BusinessUuid { get; set; }

    /// <summary>
    /// The reference of the removed business address.
    /// </summary>
    [JsonPropertyName("businessAddressReference")]
    public required string BusinessAddressReference { get; set; }

    /// <summary>
    /// When the address was removed.
    /// </summary>
    [JsonPropertyName("deletedAt")]
    public required DateTime DeletedAt { get; set; }

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
