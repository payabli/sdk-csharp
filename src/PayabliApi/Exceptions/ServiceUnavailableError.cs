namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ServiceUnavailableError(PayabliErrorBody body)
    : PayabliApiApiException("ServiceUnavailableError", 503, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new PayabliErrorBody Body => body;
}
