using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record UpdateMethodRequest
{
    /// <summary>
    /// When `true`, enables real-time validation of ACH account and routing numbers. This is an add-on feature, contact Payabli for more information.
    /// </summary>
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
