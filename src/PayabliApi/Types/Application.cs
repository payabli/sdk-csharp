using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A boarding application (request), as returned when you create, get, or update one.
/// </summary>
[Serializable]
public record Application : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The reference of the paypoint the application boards.
    /// </summary>
    [JsonPropertyName("paypointReference")]
    public required string PaypointReference { get; set; }

    /// <summary>
    /// The status of the paypoint the application boards. New paypoints start in `pending`.
    /// </summary>
    [JsonPropertyName("paypointStatus")]
    public required string PaypointStatus { get; set; }

    /// <summary>
    /// The application reference, used to read and manage the application.
    /// </summary>
    [JsonPropertyName("requestsReference")]
    public required string RequestsReference { get; set; }

    /// <summary>
    /// The reference of the business being boarded.
    /// </summary>
    [JsonPropertyName("businessReference")]
    public required string BusinessReference { get; set; }

    /// <summary>
    /// An identifier from your own system.
    /// </summary>
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The reference of the organization the application belongs to.
    /// </summary>
    [JsonPropertyName("parent")]
    public string? Parent { get; set; }

    /// <summary>
    /// The name of the organization the application belongs to.
    /// </summary>
    [JsonPropertyName("parentOrgName")]
    public string? ParentOrgName { get; set; }

    /// <summary>
    /// The type of entity being boarded.
    /// </summary>
    [JsonPropertyName("entityType")]
    public string? EntityType { get; set; }

    /// <summary>
    /// The doing-business-as name.
    /// </summary>
    [JsonPropertyName("dbaName")]
    public string? DbaName { get; set; }

    /// <summary>
    /// The application's lifecycle status, as a lowercase name. For what moves an application between statuses, see [Boarding application statuses](/guides/pay-ops-boarding-application-status-reference). One of:
    ///
    /// - `draft` (1): Created and editable. The only status that accepts updates.
    /// - `submitted` (2): Submitted with the signature of record.
    /// - `verifying` (3): Automated verification is in progress.
    /// - `pendingreview` (4): Awaiting underwriting review.
    /// - `escalatedreview` (5): Escalated to a higher review tier.
    /// - `pendingdocuments` (6): Underwriting requested documents from the applicant.
    /// - `pendingresponse` (7): Underwriting asked the applicant a question.
    /// - `approved` (8): Approved and waiting for services to be enabled.
    /// - `autoapproved` (9): Approved without manual review.
    /// - `denied` (10): Denied. Terminal.
    /// - `withdrawn` (11): Withdrawn. Terminal.
    /// - `abandoned` (12): Reserved. No action moves an application to this status.
    /// - `error` (13): Processing hit an error. Payabli can recover the application from this status.
    /// - `activated` (14): The requested services are provisioned and live. Terminal. An `approved` or `autoapproved` application moves to `activated` automatically after all requested services are boarded.
    /// </summary>
    [JsonPropertyName("applicationStatus")]
    public required string ApplicationStatus { get; set; }

    /// <summary>
    /// The numeric code of the application's lifecycle status. See `applicationStatus` for the code of each status.
    /// </summary>
    [JsonPropertyName("applicationStatusCode")]
    public required int ApplicationStatusCode { get; set; }

    /// <summary>
    /// The lifecycle actions currently allowed on the application. The list can include actions that Payabli or its internal services perform, which you can't call through the API.
    /// </summary>
    [JsonPropertyName("allowedActions")]
    public IEnumerable<string> AllowedActions { get; set; } = new List<string>();

    /// <summary>
    /// The reference of the boarding template applied to the application.
    /// </summary>
    [JsonPropertyName("requestTemplate")]
    public string? RequestTemplate { get; set; }

    /// <summary>
    /// The services the application requests. Left out when the application doesn't request any.
    /// </summary>
    [JsonPropertyName("services")]
    public RequestedServices? Services { get; set; }

    /// <summary>
    /// Labels for the application.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    /// <summary>
    /// The representatives assigned to the application.
    /// </summary>
    [JsonPropertyName("representatives")]
    public IEnumerable<RepresentativeResponse>? Representatives { get; set; }

    /// <summary>
    /// When the application was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required string CreatedAt { get; set; }

    /// <summary>
    /// When the application was submitted.
    /// </summary>
    [JsonPropertyName("submittedAt")]
    public string? SubmittedAt { get; set; }

    /// <summary>
    /// Hypermedia links for the application resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required ApplicationLinks Links { get; set; }

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
