using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListPaymentMethodsPaymentMethodsRequest
{
    /// <summary>
    /// Filter by the entity that owns the payment method.
    /// </summary>
    [JsonIgnore]
    public string? AccountOwner { get; set; }

    /// <summary>
    /// Filter by owner type.
    /// </summary>
    [JsonIgnore]
    public PaymentMethodOwnerType? OwnerType { get; set; }

    /// <summary>
    /// Filter by payment method status.
    /// </summary>
    [JsonIgnore]
    public string? Status { get; set; }

    /// <summary>
    /// Filter by payment method type.
    /// </summary>
    [JsonIgnore]
    public string? Type { get; set; }

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [JsonIgnore]
    public int? Limit { get; set; }

    /// <summary>
    /// Page number to return.
    /// </summary>
    [JsonIgnore]
    public int? Page { get; set; }

    /// <summary>
    /// Field to sort by.
    /// </summary>
    [JsonIgnore]
    public string? SortBy { get; set; }

    /// <summary>
    /// Sort direction.
    /// </summary>
    [JsonIgnore]
    public string? SortOrder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
