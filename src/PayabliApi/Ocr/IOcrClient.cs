namespace PayabliApi;

public partial interface IOcrClient
{
    /// <summary>
    /// Use this endpoint to upload a document file for OCR processing as `multipart/form-data`, with the file in a field named `file`. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more. To send the file as a Base64-encoded string in a JSON body instead, use `ocrDocumentJson`.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentFormAsync(
        string typeResult,
        OcrDocumentFormRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to submit a Base64-encoded image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentJsonAsync(
        string typeResult,
        OcrDocumentJsonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
