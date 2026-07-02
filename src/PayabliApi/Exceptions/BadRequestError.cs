namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class BadRequestError(object body, PayabliApi.RawResponse? rawResponse = null)
    : PayabliApiApiException("BadRequestError", 400, body, rawResponse: rawResponse);
