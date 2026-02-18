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
                { "User-Agent", "Payabli.SDK/0.0.297" },
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
        Boarding = new BoardingClient(_client);
        ChargeBacks = new ChargeBacksClient(_client);
        CheckCapture = new CheckCaptureClient(_client);
        Cloud = new CloudClient(_client);
        Customer = new CustomerClient(_client);
        Export = new ExportClient(_client);
        HostedPaymentPages = new HostedPaymentPagesClient(_client);
        Import = new ImportClient(_client);
        Invoice = new InvoiceClient(_client);
        LineItem = new LineItemClient(_client);
        MoneyIn = new MoneyInClient(_client);
        MoneyOut = new MoneyOutClient(_client);
        Notification = new NotificationClient(_client);
        Notificationlogs = new NotificationlogsClient(_client);
        Ocr = new OcrClient(_client);
        Organization = new OrganizationClient(_client);
        PaymentLink = new PaymentLinkClient(_client);
        PaymentMethodDomain = new PaymentMethodDomainClient(_client);
        Paypoint = new PaypointClient(_client);
        Query = new QueryClient(_client);
        Statistic = new StatisticClient(_client);
        Subscription = new SubscriptionClient(_client);
        Templates = new TemplatesClient(_client);
        TokenStorage = new TokenStorageClient(_client);
        User = new UserClient(_client);
        Vendor = new VendorClient(_client);
        Wallet = new WalletClient(_client);
    }

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
