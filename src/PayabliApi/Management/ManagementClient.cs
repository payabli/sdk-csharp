using global::System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class ManagementClient : IManagementClient
{
    private readonly RawClient _client;

    internal ManagementClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<VerifyAccountDetailsResponse>> VerifyAccountDetailsAsyncCore(
        string entry,
        VerifyAccountDetailsRequest request,
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
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "Management/verifyAccountDetails/{0}",
                        ValueConvert.ToPathParameterString(entry)
                    ),
                    Body = request,
                    Headers = _headers,
                    ContentType = "application/json",
                    Options = options,
                },
                cancellationToken
            )
            .ConfigureAwait(false);
        if (response.StatusCode is >= 200 and < 400)
        {
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
            try
            {
                var responseData = JsonUtils.Deserialize<VerifyAccountDetailsResponse>(
                    responseBody
                )!;
                return new WithRawResponse<VerifyAccountDetailsResponse>()
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
            var responseBody = await response
                .Raw.Content.ReadAsStringAsync(cancellationToken)
                .ConfigureAwait(false);
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

    /// <summary>
    /// Verifies a bank account and returns detailed verification results from the verification network, including bank name, account status, and response codes. Unlike a pass/fail verification, this endpoint returns granular data to support decision-making and troubleshooting.
    ///
    /// When bank authentication is enabled for the paypoint's organization, the endpoint performs an identity verification check on the account holder. Otherwise, it performs an account existence check. When bank authentication is enabled, the `accountHolderType` and `holderName` fields are required.
    ///
    /// Requires `inboundpayments_create` or `outboundpayments_create` permission.
    /// </summary>
    /// <example><code>
    /// await client.Management.VerifyAccountDetailsAsync(
    ///     "entry752",
    ///     new VerifyAccountDetailsRequest
    ///     {
    ///         RoutingNumber = "122105278",
    ///         AccountNumber = "0000000016",
    ///         AccountType = "Checking",
    ///         Country = "US",
    ///         AccountHolderType = "personal",
    ///         HolderName = "Jane Doe",
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<VerifyAccountDetailsResponse> VerifyAccountDetailsAsync(
        string entry,
        VerifyAccountDetailsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<VerifyAccountDetailsResponse>(
            VerifyAccountDetailsAsyncCore(entry, request, options, cancellationToken)
        );
    }
}
