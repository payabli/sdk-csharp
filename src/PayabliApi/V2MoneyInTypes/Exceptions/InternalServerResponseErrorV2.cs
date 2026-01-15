namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerResponseErrorV2(V2InternalServerError body)
    : PayabliApiApiException("InternalServerResponseErrorV2", 500, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V2InternalServerError Body => body;
}
