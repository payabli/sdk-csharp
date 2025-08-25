using System.Net.Http;
using System.Text.Json;
using System.Threading;
using OneOf;
using PayabliApi.Core;

namespace PayabliApi;

public partial class BoardingClient
{
    private RawClient _client;

    internal BoardingClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a boarding application in an organization. This endpoint requires an application API token.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.AddApplicationAsync(
    ///     new ApplicationDataPayIn
    ///     {
    ///         Services = new ApplicationDataPayInServices
    ///         {
    ///             Ach = new ApplicationDataPayInServicesAch(),
    ///             Card = new ApplicationDataPayInServicesCard
    ///             {
    ///                 AcceptAmex = true,
    ///                 AcceptDiscover = true,
    ///                 AcceptMastercard = true,
    ///                 AcceptVisa = true,
    ///             },
    ///         },
    ///         AnnualRevenue = 1000,
    ///         AverageBillSize = "500",
    ///         AverageMonthlyBill = "5650",
    ///         Avgmonthly = 1000,
    ///         Baddress = "123 Walnut Street",
    ///         Baddress1 = "Suite 103",
    ///         BankData = new ApplicationDataPayInBankData(),
    ///         Bcity = "New Vegas",
    ///         Bcountry = "US",
    ///         Binperson = 60,
    ///         Binphone = 20,
    ///         Binweb = 20,
    ///         Bstate = "FL",
    ///         Bsummary = "Brick and mortar store that sells office supplies",
    ///         Btype = OwnType.LimitedLiabilityCompany,
    ///         Bzip = "33000",
    ///         Contacts = new List&lt;ApplicationDataPayInContactsItem&gt;()
    ///         {
    ///             new ApplicationDataPayInContactsItem
    ///             {
    ///                 ContactEmail = "herman@hermanscoatings.com",
    ///                 ContactName = "Herman Martinez",
    ///                 ContactPhone = "3055550000",
    ///                 ContactTitle = "Owner",
    ///             },
    ///         },
    ///         CreditLimit = "creditLimit",
    ///         DbaName = "Sunshine Gutters",
    ///         Ein = "123456789",
    ///         Faxnumber = "1234567890",
    ///         Highticketamt = 1000,
    ///         LegalName = "Sunshine Services, LLC",
    ///         License = "2222222FFG",
    ///         Licstate = "CA",
    ///         Maddress = "123 Walnut Street",
    ///         Maddress1 = "STE 900",
    ///         Mcc = "7777",
    ///         Mcity = "Johnson City",
    ///         Mcountry = "US",
    ///         Mstate = "TN",
    ///         Mzip = "37615",
    ///         OrgId = 123,
    ///         Ownership = new List&lt;ApplicationDataPayInOwnershipItem&gt;()
    ///         {
    ///             new ApplicationDataPayInOwnershipItem
    ///             {
    ///                 Oaddress = "33 North St",
    ///                 Ocity = "Any City",
    ///                 Ocountry = "US",
    ///                 Odriverstate = "CA",
    ///                 Ostate = "CA",
    ///                 Ownerdob = "01/01/1990",
    ///                 Ownerdriver = "CA6677778",
    ///                 Owneremail = "test@email.com",
    ///                 Ownername = "John Smith",
    ///                 Ownerpercent = 100,
    ///                 Ownerphone1 = "555888111",
    ///                 Ownerphone2 = "555888111",
    ///                 Ownerssn = "123456789",
    ///                 Ownertitle = "CEO",
    ///                 Ozip = "55555",
    ///             },
    ///         },
    ///         Phonenumber = "1234567890",
    ///         ProcessingRegion = "US",
    ///         RecipientEmail = "josephray@example.com",
    ///         RecipientEmailNotification = true,
    ///         Resumable = true,
    ///         Signer = new SignerDataRequest
    ///         {
    ///             Address = "33 North St",
    ///             Address1 = "STE 900",
    ///             City = "Bristol",
    ///             Country = "US",
    ///             Dob = "01/01/1976",
    ///             Email = "test@email.com",
    ///             Name = "John Smith",
    ///             Phone = "555888111",
    ///             Ssn = "123456789",
    ///             State = "TN",
    ///             Zip = "55555",
    ///             PciAttestation = true,
    ///             SignedDocumentReference = "https://example.com/signed-document.pdf",
    ///             AttestationDate = "04/20/2025",
    ///             SignDate = "04/20/2025",
    ///             AdditionalData =
    ///                 "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
    ///         },
    ///         Startdate = "01/01/1990",
    ///         TaxFillName = "Sunshine LLC",
    ///         TemplateId = 22,
    ///         Ticketamt = 1000,
    ///         Website = "www.example.com",
    ///         WhenCharged = Whencharged.WhenServiceProvided,
    ///         WhenDelivered = Whendelivered.Over30Days,
    ///         WhenProvided = Whenprovided.ThirtyDaysOrLess,
    ///         WhenRefunded = Whenrefunded.ThirtyDaysOrLess,
    ///     }
    /// );
    /// </code></example>
    public async Task<PayabliApiResponse00Responsedatanonobject> AddApplicationAsync(
        OneOf<
            ApplicationDataPayIn,
            ApplicationDataManaged,
            ApplicationDataOdp,
            ApplicationData
        > request,
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
                    Path = "Boarding/app",
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
                return JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(
                    responseBody
                )!;
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
    /// Deletes a boarding application by ID.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.DeleteApplicationAsync(352);
    /// </code></example>
    public async Task<PayabliApiResponse00Responsedatanonobject> DeleteApplicationAsync(
        int appId,
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
                        "Boarding/app/{0}",
                        ValueConvert.ToPathParameterString(appId)
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
                return JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(
                    responseBody
                )!;
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
    /// Retrieves the details for a boarding application by ID.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetApplicationAsync(352);
    /// </code></example>
    public async Task<ApplicationDetailsRecord> GetApplicationAsync(
        int appId,
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
                        "Boarding/read/{0}",
                        ValueConvert.ToPathParameterString(appId)
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
                return JsonUtils.Deserialize<ApplicationDetailsRecord>(responseBody)!;
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
    /// Gets a boarding application by authentication information. This endpoint requires an `application` API token.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetApplicationByAuthAsync(
    ///     "17E",
    ///     new RequestAppByAuth { Email = "admin@email.com", ReferenceId = "n6UCd1f1ygG7" }
    /// );
    /// </code></example>
    public async Task<ApplicationQueryRecord> GetApplicationByAuthAsync(
        string xId,
        RequestAppByAuth request,
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
                        "Boarding/read/{0}",
                        ValueConvert.ToPathParameterString(xId)
                    ),
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
                return JsonUtils.Deserialize<ApplicationQueryRecord>(responseBody)!;
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
    /// Retrieves details for a boarding link, by ID.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetByIdLinkApplicationAsync(91);
    /// </code></example>
    public async Task<BoardingLinkQueryRecord> GetByIdLinkApplicationAsync(
        int boardingLinkId,
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
                        "Boarding/linkbyId/{0}",
                        ValueConvert.ToPathParameterString(boardingLinkId)
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
                return JsonUtils.Deserialize<BoardingLinkQueryRecord>(responseBody)!;
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
    /// Get details for a boarding link using the boarding template ID. This endpoint requires an application API token.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetByTemplateIdLinkApplicationAsync(80);
    /// </code></example>
    public async Task<BoardingLinkQueryRecord> GetByTemplateIdLinkApplicationAsync(
        double templateId,
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
                        "Boarding/linkbyTemplate/{0}",
                        ValueConvert.ToPathParameterString(templateId)
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
                return JsonUtils.Deserialize<BoardingLinkQueryRecord>(responseBody)!;
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
    /// Retrieves a link and the verification code used to log into an existing boarding application. You can also use this endpoint to send a link and referenceId for an existing boarding application to an email address. The recipient can use the referenceId and email address to access and edit the application.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetExternalApplicationAsync(
    ///     352,
    ///     "mail2",
    ///     new GetExternalApplicationRequest()
    /// );
    /// </code></example>
    public async Task<PayabliApiResponse00> GetExternalApplicationAsync(
        int appId,
        string mail2,
        GetExternalApplicationRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
        if (request.SendEmail != null)
        {
            _query["sendEmail"] = JsonUtils.Serialize(request.SendEmail.Value);
        }
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "Boarding/applink/{0}/{1}",
                        ValueConvert.ToPathParameterString(appId),
                        ValueConvert.ToPathParameterString(mail2)
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
                return JsonUtils.Deserialize<PayabliApiResponse00>(responseBody)!;
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
    /// Retrieves the details for a boarding link, by reference name. This endpoint requires an application API token.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.GetLinkApplicationAsync("myorgaccountname-00091");
    /// </code></example>
    public async Task<BoardingLinkQueryRecord> GetLinkApplicationAsync(
        string boardingLinkReference,
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
                        "Boarding/link/{0}",
                        ValueConvert.ToPathParameterString(boardingLinkReference)
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
                return JsonUtils.Deserialize<BoardingLinkQueryRecord>(responseBody)!;
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
    /// Returns a list of boarding applications for an organization. Use filters to limit results. Include the `exportFormat` query parameter to return the results as a file instead of a JSON response.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.ListApplicationsAsync(
    ///     123,
    ///     new ListApplicationsRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBoardingAppsListResponse> ListApplicationsAsync(
        int orgId,
        ListApplicationsRequest request,
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
                        "Query/boarding/{0}",
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
                return JsonUtils.Deserialize<QueryBoardingAppsListResponse>(responseBody)!;
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
    /// Return a list of boarding links for an organization. Use filters to limit results.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.ListBoardingLinksAsync(
    ///     123,
    ///     new ListBoardingLinksRequest
    ///     {
    ///         FromRecord = 251,
    ///         LimitRecord = 0,
    ///         SortBy = "desc(field_name)",
    ///     }
    /// );
    /// </code></example>
    public async Task<QueryBoardingLinksResponse> ListBoardingLinksAsync(
        int orgId,
        ListBoardingLinksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var _query = new Dictionary<string, object>();
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
                        "Query/boardinglinks/{0}",
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
                return JsonUtils.Deserialize<QueryBoardingLinksResponse>(responseBody)!;
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
    /// Updates a boarding application by ID. This endpoint requires an application API token.
    /// </summary>
    /// <example><code>
    /// await client.Boarding.UpdateApplicationAsync(352, new ApplicationData());
    /// </code></example>
    public async Task<PayabliApiResponse00Responsedatanonobject> UpdateApplicationAsync(
        int appId,
        ApplicationData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        var response = await _client
            .SendRequestAsync(
                new JsonRequest
                {
                    BaseUrl = _client.Options.BaseUrl,
                    Method = HttpMethod.Put,
                    Path = string.Format(
                        "Boarding/app/{0}",
                        ValueConvert.ToPathParameterString(appId)
                    ),
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
                return JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(
                    responseBody
                )!;
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
