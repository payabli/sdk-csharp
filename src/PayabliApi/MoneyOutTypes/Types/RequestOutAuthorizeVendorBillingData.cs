using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object containing vendor's bank information.
/// </summary>
[Serializable]
public record RequestOutAuthorizeVendorBillingData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    [JsonPropertyName("routingAccount")]
    public string? RoutingAccount { get; set; }

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("typeAccount")]
    public TypeAccount? TypeAccount { get; set; }

    [JsonPropertyName("bankAccountHolderName")]
    public string? BankAccountHolderName { get; set; }

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
