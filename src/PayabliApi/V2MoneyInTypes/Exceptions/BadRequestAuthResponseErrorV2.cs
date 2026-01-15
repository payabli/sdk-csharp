namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestAuthResponseErrorV2(V2BadRequestError body)
    : PayabliApiApiException("BadRequestAuthResponseErrorV2", 400, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V2BadRequestError Body => body;
}
