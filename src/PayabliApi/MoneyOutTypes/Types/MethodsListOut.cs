using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Payment methods available for Pay Out payment links. Controls which payout options are offered to the vendor.
/// </summary>
[Serializable]
public record MethodsListOut : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, ACH bank transfer is offered as a payout method.
    /// </summary>
    [JsonPropertyName("ach")]
    public bool? Ach { get; set; }

    /// <summary>
    /// When `true`, physical check is offered as a payout method.
    /// </summary>
    [JsonPropertyName("check")]
    public bool? Check { get; set; }

    /// <summary>
    /// When `true`, virtual card (vCard) is offered as a payout method.
    /// </summary>
    [JsonPropertyName("vcard")]
    public bool? Vcard { get; set; }

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
