namespace PayabliApi;

public partial interface IUserClient
{
    /// <summary>
    /// Use this endpoint to add a new user to an organization.
    /// </summary>
    WithRawResponseTask<AddUserResponse> AddUserAsync(
        UserData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to refresh the authentication token for a user within an organization.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseUserMfa> AuthRefreshUserAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to initiate a password reset for a user within an organization.
    /// </summary>
    WithRawResponseTask<AuthResetUserResponse> AuthResetUserAsync(
        UserAuthResetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint requires an application API token.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseMfaBasic> AuthUserAsync(
        string provider,
        UserAuthRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to change the password for a user within an organization.
    /// </summary>
    WithRawResponseTask<ChangePswUserResponse> ChangePswUserAsync(
        UserAuthPswResetRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to delete a specific user within an organization.
    /// </summary>
    WithRawResponseTask<DeleteUserResponse> DeleteUserAsync(
        long userId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to enable or disable multi-factor authentication (MFA) for a user within an organization.
    /// </summary>
    WithRawResponseTask<EditMfaUserResponse> EditMfaUserAsync(
        long userId,
        MfaData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to modify the details of a specific user within an organization.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse> EditUserAsync(
        long userId,
        UserData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to retrieve information about a specific user within an organization.
    /// </summary>
    WithRawResponseTask<UserQueryRecord> GetUserAsync(
        long userId,
        GetUserRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to log a user out from the system.
    /// </summary>
    WithRawResponseTask<LogoutUserResponse> LogoutUserAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Resends the MFA code to the user via the selected MFA mode (email or SMS).
    /// </summary>
    WithRawResponseTask<PayabliApiResponseMfaBasic> ResendMfaCodeAsync(
        string usrname,
        string entry,
        int entryType,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Use this endpoint to validate the multi-factor authentication (MFA) code for a user within an organization.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseUserMfa> ValidateMfaUserAsync(
        MfaValidationData request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
