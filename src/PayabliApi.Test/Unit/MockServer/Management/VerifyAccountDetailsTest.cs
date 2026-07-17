using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Management;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VerifyAccountDetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "routingNumber": "122105278",
              "accountNumber": "0000000016",
              "accountType": "Checking",
              "country": "US",
              "accountHolderType": "personal",
              "holderName": "Jane Doe"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "aba": "122105278",
                "accountNumber": "0000000016",
                "isValid": true,
                "verificationResponse": "Pass",
                "responseCode": "2",
                "responseValue": "CA11",
                "responseDescription": "Customer authentication passed gAuthenticate."
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Management/verifyAccountDetails/8cfec329267")
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

        var response = await Client.Management.VerifyAccountDetailsAsync(
            "8cfec329267",
            new VerifyAccountDetailsRequest
            {
                RoutingNumber = "122105278",
                AccountNumber = "0000000016",
                AccountType = "Checking",
                Country = "US",
                AccountHolderType = "personal",
                HolderName = "Jane Doe",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
