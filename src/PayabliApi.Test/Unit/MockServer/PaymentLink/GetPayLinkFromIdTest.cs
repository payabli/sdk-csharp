using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
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
                "Credentials": [
                  {}
                ],
                "LastAccess": "2022-06-30T15:01:00.000Z",
                "PageContent": {
                  "amount": {
                    "enabled": true
                  },
                  "autopay": {
                    "enabled": true
                  },
                  "contactUs": {
                    "enabled": true
                  },
                  "entry": "8cfec329267",
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
                "PageSettings": {
                  "color": "color",
                  "customCssUrl": "customCssUrl",
                  "language": "language",
                  "redirectAfterApprove": true,
                  "redirectAfterApproveUrl": "redirectAfterApproveUrl"
                },
                "published": 1,
                "ReceiptContent": {
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
                "Subdomain": "mypage-1",
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
                    .WithPath("/PaymentLink/load/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.GetPayLinkFromIdAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234"
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
