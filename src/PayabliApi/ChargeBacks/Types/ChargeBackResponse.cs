using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ChargeBackResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Object with attached files to response
    /// </summary>
    [JsonPropertyName("attachments")]
    public BoardingApplicationAttachments? Attachments { get; set; }

    /// <summary>
    /// Email of response submitter.
    /// </summary>
    [JsonPropertyName("contactEmail")]
    public string? ContactEmail { get; set; }

    /// <summary>
    /// Name of response submitter
    /// </summary>
    [JsonPropertyName("contactName")]
    public string? ContactName { get; set; }

    /// <summary>
    /// Timestamp when response was submitted, in UTC.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Chargeback response identifier
    /// </summary>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Response notes
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

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
