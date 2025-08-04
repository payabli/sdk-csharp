using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListPaymentMethodDomainsRequest
{
    /// <summary>
    /// Identifier for the organization or paypoint.
    /// - For organization, provide the organization ID - For paypoint, provide the paypoint ID
    /// </summary>
    [JsonIgnore]
    public long? EntityId { get; set; }

    /// <summary>
    /// The type of entity. Valid values:
    ///   - organization
    ///   - paypoint
    ///   - psp
    /// </summary>
    [JsonIgnore]
    public string? EntityType { get; set; }

    /// <summary>
    /// Number of records to skip. Defaults to `0`.
    /// </summary>
    [JsonIgnore]
    public int? FromRecord { get; set; }

    /// <summary>
    /// Max number of records for query response. Defaults to `20`.
    /// </summary>
    [JsonIgnore]
    public int? LimitRecord { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
