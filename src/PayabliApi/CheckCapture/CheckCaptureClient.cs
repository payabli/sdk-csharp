using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class CheckCaptureClient
{
    private RawClient _client;

    internal CheckCaptureClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Captures a check for Remote Deposit Capture (RDC) using the provided check images and details. This endpoint handles the OCR extraction of check data including MICR, routing number, account number, and amount. See the [RDC guide](/developers/developer-guides/pay-in-rdc) for more details.
    /// </summary>
    /// <example><code>
    /// await client.CheckCapture.CheckProcessingAsync(
    ///     new CheckCaptureRequestBody
    ///     {
    ///         EntryPoint = "47abcfea12",
    ///         FrontImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
    ///         RearImage = "/9j/4AAQSkZJRgABAQEASABIAAD...",
    ///         CheckAmount = 12550,
    ///     }
    /// );
    /// </code></example>
    public async Task<CheckCaptureResponse> CheckProcessingAsync(
        CheckCaptureRequestBody request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "CheckCapture/CheckProcessing",
                    Body = request,
                    ContentType = "application/json",
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
                return JsonUtils.Deserialize<CheckCaptureResponse>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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
}
