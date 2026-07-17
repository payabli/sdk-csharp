using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.User;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                    .WithPath("/User/resendmfa/usrname/8cfec329267/1")
                    .UsingPost()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.User.ResendMfaCodeAsync("usrname", "8cfec329267", 1);
        JsonAssert.AreEqual(response, mockResponse);
    }
}
