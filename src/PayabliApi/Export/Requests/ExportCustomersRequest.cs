using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ExportCustomersRequest
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
    /// **List of field names accepted:**
    /// - `createdDate` (gt, ge, lt, le, eq, ne)
    /// - `customernumber` (ne, eq, ct, nct)
    /// - `firstname` (ne, eq, ct, nct)
    /// - `lastname` (ne, eq, ct, nct)
    /// - `name` (ct, nct)
    /// - `address` (ne, eq, ct, nct)
    /// - `city` (ne, eq, ct, nct)
    /// - `country` (ne, eq, ct, nct)
    /// - `zip` (ne, eq, ct, nct)
    /// - `state` (ne, eq, ct, nct)
    /// - `shippingaddress` (ne, eq, ct, nct)
    /// - `shippingcity` (ne, eq, ct, nct)
    /// - `shippingcountry` (ne, eq, ct, nct)
    /// - `shippingzip` (ne, eq, ct, nct)
    /// - `shippingstate` (ne, eq, ct, nct)
    /// - `phone` (ne, eq, ct, nct)
    /// - `email` (ne, eq, ct, nct)
    /// - `company` (ne, eq, ct, nct)
    /// - `username` (ne, eq, ct, nct)
    /// - `balance` (gt, ge, lt, le, eq, ne)
    /// - `status` (in, nin, eq, ne)
    /// - `additional-xxx` (ne, eq, ct, nct) where xxx is the additional field name
    /// - `orgId` (eq) *mandatory when entry=org*
    /// - `paypointId` (ne, eq)
    /// - `paypointLegal` (ne, eq, ct, nct)
    /// - `paypointDba` (ne, eq, ct, nct)
    /// - `orgName` (ne, eq, ct, nct)
    ///
    /// **List of comparison accepted - enclosed between parentheses:**
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
    /// **List of parameters accepted:**
    /// - limitRecord: max number of records for query (default="20", "0" or negative value for all)
    /// - fromRecord: initial record in query
    ///
    /// **Example:**
    /// balance(gt)=20 return all records with balance greater than 20.00
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string?>? Parameters { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
