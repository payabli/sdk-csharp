using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response data from payment processor
/// </summary>
[Serializable]
public record TransactionDetailResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("response")]
    public string? Response { get; set; }

    [JsonPropertyName("responsetext")]
    public required string Responsetext { get; set; }

    [JsonPropertyName("authcode")]
    public string? Authcode { get; set; }

    [JsonPropertyName("transactionid")]
    public required string Transactionid { get; set; }

    [JsonPropertyName("avsresponse")]
    public string? Avsresponse { get; set; }

    [JsonPropertyName("avsresponse_text")]
    public string? AvsresponseText { get; set; }

    [JsonPropertyName("cvvresponse")]
    public string? Cvvresponse { get; set; }

    [JsonPropertyName("cvvresponse_text")]
    public string? CvvresponseText { get; set; }

    [JsonPropertyName("orderid")]
    public string? Orderid { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("response_code")]
    public required string ResponseCode { get; set; }

    [JsonPropertyName("response_code_text")]
    public required string ResponseCodeText { get; set; }

    [JsonPropertyName("customer_vault_id")]
    public string? CustomerVaultId { get; set; }

    [JsonPropertyName("emv_auth_response_data")]
    public string? EmvAuthResponseData { get; set; }

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
