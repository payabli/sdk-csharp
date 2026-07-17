using PayabliApi.Core;

namespace PayabliApi;

public partial class PayabliApiClient : IPayabliApiClient
{
    private readonly RawClient _client;

    public PayabliApiClient(string apiKey, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "PayabliApi" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Payabli.SDK/1.0.9" },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "requestToken", apiKey } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Bill = new BillClient(_client);
        Customer = new CustomerClient(_client);
        CheckCapture = new CheckCaptureClient(_client);
        MoneyIn = new MoneyInClient(_client);
        Token = new TokenClient(_client);
        Subscription = new SubscriptionClient(_client);
        Invoice = new InvoiceClient(_client);
        PaymentLink = new PaymentLinkClient(_client);
        TokenStorage = new TokenStorageClient(_client);
        Paypoint = new PaypointClient(_client);
        HostedPaymentPages = new HostedPaymentPagesClient(_client);
        PaymentMethodDomain = new PaymentMethodDomainClient(_client);
        Import = new ImportClient(_client);
        Query = new QueryClient(_client);
        Ocr = new OcrClient(_client);
        Notificationlogs = new NotificationlogsClient(_client);
        Cloud = new CloudClient(_client);
        LineItem = new LineItemClient(_client);
        Boarding = new BoardingClient(_client);
        Templates = new TemplatesClient(_client);
        Export = new ExportClient(_client);
        Organization = new OrganizationClient(_client);
        Management = new ManagementClient(_client);
        Statistic = new StatisticClient(_client);
        Notification = new NotificationClient(_client);
        User = new UserClient(_client);
        Vendor = new VendorClient(_client);
        GhostCard = new GhostCardClient(_client);
        MoneyOut = new MoneyOutClient(_client);
        Funding = new FundingClient(_client);
        Wallet = new WalletClient(_client);
        PayoutSubscription = new PayoutSubscriptionClient(_client);
        ChargeBacks = new ChargeBacksClient(_client);
    }

    public IBillClient Bill { get; }

    public ICustomerClient Customer { get; }

    public ICheckCaptureClient CheckCapture { get; }

    public IMoneyInClient MoneyIn { get; }

    public ITokenClient Token { get; }

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
