using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OrganizationQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("BillingInfo")]
    public InstrumentResponse? BillingInfo { get; set; }

    /// <summary>
    /// List of contacts.
    /// </summary>
    [JsonPropertyName("Contacts")]
    public IEnumerable<ContactsResponse>? Contacts { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("HasBilling")]
    public bool? HasBilling { get; set; }

    [JsonPropertyName("HasResidual")]
    public bool? HasResidual { get; set; }

    [JsonPropertyName("idOrg")]
    public long? IdOrg { get; set; }

    [JsonPropertyName("isRoot")]
    public bool? IsRoot { get; set; }

    [JsonPropertyName("OrgAddress")]
    public string? OrgAddress { get; set; }

    [JsonPropertyName("OrgCity")]
    public string? OrgCity { get; set; }

    [JsonPropertyName("OrgCountry")]
    public string? OrgCountry { get; set; }

    [JsonPropertyName("OrgEntryName")]
    public string? OrgEntryName { get; set; }

    /// <summary>
    /// URL of the organization's favicon.
    /// </summary>
    [JsonPropertyName("OrgFavicon")]
    public string? OrgFavicon { get; set; }

    [JsonPropertyName("OrgId")]
    public string? OrgId { get; set; }

    /// <summary>
    /// URL of the organization's logo.
    /// </summary>
    [JsonPropertyName("OrgLogo")]
    public string? OrgLogo { get; set; }

    [JsonPropertyName("OrgName")]
    public string? OrgName { get; set; }

    [JsonPropertyName("OrgParentId")]
    public long? OrgParentId { get; set; }

    [JsonPropertyName("OrgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("OrgState")]
    public string? OrgState { get; set; }

    [JsonPropertyName("OrgTimezone")]
    public int? OrgTimezone { get; set; }

    [JsonPropertyName("OrgType")]
    public int? OrgType { get; set; }

    [JsonPropertyName("OrgWebsite")]
    public string? OrgWebsite { get; set; }

    [JsonPropertyName("OrgZip")]
    public string? OrgZip { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("ReplyToEmail")]
    public string? ReplyToEmail { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

    [JsonPropertyName("Services")]
    public IEnumerable<OrganizationQueryRecordServicesItem>? Services { get; set; }

    [JsonPropertyName("summary")]
    public SummaryOrg? Summary { get; set; }

    [JsonPropertyName("users")]
    public IEnumerable<UserQueryRecord>? Users { get; set; }

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
