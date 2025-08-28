using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Response schema for invoice operations.
/// </summary>
[Serializable]
public record InvoiceResponseWithoutData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("isSuccess")]
    public required bool IsSuccess { get; set; }

    [JsonPropertyName("responseCode")]
    public required int ResponseCode { get; set; }

    /// <summary>
    /// If `isSuccess` = true, this contains the identifier of the invoice. If `isSuccess` = false, this contains the reason for the failure.
    /// </summary>
    [JsonPropertyName("responseData")]
    public required OneOf<string, int> ResponseData { get; set; }

    [JsonPropertyName("responseText")]
    public required string ResponseText { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    [JsonPropertyName("roomId")]
    public required long RoomId { get; set; }

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
