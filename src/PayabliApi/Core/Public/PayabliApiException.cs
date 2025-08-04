namespace PayabliApi;

/// <summary>
/// Base exception class for all exceptions thrown by the SDK.
/// </summary>
public class PayabliApiException(string message, Exception? innerException = null)
    : Exception(message, innerException);
