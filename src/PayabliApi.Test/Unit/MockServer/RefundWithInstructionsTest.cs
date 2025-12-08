using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class RefundWithInstructionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "source": "api",
              "orderDescription": "Materials deposit",
              "amount": 100,
              "refundDetails": {
                "splitRefunding": [
                  {
                    "originationEntryPoint": "7f1a381696",
                    "accountId": "187-342",
                    "description": "Refunding undelivered materials",
                    "amount": 60
                  },
                  {
                    "originationEntryPoint": "7f1a381696",
                    "accountId": "187-343",
                    "description": "Refunding deposit for undelivered materials",
                    "amount": 40
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "authCode": "",
                "referenceId": "288-a1192b75-99e9-4d43-8af1-7ae9ab7da4f4",
                "resultCode": 1,
                "resultText": "CAPTURED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              },
              "pageidentifier": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/refund/10-3ffa27df-b171-44e0-b251-e95fbfc7a723")
                    .WithHeader("idempotencyKey", "8A29FC40-CA47-1067-B31D-00DD010662DB")
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

        var response = await Client.MoneyIn.RefundWithInstructionsAsync(
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
            new RequestRefund
            {
                IdempotencyKey = "8A29FC40-CA47-1067-B31D-00DD010662DB",
                Source = "api",
                OrderDescription = "Materials deposit",
                Amount = 100,
                RefundDetails = new RefundDetail
                {
                    SplitRefunding = new List<SplitFundingRefundContent>()
                    {
                        new SplitFundingRefundContent
                        {
                            OriginationEntryPoint = "7f1a381696",
                            AccountId = "187-342",
                            Description = "Refunding undelivered materials",
                            Amount = 60,
                        },
                        new SplitFundingRefundContent
                        {
                            OriginationEntryPoint = "7f1a381696",
                            AccountId = "187-343",
                            Description = "Refunding deposit for undelivered materials",
                            Amount = 40,
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RefundWithInstructionsResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "source": "api",
              "orderDescription": "Materials deposit",
              "amount": 70,
              "refundDetails": {
                "splitRefunding": [
                  {
                    "originationEntryPoint": "7f1a381696",
                    "accountId": "187-342",
                    "description": "Refunding undelivered materials",
                    "amount": 40
                  },
                  {
                    "originationEntryPoint": "7f1a381696",
                    "accountId": "187-343",
                    "description": "Refunding deposit for undelivered materials",
                    "amount": 30
                  }
                ]
              }
            }
            """;

        const string mockResponse = """
            {
              "responseText": "Success",
              "isSuccess": true,
              "responseData": {
                "authCode": "",
                "referenceId": "288-a1192b75-99e9-4d43-8af1-7ae9ab7da4f4",
                "resultCode": 1,
                "resultText": "CAPTURED",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": null,
                "methodReferenceId": null
              },
              "pageidentifier": null
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/refund/10-3ffa27df-b171-44e0-b251-e95fbfc7a723")
                    .WithHeader("idempotencyKey", "8A29FC40-CA47-1067-B31D-00DD010662DB")
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

        var response = await Client.MoneyIn.RefundWithInstructionsAsync(
            "10-3ffa27df-b171-44e0-b251-e95fbfc7a723",
            new RequestRefund
            {
                IdempotencyKey = "8A29FC40-CA47-1067-B31D-00DD010662DB",
                Source = "api",
                OrderDescription = "Materials deposit",
                Amount = 70,
                RefundDetails = new RefundDetail
                {
                    SplitRefunding = new List<SplitFundingRefundContent>()
                    {
                        new SplitFundingRefundContent
                        {
                            OriginationEntryPoint = "7f1a381696",
                            AccountId = "187-342",
                            Description = "Refunding undelivered materials",
                            Amount = 40,
                        },
                        new SplitFundingRefundContent
                        {
                            OriginationEntryPoint = "7f1a381696",
                            AccountId = "187-343",
                            Description = "Refunding deposit for undelivered materials",
                            Amount = 30,
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<RefundWithInstructionsResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
