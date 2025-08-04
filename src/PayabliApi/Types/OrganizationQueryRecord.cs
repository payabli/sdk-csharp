using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OrganizationQueryRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("services")]
    public IEnumerable<OrganizationQueryRecordServicesItem>? Services { get; set; }

    [JsonPropertyName("billingInfo")]
    public Instrument? BillingInfo { get; set; }

    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("hasBilling")]
    public bool? HasBilling { get; set; }

    [JsonPropertyName("hasResidual")]
    public bool? HasResidual { get; set; }

    [JsonPropertyName("idOrg")]
    public long? IdOrg { get; set; }

    [JsonPropertyName("isRoot")]
    public bool? IsRoot { get; set; }

    [JsonPropertyName("orgAddress")]
    public string? OrgAddress { get; set; }

    [JsonPropertyName("orgCity")]
    public string? OrgCity { get; set; }

    [JsonPropertyName("orgCountry")]
    public string? OrgCountry { get; set; }

    [JsonPropertyName("orgEntryName")]
    public string? OrgEntryName { get; set; }

    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("orgLogo")]
    public FileContent? OrgLogo { get; set; }

    [JsonPropertyName("orgName")]
    public string? OrgName { get; set; }

    [JsonPropertyName("orgParentId")]
    public long? OrgParentId { get; set; }

    [JsonPropertyName("orgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("orgState")]
    public string? OrgState { get; set; }

    [JsonPropertyName("orgTimezone")]
    public int? OrgTimezone { get; set; }

    [JsonPropertyName("orgType")]
    public int? OrgType { get; set; }

    [JsonPropertyName("orgWebsite")]
    public string? OrgWebsite { get; set; }

    [JsonPropertyName("orgZip")]
    public string? OrgZip { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("replyToEmail")]
    public string? ReplyToEmail { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

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
