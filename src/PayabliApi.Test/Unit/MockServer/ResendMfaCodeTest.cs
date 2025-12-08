using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ResendMfaCodeTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "mfa": false,
              "mfaMode": "email",
              "mfaValidationCode": "50-2E-4A-16-93-0E-41-41-07-EE-22-B6-00-99-00-99",
              "responseData": "g**.com",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/User/resendmfa/usrname/Entry/1")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.User.ResendMfaCodeAsync("Entry", 1, "usrname");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseMfaBasic>(mockResponse))
                .UsingDefaults()
        );
    }
}
