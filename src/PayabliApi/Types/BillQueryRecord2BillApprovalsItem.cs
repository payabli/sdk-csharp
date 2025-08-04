using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillQueryRecord2BillApprovalsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the bill has been approved. `0` is false, and `1` is true.
    /// </summary>
    [JsonPropertyName("approved")]
    public int? Approved { get; set; }

    /// <summary>
    /// Timestamp of when the approval was made, in UTC.
    /// </summary>
    [JsonPropertyName("approvedTime")]
    public DateTime? ApprovedTime { get; set; }

    /// <summary>
    /// Additional comments on the approval.
    /// </summary>
    [JsonPropertyName("comments")]
    public string? Comments { get; set; }

    /// <summary>
    /// The approving user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The approving user's ID.
    /// </summary>
    [JsonPropertyName("Id")]
    public long? Id { get; set; }

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
