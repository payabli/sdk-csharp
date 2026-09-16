namespace PayabliApi;

public partial interface ITaptopayClient
{
    /// <summary>
    /// Issues a short-lived activation code for a Tap to Pay device in the
    /// `Pending` state. This endpoint is for Tap to Pay devices only.
    /// Deliver the code to the device to complete activation.
    ///
    /// A code is valid for 30 minutes after it's issued. Calling this
    /// endpoint again for the same device before the code expires returns
    /// the same code, with `alreadyIssued` set to `true`, instead of
    /// generating a new one. A new code is only generated when no valid
    /// code exists.
    ///
    /// Authenticate with an OAuth2 bearer token that has the `pos_create`
    /// permission. See [Accept Tap to Pay payments](/guides/pay-in-developer-tap-to-pay)
    /// for the full integration guide.
    /// </summary>
    WithRawResponseTask<TapToPayActivationChallengeResponse> ActivationChallengeAsync(
        TapToPayActivationChallengeRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
