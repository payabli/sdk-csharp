using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Identifies a payout transaction that paid a bill.
/// </summary>
[Serializable]
public record BillTransactionReference : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Identifier of the payout transaction.
    /// </summary>
    [JsonPropertyName("idOut")]
    public required long IdOut { get; set; }

    /// <summary>
    /// Payment ID of the payout transaction.
    /// </summary>
    [JsonPropertyName("paymentId")]
    public string? PaymentId { get; set; }

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
