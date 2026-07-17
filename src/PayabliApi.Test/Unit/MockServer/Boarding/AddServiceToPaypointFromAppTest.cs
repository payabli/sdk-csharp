using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Boarding;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddServiceToPaypointFromAppTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "paypointId": 3040,
              "templateId": 456,
              "recipientEmail": "merchant@example.com",
              "returnBoardingAccessInfoInLine": true,
              "onCreate": [
                "submitApplication"
              ]
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 66594,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "appId": 66594,
                "boardingLink": "https://boarding-sandbox.payabli.com/boarding/externalapp/load/10422?mode=25&email=merchant@example.com&referenceId=YpYNRPDOcGsm"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/applications")
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

        var response = await Client.Boarding.AddServiceToPaypointFromAppAsync(
            new CreateApplicationFromPaypointRequest
            {
                PaypointId = 3040,
                TemplateId = 456,
                RecipientEmail = "merchant@example.com",
                ReturnBoardingAccessInfoInLine = true,
                OnCreate = new List<string>() { "submitApplication" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
