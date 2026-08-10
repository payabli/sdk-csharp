using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// An owning entity, as returned by the List profiles endpoint (`entityType`
/// serialized as a name).
/// </summary>
[Serializable]
public record BillingEntityNamed : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entityType")]
    public required EntityTypeName EntityType { get; set; }

    /// <summary>
    /// Identifier of the entity.
    /// </summary>
    [JsonPropertyName("entityId")]
    public required long EntityId { get; set; }

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
