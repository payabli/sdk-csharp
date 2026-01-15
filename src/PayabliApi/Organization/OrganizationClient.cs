using System.Text.Json;
using PayabliApi.Core;

namespace PayabliApi;

public partial class OrganizationClient
{
    private RawClient _client;

    internal OrganizationClient(RawClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates an organization under a parent organization. This is also referred to as a suborganization.
    /// </summary>
    /// <example><code>
    /// await client.Organization.AddOrganizationAsync(
    ///     new AddOrganizationRequest
    ///     {
    ///         IdempotencyKey = "6B29FC40-CA47-1067-B31D-00DD010662DA",
    ///         BillingInfo = new Instrument
    ///         {
    ///             AchAccount = "123123123",
    ///             AchRouting = "123123123",
    ///             BillingAddress = "123 Walnut Street",
    ///             BillingCity = "Johnson City",
    ///             BillingCountry = "US",
    ///             BillingState = "TN",
    ///             BillingZip = "37615",
    ///         },
    ///         Contacts = new List&lt;Contacts&gt;()
    ///         {
    ///             new Contacts
    ///             {
    ///                 ContactEmail = "herman@hermanscoatings.com",
    ///                 ContactName = "Herman Martinez",
    ///                 ContactPhone = "3055550000",
    ///                 ContactTitle = "Owner",
    ///             },
    ///         },
    ///         HasBilling = true,
    ///         HasResidual = true,
    ///         OrgAddress = "123 Walnut Street",
    ///         OrgCity = "Johnson City",
    ///         OrgCountry = "US",
    ///         OrgEntryName = "pilgrim-planner",
    ///         OrgId = "123",
    ///         OrgLogo = new FileContent
    ///         {
    ///             FContent = "TXkgdGVzdCBmaWxlHJ==...",
    ///             Filename = "my-doc.pdf",
    ///             Ftype = FileContentFtype.Pdf,
    ///             Furl = "https://mysite.com/my-doc.pdf",
    ///         },
    ///         OrgName = "Pilgrim Planner",
    ///         OrgParentId = 236,
    ///         OrgState = "TN",
    ///         OrgTimezone = -5,
    ///         OrgType = 0,
    ///         OrgWebsite = "www.pilgrimageplanner.com",
    ///         OrgZip = "37615",
    ///         ReplyToEmail = "email@example.com",
    ///     }
    /// );
    /// </code></example>
    public async Task<AddOrganizationResponse> AddOrganizationAsync(
        AddOrganizationRequest request,
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
                    Path = "Organization",
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
                return JsonUtils.Deserialize<AddOrganizationResponse>(responseBody)!;
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
    /// Delete an organization by ID.
    /// </summary>
    /// <example><code>
    /// await client.Organization.DeleteOrganizationAsync(123);
    /// </code></example>
    public async Task<DeleteOrganizationResponse> DeleteOrganizationAsync(
        int orgId,
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
                        "Organization/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<DeleteOrganizationResponse>(responseBody)!;
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
    /// Updates an organization's details by ID.
    /// </summary>
    /// <example><code>
    /// await client.Organization.EditOrganizationAsync(
    ///     123,
    ///     new OrganizationData
    ///     {
    ///         Contacts = new List&lt;Contacts&gt;()
    ///         {
    ///             new Contacts
    ///             {
    ///                 ContactEmail = "herman@hermanscoatings.com",
    ///                 ContactName = "Herman Martinez",
    ///                 ContactPhone = "3055550000",
    ///                 ContactTitle = "Owner",
    ///             },
    ///         },
    ///         OrgAddress = "123 Walnut Street",
    ///         OrgCity = "Johnson City",
    ///         OrgCountry = "US",
    ///         OrgEntryName = "pilgrim-planner",
    ///         OrganizationDataOrgId = "123",
    ///         OrgName = "Pilgrim Planner",
    ///         OrgState = "TN",
    ///         OrgTimezone = -5,
    ///         OrgType = 0,
    ///         OrgWebsite = "www.pilgrimageplanner.com",
    ///         OrgZip = "37615",
    ///     }
    /// );
    /// </code></example>
    public async Task<EditOrganizationResponse> EditOrganizationAsync(
        int orgId,
        OrganizationData request,
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
                        "Organization/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<EditOrganizationResponse>(responseBody)!;
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
    /// Gets an organization's basic information by entry name (entrypoint identifier).
    /// </summary>
    /// <example><code>
    /// await client.Organization.GetBasicOrganizationAsync("8cfec329267");
    /// </code></example>
    public async Task<OrganizationQueryRecord> GetBasicOrganizationAsync(
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
                        "Organization/basic/{0}",
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
                return JsonUtils.Deserialize<OrganizationQueryRecord>(responseBody)!;
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
    /// Gets an organizations basic details by org ID.
    /// </summary>
    /// <example><code>
    /// await client.Organization.GetBasicOrganizationByIdAsync(123);
    /// </code></example>
    public async Task<OrganizationQueryRecord> GetBasicOrganizationByIdAsync(
        int orgId,
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
                        "Organization/basicById/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<OrganizationQueryRecord>(responseBody)!;
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
    /// Retrieves details for an organization by ID.
    /// </summary>
    /// <example><code>
    /// await client.Organization.GetOrganizationAsync(123);
    /// </code></example>
    public async Task<OrganizationQueryRecord> GetOrganizationAsync(
        int orgId,
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
                        "Organization/read/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<OrganizationQueryRecord>(responseBody)!;
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
    /// Retrieves an organization's settings.
    /// </summary>
    /// <example><code>
    /// await client.Organization.GetSettingsOrganizationAsync(123);
    /// </code></example>
    public async Task<SettingsQueryRecord> GetSettingsOrganizationAsync(
        int orgId,
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
                        "Organization/settings/{0}",
                        ValueConvert.ToPathParameterString(orgId)
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
                return JsonUtils.Deserialize<SettingsQueryRecord>(responseBody)!;
            }
            catch (JsonException e)
            {
                throw new PayabliApiException("Failed to deserialize response", e);
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
}
