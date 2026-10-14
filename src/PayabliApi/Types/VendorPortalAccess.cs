using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The vendor's vendor portal access.
/// </summary>
[Serializable]
public record VendorPortalAccess : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, at least one user has access to the vendor portal.
    /// </summary>
    [JsonPropertyName("AnyoneHasAccess")]
    public bool? AnyoneHasAccess { get; set; }

    /// <summary>
    /// Users with access to the vendor portal.
    /// </summary>
    [JsonPropertyName("Users")]
    public IEnumerable<VendorPortalAccessUsersItem>? Users { get; set; }

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
