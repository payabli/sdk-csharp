using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record AchSetup : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// CCD is an ACH SEC Code that can be used in ACH transactions by the user that indicates the transaction is a Corporate Credit or Debit Entry. Options are: `true` and `false`
    /// </summary>
    [JsonPropertyName("acceptCCD")]
    public bool? AcceptCcd { get; set; }

    /// <summary>
    /// PPD is an ACH SEC Code that can be used in ACH transactions by the user that indicates the transaction is a Prearranged Payment and Deposit.
    /// </summary>
    [JsonPropertyName("acceptPPD")]
    public bool? AcceptPpd { get; set; }

    /// <summary>
    /// Web is an ACH SEC Code that can be used in ACH transactions by the user that indicates the transaction is a Internet Initiated/Mobile Entry Options are `true` and `false`.
    /// </summary>
    [JsonPropertyName("acceptWeb")]
    public bool? AcceptWeb { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
