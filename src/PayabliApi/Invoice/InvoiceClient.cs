using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class InvoiceClient
{
    private RawClient _client;

    internal InvoiceClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates an invoice in an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.AddInvoiceAsync(
    ///     "8cfec329267",
    ///     new AddInvoiceRequest
    ///     {
    ///         Body = new InvoiceDataRequest
    ///         {
    ///             CustomerData = new PayorDataRequest
    ///             {
    ///                 FirstName = "Tamara",
    ///                 LastName = "Bagratoni",
    ///                 CustomerNumber = "3",
    ///             },
    ///             InvoiceData = new BillData
    ///             {
    ///                 Items = new List&lt;BillItem&gt;()
    ///                 {
    ///                     new BillItem
    ///                     {
    ///                         ItemProductName = "Adventure Consult",
    ///                         ItemDescription = "Consultation for Georgian tours",
    ///                         ItemCost = 100,
    ///                         ItemQty = 1,
    ///                         ItemMode = 1,
    ///                     },
    ///                     new BillItem
    ///                     {
    ///                         ItemProductName = "Deposit ",
    ///                         ItemDescription = "Deposit for trip planning",
    ///                         ItemCost = 882.37,
    ///                         ItemQty = 1,
    ///                     },
    ///                 },
    ///                 InvoiceDate = new DateOnly(2025, 10, 19),
    ///                 InvoiceType = 0,
    ///                 InvoiceStatus = 1,
    ///                 Frequency = Frequency.OneTime,
    ///                 InvoiceAmount = 982.37,
    ///                 Discount = 10,
    ///                 InvoiceNumber = "INV-3",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<InvoiceResponseWithoutData> AddInvoiceAsync(
        string entry,
        AddInvoiceRequest request,
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
                    Path = string.Format("Invoice/{0}", ValueConvert.ToPathParameterString(entry)),
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
                return JsonUtils.Deserialize<InvoiceResponseWithoutData>(responseBody)!;
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
    /// Deletes an invoice that's attached to a file.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.DeleteAttachedFromInvoiceAsync("0_Bill.pdf", 23548884);
    /// </code></example>
    public async Task<InvoiceResponseWithoutData> DeleteAttachedFromInvoiceAsync(
        int idInvoice,
        string filename,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "Invoice/attachedFileFromInvoice/{0}/{1}",
                        ValueConvert.ToPathParameterString(idInvoice),
                        ValueConvert.ToPathParameterString(filename)
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
                return JsonUtils.Deserialize<InvoiceResponseWithoutData>(responseBody)!;
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
    /// Deletes a single invoice from an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.DeleteInvoiceAsync(23548884);
    /// </code></example>
    public async Task<InvoiceResponseWithoutData> DeleteInvoiceAsync(
        int idInvoice,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Delete,
                    Path = string.Format(
                        "Invoice/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
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
                return JsonUtils.Deserialize<InvoiceResponseWithoutData>(responseBody)!;
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
    /// Updates details for a single invoice in an entrypoint.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.EditInvoiceAsync(
    ///     332,
    ///     new EditInvoiceRequest
    ///     {
    ///         Body = new InvoiceDataRequest
    ///         {
    ///             InvoiceData = new BillData
    ///             {
    ///                 Items = new List&lt;BillItem&gt;()
    ///                 {
    ///                     new BillItem
    ///                     {
    ///                         ItemProductName = "Deposit",
    ///                         ItemDescription = "Deposit for trip planning",
    ///                         ItemCost = 882.37,
    ///                         ItemQty = 1,
    ///                     },
    ///                 },
    ///                 InvoiceDate = new DateOnly(2025, 10, 19),
    ///                 InvoiceAmount = 982.37,
    ///                 InvoiceNumber = "INV-6",
    ///             },
    ///         },
    ///     }
    /// );
    /// </code></example>
    public async Task<InvoiceResponseWithoutData> EditInvoiceAsync(
        int idInvoice,
        EditInvoiceRequest request,
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
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "Invoice/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
                    ),
                    Body = request.Body,
                    Query = _query,
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
                return JsonUtils.Deserialize<InvoiceResponseWithoutData>(responseBody)!;
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
    /// Retrieves a file attached to an invoice.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.GetAttachedFileFromInvoiceAsync(
    ///     1,
    ///     "filename",
    ///     new GetAttachedFileFromInvoiceRequest()
    /// );
    /// </code></example>
    public async Task<FileContent> GetAttachedFileFromInvoiceAsync(
        int idInvoice,
        string filename,
        GetAttachedFileFromInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ReturnObject != null)
        {
            _query["returnObject"] = JsonUtils.Serialize(request.ReturnObject.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Invoice/attachedFileFromInvoice/{0}/{1}",
                        ValueConvert.ToPathParameterString(idInvoice),
                        ValueConvert.ToPathParameterString(filename)
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
                return JsonUtils.Deserialize<FileContent>(responseBody)!;
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
    /// Retrieves a single invoice by ID.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.GetInvoiceAsync(23548884);
    /// </code></example>
    public async Task<GetInvoiceRecord> GetInvoiceAsync(
        int idInvoice,
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
                        "Invoice/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
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
                return JsonUtils.Deserialize<GetInvoiceRecord>(responseBody)!;
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
    /// Retrieves the next available invoice number for a paypoint.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.GetInvoiceNumberAsync("8cfec329267");
    /// </code></example>
    public async Task<InvoiceNumberResponse> GetInvoiceNumberAsync(
        string entry,
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
                        "Invoice/getNumber/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<InvoiceNumberResponse>(responseBody)!;
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
    /// Returns a list of invoices for an entrypoint. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.ListInvoicesAsync(
    ///     "8cfec329267",
    ///     new ListInvoicesRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryInvoiceResponse> ListInvoicesAsync(
        string entry,
        ListInvoicesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/invoices/{0}",
                        ValueConvert.ToPathParameterString(entry)
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
                return JsonUtils.Deserialize<QueryInvoiceResponse>(responseBody)!;
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
    /// Returns a list of invoices for an org. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.ListInvoicesOrgAsync(
    ///     123,
    ///     new ListInvoicesOrgRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryInvoiceResponse> ListInvoicesOrgAsync(
        int orgId,
        ListInvoicesOrgRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.ExportFormat != null)
        {
            _query["exportFormat"] = request.ExportFormat.Value.Stringify();
        }
        if (request.FromRecord != null)
        {
            _query["fromRecord"] = request.FromRecord.Value.ToString();
        }
        if (request.LimitRecord != null)
        {
            _query["limitRecord"] = request.LimitRecord.Value.ToString();
        }
        if (request.Parameters != null)
        {
            _query["parameters"] = JsonUtils.Serialize(request.Parameters);
        }
        if (request.SortBy != null)
        {
            _query["sortBy"] = request.SortBy;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Query/invoices/org/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<QueryInvoiceResponse>(responseBody)!;
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
    /// Sends an invoice from an entrypoint via email.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.SendInvoiceAsync(
    ///     23548884,
    ///     new SendInvoiceRequest { Attachfile = true, Mail2 = "tamara@example.com" }
    /// );
    /// </code></example>
    public async Task<SendInvoiceResponse> SendInvoiceAsync(
        int idInvoice,
        SendInvoiceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.Attachfile != null)
        {
            _query["attachfile"] = JsonUtils.Serialize(request.Attachfile.Value);
        }
        if (request.Mail2 != null)
        {
            _query["mail2"] = request.Mail2;
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Get,
                    Path = string.Format(
                        "Invoice/send/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
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
                return JsonUtils.Deserialize<SendInvoiceResponse>(responseBody)!;
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
    /// Export a single invoice in PDF format.
    /// </summary>
    /// <example><code>
    /// await client.Invoice.GetInvoicePdfAsync(23548884);
    /// </code></example>
    public async Task<Dictionary<string, object?>> GetInvoicePdfAsync(
        int idInvoice,
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
                        "Export/invoicePdf/{0}",
                        ValueConvert.ToPathParameterString(idInvoice)
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
                return JsonUtils.Deserialize<Dictionary<string, object?>>(responseBody)!;
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
