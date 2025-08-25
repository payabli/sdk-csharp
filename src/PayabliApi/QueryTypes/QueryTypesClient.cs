using PayabliApi.Core;

namespace PayabliApi;

public partial class QueryTypesClient
{
    private RawClient _client;

    internal QueryTypesClient(RawClient client)
    {
        _client = client;
    }
}
