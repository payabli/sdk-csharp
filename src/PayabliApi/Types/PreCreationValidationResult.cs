using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The result of validating a bank account change before creating a case.
/// </summary>
[Serializable]
public record PreCreationValidationResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether the request can be created. False when there are blocking conditions.
    /// </summary>
    [JsonPropertyName("isValid")]
    public required bool IsValid { get; set; }

    /// <summary>
    /// Conditions that prevent creation. Must be resolved first.
    /// </summary>
    [JsonPropertyName("blockingConditions")]
    public IEnumerable<string> BlockingConditions { get; set; } = new List<string>();

    /// <summary>
    /// Informational warnings. Creation can still proceed.
    /// </summary>
    [JsonPropertyName("warnings")]
    public IEnumerable<string> Warnings { get; set; } = new List<string>();

    /// <summary>
    /// Field-level validation errors.
    /// </summary>
    [JsonPropertyName("validationErrors")]
    public IEnumerable<string> ValidationErrors { get; set; } = new List<string>();

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
