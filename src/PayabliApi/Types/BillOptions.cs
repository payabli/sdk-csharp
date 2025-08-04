using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flag to indicate if the scheduled invoice includes a payment link.
    /// </summary>
    [JsonPropertyName("includePaylink")]
    public bool? IncludePaylink { get; set; }

    /// <summary>
    /// Flag to indicate if the scheduled invoice includes a PDF version of invoice
    /// </summary>
    [JsonPropertyName("includePdf")]
    public bool? IncludePdf { get; set; }

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
