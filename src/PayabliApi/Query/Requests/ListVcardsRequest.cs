using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListVcardsRequest
{
    /// <summary>
    /// Export format for file downloads. When specified, returns data as a file instead of JSON.
    /// </summary>
    [JsonIgnore]
    public ExportFormat? ExportFormat { get; set; }

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
    /// Collection of field names, conditions, and values used to filter the query.
    /// &lt;Info&gt;
    ///   **You must remove `parameters=` from the request before you send it, otherwise Payabli will ignore the filters.**
    ///
    ///   Because of a technical limitation, you can't make a request that includes filters from the API console on this page. The response won't be filtered. Instead, copy the request, remove `parameters=` and run the request in a different client.
    ///
    ///   For example:
    ///
    ///   --url https://api-sandbox.payabli.com/api/Query/transactions/org/236?parameters=totalAmount(gt)=1000&limitRecord=20
    ///
    ///   should become:
    ///
    ///   --url https://api-sandbox.payabli.com/api/Query/transactions/org/236?totalAmount(gt)=1000&limitRecord=20
    /// &lt;/Info&gt;
    /// List of field names accepted:
    ///
    ///   - `status` (eq, ne, ct, nct, sw, ew)
    ///   - `createdAt` (gt, ge, lt, le, eq, ne)
    ///   - `cardToken` (ct, nct, eq, ne)
    ///   - `lastFour` (ct, nct, eq, ne)
    ///   - `expirationDate` (ct, nct, eq, ne)
    ///   - `payoutId` (eq, ne, gt, ge, lt, le)
    ///   - `vendorId` (eq, ne, gt, ge, lt, le)
    ///   - `miscData1` (ct, nct, eq, ne)
    ///   - `miscData2` (ct, nct, eq, ne)
    ///   - `currentUses` (gt, ge, lt, le, eq, ne)
    ///   - `amount` (gt, ge, lt, le, eq, ne)
    ///   - `balance` (gt, ge, lt, le, eq, ne)
    ///   - `paypointLegal` (ne, eq, ct, nct)
    ///   - `paypointDba` (ne, eq, ct, nct)
    ///   - `orgName` (eq, ne, ct, nct, sw, ew)
    ///   - `externalPaypointId` (ct, nct, eq, ne)
    ///   - `paypointId` (eq, ne, gt, ge, lt, le)
    ///   - `cardType` (eq, ne, gt, ge, lt, le)
    ///
    /// List of comparison accepted - enclosed between parentheses:
    ///
    ///   - eq or empty =&gt; equal
    ///   - gt =&gt; greater than
    ///   - ge =&gt; greater or equal
    ///   - lt =&gt; less than
    ///   - le =&gt; less or equal
    ///   - ne =&gt; not equal
    ///   - ct =&gt; contains
    ///   - nct =&gt; not contains
    ///   - sw =&gt; starts with
    ///   - ew =&gt; ends with
    ///   - in =&gt; inside array separated by "|"
    ///   - nin =&gt; not inside array separated by "|"
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string?>? Parameters { get; set; }

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
