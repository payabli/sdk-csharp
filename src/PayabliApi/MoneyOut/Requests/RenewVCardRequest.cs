using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record RenewVCardRequest
{
    /// <summary>
    /// The new expiration date for the virtual card, in `MM-YYYY` or `MM/YYYY` format. The card expires on the last day of the month you specify. The date can't be more than 2 years and 363 days in the future.
    /// </summary>
    [JsonPropertyName("expirationDate")]
    public required string ExpirationDate { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
