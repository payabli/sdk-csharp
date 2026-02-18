namespace PayabliApi;

public partial interface ICheckCaptureClient
{
    /// <summary>
    /// Captures a check for Remote Deposit Capture (RDC) using the provided check images and details. This endpoint handles the OCR extraction of check data including MICR, routing number, account number, and amount. See the [RDC guide](/developers/developer-guides/pay-in-rdc) for more details.
    /// </summary>
    WithRawResponseTask<CheckCaptureResponse> CheckProcessingAsync(
        CheckCaptureRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
