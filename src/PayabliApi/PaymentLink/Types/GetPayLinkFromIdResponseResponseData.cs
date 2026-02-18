using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetPayLinkFromIdResponseResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AdditionalData")]
    public Dictionary<string, Dictionary<string, object?>>? AdditionalData { get; set; }

    /// <summary>
    /// Array of credential objects with active services for the page
    /// </summary>
    [JsonPropertyName("credentials")]
    public IEnumerable<PayabliCredentials>? Credentials { get; set; }

    /// <summary>
    /// Timestamp of last access to page structure
    /// </summary>
    [JsonPropertyName("lastAccess")]
    public DateTime? LastAccess { get; set; }

    /// <summary>
    /// Sections of page
    /// </summary>
    [JsonPropertyName("pageContent")]
    public PageContent? PageContent { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    /// <summary>
    /// Settings of page
    /// </summary>
    [JsonPropertyName("pageSettings")]
    public PageSetting? PageSettings { get; set; }

    /// <summary>
    /// Flag indicating if page is active to accept payments. `0` for false, `1` for true.
    /// </summary>
    [JsonPropertyName("published")]
    public int? Published { get; set; }

    /// <summary>
    /// Sections of payment receipt
    /// </summary>
    [JsonPropertyName("receiptContent")]
    public ReceiptContent? ReceiptContent { get; set; }

    /// <summary>
    /// Page identifier. Must be unique in platform.
    /// </summary>
    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    /// <summary>
    /// Total amount to pay in this page
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    /// <summary>
    /// Base64 encoded image of CAPTCHA associated to this page load
    /// </summary>
    [JsonPropertyName("validationCode")]
    public string? ValidationCode { get; set; }

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
