using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class PatchOutPaymentLinkTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "expirationDate": "2026-06-01T00:00:00Z",
              "status": "Active"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/out/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.PatchOutPaymentLinkAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PatchOutPaymentLinkRequest
            {
                ExpirationDate = "2026-06-01T00:00:00Z",
                Status = PaymentLinkStatus.Active,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "status": "Canceled"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/out/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.PatchOutPaymentLinkAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PatchOutPaymentLinkRequest { Status = PaymentLinkStatus.Canceled }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "billPageData": {
                "page": {
                  "description": "You have a payment waiting",
                  "enabled": true,
                  "header": "Vendor Payment",
                  "order": 0
                },
                "paymentButton": {
                  "enabled": true,
                  "label": "Select Payment Method",
                  "order": 0
                },
                "paymentMethods": {
                  "allMethodsChecked": true,
                  "allowMultipleMethods": true,
                  "defaultMethod": "ach",
                  "enabled": true,
                  "header": "Payment Methods",
                  "methods": {
                    "ach": true,
                    "check": true,
                    "vcard": true
                  },
                  "order": 0,
                  "showPreviewVirtualCard": false
                }
              }
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/PaymentLink/out/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.PatchOutPaymentLinkAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PatchOutPaymentLinkRequest
            {
                BillPageData = new PaymentPageRequestBodyOut
                {
                    Page = new PageElement
                    {
                        Description = "You have a payment waiting",
                        Enabled = true,
                        Header = "Vendor Payment",
                        Order = 0,
                    },
                    PaymentButton = new LabelElement
                    {
                        Enabled = true,
                        Label = "Select Payment Method",
                        Order = 0,
                    },
                    PaymentMethods = new MethodElementOut
                    {
                        AllMethodsChecked = true,
                        AllowMultipleMethods = true,
                        DefaultMethod = "ach",
                        Enabled = true,
                        Header = "Payment Methods",
                        Methods = new MethodsListOut
                        {
                            Ach = true,
                            Check = true,
                            Vcard = true,
                        },
                        Order = 0,
                        ShowPreviewVirtualCard = false,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
