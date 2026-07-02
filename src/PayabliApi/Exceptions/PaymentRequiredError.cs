namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class PaymentRequiredError(
    V2DeclinedTransactionResponseWrapper body,
    PayabliApi.RawResponse? rawResponse = null
) : PayabliApiApiException("PaymentRequiredError", 402, body, rawResponse: rawResponse)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V2DeclinedTransactionResponseWrapper Body => body;
}
