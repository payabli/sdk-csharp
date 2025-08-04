using PayabliApi.Core;

namespace PayabliApi;

[Serializable]
public record ImportBillsRequest
{
    public required FileParameter File { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
