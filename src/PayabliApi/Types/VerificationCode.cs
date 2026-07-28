using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A single bank-verification result code returned by the verification provider.
/// </summary>
[Serializable]
public record VerificationCode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The numeric result code.
    /// </summary>
    [JsonPropertyName("code")]
    public required int Code { get; set; }

    /// <summary>
    /// The short code name.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A human-readable description of the result.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }

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
