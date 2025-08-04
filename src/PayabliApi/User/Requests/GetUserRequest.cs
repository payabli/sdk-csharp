using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetUserRequest
{
    /// <summary>
    /// The entrypoint identifier.
    /// </summary>
    [JsonIgnore]
    public string? Entry { get; set; }

    /// <summary>
    /// Entry level: 0 - partner, 2 - paypoint
    /// </summary>
    [JsonIgnore]
    public int? Level { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
