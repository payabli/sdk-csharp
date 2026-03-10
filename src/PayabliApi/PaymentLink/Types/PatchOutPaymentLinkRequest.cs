using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Request body for partially updating a Pay Out payment link.
/// </summary>
[Serializable]
public record PatchOutPaymentLinkRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Updated payment link page configuration.
    /// </summary>
    [JsonPropertyName("billPageData")]
    public PaymentPageRequestBodyOut? BillPageData { get; set; }

    /// <summary>
    /// New expiration date for the payment link. Must be a future date. If null and the link is expired, uses the default expiration from settings. Updating the expiration date reactivates an expired payment link to Active status.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public string? ExpirationDate { get; set; }

    /// <summary>
    /// Updated status for the payment link.
    /// </summary>
    [JsonPropertyName("status")]
    public PaymentLinkStatus? Status { get; set; }

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
