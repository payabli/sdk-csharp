using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details about a bank account.
/// </summary>
[Serializable]
public record BankSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("accountNumber")]
    public TemplateElement? AccountNumber { get; set; }

    [JsonPropertyName("accountType")]
    public TemplateElement? AccountType { get; set; }

    [JsonPropertyName("bankName")]
    public TemplateElement? BankName { get; set; }

    [JsonPropertyName("routingNumber")]
    public TemplateElement? RoutingNumber { get; set; }

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
