using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record SubStatsRequest
{
    /// <summary>
    /// List of parameters
    /// </summary>
    [JsonIgnore]
    public Dictionary<string, string>? Parameters { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
