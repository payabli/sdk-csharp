using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record QueryEntrypointResponseRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("AverageMonthlyVolume")]
    public double? AverageMonthlyVolume { get; set; }

    [JsonPropertyName("AverageTicketAmount")]
    public double? AverageTicketAmount { get; set; }

    [JsonPropertyName("BAddress1")]
    public string? BAddress1 { get; set; }

    [JsonPropertyName("BAddress2")]
    public string? BAddress2 { get; set; }

    [JsonPropertyName("BankData")]
    public IEnumerable<Bank>? BankData { get; set; }

    [JsonPropertyName("BCity")]
    public string? BCity { get; set; }

    [JsonPropertyName("BCountry")]
    public string? BCountry { get; set; }

    /// <summary>
    /// The business's fax number.
    /// </summary>
    [JsonPropertyName("BFax")]
    public string? BFax { get; set; }

    [JsonPropertyName("BinPerson")]
    public int? BinPerson { get; set; }

    [JsonPropertyName("BinPhone")]
    public int? BinPhone { get; set; }

    [JsonPropertyName("BinWeb")]
    public int? BinWeb { get; set; }

    [JsonPropertyName("BoardingId")]
    public long? BoardingId { get; set; }

    [JsonPropertyName("BPhone")]
    public string? BPhone { get; set; }

    [JsonPropertyName("BStartdate")]
    public string? BStartdate { get; set; }

    [JsonPropertyName("BState")]
    public string? BState { get; set; }

    [JsonPropertyName("BSummary")]
    public string? BSummary { get; set; }

    [JsonPropertyName("BTimeZone")]
    public int? BTimeZone { get; set; }

    [JsonPropertyName("BZip")]
    public string? BZip { get; set; }

    [JsonPropertyName("ContactData")]
    public IEnumerable<Contacts>? ContactData { get; set; }

    [JsonPropertyName("CreatedAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("DbaName")]
    public string? DbaName { get; set; }

    [JsonPropertyName("DocumentsRef")]
    public string? DocumentsRef { get; set; }

    [JsonPropertyName("Ein")]
    public string? Ein { get; set; }

    [JsonPropertyName("EntryPoints")]
    public IEnumerable<PaypointEntryConfig>? EntryPoints { get; set; }

    [JsonPropertyName("externalPaypointID")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("ExternalProcessorInformation")]
    public string? ExternalProcessorInformation { get; set; }

    [JsonPropertyName("HighTicketAmount")]
    public double? HighTicketAmount { get; set; }

    [JsonPropertyName("IdPaypoint")]
    public long? IdPaypoint { get; set; }

    [JsonPropertyName("LastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("LegalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("License")]
    public string? License { get; set; }

    [JsonPropertyName("LicenseState")]
    public string? LicenseState { get; set; }

    [JsonPropertyName("MAddress1")]
    public string? MAddress1 { get; set; }

    [JsonPropertyName("MAddress2")]
    public string? MAddress2 { get; set; }

    [JsonPropertyName("Mccid")]
    public string? Mccid { get; set; }

    [JsonPropertyName("MCity")]
    public string? MCity { get; set; }

    [JsonPropertyName("MCountry")]
    public string? MCountry { get; set; }

    [JsonPropertyName("MState")]
    public string? MState { get; set; }

    [JsonPropertyName("MZip")]
    public string? MZip { get; set; }

    [JsonPropertyName("OrgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("OrgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("OwnerData")]
    public IEnumerable<Owners>? OwnerData { get; set; }

    [JsonPropertyName("OwnType")]
    public OwnType? OwnType { get; set; }

    [JsonPropertyName("PaypointStatus")]
    public int? PaypointStatus { get; set; }

    [JsonPropertyName("SalesCode")]
    public string? SalesCode { get; set; }

    [JsonPropertyName("ServiceData")]
    public Services? ServiceData { get; set; }

    [JsonPropertyName("summary")]
    public PaypointSummary? Summary { get; set; }

    [JsonPropertyName("Taxfillname")]
    public string? Taxfillname { get; set; }

    [JsonPropertyName("TemplateId")]
    public long? TemplateId { get; set; }

    /// <summary>
    /// Business website.
    /// </summary>
    [JsonPropertyName("WebsiteAddress")]
    public string? WebsiteAddress { get; set; }

    [JsonPropertyName("Whencharged")]
    public Whencharged? Whencharged { get; set; }

    [JsonPropertyName("Whendelivered")]
    public Whendelivered? Whendelivered { get; set; }

    [JsonPropertyName("Whenprovided")]
    public Whenprovided? Whenprovided { get; set; }

    [JsonPropertyName("Whenrefund")]
    public Whenrefunded? Whenrefund { get; set; }

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
