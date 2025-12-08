using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListPayoutRequest
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
    ///
    /// List of field names accepted:
    ///
    ///   - `status` (in, nin, eq, ne)
    ///   - `transactionDate` (gt, ge, lt, le, eq, ne)
    ///   - `billNumber` (ct, nct)
    ///   - `vendorNumber` (ct, nct, eq, ne)
    ///   - `vendorName` (ct, nct, eq, ne)
    ///   - `paymentMethod` (ct, nct, eq, ne, in, nin)
    ///   - `paymentId` (ct, nct, eq, ne)
    ///   - `parentOrgId` (ne, eq, nin, in)
    ///   - `batchNumber` (ct, nct, eq, ne)
    ///   - `totalAmount` (gt, ge, lt, le, eq, ne)
    ///   - `paypointLegal` (ne, eq, ct, nct)
    ///   - `paypointDba` (ne, eq, ct, nct)
    ///   - `accountId` (ne, eq, ct, nct)
    ///   - `orgName` (ne, eq, ct, nct)
    ///   - `externalPaypointID` (ct, nct, eq, ne)
    ///   - `paypointId` (eq, ne)
    ///   - `vendorId` (eq, ne)
    ///   - `vendorEIN` (ct, nct, eq, ne)
    ///   - `vendorPhone` (ct, nct, eq, ne)
    ///   - `vendorEmail` (ct, nct, eq, ne)
    ///   - `vendorAddress` (ct, nct, eq, ne)
    ///   - `vendorCity` (ct, nct, eq, ne)
    ///   - `vendorState` (ct, nct, eq, ne)
    ///   - `vendorCountry` (ct, nct, eq, ne)
    ///   - `vendorZip` (ct, nct, eq, ne)
    ///   - `vendorMCC` (ct, nct, eq, ne)
    ///   - `vendorLocationCode` (ct, nct, eq, ne)
    ///   - `vendorCustomField1` (ct, nct, eq, ne)
    ///   - `vendorCustomField2` (ct, nct, eq, ne)
    ///   - `comments` (ct, nct)
    ///   - `payaccountCurrency` (ne, eq, in, nin)
    ///   - `remitAddress` (ct, nct)
    ///   - `source` (ct, nct, eq, ne)
    ///   - `updatedOn` (gt, ge, lt, le, eq, ne)
    ///   - `feeAmount` (gt, ge, lt, le, eq, ne)
    ///   - `lotNumber` (ct, nct)
    ///   - `customerVendorAccount` (ct, nct, eq, ne)
    ///   - `batchId` (eq, ne)
    ///   - `AchTraceNumber` (eq, ne)
    ///   - `payoutProgram`(eq, ne) the options are `managed` or `odp`. For example, `payoutProgram(eq)=managed` returns all records with a `payoutProgram` equal to `managed`.
    ///
    ///   List of comparison accepted - enclosed between parentheses:
    ///   - eq or empty =&gt; equal
    ///   - gt =&gt; greater than
    ///   - ge =&gt; greater or equal
    ///   - lt =&gt; less than
    ///   - le =&gt; less or equal
    ///   - ne =&gt; not equal
    ///   - ct =&gt; contains
    ///   - nct =&gt; not contains
    ///   - in =&gt; inside array separated by \"|\"
    ///   - nin =&gt; not inside array separated by \"|\"
    ///
    ///   List of parameters accepted:
    ///
    ///   - limitRecord : max number of records for query (default=\"20\", \"0\" or negative value for all)
    ///   - fromRecord : initial record in query
    ///   - sortBy : indicate field name and direction to sort the results
    ///
    ///   Example: `netAmount(gt)=20` returns all records with a `netAmount` greater than 20.00
    ///
    ///   Example: `sortBy=desc(netamount)` returns all records sorted by `netAmount` descending
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
