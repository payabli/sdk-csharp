using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Case metadata, populated as the case progresses. Null until verification completes.
/// </summary>
[Serializable]
public record CaseMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The verification outcome. Null until verification finishes.
    /// </summary>
    [JsonPropertyName("verification")]
    public BankVerificationMetadata? Verification { get; set; }

    /// <summary>
    /// The reviewer's decision, when one has been made.
    /// </summary>
    [JsonPropertyName("reviewDecision")]
    public ReviewDecisionMetadata? ReviewDecision { get; set; }

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
