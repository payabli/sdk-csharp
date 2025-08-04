using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateMethodRequest
{
    [JsonIgnore]
    public bool? AchValidation { get; set; }

    [JsonIgnore]
    public required RequestTokenStorage Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
