using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Object describing the ACH payment method to use for transaction.
/// </summary>
[Serializable]
public record RequestCreditPaymentMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("achAccount")]
    public string? AchAccount { get; set; }

    [JsonPropertyName("achAccountType")]
    public Achaccounttype? AchAccountType { get; set; }

    [JsonPropertyName("achCode")]
    public string? AchCode { get; set; }

    /// <summary>
    /// Bank account holder.
    /// </summary>
    [JsonPropertyName("achHolder")]
    public string? AchHolder { get; set; }

    [JsonPropertyName("achRouting")]
    public string? AchRouting { get; set; }

    /// <summary>
    /// Method to use for the transaction. Must be ACH.
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; } = "ach";

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
