using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Standard response wrapper for v2 Money In transaction endpoints. All v2 transaction endpoints return responses in this format with consistent `code`, `reason`, `explanation`, and `action` fields. The `data` field contains transaction details.
/// </summary>
[Serializable]
public record V2TransactionResponseWrapper : IJsonOnDeserialized
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
