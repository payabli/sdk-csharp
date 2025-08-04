using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record DocumentSection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("visble")]
    public bool? Visble { get; set; }

    [JsonPropertyName("subFooter")]
    public string? SubFooter { get; set; }

    [JsonPropertyName("subHeader")]
    public string? SubHeader { get; set; }

    [JsonPropertyName("depositBank")]
    public BankSection? DepositBank { get; set; }

    /// <summary>
    /// The minimum number of documents the applicant must upload with the application.
    /// </summary>
    [JsonPropertyName("minimumDocuments")]
    public int? MinimumDocuments { get; set; }

    /// <summary>
    /// When `true`, allows the applicant to upload documents to the application.
    /// </summary>
    [JsonPropertyName("uploadDocuments")]
    public bool? UploadDocuments { get; set; }

    [JsonPropertyName("bankData")]
    public BankSection? BankData { get; set; }

    [JsonPropertyName("termsAndConditions")]
    public DocumentSectionTermsAndConditions? TermsAndConditions { get; set; }

    [JsonPropertyName("signer")]
    public SignerSection? Signer { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }

    [JsonPropertyName("withdrawalBank")]
    public BankSection? WithdrawalBank { get; set; }

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
