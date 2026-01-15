namespace PayabliApi;

/// <summary>
/// This exception type will be thrown for any non-2XX API responses.
/// </summary>
[Serializable]
public class DeclinedAuthResponseErrorV2(V2DeclinedTransactionResponseWrapper body)
    : PayabliApiApiException("DeclinedAuthResponseErrorV2", 402, body)
{
    /// <summary>
    /// The body of the response that triggered the exception.
    /// </summary>
    public new V2DeclinedTransactionResponseWrapper Body => body;
}
