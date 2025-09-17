using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("responseCode")]
    public int? ResponseCode { get; set; }

    [JsonPropertyName("pageIdentifier")]
    public string? PageIdentifier { get; set; }

    [JsonPropertyName("roomId")]
    public long? RoomId { get; set; }

    [JsonPropertyName("isSuccess")]
    public bool? IsSuccess { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    /// <summary>
    /// If `isSuccess` = true, this contains the bill identifier. If `isSuccess` = false, this contains the reason for the error.
    /// </summary>
    [JsonPropertyName("responseData")]
    public OneOf<string, int>? ResponseData { get; set; }

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
