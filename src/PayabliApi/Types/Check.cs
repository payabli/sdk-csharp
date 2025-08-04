using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record Check : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The checking accountholder's name.
    /// </summary>
    [JsonPropertyName("achHolder")]
    public required string AchHolder { get; set; }

    /// <summary>
    /// Method to use for the transaction. Use `check` for a paper check transaction. When the method is `check`, then `paymentDetails.checkNumber` is required.
    /// </summary>
    [JsonPropertyName("method")]
    public string Method { get; set; } = "check";

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
