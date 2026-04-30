using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListDevicesRequest
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
    /// Collection of field names, conditions, and values used to filter
    /// the query.
    ///
    /// &lt;Info&gt;
    ///   **You must remove `parameters=` from the request before you send it, otherwise Payabli will ignore the filters.**
    ///
    ///   Because of a technical limitation, you can't make a request that includes filters from the API console on this page. The response won't be filtered. Instead, copy the request, remove `parameters=` and run the request in a different client.
    ///
    ///   For example:
    ///
    ///   --url https://api-sandbox.payabli.com/api/Query/devices/8cfec329267?parameters=status=1&limitRecord=20
    ///
    ///   should become:
    ///
    ///   --url https://api-sandbox.payabli.com/api/Query/devices/8cfec329267?status=1&limitRecord=20
    /// &lt;/Info&gt;
    ///
    /// See [Filters and Conditions
    /// Reference](/developers/developer-guides/pay-ops-reporting-engine-overview#filters-and-conditions-reference)
    /// for more information.
    ///
    /// **List of field names accepted:**
    ///
    ///
    /// - `deviceId` (eq, ne, ct, nct)
    ///
    /// - `serialNumber` (eq, ne, ct, nct)
    ///
    /// - `friendlyName` (eq, ne, ct, nct)
    ///
    /// - `description` (eq, ne, ct, nct)
    ///
    /// - `model` (eq, ne, ct, nct)
    ///
    /// - `make` (eq, ne, ct, nct)
    ///
    /// - `macAddress` (eq, ne, ct, nct)
    ///
    /// - `registrationCode` (eq, ne, ct, nct)
    ///
    /// - `status` (eq, ne, in, nin)
    ///
    /// - `deviceType` (eq, ne, in, nin)
    ///
    /// - `deviceOs` (eq, ne, in, nin)
    ///
    /// - `activationAttempts` (eq, ne, gt, ge, lt, le)
    ///
    /// - `createdDate` (gt, ge, lt, le, eq, ne)
    ///
    /// - `updatedDate` (gt, ge, lt, le, eq, ne)
    ///
    /// - `lastHealthCheck` (gt, ge, lt, le, eq, ne)
    ///
    /// - `activationExpiry` (gt, ge, lt, le, eq, ne). This filter corresponds to the `activationCodeExpiry` response field.
    ///
    /// - `paypointId` (eq, ne)
    ///
    /// - `paypointDba` (eq, ne, ct, nct)
    ///
    /// - `paypointLegal` (eq, ne, ct, nct)
    ///
    /// - `paypointEntry` (eq, ne, ct, nct)
    ///
    /// - `externalPaypointId` (eq, ne, ct, nct)
    ///
    /// - `parentOrgId` (eq, ne)
    ///
    /// - `parentOrgName` (eq, ne, ct, nct)
    ///
    ///
    /// **List of comparison operators accepted:**
    ///
    /// - `eq` or empty =&gt; equal
    ///
    /// - `gt` =&gt; greater than
    ///
    /// - `ge` =&gt; greater or equal
    ///
    /// - `lt` =&gt; less than
    ///
    /// - `le` =&gt; less or equal
    ///
    /// - `ne` =&gt; not equal
    ///
    /// - `ct` =&gt; contains
    ///
    /// - `nct` =&gt; not contains
    ///
    /// - `in` =&gt; inside array
    ///
    /// - `nin` =&gt; not inside array
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
