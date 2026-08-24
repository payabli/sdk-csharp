namespace PayabliApi;

public partial interface IDeviceClient
{
    /// <summary>
    /// Generates a one-time, 6-digit verification code for activating a
    /// semi-integrated card-present device in a paypoint. After calling this endpoint, an operator enters the returned code
    /// on the device's terminal, along with a device name, to register the
    /// device to the paypoint resolved from `{entry}`.
    ///
    /// A code expires 5 minutes after it's issued. A paypoint can have several
    /// codes active at once — for example, when activating a batch of devices —
    /// and a code binds to whichever device enters it first.
    ///
    /// Authenticate with an OAuth2 Bearer token that has the `device_registry` scope.
    /// </summary>
    WithRawResponseTask<DeviceChallengeResponse> ChallengeAsync(
        string entry,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
