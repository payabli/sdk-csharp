using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Detailed bank account verification results from the verification network.
/// </summary>
[Serializable]
public record BankAccountVerificationDetailsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ABA routing number that was verified.
    /// </summary>
    [JsonPropertyName("aba")]
    public string? Aba { get; set; }

    /// <summary>
    /// The account number that was verified.
    /// </summary>
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Whether the bank account passed verification.
    /// </summary>
    [JsonPropertyName("isValid")]
    public required bool IsValid { get; set; }

    /// <summary>
    /// Error message if the verification request failed.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Overall verification outcome. Possible values include `Pass`, `Verified`, `Declined`, `NoData`, `Bypassed`, and `Error`.
    /// </summary>
    [JsonPropertyName("verificationResponse")]
    public string? VerificationResponse { get; set; }

    /// <summary>
    /// Response code returned by the verification network.
    /// </summary>
    [JsonPropertyName("responseCode")]
    public string? ResponseCode { get; set; }

    /// <summary>
    /// Response value associated with the verification outcome.
    /// </summary>
    [JsonPropertyName("responseValue")]
    public string? ResponseValue { get; set; }

    /// <summary>
    /// Human-readable description of the verification outcome.
    /// </summary>
    [JsonPropertyName("responseDescription")]
    public string? ResponseDescription { get; set; }

    /// <summary>
    /// Name of the bank associated with the routing number.
    /// </summary>
    [JsonPropertyName("bankName")]
    public string? BankName { get; set; }

    /// <summary>
    /// Account type as reported by the verification network, such as `Checking` or `Savings`.
    /// </summary>
    [JsonPropertyName("reportedAccountType")]
    public string? ReportedAccountType { get; set; }

    /// <summary>
    /// Date the account was first seen by the verification network (ISO 8601 format).
    /// </summary>
    [JsonPropertyName("accountAddedDate")]
    public string? AccountAddedDate { get; set; }

    /// <summary>
    /// Date the account record was last updated in the verification network (ISO 8601 format).
    /// </summary>
    [JsonPropertyName("accountLastUpdatedDate")]
    public string? AccountLastUpdatedDate { get; set; }

    /// <summary>
    /// Date the account was closed, if applicable (ISO 8601 format).
    /// </summary>
    [JsonPropertyName("accountClosedDate")]
    public string? AccountClosedDate { get; set; }

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
