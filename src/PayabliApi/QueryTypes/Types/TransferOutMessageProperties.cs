using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Properties associated with a transfer message.
/// </summary>
[Serializable]
public record TransferOutMessageProperties : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The original status of the transfer before the message.
    /// </summary>
    [JsonPropertyName("originalTransferStatus")]
    public string? OriginalTransferStatus { get; set; }

    /// <summary>
    /// The current status of the transfer after the message.
    /// </summary>
    [JsonPropertyName("currentTransferStatus")]
    public string? CurrentTransferStatus { get; set; }

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
