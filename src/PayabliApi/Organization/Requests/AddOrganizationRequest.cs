using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AddOrganizationRequest
{
    /// <summary>
    /// A unique ID you can include to prevent duplicating objects or transactions if a request is sent more than once. This key isn't generated in Payabli, you must generate it yourself.
    /// </summary>
    [JsonIgnore]
    public string? IdempotencyKey { get; set; }

    [JsonPropertyName("services")]
    public IEnumerable<ServiceCost>? Services { get; set; }

    [JsonPropertyName("billingInfo")]
    public Instrument? BillingInfo { get; set; }

    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    [JsonPropertyName("hasBilling")]
    public bool? HasBilling { get; set; }

    [JsonPropertyName("hasResidual")]
    public bool? HasResidual { get; set; }

    [JsonPropertyName("orgAddress")]
    public string? OrgAddress { get; set; }

    [JsonPropertyName("orgCity")]
    public string? OrgCity { get; set; }

    [JsonPropertyName("orgCountry")]
    public string? OrgCountry { get; set; }

    [JsonPropertyName("orgEntryName")]
    public string? OrgEntryName { get; set; }

    [JsonPropertyName("orgId")]
    public string? OrgId { get; set; }

    [JsonPropertyName("orgLogo")]
    public FileContent? OrgLogo { get; set; }

    [JsonPropertyName("orgName")]
    public required string OrgName { get; set; }

    [JsonPropertyName("orgParentId")]
    public long? OrgParentId { get; set; }

    [JsonPropertyName("orgState")]
    public string? OrgState { get; set; }

    [JsonPropertyName("orgTimezone")]
    public int? OrgTimezone { get; set; }

    [JsonPropertyName("orgType")]
    public required int OrgType { get; set; }

    [JsonPropertyName("orgWebsite")]
    public string? OrgWebsite { get; set; }

    [JsonPropertyName("orgZip")]
    public string? OrgZip { get; set; }

    [JsonPropertyName("replyToEmail")]
    public required string ReplyToEmail { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
