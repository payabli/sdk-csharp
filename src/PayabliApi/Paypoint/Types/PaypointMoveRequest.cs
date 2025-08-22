using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PaypointMoveRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("entryPoint")]
    public required string EntryPoint { get; set; }

    /// <summary>
    /// The ID for the paypoint's new parent organization.
    /// </summary>
    [JsonPropertyName("newParentOrganizationId")]
    public required int NewParentOrganizationId { get; set; }

    /// <summary>
    /// Optional notification request object for a webhook
    /// </summary>
    [JsonPropertyName("notificationRequest")]
    public NotificationRequest? NotificationRequest { get; set; }

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
