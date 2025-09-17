using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponseTemplateId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    /// <summary>
    /// When the operation is successful, contains the template's ID.
    /// </summary>
    [JsonPropertyName("responseData")]
    public OneOf<string, int>? ResponseData { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

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
