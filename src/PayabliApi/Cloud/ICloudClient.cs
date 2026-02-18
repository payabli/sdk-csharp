namespace PayabliApi;

public partial interface ICloudClient
{
    /// <summary>
    /// Register a cloud device to an entrypoint. See [Devices Quickstart](/developers/developer-guides/devices-quickstart#devices-quickstart) for a complete guide.
    /// </summary>
    WithRawResponseTask<AddDeviceResponse> AddDeviceAsync(
        string entry,
        DeviceEntry request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve the registration history for a device.
    /// </summary>
    WithRawResponseTask<CloudQueryApiResponse> HistoryDeviceAsync(
        string entry,
        string deviceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a list of cloud devices registered to an entrypoint.
    /// </summary>
    WithRawResponseTask<CloudQueryApiResponse> ListDeviceAsync(
        string entry,
        ListDeviceRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a cloud device from an entrypoint.
    /// </summary>
    WithRawResponseTask<RemoveDeviceResponse> RemoveDeviceAsync(
        string entry,
        string deviceId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
