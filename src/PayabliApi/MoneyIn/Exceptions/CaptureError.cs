namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class CaptureError(PayabliApiResponseError400 body)
    : PayabliApiApiException("CaptureError", 423, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new PayabliApiResponseError400 Body => body;
}
