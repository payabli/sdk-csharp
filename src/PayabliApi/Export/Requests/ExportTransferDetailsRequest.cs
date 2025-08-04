using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ExportTransferDetailsRequest
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
    /// Collection of field names, conditions, and values used to filter the query
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
    ///
    ///   - `grossAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `chargeBackAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `returnedAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `billingFeeAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `thirdPartyPaidAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `netFundedAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `adjustmentAmount` (gt, ge, lt, le, eq, ne)
    ///
    ///   - `transactionId` (eq, ne, in, nin)
    ///
    ///   - `category` (eq, ne, ct, nct)
    ///
    ///   - `type` (eq, ne, in, nin)
    ///
    ///   - `method` (eq, ne, in, nin)
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
