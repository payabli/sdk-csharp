using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PaypointData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }

    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }

    [JsonPropertyName("bankData")]
    public IEnumerable<Bank>? BankData { get; set; }

    [JsonPropertyName("boardingId")]
    public long? BoardingId { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("credentials")]
    public IEnumerable<PayabliCredentialsPascal>? Credentials { get; set; }

    [JsonPropertyName("dbaName")]
    public string? DbaName { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Fax number
    /// </summary>
    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("idPaypoint")]
    public long? IdPaypoint { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("parentOrg")]
    public OrgData? ParentOrg { get; set; }

    [JsonPropertyName("paypointStatus")]
    public int? PaypointStatus { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("serviceData")]
    public Services? ServiceData { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("summary")]
    public PaypointSummary? Summary { get; set; }

    [JsonPropertyName("timeZone")]
    public int? TimeZone { get; set; }

    [JsonPropertyName("websiteAddress")]
    public string? WebsiteAddress { get; set; }

    [JsonPropertyName("zip")]
    public string? Zip { get; set; }

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
