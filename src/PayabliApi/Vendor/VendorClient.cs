using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class VendorClient : IVendorClient
{
    private RawClient _client;

    internal VendorClient(RawClient client)
    {
        _client = client;
    }

    private async Task<WithRawResponse<PayabliApiResponseVendors>> AddVendorAsyncCore(
        string entry,
        VendorData request,
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
                        "Vendor/single/{0}",
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
            var responseBody = await response.Raw.Content.ReadAsStringAsync();
            try
            {
                var responseData = JsonUtils.Deserialize<PayabliApiResponseVendors>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseVendors>()
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

    private async Task<WithRawResponse<PayabliApiResponseVendors>> DeleteVendorAsyncCore(
        int idVendor,
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
                        "Vendor/{0}",
                        ValueConvert.ToPathParameterString(idVendor)
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponseVendors>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseVendors>()
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

    private async Task<WithRawResponse<PayabliApiResponseVendors>> EditVendorAsyncCore(
        int idVendor,
        VendorData request,
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
                        "Vendor/{0}",
                        ValueConvert.ToPathParameterString(idVendor)
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
                var responseData = JsonUtils.Deserialize<PayabliApiResponseVendors>(responseBody)!;
                return new WithRawResponse<PayabliApiResponseVendors>()
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

    private async Task<WithRawResponse<VendorQueryRecord>> GetVendorAsyncCore(
        int idVendor,
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
                        "Vendor/{0}",
                        ValueConvert.ToPathParameterString(idVendor)
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
                var responseData = JsonUtils.Deserialize<VendorQueryRecord>(responseBody)!;
                return new WithRawResponse<VendorQueryRecord>()
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
    /// Creates a vendor in an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Vendor.AddVendorAsync(
    ///     "8cfec329267",
    ///     new VendorData
    ///     {
    ///         VendorNumber = "1234",
    ///         Name1 = "Herman's Coatings and Masonry",
    ///         Name2 = "&lt;string&gt;",
    ///         Ein = "12-3456789",
    ///         Phone = "5555555555",
    ///         Email = "example@email.com",
    ///         Address1 = "123 Ocean Drive",
    ///         Address2 = "Suite 400",
    ///         City = "Miami",
    ///         State = "FL",
    ///         Zip = "33139",
    ///         Country = "US",
    ///         Mcc = "7777",
    ///         LocationCode = "MIA123",
    ///         Contacts = new List&lt;Contacts&gt;()
    ///         {
    ///             new Contacts
    ///             {
    ///                 ContactName = "Herman Martinez",
    ///                 ContactEmail = "example@email.com",
    ///                 ContactTitle = "Owner",
    ///                 ContactPhone = "3055550000",
    ///             },
    ///         },
    ///         BillingData = new BillingData
    ///         {
    ///             Id = 123,
    ///             BankName = "Country Bank",
    ///             RoutingAccount = "123123123",
    ///             AccountNumber = "123123123",
    ///             TypeAccount = TypeAccount.Checking,
    ///             BankAccountHolderName = "Gruzya Adventure Outfitters LLC",
    ///             BankAccountHolderType = BankAccountHolderType.Business,
    ///             BankAccountFunction = 0,
    ///         },
    ///         PaymentMethod = "managed",
    ///         VendorStatus = 1,
    ///         RemitAddress1 = "123 Walnut Street",
    ///         RemitAddress2 = "Suite 900",
    ///         RemitCity = "Miami",
    ///         RemitState = "FL",
    ///         RemitZip = "31113",
    ///         RemitCountry = "US",
    ///         PayeeName1 = "&lt;string&gt;",
    ///         PayeeName2 = "&lt;string&gt;",
    ///         CustomerVendorAccount = "A-37622",
    ///         InternalReferenceId = 123,
    ///     }
    /// );
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseVendors> AddVendorAsync(
        string entry,
        VendorData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseVendors>(
            AddVendorAsyncCore(entry, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Delete a vendor.
    /// </summary>
    /// <example><code>
    /// await client.Vendor.DeleteVendorAsync(1);
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseVendors> DeleteVendorAsync(
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseVendors>(
            DeleteVendorAsyncCore(idVendor, options, cancellationToken)
        );
    }

    /// <summary>
    /// Updates a vendor's information. Send only the fields you need to update.
    /// </summary>
    /// <example><code>
    /// await client.Vendor.EditVendorAsync(1, new VendorData { Name1 = "Theodore's Janitorial" });
    /// </code></example>
    public WithRawResponseTask<PayabliApiResponseVendors> EditVendorAsync(
        int idVendor,
        VendorData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<PayabliApiResponseVendors>(
            EditVendorAsyncCore(idVendor, request, options, cancellationToken)
        );
    }

    /// <summary>
    /// Retrieves a vendor's details.
    /// </summary>
    /// <example><code>
    /// await client.Vendor.GetVendorAsync(1);
    /// </code></example>
    public WithRawResponseTask<VendorQueryRecord> GetVendorAsync(
        int idVendor,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        return new WithRawResponseTask<VendorQueryRecord>(
            GetVendorAsyncCore(idVendor, options, cancellationToken)
        );
    }
}
