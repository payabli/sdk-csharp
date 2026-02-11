using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SettingElement : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Fields to display on the reciept.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<DisplayProperty>? Fields { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// When `true`, Payabli automatically sends the receipt to the payor email address.
    /// </summary>
    [JsonPropertyName("sendAuto")]
    public bool? SendAuto { get; set; }

    /// <summary>
    /// When `true`, you must send the reciept to the payor manually using the [/MoneyIn/sendreceipt/\{transId\}](/developers/api-reference/moneyin/send-receipt-for-transaction) endpoint.
    /// </summary>
    [JsonPropertyName("sendManual")]
    public bool? SendManual { get; set; }

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
