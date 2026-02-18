using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class PaymentLinkClient : IPaymentLinkClient
{
    private RawClient _client;

    internal PaymentLinkClient(RawClient client)
    {
        _client = client;
    }

    private async Task<
        WithRawResponse<PayabliApiResponsePaymentLinks>
    > AddPayLinkFromInvoiceAsyncCore(
        int idInvoice,
        PayLinkDataInvoice request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("amountFixed", request.AmountFixed)
            .Add("mail2", request.Mail2)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
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
                        "PaymentLink/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
                    ),
                    Body = request.Body,
                    QueryString = _queryString,
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<WithRawResponse<PayabliApiResponsePaymentLinks>> AddPayLinkFromBillAsyncCore(
        int billId,
        PayLinkDataBill request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("amountFixed", request.AmountFixed)
            .Add("mail2", request.Mail2)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
        var _headers = await new PayabliApi.Core.HeadersBuilder.Builder()
            .Add("idempotencyKey", request.IdempotencyKey)
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
                        "PaymentLink/bill/{0}",
                        ValueConvert.ToPathParameterString(billId)
                    ),
                    Body = request.Body,
                    QueryString = _queryString,
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<
        WithRawResponse<PayabliApiResponsePaymentLinks>
    > DeletePayLinkFromIdAsyncCore(
        string payLinkId,
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
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "PaymentLink/{0}",
                        ValueConvert.ToPathParameterString(payLinkId)
                    ),
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<WithRawResponse<GetPayLinkFromIdResponse>> GetPayLinkFromIdAsyncCore(
        string paylinkId,
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "PaymentLink/load/{0}",
                        ValueConvert.ToPathParameterString(paylinkId)
                    ),
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
                var responseData = JsonUtils.Deserialize<GetPayLinkFromIdResponse>(responseBody)!;
                return new WithRawResponse<GetPayLinkFromIdResponse>()
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

    private async Task<WithRawResponse<PayabliApiResponsePaymentLinks>> PushPayLinkFromIdAsyncCore(
        string payLinkId,
        PushPayLinkRequest request,
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
                        "PaymentLink/push/{0}",
                        ValueConvert.ToPathParameterString(payLinkId)
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<
        WithRawResponse<PayabliApiResponsePaymentLinks>
    > RefreshPayLinkFromIdAsyncCore(
        string payLinkId,
        RefreshPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 1)
            .Add("amountFixed", request.AmountFixed)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "PaymentLink/refresh/{0}",
                        ValueConvert.ToPathParameterString(payLinkId)
                    ),
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<WithRawResponse<PayabliApiResponsePaymentLinks>> SendPayLinkFromIdAsyncCore(
        string payLinkId,
        SendPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 2)
            .Add("attachfile", request.Attachfile)
            .Add("mail2", request.Mail2)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "PaymentLink/send/{0}",
                        ValueConvert.ToPathParameterString(payLinkId)
                    ),
                    QueryString = _queryString,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<
        WithRawResponse<PayabliApiResponsePaymentLinks>
    > UpdatePayLinkFromIdAsyncCore(
        string payLinkId,
        PayLinkUpdateData request,
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
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "PaymentLink/update/{0}",
                        ValueConvert.ToPathParameterString(payLinkId)
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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

    private async Task<
        WithRawResponse<PayabliApiResponsePaymentLinks>
    > AddPayLinkFromBillLotNumberAsyncCore(
        string lotNumber,
        PayLinkDataOut request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _queryString = new PayabliApi.Core.QueryStringBuilder.Builder(capacity: 4)
            .Add("entryPoint", request.EntryPoint)
            .Add("vendorNumber", request.VendorNumber)
            .Add("mail2", request.Mail2)
            .Add("amountFixed", request.AmountFixed)
            .MergeAdditional(options?.AdditionalQueryParameters)
            .Build();
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
                        "PaymentLink/bill/lotNumber/{0}",
                        ValueConvert.ToPathParameterString(lotNumber)
                    ),
                    Body = request.Body,
                    QueryString = _queryString,
                    Headers = _headers,
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(
                    responseBody
                )!;
                return new WithRawResponse<PayabliApiResponsePaymentLinks>()
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
    /// Generates a payment link for an invoice from the invoice ID.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.AddPayLinkFromInvoiceAsync(
    ///     23548884,
    ///     new PayLinkDataInvoice
    ///     {
    ///         Mail2 = "jo@example.com; ceo@example.com",
    ///         Body = new PaymentPageRequestBody
    ///         {
    ///             ContactUs = new ContactElement
    ///             {
    ///                 EmailLabel = "Email",
    ///                 Enabled = true,
    ///                 Header = "Contact Us",
    ///                 Order = 0,
    ///                 PaymentIcons = true,
    ///                 PhoneLabel = "Phone",
    ///             },
    ///             Invoices = new InvoiceElement
    ///             {
    ///                 Enabled = true,
    ///                 InvoiceLink = new LabelElement
    ///                 {
    ///                     Enabled = true,
    ///                     Label = "View Invoice",
    ///                     Order = 0,
    ///                 },
    ///                 Order = 0,
    ///                 ViewInvoiceDetails = new LabelElement
    ///                 {
    ///                     Enabled = true,
    ///                     Label = "Invoice Details",
    ///                     Order = 0,
    ///                 },
    ///             },
    ///             Logo = new Element { Enabled = true, Order = 0 },
    ///             MessageBeforePaying = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Please review your payment details",
    ///                 Order = 0,
    ///             },
    ///             Notes = new NoteElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Additional Notes",
    ///                 Order = 0,
    ///                 Placeholder = "Enter any additional notes here",
    ///                 Value = "",
    ///             },
    ///             Page = new PageElement
    ///             {
    ///                 Description = "Complete your payment securely",
    ///                 Enabled = true,
    ///                 Header = "Payment Page",
    ///                 Order = 0,
    ///             },
    ///             PaymentButton = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Pay Now",
    ///                 Order = 0,
    ///             },
    ///             PaymentMethods = new MethodElement
    ///             {
    ///                 AllMethodsChecked = true,
    ///                 Enabled = true,
    ///                 Header = "Payment Methods",
    ///                 Methods = new MethodsList
    ///                 {
    ///                     Amex = true,
    ///                     ApplePay = true,
    ///                     Discover = true,
    ///                     ECheck = true,
    ///                     Mastercard = true,
    ///                     Visa = true,
    ///                 },
    ///                 Order = 0,
    ///                 Settings = new MethodElementSettings
    ///                 {
    ///                     ApplePay = new MethodElementSettingsApplePay
    ///                     {
    ///                         ButtonStyle = MethodElementSettingsApplePayButtonStyle.Black,
    ///                         ButtonType = MethodElementSettingsApplePayButtonType.Pay,
    ///                         Language = MethodElementSettingsApplePayLanguage.EnUs,
    ///                     },
    ///                 },
    ///             },
    ///             Payor = new PayorElement
    ///             {
    ///                 Enabled = true,
    ///                 Fields = new List&lt;PayorFields&gt;()
    ///                 {
    ///                     new PayorFields
    ///                     {
    ///                         Display = true,
    ///                         Fixed = true,
    ///                         Identifier = true,
    ///                         Label = "Full Name",
    ///                         Name = "fullName",
    ///                         Order = 0,
    ///                         Required = true,
    ///                         Validation = "alpha",
    ///                         Value = "",
    ///                         Width = 0,
    ///                     },
    ///                 },
    ///                 Header = "Payor Information",
    ///                 Order = 0,
    ///             },
    ///             Review = new HeaderElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Review Payment",
    ///                 Order = 0,
    ///             },
    ///             Settings = new PagelinkSetting
    ///             {
    ///                 Color = "#000000",
    ///                 CustomCssUrl = "https://example.com/custom.css",
    ///                 Language = "en",
    ///                 PageLogo = new FileContent
    ///                 {
    ///                     FContent =
    ///                         "PHN2ZyB2aWV3Qm94PSIwIDAgODAwIDEwMDAiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiAgPCEtLSBCYWNrZ3JvdW5kIC0tPgogIDxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iMTAwMCIgZmlsbD0id2hpdGUiLz4KICAKICA8IS0tIENvbXBhbnkgSGVhZGVyIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI2MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjI0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+R3J1enlhIEFkdmVudHVyZSBPdXRmaXR0ZXJzPC90ZXh0PgogIDxsaW5lIHgxPSI0MCIgeTE9IjgwIiB4Mj0iNzYwIiB5Mj0iODAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIyIi8+CiAgCiAgPCEtLSBDb21wYW55IERldGFpbHMgLS0+CiAgPHRleHQgeD0iNDAiIHk9IjExMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4xMjMgTW91bnRhaW4gVmlldyBSb2FkPC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxMzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+VGJpbGlzaSwgR2VvcmdpYSAwMTA1PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxNTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+VGVsOiArOTk1IDMyIDEyMyA0NTY3PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSIxNzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+RW1haWw6IGluZm9AZ3J1enlhYWR2ZW50dXJlcy5jb208L3RleHQ+CgogIDwhLS0gSW52b2ljZSBUaXRsZSAtLT4KICA8dGV4dCB4PSI2MDAiIHk9IjExMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjI0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+SU5WT0lDRTwvdGV4dD4KICA8dGV4dCB4PSI2MDAiIHk9IjE0MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5EYXRlOiAxMi8xMS8yMDI0PC90ZXh0PgogIDx0ZXh0IHg9IjYwMCIgeT0iMTYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPkludm9pY2UgIzogR1JaLTIwMjQtMTEyMzwvdGV4dD4KCiAgPCEtLSBCaWxsIFRvIFNlY3Rpb24gLS0+CiAgPHRleHQgeD0iNDAiIHk9IjIyMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE2IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+QklMTCBUTzo8L3RleHQ+CiAgPHJlY3QgeD0iNDAiIHk9IjIzNSIgd2lkdGg9IjMwMCIgaGVpZ2h0PSI4MCIgZmlsbD0iI2Y3ZjlmYSIvPgogIDx0ZXh0IHg9IjUwIiB5PSIyNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+W0N1c3RvbWVyIE5hbWVdPC90ZXh0PgogIDx0ZXh0IHg9IjUwIiB5PSIyODAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+W0FkZHJlc3MgTGluZSAxXTwvdGV4dD4KICA8dGV4dCB4PSI1MCIgeT0iMzAwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPltDaXR5LCBDb3VudHJ5XTwvdGV4dD4KCiAgPCEtLSBUYWJsZSBIZWFkZXJzIC0tPgogIDxyZWN0IHg9IjQwIiB5PSIzNDAiIHdpZHRoPSI3MjAiIGhlaWdodD0iMzAiIGZpbGw9IiMyYzNlNTAiLz4KICA8dGV4dCB4PSI1MCIgeT0iMzYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSJ3aGl0ZSI+RGVzY3JpcHRpb248L3RleHQ+CiAgPHRleHQgeD0iNDUwIiB5PSIzNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IndoaXRlIj5RdWFudGl0eTwvdGV4dD4KICA8dGV4dCB4PSI1NTAiIHk9IjM2MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0id2hpdGUiPlJhdGU8L3RleHQ+CiAgPHRleHQgeD0iNjgwIiB5PSIzNjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IndoaXRlIj5BbW91bnQ8L3RleHQ+CgogIDwhLS0gVGFibGUgUm93cyAtLT4KICA8cmVjdCB4PSI0MCIgeT0iMzcwIiB3aWR0aD0iNzIwIiBoZWlnaHQ9IjMwIiBmaWxsPSIjZjdmOWZhIi8+CiAgPHRleHQgeD0iNTAiIHk9IjM5MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5Nb3VudGFpbiBDbGltYmluZyBFcXVpcG1lbnQgUmVudGFsPC90ZXh0PgogIDx0ZXh0IHg9IjQ1MCIgeT0iMzkwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPjE8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSIzOTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDI1MC4wMDwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjM5MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kMjUwLjAwPC90ZXh0PgoKICA8cmVjdCB4PSI0MCIgeT0iNDAwIiB3aWR0aD0iNzIwIiBoZWlnaHQ9IjMwIiBmaWxsPSJ3aGl0ZSIvPgogIDx0ZXh0IHg9IjUwIiB5PSI0MjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+R3VpZGVkIFRyZWsgUGFja2FnZSAtIDIgRGF5czwvdGV4dD4KICA8dGV4dCB4PSI0NTAiIHk9IjQyMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4xPC90ZXh0PgogIDx0ZXh0IHg9IjU1MCIgeT0iNDIwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPiQ0MDAuMDA8L3RleHQ+CiAgPHRleHQgeD0iNjgwIiB5PSI0MjAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDQwMC4wMDwvdGV4dD4KCiAgPHJlY3QgeD0iNDAiIHk9IjQzMCIgd2lkdGg9IjcyMCIgaGVpZ2h0PSIzMCIgZmlsbD0iI2Y3ZjlmYSIvPgogIDx0ZXh0IHg9IjUwIiB5PSI0NTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+U2FmZXR5IEVxdWlwbWVudCBQYWNrYWdlPC90ZXh0PgogIDx0ZXh0IHg9IjQ1MCIgeT0iNDUwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPjE8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSI0NTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+JDE1MC4wMDwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjQ1MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kMTUwLjAwPC90ZXh0PgoKICA8IS0tIFRvdGFscyAtLT4KICA8bGluZSB4MT0iNDAiIHkxPSI0ODAiIHgyPSI3NjAiIHkyPSI0ODAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIxIi8+CiAgPHRleHQgeD0iNTUwIiB5PSI1MTAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMzNDQ5NWUiPlN1YnRvdGFsOjwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjUxMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj4kODAwLjAwPC90ZXh0PgogIDx0ZXh0IHg9IjU1MCIgeT0iNTM1IiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZvbnQtd2VpZ2h0PSJib2xkIiBmaWxsPSIjMzQ0OTVlIj5UYXggKDE4JSk6PC90ZXh0PgogIDx0ZXh0IHg9IjY4MCIgeT0iNTM1IiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPiQxNDQuMDA8L3RleHQ+CiAgPHRleHQgeD0iNTUwIiB5PSI1NzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPlRvdGFsOjwvdGV4dD4KICA8dGV4dCB4PSI2ODAiIHk9IjU3MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE2IiBmb250LXdlaWdodD0iYm9sZCIgZmlsbD0iIzJjM2U1MCI+JDk0NC4wMDwvdGV4dD4KCiAgPCEtLSBQYXltZW50IFRlcm1zIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI2NDAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPlBheW1lbnQgVGVybXM8L3RleHQ+CiAgPHRleHQgeD0iNDAiIHk9IjY3MCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjE0IiBmaWxsPSIjMzQ0OTVlIj5QYXltZW50IGlzIGR1ZSB3aXRoaW4gMzAgZGF5czwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNjkwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPlBsZWFzZSBpbmNsdWRlIGludm9pY2UgbnVtYmVyIG9uIHBheW1lbnQ8L3RleHQ+CgogIDwhLS0gQmFuayBEZXRhaWxzIC0tPgogIDx0ZXh0IHg9IjQwIiB5PSI3MzAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNiIgZm9udC13ZWlnaHQ9ImJvbGQiIGZpbGw9IiMyYzNlNTAiPkJhbmsgRGV0YWlsczwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNzYwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPkJhbms6IEJhbmsgb2YgR2VvcmdpYTwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iNzgwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTQiIGZpbGw9IiMzNDQ5NWUiPklCQU46IEdFMTIzNDU2Nzg5MDEyMzQ1Njc4PC90ZXh0PgogIDx0ZXh0IHg9IjQwIiB5PSI4MDAiIGZvbnQtZmFtaWx5PSJBcmlhbCIgZm9udC1zaXplPSIxNCIgZmlsbD0iIzM0NDk1ZSI+U1dJRlQ6IEJBR0FHRTIyPC90ZXh0PgoKICA8IS0tIEZvb3RlciAtLT4KICA8bGluZSB4MT0iNDAiIHkxPSI5MDAiIHgyPSI3NjAiIHkyPSI5MDAiIHN0cm9rZT0iIzJjM2U1MCIgc3Ryb2tlLXdpZHRoPSIxIi8+CiAgPHRleHQgeD0iNDAiIHk9IjkzMCIgZm9udC1mYW1pbHk9IkFyaWFsIiBmb250LXNpemU9IjEyIiBmaWxsPSIjN2Y4YzhkIj5UaGFuayB5b3UgZm9yIGNob29zaW5nIEdydXp5YSBBZHZlbnR1cmUgT3V0Zml0dGVyczwvdGV4dD4KICA8dGV4dCB4PSI0MCIgeT0iOTUwIiBmb250LWZhbWlseT0iQXJpYWwiIGZvbnQtc2l6ZT0iMTIiIGZpbGw9IiM3ZjhjOGQiPnd3dy5ncnV6eWFhZHZlbnR1cmVzLmNvbTwvdGV4dD4KPC9zdmc+Cg==",
    ///                     Filename = "logo.jpg",
    ///                     Ftype = FileContentFtype.Jpg,
    ///                     Furl = "",
    ///                 },
    ///                 RedirectAfterApprove = true,
    ///                 RedirectAfterApproveUrl = "https://example.com/success",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromInvoiceAsync(
        int idInvoice,
        PayLinkDataInvoice request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            AddPayLinkFromInvoiceAsyncCore(idInvoice, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Generates a payment link for a bill from the bill ID.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.AddPayLinkFromBillAsync(
    ///     23548884,
    ///     new PayLinkDataBill
    ///     {
    ///         Mail2 = "jo@example.com; ceo@example.com",
    ///         Body = new PaymentPageRequestBody
    ///         {
    ///             ContactUs = new ContactElement
    ///             {
    ///                 EmailLabel = "Email",
    ///                 Enabled = true,
    ///                 Header = "Contact Us",
    ///                 Order = 0,
    ///                 PaymentIcons = true,
    ///                 PhoneLabel = "Phone",
    ///             },
    ///             Logo = new Element { Enabled = true, Order = 0 },
    ///             MessageBeforePaying = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Please review your payment details",
    ///                 Order = 0,
    ///             },
    ///             Notes = new NoteElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Additional Notes",
    ///                 Order = 0,
    ///                 Placeholder = "Enter any additional notes here",
    ///                 Value = "",
    ///             },
    ///             Page = new PageElement
    ///             {
    ///                 Description = "Get paid securely",
    ///                 Enabled = true,
    ///                 Header = "Payment Page",
    ///                 Order = 0,
    ///             },
    ///             PaymentButton = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Pay Now",
    ///                 Order = 0,
    ///             },
    ///             PaymentMethods = new MethodElement
    ///             {
    ///                 AllMethodsChecked = true,
    ///                 Enabled = true,
    ///                 Header = "Payment Methods",
    ///                 Methods = new MethodsList
    ///                 {
    ///                     Amex = true,
    ///                     ApplePay = true,
    ///                     Discover = true,
    ///                     ECheck = true,
    ///                     Mastercard = true,
    ///                     Visa = true,
    ///                 },
    ///                 Order = 0,
    ///             },
    ///             Payor = new PayorElement
    ///             {
    ///                 Enabled = true,
    ///                 Fields = new List&lt;PayorFields&gt;()
    ///                 {
    ///                     new PayorFields
    ///                     {
    ///                         Display = true,
    ///                         Fixed = true,
    ///                         Identifier = true,
    ///                         Label = "Full Name",
    ///                         Name = "fullName",
    ///                         Order = 0,
    ///                         Required = true,
    ///                         Validation = "alpha",
    ///                         Value = "",
    ///                         Width = 0,
    ///                     },
    ///                 },
    ///                 Header = "Payor Information",
    ///                 Order = 0,
    ///             },
    ///             Review = new HeaderElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Review Payment",
    ///                 Order = 0,
    ///             },
    ///             Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromBillAsync(
        int billId,
        PayLinkDataBill request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            AddPayLinkFromBillAsyncCore(billId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Deletes a payment link by ID.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.DeletePayLinkFromIdAsync("payLinkId");
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> DeletePayLinkFromIdAsync(
        string payLinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            DeletePayLinkFromIdAsyncCore(payLinkId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a payment link by ID.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.GetPayLinkFromIdAsync("paylinkId");
    /// </code></example>
    public WithRawResponseTask<GetPayLinkFromIdResponse> GetPayLinkFromIdAsync(
        string paylinkId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<GetPayLinkFromIdResponse>(
            GetPayLinkFromIdAsyncCore(paylinkId, options, cancellationToken)
        );
    }

    /// <summary>
    /// Send a payment link to the specified email addresses or phone numbers.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.PushPayLinkFromIdAsync(
    ///     "payLinkId",
    ///     new PushPayLinkRequest(new PushPayLinkRequest.Sms(new PushPayLinkRequestSms()))
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> PushPayLinkFromIdAsync(
        string payLinkId,
        PushPayLinkRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            PushPayLinkFromIdAsyncCore(payLinkId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Refresh a payment link's content after an update.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.RefreshPayLinkFromIdAsync("payLinkId", new RefreshPayLinkFromIdRequest());
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> RefreshPayLinkFromIdAsync(
        string payLinkId,
        RefreshPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            RefreshPayLinkFromIdAsyncCore(payLinkId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Sends a payment link to the specified email addresses.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.SendPayLinkFromIdAsync(
    ///     "payLinkId",
    ///     new SendPayLinkFromIdRequest { Mail2 = "jo@example.com; ceo@example.com" }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> SendPayLinkFromIdAsync(
        string payLinkId,
        SendPayLinkFromIdRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            SendPayLinkFromIdAsyncCore(payLinkId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates a payment link's details.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.UpdatePayLinkFromIdAsync(
    ///     "332-c277b704-1301",
    ///     new PayLinkUpdateData
    ///     {
    ///         Notes = new NoteElement
    ///         {
    ///             Enabled = true,
    ///             Header = "Additional Notes",
    ///             Order = 0,
    ///             Placeholder = "Enter any additional notes here",
    ///             Value = "",
    ///         },
    ///         PaymentButton = new LabelElement
    ///         {
    ///             Enabled = true,
    ///             Label = "Pay Now",
    ///             Order = 0,
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> UpdatePayLinkFromIdAsync(
        string payLinkId,
        PayLinkUpdateData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            UpdatePayLinkFromIdAsyncCore(payLinkId, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Generates a vendor payment link for a specific bill lot number. This allows you to pay all bills with the same lot number for a vendor with a single payment link.
    /// </summary>
    /// <example><code>
    /// await client.PaymentLink.AddPayLinkFromBillLotNumberAsync(
    ///     "LOT-2024-001",
    ///     new PayLinkDataOut
    ///     {
    ///         EntryPoint = "billing",
    ///         VendorNumber = "VENDOR-123",
    ///         Mail2 = "customer@example.com; billing@example.com",
    ///         AmountFixed = "true",
    ///         Body = new PaymentPageRequestBody
    ///         {
    ///             ContactUs = new ContactElement
    ///             {
    ///                 EmailLabel = "Email",
    ///                 Enabled = true,
    ///                 Header = "Contact Us",
    ///                 Order = 0,
    ///                 PaymentIcons = true,
    ///                 PhoneLabel = "Phone",
    ///             },
    ///             Logo = new Element { Enabled = true, Order = 0 },
    ///             MessageBeforePaying = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Please review your payment details",
    ///                 Order = 0,
    ///             },
    ///             Notes = new NoteElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Additional Notes",
    ///                 Order = 0,
    ///                 Placeholder = "Enter any additional notes here",
    ///                 Value = "",
    ///             },
    ///             Page = new PageElement
    ///             {
    ///                 Description = "Get paid securely",
    ///                 Enabled = true,
    ///                 Header = "Payment Page",
    ///                 Order = 0,
    ///             },
    ///             PaymentButton = new LabelElement
    ///             {
    ///                 Enabled = true,
    ///                 Label = "Pay Now",
    ///                 Order = 0,
    ///             },
    ///             PaymentMethods = new MethodElement
    ///             {
    ///                 AllMethodsChecked = true,
    ///                 Enabled = true,
    ///                 Header = "Payment Methods",
    ///                 Methods = new MethodsList
    ///                 {
    ///                     Amex = true,
    ///                     ApplePay = true,
    ///                     Discover = true,
    ///                     ECheck = true,
    ///                     Mastercard = true,
    ///                     Visa = true,
    ///                 },
    ///                 Order = 0,
    ///             },
    ///             Payor = new PayorElement
    ///             {
    ///                 Enabled = true,
    ///                 Fields = new List&lt;PayorFields&gt;()
    ///                 {
    ///                     new PayorFields
    ///                     {
    ///                         Display = true,
    ///                         Fixed = true,
    ///                         Identifier = true,
    ///                         Label = "Full Name",
    ///                         Name = "fullName",
    ///                         Order = 0,
    ///                         Required = true,
    ///                         Validation = "alpha",
    ///                         Value = "",
    ///                         Width = 0,
    ///                     },
    ///                 },
    ///                 Header = "Payor Information",
    ///                 Order = 0,
    ///             },
    ///             Review = new HeaderElement
    ///             {
    ///                 Enabled = true,
    ///                 Header = "Review Payment",
    ///                 Order = 0,
    ///             },
    ///             Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponsePaymentLinks> AddPayLinkFromBillLotNumberAsync(
        string lotNumber,
        PayLinkDataOut request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponsePaymentLinks>(
            AddPayLinkFromBillLotNumberAsyncCore(lotNumber, request, options, cancellationToken)
        );
    }
}
