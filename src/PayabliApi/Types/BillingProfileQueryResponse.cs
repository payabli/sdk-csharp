using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A page of billing profiles that belong to an organization, returned by the
/// List profiles endpoint. This is the data behind the Profile Library table in
/// the Payabli Portal.
/// </summary>
[Serializable]
public record BillingProfileQueryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("summary")]
    public required BillingProfileSummary Summary { get; set; }

    /// <summary>
    /// The billing profiles on this page. Empty when the org has no profiles.
    /// </summary>
    [JsonPropertyName("records")]
    public IEnumerable<BillingProfileRecord> Records { get; set; } =
        new List<BillingProfileRecord>();

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
