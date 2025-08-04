using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SummaryOrg : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("amountSubs")]
    public double? AmountSubs { get; set; }

    [JsonPropertyName("amountTx")]
    public double? AmountTx { get; set; }

    [JsonPropertyName("childOrgs")]
    public int? ChildOrgs { get; set; }

    [JsonPropertyName("childPaypoints")]
    public int? ChildPaypoints { get; set; }

    [JsonPropertyName("countSubs")]
    public int? CountSubs { get; set; }

    [JsonPropertyName("countTx")]
    public int? CountTx { get; set; }

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
