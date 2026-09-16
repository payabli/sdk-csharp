namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class ForbiddenError(object body, PayabliApi.RawResponse? rawResponse = null)
    : PayabliApiClientApiException("ForbiddenError", 403, body, rawResponse: rawResponse);
