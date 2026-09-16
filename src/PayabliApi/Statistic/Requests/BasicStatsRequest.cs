using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BasicStatsRequest
{
    /// <summary>
    /// Used with `custom` mode. The end date for the range.
    /// Valid formats:
    ///   - YYYY-mm-dd
    ///   - YYYY/mm/dd
    ///   - mm-dd-YYYY
    ///   - mm/dd/YYYY
    /// </summary>
    [JsonIgnore]
    public string? EndDate { get; set; }

    /// <summary>
    /// Used with `custom` mode. The start date for the range.
    /// Valid formats:
    ///    - YYYY-mm-dd
    ///    - YYYY/mm/dd
    ///    -  mm-dd-YYYY
    ///    - mm/dd/YYYY
    /// </summary>
    [JsonIgnore]
    public string? StartDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
