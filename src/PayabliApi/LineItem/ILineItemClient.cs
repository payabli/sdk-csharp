namespace PayabliApi;

public partial interface ILineItemClient
{
    /// <summary>
    /// Adds products and services to an entrypoint's catalog. These are used as line items for invoicing and transactions. In the response, "responseData" displays the item's code.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse6> AddItemAsync(
        string entry,
        AddItemRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an item.
    /// </summary>
    WithRawResponseTask<DeleteItemResponse> DeleteItemAsync(
        int lineItemId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Gets an item by ID.
    /// </summary>
    WithRawResponseTask<LineItemQueryRecord> GetItemAsync(
        int lineItemId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of line items and their details from an entrypoint. Line items are also known as items, products, and services. Use filters to limit results.
    /// </summary>
    WithRawResponseTask<QueryResponseItems> ListLineItemsAsync(
        string entry,
        ListLineItemsRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an item.
    /// </summary>
    WithRawResponseTask<PayabliApiResponse6> UpdateItemAsync(
        int lineItemId,
        LineItem request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
