using System.Text.Json.Serialization;
using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ListDeviceRequest
{
    /// <summary>
    /// When `true`, the request retrieves an updated list of devices from the processor instead of returning a cached list of devices.
    /// </summary>
    [JsonIgnore]
    public bool? ForceRefresh { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
