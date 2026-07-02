namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class InternalServerError(object body, PayabliApi.RawResponse? rawResponse = null)
    : PayabliApiApiException("InternalServerError", 500, body, rawResponse: rawResponse);
