using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response for a deposit funds request.
/// </summary>
[Serializable]
public record DepositFundsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    /// <summary>
    /// The object containing the response data.
    /// </summary>
    [JsonPropertyName("responseData")]
    public Dictionary<string, object?>? ResponseData { get; set; }

    /// <summary>
    /// Auxiliary validation used internally by payment pages and components.
    /// </summary>
    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

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
