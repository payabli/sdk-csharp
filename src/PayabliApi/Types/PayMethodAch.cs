using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayMethodAch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Bank account number. This field is **required** when method = 'ach'.
    /// </summary>
    [JsonPropertyName("achAccount")]
    public required string AchAccount { get; set; }

    /// <summary>
    /// Bank account type. This field is **required** when method = 'ach'.
    /// </summary>
    [JsonPropertyName("achAccountType")]
    public Achaccounttype? AchAccountType { get; set; }

    [JsonPropertyName("achCode")]
    public string? AchCode { get; set; }

    [JsonPropertyName("achHolder")]
    public required string AchHolder { get; set; }

    [JsonPropertyName("achHolderType")]
    public AchHolderType? AchHolderType { get; set; }

    /// <summary>
    /// ABA/routing number of bank account. This field is **required** when method = 'ach'.
    /// </summary>
    [JsonPropertyName("achRouting")]
    public required string AchRouting { get; set; }

    [JsonPropertyName("device")]
    public string? Device { get; set; }

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
