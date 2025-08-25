using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BatchDetailResponseSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("serviceFees")]
    public required double ServiceFees { get; set; }

    [JsonPropertyName("transferAmount")]
    public required double TransferAmount { get; set; }

    [JsonPropertyName("refunds")]
    public required double Refunds { get; set; }

    [JsonPropertyName("heldAmount")]
    public required double HeldAmount { get; set; }

    [JsonPropertyName("totalRecords")]
    public required int TotalRecords { get; set; }

    [JsonPropertyName("totalAmount")]
    public required double TotalAmount { get; set; }

    [JsonPropertyName("totalNetAmount")]
    public required double TotalNetAmount { get; set; }

    [JsonPropertyName("totalPages")]
    public required int TotalPages { get; set; }

    [JsonPropertyName("pageSize")]
    public required int PageSize { get; set; }

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

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
