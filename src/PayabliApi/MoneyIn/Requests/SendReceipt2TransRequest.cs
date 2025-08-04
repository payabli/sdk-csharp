using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SendReceipt2TransRequest
{
    /// <summary>
    /// Email address where the payment receipt should be sent.
    ///
    /// If not provided, the email address on file for the user owner of the transaction is used.
    /// </summary>
    [JsonIgnore]
    public string? Email { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
