using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record Bnk : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("accountNumber")]
    public LinkData? AccountNumber { get; set; }

    [JsonPropertyName("bankName")]
    public LinkData? BankName { get; set; }

    [JsonPropertyName("routingAccount")]
    public LinkData? RoutingAccount { get; set; }

    [JsonPropertyName("typeAccount")]
    public LinkData? TypeAccount { get; set; }

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
