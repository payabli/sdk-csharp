using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ApplicationDetailsRecord : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("annualRevenue")]
    public double? AnnualRevenue { get; set; }

    [JsonPropertyName("averageMonthlyVolume")]
    public double? AverageMonthlyVolume { get; set; }

    [JsonPropertyName("averageTicketAmount")]
    public double? AverageTicketAmount { get; set; }

    [JsonPropertyName("bAddress1")]
    public string? BAddress1 { get; set; }

    [JsonPropertyName("bAddress2")]
    public string? BAddress2 { get; set; }

    [JsonPropertyName("bankData")]
    public IEnumerable<Bank>? BankData { get; set; }

    [JsonPropertyName("bCity")]
    public string? BCity { get; set; }

    [JsonPropertyName("bCountry")]
    public string? BCountry { get; set; }

    /// <summary>
    /// The business's fax number.
    /// </summary>
    [JsonPropertyName("bFax")]
    public string? BFax { get; set; }

    [JsonPropertyName("binPerson")]
    public int? BinPerson { get; set; }

    [JsonPropertyName("binPhone")]
    public int? BinPhone { get; set; }

    [JsonPropertyName("binWeb")]
    public int? BinWeb { get; set; }

    [JsonPropertyName("boardingLinkId")]
    public int? BoardingLinkId { get; set; }

    [JsonPropertyName("boardingStatus")]
    public int? BoardingStatus { get; set; }

    [JsonPropertyName("boardingSubStatus")]
    public int? BoardingSubStatus { get; set; }

    [JsonPropertyName("bPhone")]
    public string? BPhone { get; set; }

    [JsonPropertyName("bStartdate")]
    public string? BStartdate { get; set; }

    [JsonPropertyName("bState")]
    public string? BState { get; set; }

    [JsonPropertyName("bSummary")]
    public string? BSummary { get; set; }

    [JsonPropertyName("builderData")]
    public BuilderData? BuilderData { get; set; }

    [JsonPropertyName("bZip")]
    public string? BZip { get; set; }

    [JsonPropertyName("contactData")]
    public IEnumerable<Contacts>? ContactData { get; set; }

    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("dbaName")]
    public string? DbaName { get; set; }

    [JsonPropertyName("documentsRef")]
    public BoardingApplicationAttachments? DocumentsRef { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    [JsonPropertyName("externalPaypointId")]
    public string? ExternalPaypointId { get; set; }

    /// <summary>
    /// Events associated with the application.
    /// </summary>
    [JsonPropertyName("generalEvents")]
    public IEnumerable<GeneralEvents>? GeneralEvents { get; set; }

    [JsonPropertyName("highTicketAmount")]
    public double? HighTicketAmount { get; set; }

    [JsonPropertyName("idApplication")]
    public int? IdApplication { get; set; }

    [JsonPropertyName("lastModified")]
    public DateTime? LastModified { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("license")]
    public string? License { get; set; }

    [JsonPropertyName("licenseState")]
    public string? LicenseState { get; set; }

    /// <summary>
    /// Object containing logo file.
    /// </summary>
    [JsonPropertyName("logo")]
    public FileContent? Logo { get; set; }

    [JsonPropertyName("mAddress1")]
    public string? MAddress1 { get; set; }

    [JsonPropertyName("mAddress2")]
    public string? MAddress2 { get; set; }

    [JsonPropertyName("mccid")]
    public string? Mccid { get; set; }

    [JsonPropertyName("mCity")]
    public string? MCity { get; set; }

    [JsonPropertyName("mCountry")]
    public string? MCountry { get; set; }

    [JsonPropertyName("messages")]
    public IEnumerable<ApplicationDetailsRecordMessagesItem>? Messages { get; set; }

    [JsonPropertyName("mState")]
    public string? MState { get; set; }

    [JsonPropertyName("mZip")]
    public string? MZip { get; set; }

    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    [JsonPropertyName("orgParentName")]
    public string? OrgParentName { get; set; }

    [JsonPropertyName("ownerData")]
    public IEnumerable<Owners>? OwnerData { get; set; }

    [JsonPropertyName("ownType")]
    public OwnType? OwnType { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

    [JsonPropertyName("salesCode")]
    public string? SalesCode { get; set; }

    [JsonPropertyName("serviceData")]
    public Services? ServiceData { get; set; }

    [JsonPropertyName("signer")]
    public SignerData? Signer { get; set; }

    [JsonPropertyName("taxfillname")]
    public string? Taxfillname { get; set; }

    [JsonPropertyName("templateId")]
    public long? TemplateId { get; set; }

    [JsonPropertyName("websiteAddress")]
    public string? WebsiteAddress { get; set; }

    [JsonPropertyName("whencharged")]
    public Whencharged? Whencharged { get; set; }

    [JsonPropertyName("whendelivered")]
    public Whendelivered? Whendelivered { get; set; }

    [JsonPropertyName("whenProvided")]
    public Whenprovided? WhenProvided { get; set; }

    [JsonPropertyName("whenrefund")]
    public Whenrefunded? Whenrefund { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

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
