using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListVcardsRequest
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
    ///   - `status` (in, nin, eq, ne)
    ///   - `createdAt` (gt, ge, lt, le, eq, ne)
    ///   - `cardToken` (ct, nct, eq, ne)
    ///   - `lastFour` (ct, nct, eq, ne)
    ///   - `expirationDate` (ct, nct, eq, ne)
    ///   - `mcc` (ct, nct, eq, ne)
    ///   - `payoutId` (ct, nct, eq, ne, in, nin)
    ///   - `customerId` (ct, nct, eq, ne, in, nin)
    ///   - `vendorId` (ct, nct, eq, ne, in, nin)
    ///   - `miscData1` (ct, nct, eq, ne)
    ///   - `miscData2` (ct, nct, eq, ne)
    ///   - `currentUses` (gt, ge, lt, le, eq, ne)
    ///   - `amount` (gt, ge, lt, le, eq, ne)
    ///   - `balance` (gt, ge, lt, le, eq, ne)
    ///   - `paypointLegal` (ne, eq, ct, nct)
    ///   - `paypointDba` (ne, eq, ct, nct)
    ///   - `orgName` (ne, eq, ct, nct)
    ///   - `externalPaypointId` (ct, nct, eq, ne)
    ///   - `paypointId` (in, nin, eq, ne)
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
