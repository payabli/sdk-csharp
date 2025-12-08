using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetPayLinkFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "AdditionalData": {
                  "key1": {
                    "key": "value"
                  },
                  "key2": {
                    "key": "value"
                  },
                  "key3": {
                    "key": "value"
                  }
                },
                "credentials": [
                  {}
                ],
                "lastAccess": "2022-06-30T15:01:00.000Z",
                "pageContent": {
                  "amount": {
                    "enabled": true
                  },
                  "autopay": {
                    "enabled": true
                  },
                  "contactUs": {
                    "enabled": true
                  },
                  "entry": "entry",
                  "invoices": {
                    "enabled": true
                  },
                  "logo": {
                    "enabled": true
                  },
                  "messageBeforePaying": {
                    "enabled": true
                  },
                  "name": "name",
                  "notes": {
                    "enabled": true
                  },
                  "page": {
                    "enabled": true
                  },
                  "paymentButton": {
                    "enabled": true
                  },
                  "paymentMethods": {
                    "enabled": true
                  },
                  "payor": {
                    "enabled": true
                  },
                  "review": {
                    "enabled": true
                  },
                  "subdomain": "mypage-1"
                },
                "pageIdentifier": "null",
                "pageSettings": {
                  "color": "color",
                  "customCssUrl": "customCssUrl",
                  "language": "language",
                  "redirectAfterApprove": true,
                  "redirectAfterApproveUrl": "redirectAfterApproveUrl"
                },
                "published": 1,
                "receiptContent": {
                  "amount": {
                    "enabled": true
                  },
                  "contactUs": {
                    "enabled": true
                  },
                  "details": {
                    "enabled": true
                  },
                  "logo": {
                    "enabled": true
                  },
                  "messageBeforeButton": {
                    "enabled": true
                  },
                  "page": {
                    "enabled": true
                  },
                  "paymentButton": {
                    "enabled": true
                  },
                  "paymentInformation": {
                    "enabled": true
                  },
                  "settings": {
                    "enabled": true
                  }
                },
                "subdomain": "mypage-1",
                "totalAmount": 1.1,
                "validationCode": "validationCode"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/load/paylinkId")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.GetPayLinkFromIdAsync("paylinkId");
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<GetPayLinkFromIdResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
