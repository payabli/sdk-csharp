using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OcrVendorBillingData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("typeAccount")]
    public string? TypeAccount { get; set; }

    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

    [JsonPropertyName("bankAccountHolderType")]
    public string? BankAccountHolderType { get; set; }

    [JsonPropertyName("bankAccountFunction")]
    public int? BankAccountFunction { get; set; }

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
