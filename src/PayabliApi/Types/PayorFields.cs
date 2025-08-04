using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record PayorFields : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flag indicating if the input field will show in container
    /// </summary>
    [JsonPropertyName("display")]
    public bool? Display { get; set; }

    /// <summary>
    /// Flag indicating if the value in input field is read-only or not.
    /// </summary>
    [JsonPropertyName("fixed")]
    public bool? Fixed { get; set; }

    /// <summary>
    /// Flag indicating if the input field is a customer identifier
    /// </summary>
    [JsonPropertyName("identifier")]
    public bool? Identifier { get; set; }

    /// <summary>
    /// Label to display for field
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    /// Name of field to show. Should be one of the standard customer fields or a custom field name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("order")]
    public int? Order { get; set; }

    /// <summary>
    /// Flag indicating if the input field is required for validation
    /// </summary>
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    /// <summary>
    /// Type of validation to apply to the input field Accepted values:
    ///
    ///   - alpha for alphabetical
    ///
    ///   - numbers for numeric
    ///
    ///   - text for alphanumeric
    ///
    ///   - email for masked email address input
    ///
    ///   - phone for US phone numbers
    /// </summary>
    [JsonPropertyName("validation")]
    public string? Validation { get; set; }

    /// <summary>
    /// Pre-populated value for field
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// Numeric value indicating the size of input relative to the container. Accepted values:
    ///
    ///     - 4 = 1/3
    ///
    ///     - 6 = 1/2
    ///
    ///     - 8 = 2/3
    ///
    ///     - 12 = 3/3
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

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
