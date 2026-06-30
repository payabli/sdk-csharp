namespace PayabliApi;

public partial interface IPayabliApiClient
{
    public IBillClient Bill { get; }
    public ICustomerClient Customer { get; }
    public ICheckCaptureClient CheckCapture { get; }
    public IMoneyInClient MoneyIn { get; }
    public ISubscriptionClient Subscription { get; }
    public IInvoiceClient Invoice { get; }
    public IPaymentLinkClient PaymentLink { get; }
    public ITokenStorageClient TokenStorage { get; }
    public IPaypointClient Paypoint { get; }
    public IHostedPaymentPagesClient HostedPaymentPages { get; }
    public IPaymentMethodDomainClient PaymentMethodDomain { get; }
    public IImportClient Import { get; }
    public IQueryClient Query { get; }
    public IOcrClient Ocr { get; }
    public INotificationlogsClient Notificationlogs { get; }
    public ICloudClient Cloud { get; }
    public ILineItemClient LineItem { get; }
    public IBoardingClient Boarding { get; }
    public ITemplatesClient Templates { get; }
    public IExportClient Export { get; }
    public IOrganizationClient Organization { get; }
    public IManagementClient Management { get; }
    public IStatisticClient Statistic { get; }
    public INotificationClient Notification { get; }
    public IUserClient User { get; }
    public IVendorClient Vendor { get; }
    public IGhostCardClient GhostCard { get; }
    public IMoneyOutClient MoneyOut { get; }
    public IFundingClient Funding { get; }
    public IWalletClient Wallet { get; }
    public IPayoutSubscriptionClient PayoutSubscription { get; }
    public IChargeBacksClient ChargeBacks { get; }
}
