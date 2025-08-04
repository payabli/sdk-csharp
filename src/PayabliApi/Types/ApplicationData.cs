using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ApplicationData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("services")]
    public Services? Services { get; set; }

    [JsonPropertyName("annualRevenue")]
    public double? AnnualRevenue { get; set; }

    [JsonPropertyName("attachments")]
    public IEnumerable<FileContent>? Attachments { get; set; }

    [JsonPropertyName("avgmonthly")]
    public double? Avgmonthly { get; set; }

    [JsonPropertyName("baddress")]
    public string? Baddress { get; set; }

    [JsonPropertyName("baddress1")]
    public string? Baddress1 { get; set; }

    [JsonPropertyName("bankData")]
    public Bank? BankData { get; set; }

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

    [JsonPropertyName("bstate")]
    public string? Bstate { get; set; }

    [JsonPropertyName("bsummary")]
    public string? Bsummary { get; set; }

    [JsonPropertyName("btype")]
    public OwnType? Btype { get; set; }

    [JsonPropertyName("bzip")]
    public string? Bzip { get; set; }

    [JsonPropertyName("contacts")]
    public IEnumerable<Contacts>? Contacts { get; set; }

    [JsonPropertyName("dbaname")]
    public string? Dbaname { get; set; }

    [JsonPropertyName("ein")]
    public string? Ein { get; set; }

    [JsonPropertyName("externalPaypointId")]
    public string? ExternalPaypointId { get; set; }

    [JsonPropertyName("faxnumber")]
    public string? Faxnumber { get; set; }

    [JsonPropertyName("highticketamt")]
    public double? Highticketamt { get; set; }

    [JsonPropertyName("legalname")]
    public string? Legalname { get; set; }

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

    [JsonPropertyName("ownership")]
    public IEnumerable<Owners>? Ownership { get; set; }

    [JsonPropertyName("payoutAverageMonthlyVolume")]
    public double? PayoutAverageMonthlyVolume { get; set; }

    [JsonPropertyName("payoutAverageTicketLimit")]
    public double? PayoutAverageTicketLimit { get; set; }

    [JsonPropertyName("payoutCreditLimit")]
    public double? PayoutCreditLimit { get; set; }

    [JsonPropertyName("payoutHighTicketAmount")]
    public double? PayoutHighTicketAmount { get; set; }

    [JsonPropertyName("phonenumber")]
    public string? Phonenumber { get; set; }

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
    public SignerDataRequest? Signer { get; set; }

    [JsonPropertyName("startdate")]
    public string? Startdate { get; set; }

    [JsonPropertyName("taxfillname")]
    public string? Taxfillname { get; set; }

    [JsonPropertyName("templateId")]
    public long? TemplateId { get; set; }

    [JsonPropertyName("ticketamt")]
    public double? Ticketamt { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("whenCharged")]
    public Whencharged? WhenCharged { get; set; }

    [JsonPropertyName("whenDelivered")]
    public Whendelivered? WhenDelivered { get; set; }

    [JsonPropertyName("whenProvided")]
    public Whenprovided? WhenProvided { get; set; }

    [JsonPropertyName("whenRefunded")]
    public Whenrefunded? WhenRefunded { get; set; }

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
