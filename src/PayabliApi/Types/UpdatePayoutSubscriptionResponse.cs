using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Success response
/// </summary>
[Serializable]
public record UpdatePayoutSubscriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    /// <summary>
    /// If `isSuccess` = true, this contains the payout subscription ID. When the subscription is paused, it also includes a description (for example, "42 paused").
    ///
    /// If `isSuccess` = false, this contains the reason for the failure.
    /// </summary>
    [JsonPropertyName("responseData")]
    public string? ResponseData { get; set; }

    [JsonPropertyName("customerId")]
    public long? CustomerId { get; set; }

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
