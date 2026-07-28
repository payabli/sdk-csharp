using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The outcome of automatic bank account verification.
/// </summary>
[Serializable]
public record BankVerificationMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("verificationResult")]
    public required VerificationCode VerificationResult { get; set; }

    /// <summary>
    /// The account-level verification code. Null when not returned.
    /// </summary>
    [JsonPropertyName("accountResponseCode")]
    public VerificationCode? AccountResponseCode { get; set; }

    /// <summary>
    /// The customer-level verification code. Null when not returned.
    /// </summary>
    [JsonPropertyName("customerResponseCode")]
    public VerificationCode? CustomerResponseCode { get; set; }

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
