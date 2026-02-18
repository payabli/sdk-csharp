using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ExportVendorsOrgRequest
{
    [JsonIgnore]
    public string? ColumnsExport { get; set; }

    /// <summary>
    /// The number of records to skip before starting to collect the result set.
    /// </summary>
    [JsonIgnore]
    public int? FromRecord { get; set; }

    /// <summary>
    /// The number of records to return for the query. The maximum is 30,000 records. When this parameter isn't sent, the API returns up to 25,000 records.
    /// </summary>
    [JsonIgnore]
    public int? LimitRecord { get; set; }

    /// <summary>
    /// Collection of field names, conditions, and values used to filter the query.
    ///
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
    ///
    /// See [Filters and Conditions Reference](/developers/developer-guides/pay-ops-reporting-engine-overview#filters-and-conditions-reference) for help.
    ///
    /// List of field names accepted:
    /// - `method` (in, nin, eq, ne)
    /// - `enrollmentStatus` (in, nin, eq, ne)
    /// - `status` (in, nin, eq, ne)
    /// - `vendorNumber` (ct, nct, eq, ne)
    /// - `name` (ct, nct, eq, ne)
    /// - `ein` (ct, nct, eq, ne)
    /// - `phone` (ct, nct, eq, ne)
    /// - `email` (ct, nct, eq, ne)
    /// - `address` (ct, nct, eq, ne)
    /// - `city` (ct, nct, eq, ne)
    /// - `state` (ct, nct, eq, ne)
    /// - `country` (ct, nct, eq, ne)
    /// - `zip` (ct, nct, eq, ne)
    /// - `mcc` (ct, nct, eq, ne)
    /// - `locationCode` (ct, nct, eq, ne)
    /// - `paypointLegal` (ne, eq, ct, nct)
    /// - `paypointDba` (ne, eq, ct, nct)
    /// - `orgName` (ne, eq, ct, nct)
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
    /// - in =&gt; inside array separated by "|"
    /// - nin =&gt; not inside array separated by "|"
    ///
    /// List of parameters accepted:
    /// - limitRecord : max number of records for query (default="20", "0" or negative value for all)
    /// - fromRecord : initial record in query
    ///
    /// Example: `netAmount(gt)=20` returns all records with a `netAmount` greater than 20.00
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string>? Parameters { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
