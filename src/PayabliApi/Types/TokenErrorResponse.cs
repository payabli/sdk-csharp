using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Error response from the token endpoint when the request is invalid, for example when the client credentials are wrong.
/// </summary>
[Serializable]
public record TokenErrorResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The error category, for example `InvalidCredentials`.
    /// </summary>
    [JsonPropertyName("errorType")]
    public required string ErrorType { get; set; }

    /// <summary>
    /// A human-readable error description.
    /// </summary>
    [JsonPropertyName("errorMessage")]
    public required string ErrorMessage { get; set; }

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
