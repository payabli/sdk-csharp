using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record OrgData : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("idOrg")]
    public long? IdOrg { get; set; }

    [JsonPropertyName("orgAddress")]
    public string? OrgAddress { get; set; }

    [JsonPropertyName("orgLogo")]
    public FileContent? OrgLogo { get; set; }

    [JsonPropertyName("orgName")]
    public string? OrgName { get; set; }

    /// <summary>
    /// The paypoint's status.
    ///
    /// Active - `1`
    ///
    /// Inactive - 0
    /// </summary>
    [JsonPropertyName("orgStatus")]
    public int? OrgStatus { get; set; }

    [JsonPropertyName("orgType")]
    public int? OrgType { get; set; }

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
