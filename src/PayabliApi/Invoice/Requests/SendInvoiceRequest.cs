using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SendInvoiceRequest
{
    /// <summary>
    /// When `true`, attaches a PDF version of invoice to the email.
    /// </summary>
    [JsonIgnore]
    public bool? Attachfile { get; set; }

    /// <summary>
    /// Email address where the invoice will be sent to. If this parameter isn't included, Payabli uses the email address on file for the customer owner of the invoice.
    /// </summary>
    [JsonIgnore]
    public string? Mail2 { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
