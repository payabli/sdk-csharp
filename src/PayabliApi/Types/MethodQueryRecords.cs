using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record MethodQueryRecords : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The bank identification number (BIN). Null when method is ACH.
    /// </summary>
    [JsonPropertyName("bin")]
    public string? Bin { get; set; }

    [JsonPropertyName("binData")]
    public BinData? BinData { get; set; }

    [JsonPropertyName("descriptor")]
    public string? Descriptor { get; set; }

    /// <summary>
    /// Expiration date associated to the method (only for card) in format MMYY.
    /// </summary>
    [JsonPropertyName("expDate")]
    public string? ExpDate { get; set; }

    [JsonPropertyName("holderName")]
    public string? HolderName { get; set; }

    /// <summary>
    /// Method internal ID
    /// </summary>
    [JsonPropertyName("idPmethod")]
    public string? IdPmethod { get; set; }

    /// <summary>
    /// Date of last update
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("maskedAccount")]
    public string? MaskedAccount { get; set; }

    /// <summary>
    /// Type of payment vehicle: **ach** or **card**
    /// </summary>
    [JsonPropertyName("method")]
    public string? Method { get; set; }

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
