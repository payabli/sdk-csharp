using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// This metadata appears only when the domain verification check fails. It gives more information about why the check failed.
/// </summary>
[Serializable]
public record ApplePayMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// When `true`, indicates whether the domain verification file is available at the expected path. When `false`, Payabli was unable to find the file at the expected path. If the file is missing, make sure it's hosted at the correct path: `/.well-known/apple-developer-merchantid-domain-association`
    /// </summary>
    [JsonPropertyName("isFileAvailable")]
    public bool? IsFileAvailable { get; set; }

    /// <summary>
    /// Indicates whether the domain verification file content is valid. If the file is invalid, try downloading it and hosting it again.
    /// </summary>
    [JsonPropertyName("isFileContentValid")]
    public bool? IsFileContentValid { get; set; }

    /// <summary>
    /// The domain name if the domain verification URL returns a redirect.
    /// </summary>
    [JsonPropertyName("redirectDomainName")]
    public string? RedirectDomainName { get; set; }

    /// <summary>
    /// If the domain verification URL is redirected, this is the URL it's redirected to.
    /// For example, www.partner.com could redirect to www.partners-new-home-page.com. In this case, you should add www.partners-new-home-page.com as a domain instead of www.partner.com.
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }

    /// <summary>
    /// The status code return by the domain verification URL.
    /// </summary>
    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }

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
