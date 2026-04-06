using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateCardRequestBody
{
    /// <summary>
    /// Token that uniquely identifies the card. This is the `ReferenceId` returned when the card was created.
    /// </summary>
    [JsonPropertyName("cardToken")]
    public required string CardToken { get; set; }

    /// <summary>
    /// The new status to set on the card.
    /// </summary>
    [JsonPropertyName("status")]
    public CardStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
