using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PushPayLinkRequestEmail : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of additional email addresses you want to send the paylink to, formatted as an array.
    /// Payment links and opt-in requests are sent to the customer email address on file, and additional
    /// recipients can be specified here.
    /// </summary>
    [JsonPropertyName("additionalEmails")]
    public IEnumerable<string>? AdditionalEmails { get; set; }

    /// <summary>
    /// When `true`, attaches a PDF version of the invoice to the email.
    /// </summary>
    [JsonPropertyName("attachFile")]
    public bool? AttachFile { get; set; }

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
