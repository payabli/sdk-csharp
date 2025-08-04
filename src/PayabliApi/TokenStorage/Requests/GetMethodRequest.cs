using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetMethodRequest
{
    /// <summary>
    /// Format for card expiration dates in the response.
    ///
    /// Accepted values:
    ///
    /// - 0: default, no formatting. Expiration dates are returned in the format they're saved in.
    ///
    /// - 1: MMYY
    ///
    /// - 2: MM/YY
    /// </summary>
    [JsonIgnore]
    public int? CardExpirationFormat { get; set; }

    /// <summary>
    /// When `true`, the request will include temporary tokens in the search and return details for a matching temporary token. The default behavior searches only for permanent tokens.
    /// </summary>
    [JsonIgnore]
    public bool? IncludeTemporary { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
