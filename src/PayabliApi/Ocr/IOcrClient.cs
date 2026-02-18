namespace PayabliApi;

public partial interface IOcrClient
{
    /// <summary>
    /// Use this endpoint to upload an image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentFormAsync(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to submit a Base64-encoded image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentJsonAsync(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
