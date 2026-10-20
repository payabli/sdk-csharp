using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

/// <summary>
/// A person as it appears in a list response.
/// </summary>
[Serializable]
public record PersonSummaryResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Hypermedia links for the person resource.
    /// </summary>
    [JsonPropertyName("_links")]
    public required PersonLinks Links { get; set; }

    /// <summary>
    /// The person reference, used to read and manage the person.
    /// </summary>
    [JsonPropertyName("personReference")]
    public required string PersonReference { get; set; }

    /// <summary>
    /// The person's first name.
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    /// <summary>
    /// The person's last name.
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    /// <summary>
    /// The person's primary email address.
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// The person's identity verification status, for example `notstarted`.
    /// </summary>
    [JsonPropertyName("verificationStatus")]
    public required string VerificationStatus { get; set; }

    /// <summary>
    /// When the person was created.
    /// </summary>
    [JsonPropertyName("createdAt")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the person was last updated.
    /// </summary>
    [JsonPropertyName("lastUpdated")]
    public required DateTime LastUpdated { get; set; }

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
