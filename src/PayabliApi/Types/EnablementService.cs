using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The enablement progress of one service the application requested.
/// </summary>
[Serializable]
public record EnablementService : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The service, such as `Card`.
    /// </summary>
    [JsonPropertyName("service")]
    public required string Service { get; set; }

    /// <summary>
    /// Whether the service moves money in (`MoneyIn`) or out (`MoneyOut`).
    /// </summary>
    [JsonPropertyName("rail")]
    public required string Rail { get; set; }

    /// <summary>
    /// The service's enablement state. One of:
    ///
    /// - `Pending`: Not sent to the processor yet.
    /// - `Submitted`: Sent to the processor, waiting for a response.
    /// - `Approved`: The processor approved the service.
    /// - `Provisioned`: The service is set up and ready to use.
    /// - `HeldForInput`: Needs a correction or more information. Enablement resumes after someone acts.
    /// - `Failed`: Enablement failed for this service.
    /// </summary>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// A sentence about the service when its last attempt didn't go through, or when it failed. When the processor refused fields or reported them as missing, the sentence names them. `null` otherwise.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The boarding API fields the processor refused or reported as missing, such as `addresses.cityLocality`. `null` when the processor named none.
    /// </summary>
    [JsonPropertyName("missingFields")]
    public IEnumerable<string>? MissingFields { get; set; }

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
