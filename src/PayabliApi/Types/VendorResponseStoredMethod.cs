using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Stored payment method information
/// </summary>
[Serializable]
public record VendorResponseStoredMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("IdPmethod")]
    public string? IdPmethod { get; set; }

    [JsonPropertyName("Method")]
    public string? Method { get; set; }

    [JsonPropertyName("Descriptor")]
    public string? Descriptor { get; set; }

    [JsonPropertyName("MaskedAccount")]
    public string? MaskedAccount { get; set; }

    [JsonPropertyName("ExpDate")]
    public string? ExpDate { get; set; }

    [JsonPropertyName("HolderName")]
    public string? HolderName { get; set; }

    [JsonPropertyName("AchSecCode")]
    public string? AchSecCode { get; set; }

    [JsonPropertyName("AchHolderType")]
    public string? AchHolderType { get; set; }

    [JsonPropertyName("IsValidatedACH")]
    public bool? IsValidatedAch { get; set; }

    [JsonPropertyName("BIN")]
    public string? Bin { get; set; }

    [JsonPropertyName("binData")]
    public string? BinData { get; set; }

    [JsonPropertyName("ABA")]
    public string? Aba { get; set; }

    [JsonPropertyName("PostalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("MethodType")]
    public string? MethodType { get; set; }

    [JsonPropertyName("LastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("CardUpdatedOn")]
    public DateTime? CardUpdatedOn { get; set; }

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
