using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Token;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreateServerSideTokenTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
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
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Token.CreateServerSideTokenAsync(
            new CreateServerSideTokenRequest
            {
                ClientId = "YOUR_CLIENT_ID",
                ClientSecret = "YOUR_CLIENT_SECRET",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
