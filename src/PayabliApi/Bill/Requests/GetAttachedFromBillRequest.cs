using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record GetAttachedFromBillRequest
{
    /// <summary>
    /// When `true`, the request returns the file content as a Base64-encoded string.
    /// </summary>
    [JsonIgnore]
    public bool? ReturnObject { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
