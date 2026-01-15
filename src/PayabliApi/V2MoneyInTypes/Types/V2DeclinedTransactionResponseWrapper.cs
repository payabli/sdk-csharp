using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response wrapper for declined v2 Money In transaction endpoints (HTTP 402). Returned when a transaction is declined by the card network or issuer. All decline responses use this format with unified response codes starting with 'D'. The `data` field contains transaction details.
/// </summary>
[Serializable]
public record V2DeclinedTransactionResponseWrapper : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("code")]
    public required string Code { get; set; }

    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    [JsonPropertyName("explanation")]
    public required string Explanation { get; set; }

    [JsonPropertyName("action")]
    public required string Action { get; set; }

    [JsonPropertyName("data")]
    public required V2TransactionDetails Data { get; set; }

    /// <summary>
    /// Pagination token (equivalent to `pageIdentifier` in v1 APIs). Returns `null` when pagination is not applicable.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

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
