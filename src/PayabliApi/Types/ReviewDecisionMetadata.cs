using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Details of a reviewer's decision, when one has been made.
/// </summary>
[Serializable]
public record ReviewDecisionMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The decline reason, when the case was denied.
    /// </summary>
    [JsonPropertyName("declineReason")]
    public BankReviewDecisionReason? DeclineReason { get; set; }

    /// <summary>
    /// A free-text note attached to the decision.
    /// </summary>
    [JsonPropertyName("note")]
    public string? Note { get; set; }

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
