using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayabliApiResponsePaymentLinks : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    /// <summary>
    /// If `isSuccess` = true, this contains the payment link identifier. If `isSuccess` = false, this contains the reason of the error.
    /// </summary>
    [JsonPropertyName("responseData")]
    public string? ResponseData { get; set; }

    [JsonPropertyName("responseText")]
    public string? ResponseText { get; set; }

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
