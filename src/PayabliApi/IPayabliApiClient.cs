namespace PayabliApi;

public partial interface IPayabliApiClient
{
    public IBillClient Bill { get; }
    public IBoardingClient Boarding { get; }
    public IChargeBacksClient ChargeBacks { get; }
    public ICheckCaptureClient CheckCapture { get; }
    public ICloudClient Cloud { get; }
    public ICustomerClient Customer { get; }
    public IExportClient Export { get; }
    public IHostedPaymentPagesClient HostedPaymentPages { get; }
    public IImportClient Import { get; }
    public IInvoiceClient Invoice { get; }
    public ILineItemClient LineItem { get; }
    public IMoneyInClient MoneyIn { get; }
    public IMoneyOutClient MoneyOut { get; }
    public INotificationClient Notification { get; }
    public INotificationlogsClient Notificationlogs { get; }
    public IOcrClient Ocr { get; }
    public IOrganizationClient Organization { get; }
    public IPaymentLinkClient PaymentLink { get; }
    public IPaymentMethodDomainClient PaymentMethodDomain { get; }
    public IPaypointClient Paypoint { get; }
    public IQueryClient Query { get; }
    public IStatisticClient Statistic { get; }
    public ISubscriptionClient Subscription { get; }
    public ITemplatesClient Templates { get; }
    public ITokenStorageClient TokenStorage { get; }
    public IUserClient User { get; }
    public IVendorClient Vendor { get; }
    public IWalletClient Wallet { get; }
}
