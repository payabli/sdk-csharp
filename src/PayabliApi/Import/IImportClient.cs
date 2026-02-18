namespace PayabliApi;

public partial interface IImportClient
{
    /// <summary>
    /// Import a list of bills from a CSV file. See the [Import Guide](/developers/developer-guides/bills-add#import-bills) for more help and an example file.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseImport> ImportBillsAsync(
        string entry,
        ImportBillsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Import a list of customers from a CSV file. See the [Import Guide](/developers/developer-guides/entities-customers#import-customers) for more help and example files.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseImport> ImportCustomerAsync(
        string entry,
        ImportCustomerRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Import a list of vendors from a CSV file. See the [Import Guide](/developers/developer-guides/entities-vendors#import-vendors) for more help and example files.
    /// </summary>
    WithRawResponseTask<PayabliApiResponseImport> ImportVendorAsync(
        string entry,
        ImportVendorRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
