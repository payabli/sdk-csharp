using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A page of payment methods.
/// </summary>
[Serializable]
public record ListPaymentMethodsResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The payment methods on this page.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<PaymentMethodDetail>? Data { get; set; }

    /// <summary>
    /// Pagination metadata.
    /// </summary>
    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; }

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
