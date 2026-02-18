using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListBoardingLinksRequest
{
    /// <summary>
    /// The number of records to skip before starting to collect the result set.
    /// </summary>
    [JsonIgnore]
    public int? FromRecord { get; set; }

    /// <summary>
    /// Max number of records to return for the query. Use `0` or negative value to return all records.
    /// </summary>
    [JsonIgnore]
    public int? LimitRecord { get; set; }

    /// <summary>
    /// Collection of field names, conditions, and values used to filter the query
    ///
    /// See [Filters and Conditions Reference](/developers/developer-guides/pay-ops-reporting-engine-overview#filters-and-conditions-reference) for help.
    ///
    /// List of field names accepted:
    /// - `lastUpdated` (gt, ge, lt, le, eq, ne)
    /// - `templateName` (ct, nct)
    /// - `referenceName` (ct, nct)
    /// - `acceptRegister` (eq, ne)
    /// - `acceptAuth` (eq, ne)
    /// - `templateCode` (ct, nct)
    /// - `templateId` (eq, ne)
    /// - `orgParentname` (ct, nct)
    ///
    /// List of comparison accepted - enclosed between parentheses:
    /// - eq or empty =&gt; equal
    /// - gt =&gt; greater than
    /// - ge =&gt; greater or equal
    /// - lt =&gt; less than
    /// - le =&gt; less or equal
    /// - ne =&gt; not equal
    /// - ct =&gt; contains
    /// - nct =&gt; not contains
    /// - in =&gt; inside array
    /// - nin =&gt; not inside array
    ///
    /// List of parameters accepted:
    /// - limitRecord : max number of records for query (default="20", "0" or negative value for all)
    /// - fromRecord : initial record in query
    ///
    /// Example: templateName(ct)=hoa return all records with template title containing "hoa"
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string>? Parameters { get; set; }

    /// <summary>
    /// The field name to use for sorting results. Use `desc(field_name)` to sort descending by `field_name`, and use `asc(field_name)` to sort ascending by `field_name`.
    /// </summary>
    [JsonIgnore]
    public string? SortBy { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
