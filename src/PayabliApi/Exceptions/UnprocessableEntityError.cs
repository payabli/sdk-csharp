namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class UnprocessableEntityError(object body, PayabliApi.RawResponse? rawResponse = null)
    : PayabliApiClientApiException("UnprocessableEntityError", 422, body, rawResponse: rawResponse);
