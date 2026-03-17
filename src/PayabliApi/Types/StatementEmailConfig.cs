using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// Configuration for statement email recipients and the sender address.
/// </summary>
[Serializable]
public record StatementEmailConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The email address from which statements are sent. Always uses a Payabli domain, for example `acme-partners@payabli.com`. If `null`, `noreply@payabli.com` is used.
    /// </summary>
    [JsonPropertyName("sender")]
    public string? Sender { get; set; }

    /// <summary>
    /// List of email addresses that receive billing statements. These are merchant or partner contacts.
    /// </summary>
    [JsonPropertyName("recipients")]
    public IEnumerable<string>? Recipients { get; set; }

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
