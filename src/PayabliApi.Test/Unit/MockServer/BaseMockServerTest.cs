using NUnit.Framework;
using PayabliApi;
using WireMock.Logging;
using WireMock.Server;
using WireMock.Settings;

namespace PayabliApi.Test.Unit.MockServer;

public class BaseMockServerTest
{
    protected WireMockServer Server { get; set; } = null!;

    protected PayabliApiClient Client { get; set; } = null!;

    protected RequestOptions RequestOptions { get; set; } = new();

    private void MockOAuthEndpoint()
    {
        const string requestJson = """
            {
              "clientId": "YOUR_CLIENT_ID",
              "clientSecret": "YOUR_CLIENT_SECRET"
            }
            """;

        const string mockResponse = """
            {
              "token_type": "Bearer",
              "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.example.token",
              "expires_in": 3600
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/Token/serverside")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );
    }

    [OneTimeSetUp]
    public void GlobalSetup()
    {
        // Start the WireMock server
        Server = WireMockServer.Start(
            new WireMockServerSettings { Logger = new WireMockConsoleLogger() }
        );

        // Initialize the Client
        Client = new PayabliApiClient(
            "client_id",
            "client_secret",
            "API_KEY",
            clientOptions: new ClientOptions { BaseUrl = Server.Urls[0], MaxRetries = 0 }
        );
        MockOAuthEndpoint();
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        Server.Stop();
        Server.Dispose();
    }
}
