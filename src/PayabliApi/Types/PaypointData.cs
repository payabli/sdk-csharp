using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PaypointData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("Address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("Address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("BankData")]
    public IEnumerable<Bank>? BankData { get; set; }

    [JsonPropertyName("BoardingId")]
    public long? BoardingId { get; set; }

    [JsonPropertyName("City")]
    public string? City { get; set; }

    [JsonPropertyName("Contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    [JsonPropertyName("Country")]
    public string? Country { get; set; }

    [JsonPropertyName("Credentials")]
    public IEnumerable<PayabliCredentialsPascal>? Credentials { get; set; }

    [JsonPropertyName("DbaName")]
    public string? DbaName { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Fax number
    /// </summary>
    [JsonPropertyName("Fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("IdPaypoint")]
    public long? IdPaypoint { get; set; }

    [JsonPropertyName("LegalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("ParentOrg")]
    public OrgData? ParentOrg { get; set; }

    [JsonPropertyName("PaypointStatus")]
    public int? PaypointStatus { get; set; }

    [JsonPropertyName("Phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("ServiceData")]
    public Services? ServiceData { get; set; }

    [JsonPropertyName("State")]
    public string? State { get; set; }

    [JsonPropertyName("summary")]
    public PaypointSummary? Summary { get; set; }

    [JsonPropertyName("TimeZone")]
    public int? TimeZone { get; set; }

    [JsonPropertyName("WebsiteAddress")]
    public string? WebsiteAddress { get; set; }

    [JsonPropertyName("Zip")]
    public string? Zip { get; set; }

    /// <summary>
    /// Configuration for billing statement email recipients and sender address. `null` if not configured.
    /// </summary>
    [JsonPropertyName("StatementEmail")]
    public StatementEmailConfig? StatementEmail { get; set; }

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
