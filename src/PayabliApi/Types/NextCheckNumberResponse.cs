using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response body for the next check number lookup.
/// </summary>
[Serializable]
public record NextCheckNumberResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The suggested next check number for the paypoint and funding account. Payabli returns the highest check number on the account's check payouts plus one, or `1` if the account has no check history. Canceled check payouts don't count.
    /// </summary>
    [JsonPropertyName("checkNumber")]
    public required string CheckNumber { get; set; }

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
