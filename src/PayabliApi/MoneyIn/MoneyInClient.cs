using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class MoneyInClient
{
    private RawClient _client;

    internal MoneyInClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Authorize a card transaction. This returns an authorization code and reserves funds for the merchant. Authorized transactions aren't flagged for settlement until [captured](/api-reference/moneyin/capture-an-authorized-transaction).
    ///
    /// **Note**: Only card transactions can be authorized. This endpoint can't be used for ACH transactions.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.AuthorizeAsync(
    ///     new RequestPaymentAuthorize
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<AuthResponse> AuthorizeAsync(
        RequestPaymentAuthorize request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ForceCustomerCreation != null)
        {
            _query["forceCustomerCreation"] = JsonUtils.Serialize(
                request.ForceCustomerCreation.Value
            );
        }
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "MoneyIn/authorize",
                    Body = request.Body,
                    Query = _query,
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
                return JsonUtils.Deserialize<AuthResponse>(responseBody)!;
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

    /// <summary>
    /// &lt;Warning&gt;
    ///   This endpoint is deprecated and will be sunset on November 24, 2025. Migrate to [POST `/capture/{transId}`](/api-reference/moneyin/capture-an-authorized-transaction)`.
    /// &lt;/Warning&gt;
    ///
    ///   Capture an [authorized
    /// transaction](/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CaptureAsync("10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13", 0);
    /// </code></example>
    public async Task<CaptureResponse> CaptureAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/capture/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
                    ),
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
                return JsonUtils.Deserialize<CaptureResponse>(responseBody)!;
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

    /// <summary>
    /// Capture an [authorized transaction](/api-reference/moneyin/authorize-a-transaction) to complete the transaction and move funds from the customer to merchant account.
    ///
    /// You can use this endpoint to capture both full and partial amounts of the original authorized transaction. See [Capture an authorized transaction](/developers/developer-guides/pay-in-auth-and-capture) for more information about this endpoint.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CaptureAuthAsync(
    ///     "10-7d9cd67d-2d5d-4cd7-a1b7-72b8b201ec13",
    ///     new CaptureRequest
    ///     {
    ///         PaymentDetails = new CapturePaymentDetails { TotalAmount = 105, ServiceFee = 5 },
    ///     }
    /// );
    /// </code></example>
    public async Task<CaptureResponse> CaptureAuthAsync(
        string transId,
        CaptureRequest request,
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
                    Path = string.Format(
                        "MoneyIn/capture/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
                    Body = request,
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
                return JsonUtils.Deserialize<CaptureResponse>(responseBody)!;
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

    /// <summary>
    /// Make a temporary microdeposit in a customer account to verify the customer's ownership and access to the target account. Reverse the microdeposit with `reverseCredit`.
    ///
    /// This feature must be enabled by Payabli on a per-merchant basis. Contact support for help.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.CreditAsync(
    ///     new RequestCredit
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         CustomerData = new PayorDataRequest
    ///         {
    ///             BillingAddress1 = "5127 Linkwood ave",
    ///             CustomerNumber = "100",
    ///         },
    ///         Entrypoint = "my-entrypoint",
    ///         PaymentDetails = new PaymentDetailCredit { ServiceFee = 0, TotalAmount = 1 },
    ///         PaymentMethod = new RequestCreditPaymentMethod
    ///         {
    ///             AchAccount = "88354454",
    ///             AchAccountType = Achaccounttype.Checking,
    ///             AchHolder = "John Smith",
    ///             AchRouting = "021000021",
    ///             Method = "ach",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<PayabliApiResponse0> CreditAsync(
        RequestCredit request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ForceCustomerCreation != null)
        {
            _query["forceCustomerCreation"] = JsonUtils.Serialize(
                request.ForceCustomerCreation.Value
            );
        }
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "MoneyIn/makecredit",
                    Body = request,
                    Query = _query,
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
                return JsonUtils.Deserialize<PayabliApiResponse0>(responseBody)!;
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

    /// <summary>
    /// Retrieve a processed transaction's details.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.DetailsAsync("45-as456777hhhhhhhhhh77777777-324");
    /// </code></example>
    public async Task<TransactionQueryRecordsCustomer> DetailsAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/details/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
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
                return JsonUtils.Deserialize<TransactionQueryRecordsCustomer>(responseBody)!;
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

    /// <summary>
    /// Make a single transaction. This method authorizes and captures a payment in one step.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.GetpaidAsync(
    ///     new RequestPayment
    ///     {
    ///         Body = new TransRequestBody
    ///         {
    ///             CustomerData = new PayorDataRequest { CustomerId = 4440 },
    ///             EntryPoint = "f743aed24a",
    ///             Ipaddress = "255.255.255.255",
    ///             PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
    ///             PaymentMethod = new PayMethodCredit
    ///             {
    ///                 Cardcvv = "999",
    ///                 Cardexp = "02/27",
    ///                 CardHolder = "John Cassian",
    ///                 Cardnumber = "4111111111111111",
    ///                 Cardzip = "12345",
    ///                 Initiator = "payor",
    ///                 Method = "card",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<PayabliApiResponseGetPaid> GetpaidAsync(
        RequestPayment request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.AchValidation != null)
        {
            _query["achValidation"] = JsonUtils.Serialize(request.AchValidation.Value);
        }
        if (request.ForceCustomerCreation != null)
        {
            _query["forceCustomerCreation"] = JsonUtils.Serialize(
                request.ForceCustomerCreation.Value
            );
        }
        if (request.IncludeDetails != null)
        {
            _query["includeDetails"] = JsonUtils.Serialize(request.IncludeDetails.Value);
        }
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        if (request.ValidationCode != null)
        {
            _headers["validationCode"] = request.ValidationCode;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "MoneyIn/getpaid",
                    Body = request.Body,
                    Query = _query,
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
                return JsonUtils.Deserialize<PayabliApiResponseGetPaid>(responseBody)!;
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

    /// <summary>
    /// A reversal either refunds or voids a transaction independent of the transaction's settlement status. Send a reversal request for a transaction, and Payabli automatically determines whether it's a refund or void. You don't need to know whether the transaction is settled or not.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ReverseAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public async Task<ReverseResponse> ReverseAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/reverse/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
                    ),
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
                return JsonUtils.Deserialize<ReverseResponse>(responseBody)!;
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

    /// <summary>
    /// Refund a transaction that has settled and send money back to the account holder. If a transaction hasn't been settled, void it instead.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.RefundAsync(0, "10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public async Task<RefundResponse> RefundAsync(
        string transId,
        double amount,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/refund/{0}/{1}",
                        ValueConvert.ToPathParameterString(transId),
                        ValueConvert.ToPathParameterString(amount)
                    ),
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
                return JsonUtils.Deserialize<RefundResponse>(responseBody)!;
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

    /// <summary>
    /// Refunds a settled transaction with split instructions.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.RefundWithInstructionsAsync(
    ///     "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
    ///     new RequestRefund
    ///     {
    ///         IdempotencyKey = "8A29FC40-CA47-1067-B31D-00DD010662DB",
    ///         Source = "api",
    ///         OrderDescription = "Materials deposit",
    ///         Amount = 100,
    ///         RefundDetails = new RefundDetail
    ///         {
    ///             SplitRefunding = new List&lt;SplitFundingRefundContent&gt;()
    ///             {
    ///                 new SplitFundingRefundContent
    ///                 {
    ///                     OriginationEntryPoint = "7f1a381696",
    ///                     AccountId = "187-342",
    ///                     Description = "Refunding undelivered materials",
    ///                     Amount = 60,
    ///                 },
    ///                 new SplitFundingRefundContent
    ///                 {
    ///                     OriginationEntryPoint = "7f1a381696",
    ///                     AccountId = "187-343",
    ///                     Description = "Refunding deposit for undelivered materials",
    ///                     Amount = 40,
    ///                 },
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<RefundWithInstructionsResponse> RefundWithInstructionsAsync(
        string transId,
        RequestRefund request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = string.Format(
                        "MoneyIn/refund/{0}",
                        ValueConvert.ToPathParameterString(transId)
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
                return JsonUtils.Deserialize<RefundWithInstructionsResponse>(responseBody)!;
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

    /// <summary>
    /// Reverse microdeposits that are used to verify customer account ownership and access. The `transId` value is returned in the success response for the original credit transaction made with `api/MoneyIn/makecredit`.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ReverseCreditAsync("45-as456777hhhhhhhhhh77777777-324");
    /// </code></example>
    public async Task<PayabliApiResponse> ReverseCreditAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/reverseCredit/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
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
                return JsonUtils.Deserialize<PayabliApiResponse>(responseBody)!;
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

    /// <summary>
    /// Send a payment receipt for a transaction.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.SendReceipt2TransAsync(
    ///     "45-as456777hhhhhhhhhh77777777-324",
    ///     new SendReceipt2TransRequest { Email = "example@email.com" }
    /// );
    /// </code></example>
    public async Task<ReceiptResponse> SendReceipt2TransAsync(
        string transId,
        SendReceipt2TransRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Email != null)
        {
            _query["email"] = request.Email;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/sendreceipt/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
                    Query = _query,
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
                return JsonUtils.Deserialize<ReceiptResponse>(responseBody)!;
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

    /// <summary>
    /// Validates a card number without running a transaction or authorizing a charge.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.ValidateAsync(
    ///     new RequestPaymentValidate
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         EntryPoint = "entry132",
    ///         PaymentMethod = new RequestPaymentValidatePaymentMethod
    ///         {
    ///             Method = RequestPaymentValidatePaymentMethodMethod.Card,
    ///             Cardnumber = "4360000001000005",
    ///             Cardexp = "12/29",
    ///             Cardzip = "14602-8328",
    ///             CardHolder = "Dianne Becker-Smith",
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<ValidateResponse> ValidateAsync(
        RequestPaymentValidate request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _headers = new Headers(new Dictionary<string, string>() { });
        if (request.IdempotencyKey != null)
        {
            _headers["idempotencyKey"] = request.IdempotencyKey;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Post,
                    Path = "MoneyIn/validate",
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
                return JsonUtils.Deserialize<ValidateResponse>(responseBody)!;
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

    /// <summary>
    /// Cancel a transaction that hasn't been settled yet. Voiding non-captured authorizations prevents future captures. If a transaction has been settled, refund it instead.
    /// </summary>
    /// <example><code>
    /// await client.MoneyIn.VoidAsync("10-3ffa27df-b171-44e0-b251-e95fbfc7a723");
    /// </code></example>
    public async Task<VoidResponse> VoidAsync(
        string transId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "MoneyIn/void/{0}",
                        ValueConvert.ToPathParameterString(transId)
                    ),
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
                return JsonUtils.Deserialize<VoidResponse>(responseBody)!;
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
