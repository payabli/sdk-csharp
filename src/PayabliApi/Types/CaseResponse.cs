using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A bank-account-change case.
/// </summary>
[Serializable]
public record CaseResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The case's unique identifier.
    /// </summary>
    [JsonPropertyName("uuid")]
    public required string Uuid { get; set; }

    [JsonPropertyName("state")]
    public required CaseState State { get; set; }

    [JsonPropertyName("caseType")]
    public required CaseType CaseType { get; set; }

    [JsonPropertyName("parameters")]
    public required BankAccountChangeParameters Parameters { get; set; }

    /// <summary>
    /// The organization that owns the case.
    /// </summary>
    [JsonPropertyName("orgId")]
    public required long OrgId { get; set; }

    /// <summary>
    /// The paypoint the case applies to.
    /// </summary>
    [JsonPropertyName("paypointId")]
    public required long PaypointId { get; set; }

    /// <summary>
    /// When the change is scheduled to run. Null when not scheduled.
    /// </summary>
    [JsonPropertyName("scheduleFor")]
    public DateTime? ScheduleFor { get; set; }

    /// <summary>
    /// When the case was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the case was last updated.
    /// </summary>
    [JsonPropertyName("updatedAt")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The numeric id of the user who created the case. `0` when created by a server-side integration.
    /// </summary>
    [JsonPropertyName("createdBy")]
    public required long CreatedBy { get; set; }

    /// <summary>
    /// The numeric id of the assigned reviewer. Null when unassigned.
    /// </summary>
    [JsonPropertyName("assigneeId")]
    public long? AssigneeId { get; set; }

    /// <summary>
    /// The numeric id of the last reviewer. Null when not yet reviewed.
    /// </summary>
    [JsonPropertyName("lastReviewedById")]
    public long? LastReviewedById { get; set; }

    /// <summary>
    /// The ordered history of state transitions.
    /// </summary>
    [JsonPropertyName("stateHistory")]
    public IEnumerable<StateTransitionResponse> StateHistory { get; set; } =
        new List<StateTransitionResponse>();

    /// <summary>
    /// Files attached to the case.
    /// </summary>
    [JsonPropertyName("attachments")]
    public IEnumerable<AttachmentResponse> Attachments { get; set; } =
        new List<AttachmentResponse>();

    /// <summary>
    /// The id of the message room for the case. Null until provisioned.
    /// </summary>
    [JsonPropertyName("roomId")]
    public long? RoomId { get; set; }

    /// <summary>
    /// Case metadata, including the verification outcome. Null until verification completes.
    /// </summary>
    [JsonPropertyName("metadata")]
    public CaseMetadata? Metadata { get; set; }

    /// <summary>
    /// The resolved organization. Null when not enriched.
    /// </summary>
    [JsonPropertyName("org")]
    public OrgRef? Org { get; set; }

    /// <summary>
    /// The resolved paypoint. Null when not enriched.
    /// </summary>
    [JsonPropertyName("paypoint")]
    public PaypointRef? Paypoint { get; set; }

    /// <summary>
    /// The resolved creator. Null when created by a server-side integration or not enriched.
    /// </summary>
    [JsonPropertyName("createdByUser")]
    public UserRef? CreatedByUser { get; set; }

    /// <summary>
    /// The resolved assigned reviewer. Null when unassigned.
    /// </summary>
    [JsonPropertyName("assignee")]
    public UserRef? Assignee { get; set; }

    /// <summary>
    /// The resolved last reviewer. Null when not yet reviewed.
    /// </summary>
    [JsonPropertyName("lastReviewedBy")]
    public UserRef? LastReviewedBy { get; set; }

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
