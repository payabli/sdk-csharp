using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Attachment for a bill.
/// </summary>
[Serializable]
public record TransferOutDetailBillAttachment : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// File type.
    /// </summary>
    [JsonPropertyName("ftype")]
    public string? Ftype { get; set; }

    /// <summary>
    /// File name.
    /// </summary>
    [JsonPropertyName("filename")]
    public string? Filename { get; set; }

    /// <summary>
    /// File descriptor.
    /// </summary>
    [JsonPropertyName("fileDescriptor")]
    public string? FileDescriptor { get; set; }

    /// <summary>
    /// File URL.
    /// </summary>
    [JsonPropertyName("furl")]
    public string? Furl { get; set; }

    /// <summary>
    /// File content.
    /// </summary>
    [JsonPropertyName("fContent")]
    public string? FContent { get; set; }

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
