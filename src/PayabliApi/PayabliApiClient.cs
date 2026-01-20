using PayabliApi.Core;

namespace PayabliApi;

public partial class PayabliApiClient
{
    private readonly RawClient _client;

    public PayabliApiClient(string apiKey, ClientOptions? clientOptions = null)
    {
        var defaultHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "requestToken", apiKey },
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "PayabliApi" },
                { "X-Fern-SDK-Version", Version.Current },
                { "User-Agent", "Payabli.SDK/0.0.293" },
            }
        );
        clientOptions ??= new ClientOptions();
        foreach (var header in defaultHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        _client = new RawClient(clientOptions);
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

    public BillClient Bill { get; }

    public BoardingClient Boarding { get; }

    public ChargeBacksClient ChargeBacks { get; }

    public CheckCaptureClient CheckCapture { get; }

    public CloudClient Cloud { get; }

    public CustomerClient Customer { get; }

    public ExportClient Export { get; }

    public HostedPaymentPagesClient HostedPaymentPages { get; }

    public ImportClient Import { get; }

    public InvoiceClient Invoice { get; }

    public LineItemClient LineItem { get; }

    public MoneyInClient MoneyIn { get; }

    public MoneyOutClient MoneyOut { get; }

    public NotificationClient Notification { get; }

    public NotificationlogsClient Notificationlogs { get; }

    public OcrClient Ocr { get; }

    public OrganizationClient Organization { get; }

    public PaymentLinkClient PaymentLink { get; }

    public PaymentMethodDomainClient PaymentMethodDomain { get; }

    public PaypointClient Paypoint { get; }

    public QueryClient Query { get; }

    public StatisticClient Statistic { get; }

    public SubscriptionClient Subscription { get; }

    public TemplatesClient Templates { get; }

    public TokenStorageClient TokenStorage { get; }

    public UserClient User { get; }

    public VendorClient Vendor { get; }

    public WalletClient Wallet { get; }
}
