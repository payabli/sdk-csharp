using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Success response
/// </summary>
[Serializable]
public record AddPayoutSubscriptionResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    /// <summary>
    /// The identifier of the newly created payout subscription.
    /// </summary>
    [JsonPropertyName("responseData")]
    public required int ResponseData { get; set; }

    /// <summary>
    /// The identifier of the vendor associated with the payout subscription.
    /// </summary>
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
