using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UserAuthRequest
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Identifier for entry point originating the request (used by front-end apps)
    /// </summary>
    [JsonPropertyName("entry")]
    public string? Entry { get; set; }

    /// <summary>
    /// Type of entry identifier: 0 - partner, 2 - paypoint. This is used by front-end apps, required if an Entry is indicated.
    /// </summary>
    [JsonPropertyName("entryType")]
    public int? EntryType { get; set; }

    [JsonPropertyName("psw")]
    public string? Psw { get; set; }

    [JsonPropertyName("userId")]
    public long? UserId { get; set; }

    [JsonPropertyName("userTokenId")]
    public string? UserTokenId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
