using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// The response data containing the result of the import operation.
/// </summary>
[Serializable]
public record PayabliApiResponseImportResponseData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The number of records successfully added.
    /// </summary>
    [JsonPropertyName("added")]
    public int? Added { get; set; }

    /// <summary>
    /// List of errors, if any.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<string>? Errors { get; set; }

    /// <summary>
    /// The number of records that were rejected.
    /// </summary>
    [JsonPropertyName("rejected")]
    public int? Rejected { get; set; }

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
