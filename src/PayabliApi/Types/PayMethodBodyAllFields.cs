using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Model for the PaymentMethod object, includes all method types.
/// </summary>
[Serializable]
public record PayMethodBodyAllFields : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Bank account number. This field is **required** when method = 'ach'.
    /// </summary>
    [JsonPropertyName("achAccount")]
    public required string AchAccount { get; set; }

    [JsonPropertyName("achAccountType")]
    public Achaccounttype? AchAccountType { get; set; }

    [JsonPropertyName("achCode")]
    public string? AchCode { get; set; }

    [JsonPropertyName("achHolder")]
    public required string AchHolder { get; set; }

    /// <summary>
    /// ABA/routing number of Bank account. This field is **required** when method = 'ach'.
    /// </summary>
    [JsonPropertyName("achRouting")]
    public required string AchRouting { get; set; }

    [JsonPropertyName("cardcvv")]
    public string? Cardcvv { get; set; }

    [JsonPropertyName("cardexp")]
    public string? Cardexp { get; set; }

    [JsonPropertyName("cardHolder")]
    public string? CardHolder { get; set; }

    [JsonPropertyName("cardnumber")]
    public string? Cardnumber { get; set; }

    [JsonPropertyName("cardzip")]
    public string? Cardzip { get; set; }

    [JsonPropertyName("device")]
    public string? Device { get; set; }

    [JsonPropertyName("initator")]
    public string? Initator { get; set; }

    [JsonPropertyName("method")]
    public Methodall? Method { get; set; }

    [JsonPropertyName("saveIfSuccess")]
    public bool? SaveIfSuccess { get; set; }

    [JsonPropertyName("storedMethodId")]
    public string? StoredMethodId { get; set; }

    [JsonPropertyName("storedMethodUsageType")]
    public string? StoredMethodUsageType { get; set; }

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
