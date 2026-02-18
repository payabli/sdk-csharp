using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class OcrClient : IOcrClient
{
    private RawClient _client;

    internal OcrClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<PayabliApiResponseOcr>> OcrDocumentFormAsyncCore(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/Import/ocrDocumentForm/{0}",
                        ValueConvert.ToPathParameterString(typeResult)
                    ),
                    Body = request,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<PayabliApiResponseOcr>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseOcr>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                switch (response.StatusCode)
                {
                    case 400:
                        throw new BadRequestError(JsonUtils.Deserialize<object>(responseBody));
                    case 401:
                        throw new UnauthorizedError(JsonUtils.Deserialize<object>(responseBody));
                    case 500:
                        throw new InternalServerError(JsonUtils.Deserialize<object>(responseBody));
                    case 503:
                        throw new ServiceUnavailableError(
                            JsonUtils.Deserialize<PayabliApiResponse>(responseBody)
                        );
                }
            }
            catch (JsonException)
            {
                // unable to map error response, throwing generic error
            }
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    private async Task<WithRawResponse<PayabliApiResponseOcr>> OcrDocumentJsonAsyncCore(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add(_client.Options.Headers)
            .Add(_client.Options.AdditionalHeaders)
            .Add(options?.AdditionalHeaders)
            .BuildAsync()
            .ConfigureAwait(false);
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "/Import/ocrDocumentJson/{0}",
                        ValueConvert.ToPathParameterString(typeResult)
                    ),
                    Body = request,
                    Headers = _headers,
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<PayabliApiResponseOcr>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseOcr>()
                {
                    Data = responseData,
                    RawResponse = new RawResponse()
                    {
                        StatusCode = response.Raw.StatusCode,
                        Url = response.Raw.RequestMessage?.RequestUri ?? new Uri("about:blank"),
                        Headers = ResponseHeaders.FromHttpResponseMessage(response.Raw),
                    },
                };
            }
            catch (JsonException e)
            {
                throw new PayabliApiApiException(
                    "Failed to deserialize response",
                    response.StatusCode,
                    responseBody,
                    e
                );
            }
        }
        {
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            throw new PayabliApiApiException(
                $"Error with status code {response.StatusCode}",
                response.StatusCode,
                responseBody
            );
        }
    }

    /// <summary>
    /// Use this endpoint to upload an image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
    /// </summary>
    /// <example><code>
    /// await client.Ocr.OcrDocumentFormAsync(
    ///     "typeResult",
    ///     new FileContentImageOnly
    ///     {
    ///         Ftype = null,
    ///         Filename = null,
    ///         Furl = null,
    ///         FContent = null,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentFormAsync(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseOcr>(
            OcrDocumentFormAsyncCore(typeResult, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Use this endpoint to submit a Base64-encoded image file for OCR processing. The accepted file formats include PDF, JPG, JPEG, PNG, and GIF. Specify the desired type of result (either 'bill' or 'invoice') in the path parameter `typeResult`. The response will contain the OCR processing results, including extracted data such as bill number, vendor information, bill items, and more.
    /// </summary>
    /// <example><code>
    /// await client.Ocr.OcrDocumentJsonAsync(
    ///     "typeResult",
    ///     new FileContentImageOnly
    ///     {
    ///         Ftype = null,
    ///         Filename = null,
    ///         Furl = null,
    ///         FContent = null,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseOcr> OcrDocumentJsonAsync(
        string typeResult,
        FileContentImageOnly request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseOcr>(
            OcrDocumentJsonAsyncCore(typeResult, request, options, cancellationToken)
        );
    }
}
