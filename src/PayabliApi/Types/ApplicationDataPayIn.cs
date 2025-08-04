using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Fields for Pay In boarding applications.
/// </summary>
[Serializable]
public record ApplicationDataPayIn : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("services")]
    public required ApplicationDataPayInServices Services { get; set; }

    [JsonPropertyName("annualRevenue")]
    public double? AnnualRevenue { get; set; }

    [JsonPropertyName("averageBillSize")]
    public string? AverageBillSize { get; set; }

    [JsonPropertyName("averageMonthlyBill")]
    public string? AverageMonthlyBill { get; set; }

    [JsonPropertyName("avgmonthly")]
    public double? Avgmonthly { get; set; }

    [JsonPropertyName("baddress")]
    public string? Baddress { get; set; }

    [JsonPropertyName("baddress1")]
    public string? Baddress1 { get; set; }

    [JsonPropertyName("bankData")]
    public required ApplicationDataPayInBankData BankData { get; set; }

    [JsonPropertyName("bcity")]
    public string? Bcity { get; set; }

    [JsonPropertyName("bcountry")]
    public string? Bcountry { get; set; }

    [JsonPropertyName("binperson")]
    public int? Binperson { get; set; }

    [JsonPropertyName("binphone")]
    public int? Binphone { get; set; }

    [JsonPropertyName("binweb")]
    public int? Binweb { get; set; }

    /// <summary>
    /// Boarding link ID for the application. Either `templateId` or `boardingLinkId` are required.
    /// </summary>
    [JsonPropertyName("boardingLinkId")]
    public string? BoardingLinkId { get; set; }

    [JsonPropertyName("bstate")]
    public string? Bstate { get; set; }

    [JsonPropertyName("bsummary")]
    public string? Bsummary { get; set; }

    [JsonPropertyName("btype")]
    public OwnType? Btype { get; set; }

    [JsonPropertyName("bzip")]
    public string? Bzip { get; set; }

    /// <summary>
    /// List of contacts for the business.
    /// </summary>
    [JsonPropertyName("contacts")]
    public IEnumerable<ApplicationDataPayInContactsItem>? Contacts { get; set; }

    [JsonPropertyName("creditLimit")]
    public string? CreditLimit { get; set; }

    /// <summary>
    /// The alternate or common name that this business is doing business under usually referred to as a DBA name. Payabli strongly recommends including this information.
    /// </summary>
    [JsonPropertyName("dbaName")]
    public string? DbaName { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    [JsonPropertyName("externalpaypointID")]
    public string? ExternalpaypointId { get; set; }

    /// <summary>
    /// The business's fax number.
    /// </summary>
    [JsonPropertyName("faxnumber")]
    public string? Faxnumber { get; set; }

    [JsonPropertyName("highticketamt")]
    public double? Highticketamt { get; set; }

    [JsonPropertyName("legalName")]
    public string? LegalName { get; set; }

    [JsonPropertyName("license")]
    public string? License { get; set; }

    [JsonPropertyName("licstate")]
    public string? Licstate { get; set; }

    [JsonPropertyName("maddress")]
    public string? Maddress { get; set; }

    [JsonPropertyName("maddress1")]
    public string? Maddress1 { get; set; }

    [JsonPropertyName("mcc")]
    public string? Mcc { get; set; }

    [JsonPropertyName("mcity")]
    public string? Mcity { get; set; }

    [JsonPropertyName("mcountry")]
    public string? Mcountry { get; set; }

    [JsonPropertyName("mstate")]
    public string? Mstate { get; set; }

    [JsonPropertyName("mzip")]
    public string? Mzip { get; set; }

    [JsonPropertyName("orgId")]
    public long? OrgId { get; set; }

    /// <summary>
    /// List of Owners with at least a 25% ownership.
    /// </summary>
    [JsonPropertyName("ownership")]
    public IEnumerable<ApplicationDataPayInOwnershipItem>? Ownership { get; set; }

    /// <summary>
    /// The business's phone number.
    /// </summary>
    [JsonPropertyName("phonenumber")]
    public required string Phonenumber { get; set; }

    [JsonPropertyName("processingRegion")]
    public required BoardingProcessingRegion ProcessingRegion { get; set; }

    /// <summary>
    /// Email address for the applicant. This is used to send the applicant a boarding link.
    /// </summary>
    [JsonPropertyName("recipientEmail")]
    public string? RecipientEmail { get; set; }

    [JsonPropertyName("recipientEmailNotification")]
    public bool? RecipientEmailNotification { get; set; }

    [JsonPropertyName("resumable")]
    public bool? Resumable { get; set; }

    [JsonPropertyName("signer")]
    public required SignerDataRequest Signer { get; set; }

    [JsonPropertyName("startdate")]
    public string? Startdate { get; set; }

    [JsonPropertyName("taxFillName")]
    public string? TaxFillName { get; set; }

    /// <summary>
    /// The associated boarding template's ID in Payabli. Either `templateId` or `boardingLinkId` are required.
    /// </summary>
    [JsonPropertyName("templateId")]
    public long? TemplateId { get; set; }

    [JsonPropertyName("ticketamt")]
    public double? Ticketamt { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("whenCharged")]
    public required Whencharged WhenCharged { get; set; }

    [JsonPropertyName("whenDelivered")]
    public required Whendelivered WhenDelivered { get; set; }

    [JsonPropertyName("whenProvided")]
    public required Whenprovided WhenProvided { get; set; }

    [JsonPropertyName("whenRefunded")]
    public required Whenrefunded WhenRefunded { get; set; }

    [JsonPropertyName("additionalData")]
    public string? AdditionalData { get; set; }

    [JsonPropertyName("RepCode")]
    public string? RepCode { get; set; }

    [JsonPropertyName("RepName")]
    public string? RepName { get; set; }

    [JsonPropertyName("RepOffice")]
    public string? RepOffice { get; set; }

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
