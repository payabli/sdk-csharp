using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ReverseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "A0000",
                "referenceId": "255-fb61db4171334aa79224b019f090e4c5",
                "resultCode": 1,
                "resultText": "REVERSED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/reverse/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/0")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.ReverseAsync(
            0,
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ReverseResponse>(mockResponse)).UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": "A0000",
                "referenceId": "255-fb61db4171334aa79224b019f090e4c5",
                "resultCode": 10,
                "resultText": "INITIATED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/reverse/10-3ffa27df-b171-44e0-b251-e95fbfc7a723/53.76")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.ReverseAsync(
            53.76,
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723"
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<ReverseResponse>(mockResponse)).UsingDefaults()
        );
    }
}
