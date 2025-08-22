using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListBatchDetailsOrgRequest
{
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
    /// See [Filters and Conditions Reference](/developers/developer-guides/pay-ops-reporting-engine-overview#filters-and-conditions-reference) for more information.
    ///
    /// **List of field names accepted:**
    ///
    /// - `settlementDate` (gt, ge, lt, le, eq, ne)
    /// - `depositDate` (gt, ge, lt, le, eq, ne)
    /// - `transId`  (ne, eq, ct, nct)
    /// - `gatewayTransId`  (ne, eq, ct, nct)
    /// - `method`   (in, nin, eq, ne)
    /// - `settledAmount`  (gt, ge, lt, le, eq, ne)
    /// - `operation`    (in, nin, eq, ne)
    /// - `source`   (in, nin, eq, ne)
    /// - `batchNumber`  (ct, nct, eq, ne)
    /// - `payaccountLastfour`   (nct, ct)
    /// - `payaccountType`   (ne, eq, in, nin)
    /// - `customerFirstname`   (ct, nct, eq, ne)
    /// - `customerLastname`    (ct, nct, eq, ne)
    /// - `customerName`   (ct, nct)
    /// - `customerId`  (eq, ne)
    /// - `customerNumber`  (ct, nct, eq, ne)
    /// - `customerCompanyname`    (ct, nct, eq, ne)
    /// - `customerAddress` (ct, nct, eq, ne)
    /// - `customerCity`    (ct, nct, eq, ne)
    /// - `customerZip` (ct, nct, eq, ne)
    /// - `customerState` (ct, nct, eq, ne)
    /// - `customerCountry` (ct, nct, eq, ne)
    /// - `customerPhone` (ct, nct, eq, ne)
    /// - `customerEmail` (ct, nct, eq, ne)
    /// - `customerShippingAddress` (ct, nct, eq, ne)
    /// - `customerShippingCity`    (ct, nct, eq, ne)
    /// - `customerShippingZip` (ct, nct, eq, ne)
    /// - `customerShippingState` (ct, nct, eq, ne)
    /// - `customerShippingCountry` (ct, nct, eq, ne)
    /// - `orgId`  (eq) *mandatory when entry=org*
    /// - `isHold` (eq, ne)
    /// - `paypointId`  (ne, eq)
    /// - `paypointLegal`  (ne, eq, ct, nct)
    /// - `paypointDba`  (ne, eq, ct, nct)
    /// - `orgName`  (ne, eq, ct, nct)
    /// - `batchId` (ct, nct, eq, neq)
    /// - `additional-xxx`  (ne, eq, ct, nct) where xxx is the additional field name
    ///
    /// **List of comparison accepted:**
    /// - `eq` or empty =&gt; equal
    /// - `gt` =&gt; greater than
    /// - `ge` =&gt; greater or equal
    /// - `lt` =&gt; less than
    /// - `le` =&gt; less or equal
    /// - `ne` =&gt; not equal
    /// - `ct` =&gt; contains
    /// - `nct` =&gt; not contains
    /// - `in` =&gt; inside array separated by "|"
    /// - `nin` =&gt; not inside array separated by "|"
    ///
    /// **List of parameters accepted:**
    ///
    /// - `limitRecord`: max number of records for query (default="20", "0" or negative value for all)
    /// - `fromRecord`: initial record in query
    ///
    /// Example: `settledAmount(gt)=20` returns all records with a `settledAmount` greater than 20.00.
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
