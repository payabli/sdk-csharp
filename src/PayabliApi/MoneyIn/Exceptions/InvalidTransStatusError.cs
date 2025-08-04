namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InvalidTransStatusError(InvalidTransStatusErrorType body)
    : PayabliApiApiException("InvalidTransStatusError", 400, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new InvalidTransStatusErrorType Body => body;
}
