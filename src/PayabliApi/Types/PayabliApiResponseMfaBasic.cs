using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponseMfaBasic : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("mfa")]
    public bool? Mfa { get; set; }

    /// <summary>
    /// The mode of multi-factor authentication used.
    /// </summary>
    [JsonPropertyName("mfaMode")]
    public string? MfaMode { get; set; }

    [JsonPropertyName("mfaValidationCode")]
    public string? MfaValidationCode { get; set; }

    /// <summary>
    /// Data returned by the response, masked for security.
    /// </summary>
    [JsonPropertyName("responseData")]
    public string? ResponseData { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

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
