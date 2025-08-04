using System.Text.Json;
using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record BillQueryResponseSummary : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("pageidentifier")]
    public string? Pageidentifier { get; set; }

    [JsonPropertyName("pageSize")]
    public int? PageSize { get; set; }

    [JsonPropertyName("total2approval")]
    public int? Total2Approval { get; set; }

    [JsonPropertyName("totalactive")]
    public int? Totalactive { get; set; }

    /// <summary>
    /// Total amount of bills in response.
    /// </summary>
    [JsonPropertyName("totalAmount")]
    public double? TotalAmount { get; set; }

    [JsonPropertyName("totalamount2approval")]
    public double? Totalamount2Approval { get; set; }

    [JsonPropertyName("totalamountactive")]
    public double? Totalamountactive { get; set; }

    /// <summary>
    /// The total amount of approved bills.
    /// </summary>
    [JsonPropertyName("totalamountapproved")]
    public double? Totalamountapproved { get; set; }

    [JsonPropertyName("totalamountcancel")]
    public double? Totalamountcancel { get; set; }

    /// <summary>
    /// The total amount of disapproved bills.
    /// </summary>
    [JsonPropertyName("totalamountdisapproved")]
    public double? Totalamountdisapproved { get; set; }

    [JsonPropertyName("totalamountintransit")]
    public double? Totalamountintransit { get; set; }

    /// <summary>
    /// The total amount of bills that are overdue.
    /// </summary>
    [JsonPropertyName("totalamountoverdue")]
    public double? Totalamountoverdue { get; set; }

    /// <summary>
    /// The total amount of paid bills.
    /// </summary>
    [JsonPropertyName("totalamountpaid")]
    public double? Totalamountpaid { get; set; }

    [JsonPropertyName("totalamountsent2approval")]
    public double? Totalamountsent2Approval { get; set; }

    /// <summary>
    /// The total number of bills that were approved.
    /// </summary>
    [JsonPropertyName("totalapproved")]
    public int? Totalapproved { get; set; }

    [JsonPropertyName("totalcancel")]
    public int? Totalcancel { get; set; }

    /// <summary>
    /// The number of bills that were disapproved.
    /// </summary>
    [JsonPropertyName("totaldisapproved")]
    public int? Totaldisapproved { get; set; }

    [JsonPropertyName("totalintransit")]
    public int? Totalintransit { get; set; }

    /// <summary>
    /// The number of bills that are overdue.
    /// </summary>
    [JsonPropertyName("totaloverdue")]
    public int? Totaloverdue { get; set; }

    [JsonPropertyName("totalPages")]
    public int? TotalPages { get; set; }

    /// <summary>
    /// The total number of paid bills.
    /// </summary>
    [JsonPropertyName("totalpaid")]
    public int? Totalpaid { get; set; }

    [JsonPropertyName("totalRecords")]
    public int? TotalRecords { get; set; }

    [JsonPropertyName("totalsent2approval")]
    public int? Totalsent2Approval { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
