using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The transaction's response data.
/// </summary>
[Serializable]
public record QueryResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authcode")]
    public string? Authcode { get; set; }

    [JsonPropertyName("avsresponse")]
    public string? Avsresponse { get; set; }

    [JsonPropertyName("avsresponse_text")]
    public string? AvsresponseText { get; set; }

    [JsonPropertyName("cvvresponse")]
    public string? Cvvresponse { get; set; }

    [JsonPropertyName("cvvresponse_text")]
    public string? CvvresponseText { get; set; }

    [JsonPropertyName("emv_auth_response_data")]
    public string? EmvAuthResponseData { get; set; }

    [JsonPropertyName("orderid")]
    public string? Orderid { get; set; }

    /// <summary>
    /// Response text for operation: 'Success' or 'Declined'.
    /// </summary>
    [JsonPropertyName("response")]
    public string? Response { get; set; }

    /// <summary>
    /// Internal result code processing the transaction. Value 1 indicates successful operation, values 2 and 3 indicate errors.
    /// </summary>
    [JsonPropertyName("response_code")]
    public string? ResponseCode { get; set; }

    /// <summary>
    /// Text describing the result. If resultCode = 1, will return 'Approved' or a general success message. If resultCode = 2 or 3, will contain the cause of the decline.
    /// </summary>
    [JsonPropertyName("response_code_text")]
    public string? ResponseCodeText { get; set; }

    /// <summary>
    /// Text describing the result. If resultCode = 1, will return 'Approved' or a general success message. If resultCode = 2 or 3, will contain the cause of the decline.
    /// </summary>
    [JsonPropertyName("responsetext")]
    public string? Responsetext { get; set; }

    [JsonPropertyName("resultCode")]
    public string? ResultCode { get; set; }

    [JsonPropertyName("resultCodeText")]
    public string? ResultCodeText { get; set; }

    /// <summary>
    /// The transaction identifier in Payabli.
    /// </summary>
    [JsonPropertyName("transactionid")]
    public string? Transactionid { get; set; }

    /// <summary>
    /// Type of transaction or operation.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

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
