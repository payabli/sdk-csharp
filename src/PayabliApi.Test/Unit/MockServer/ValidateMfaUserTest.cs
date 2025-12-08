using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ValidateMfaUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {}
            """;

        const string mockResponse = """
            {
              "inactiveTokenTime": 31,
              "isSuccess": true,
              "remaining": 120,
              "responseData": "u.fPLVSzFv1gZpHl......",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/User/mfa")
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

        var response = await Client.User.ValidateMfaUserAsync(new MfaValidationData());
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseUserMfa>(mockResponse))
                .UsingDefaults()
        );
    }
}
