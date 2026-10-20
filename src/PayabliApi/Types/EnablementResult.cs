using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The progress of setting up an approved application's services with their processors.
/// </summary>
[Serializable]
public record EnablementResult : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The application reference.
    /// </summary>
    [JsonPropertyName("requestsReference")]
    public required string RequestsReference { get; set; }

    /// <summary>
    /// The overall enablement state. `null` when enablement hasn't started. One of:
    ///
    /// - `Submitted`: Enablement is in progress.
    /// - `Activated`: Every service is `Provisioned`.
    /// - `Failed`: Enablement stopped and isn't retried.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The enablement progress of each requested service. Empty when enablement hasn't started.
    /// </summary>
    [JsonPropertyName("services")]
    public IEnumerable<EnablementService> Services { get; set; } = new List<EnablementService>();

    /// <summary>
    /// Why enablement isn't moving. `null` when nothing is blocking it, or when enablement hasn't started. One of:
    ///
    /// - `processor`: At least one service is waiting on its processor, for example during an outage or the processor's review. Payabli retries automatically.
    /// - `merchant_data`: Something about the merchant needs a correction, such as fields the processor refused or a missing tax ID. Check `missingFields` on each service.
    /// - `platform_configuration`: Waiting on configuration that Payabli maintains. The merchant doesn't need to act.
    /// - `enablement_failed`: Enablement stopped and isn't retried. `services` shows which service stopped.
    /// - `unclassified`: Enablement isn't complete, and the cause isn't determined yet.
    /// </summary>
    [JsonPropertyName("blockedOn")]
    public string? BlockedOn { get; set; }

    /// <summary>
    /// A sentence that explains `blockedOn`. From the second attempt on, it includes the number of attempts.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// How many times Payabli has attempted enablement. `null` when enablement hasn't started.
    /// </summary>
    [JsonPropertyName("attempts")]
    public int? Attempts { get; set; }

    /// <summary>
    /// When Payabli first attempted enablement.
    /// </summary>
    [JsonPropertyName("firstAttemptAt")]
    public DateTime? FirstAttemptAt { get; set; }

    /// <summary>
    /// When Payabli most recently attempted enablement.
    /// </summary>
    [JsonPropertyName("lastAttemptAt")]
    public DateTime? LastAttemptAt { get; set; }

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
