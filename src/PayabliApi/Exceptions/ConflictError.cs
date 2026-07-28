namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ConflictError(object body, PayabliApi.RawResponse? rawResponse = null)
    : PayabliApiApiException("ConflictError", 409, body, rawResponse: rawResponse);
