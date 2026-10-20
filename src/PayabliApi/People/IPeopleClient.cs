namespace PayabliApi;

public partial interface IPeopleClient
{
    /// <summary>
    /// Lists people with optional filtering and pagination.
    /// </summary>
    WithRawResponseTask<ListPeopleEnvelope> ListPeopleAsync(
        ListPeoplePeopleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a person, an individual associated with a business such as an
    /// owner, director, or signer. Include a `businessRelationship` object to
    /// link the person to a business on create; the business reference, role
    /// (`personType`), and `ownershipPercentage` go inside that object.
    ///
    /// A person's job `title` and whether they're the signer (`isSigner`) also
    /// belong to the business link, so send them inside `businessRelationship`.
    /// A top-level `title` returns a `400` with the message
    /// `title moved into the businessRelationship object; send them there instead of at the top level.`
    /// </summary>
    WithRawResponseTask<PersonDetailEnvelope> CreatePersonAsync(
        CreatePersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a person by reference. Sensitive fields such as `ssn` are masked.
    /// </summary>
    WithRawResponseTask<PersonDetailEnvelope> GetPersonAsync(
        string personReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Applies a partial update to a person. Send only the fields you want to change.
    ///
    /// A person's job title belongs to their business link, not the person. Sending `title` in any form, including `null`, returns a `400` with the message `title moved to the business relationship; update it with PATCH /api/v2/businesses/{businessReference}/people/{personReference}.`
    /// </summary>
    WithRawResponseTask<PersonUpdatedEnvelope> UpdatePersonAsync(
        string personReference,
        UpdatePersonRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a person by reference with sensitive fields unmasked.
    /// </summary>
    WithRawResponseTask<PersonDetailEnvelope> GetPersonUnmaskedAsync(
        string personReference,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for people by identity attributes during boarding. The search
    /// covers every business in your organization, so use it to find a person
    /// before you create them again. To read the people already on a
    /// paypoint's business, use a standard `GET` instead.
    /// Provide at least one of `firstName` or `lastName`. Each result has a
    /// `matchScore` showing how closely it matches, and an external identity
    /// vendor can enrich the results. Each result's `dateOfBirth` is masked.
    /// To get the full value, use the unmasked search.
    /// </summary>
    WithRawResponseTask<PeopleSearchEnvelope> SearchPeopleAsync(
        SearchPeopleRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Searches for people by identity attributes during boarding, and returns
    /// each result's `dateOfBirth` unmasked. The query parameters, request
    /// body, and other response fields match the standard people search.
    /// Provide at least one of `firstName` or `lastName`.
    /// </summary>
    WithRawResponseTask<PeopleSearchEnvelope> SearchPeopleUnmaskedAsync(
        SearchPeopleUnmaskedRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
