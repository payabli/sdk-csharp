using global::System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record DeleteAttachedFromBillRequest
{
    /// <summary>
    /// When `true`, the response includes the full bill object.
    /// </summary>
    [JsonIgnore]
    public bool? ReturnObject { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
