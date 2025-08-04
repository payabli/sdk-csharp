using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillingFeeDetail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("billableEvent")]
    public string? BillableEvent { get; set; }

    [JsonPropertyName("service")]
    public string? Service { get; set; }

    [JsonPropertyName("eventId")]
    public string? EventId { get; set; }

    /// <summary>
    /// Description of the billing fee
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Category of the billing fee
    /// </summary>
    [JsonPropertyName("category")]
    public string? Category { get; set; }

    /// <summary>
    /// Fixed price component of the fee
    /// </summary>
    [JsonPropertyName("fixPrice")]
    public double? FixPrice { get; set; }

    /// <summary>
    /// Percentage component of the fee
    /// </summary>
    [JsonPropertyName("floatPrice")]
    public double? FloatPrice { get; set; }

    /// <summary>
    /// Amount eligible for the fee
    /// </summary>
    [JsonPropertyName("billableAmount")]
    public double? BillableAmount { get; set; }

    /// <summary>
    /// Total fee amount charged
    /// </summary>
    [JsonPropertyName("billAmount")]
    public double? BillAmount { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("serviceGroup")]
    public string? ServiceGroup { get; set; }

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
