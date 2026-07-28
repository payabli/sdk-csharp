using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record TransitionCaseRequest
{
    [JsonPropertyName("trigger")]
    public required CaseTrigger Trigger { get; set; }

    /// <summary>
    /// The reason for the action.
    /// </summary>
    [JsonPropertyName("reason")]
    public required string Reason { get; set; }

    /// <summary>
    /// The decline reason. Required when the trigger is `Deny`, and must be omitted otherwise.
    /// </summary>
    [JsonPropertyName("declineReason")]
    public BankReviewDecisionReason? DeclineReason { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
