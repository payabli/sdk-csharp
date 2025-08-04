using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record EditInvoiceRequest
{
    /// <summary>
    /// When `true`, the request creates a new customer record, regardless of whether customer identifiers match an existing customer.
    /// </summary>
    [JsonIgnore]
    public bool? ForceCustomerCreation { get; set; }

    [JsonIgnore]
    public required InvoiceDataRequest Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
