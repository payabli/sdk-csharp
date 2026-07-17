using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.PaymentLink;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdatePayLinkOutFromIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "contactUs": {
                "emailLabel": "Email",
                "enabled": true,
                "header": "Contact Us",
                "order": 0,
                "paymentIcons": true,
                "phoneLabel": "Phone"
              },
              "logo": {
                "enabled": true,
                "order": 0
              },
              "messageBeforePaying": {
                "enabled": true,
                "label": "Please review your payment details",
                "order": 0
              },
              "notes": {
                "enabled": true,
                "header": "Additional Notes",
                "order": 0,
                "placeholder": "Enter any additional notes here",
                "value": ""
              },
              "page": {
                "description": "Get paid securely",
                "enabled": true,
                "header": "Payment Page",
                "order": 0
              },
              "paymentButton": {
                "enabled": true,
                "label": "Pay Now",
                "order": 0
              },
              "paymentMethods": {
                "allMethodsChecked": true,
                "allowMultipleMethods": true,
                "defaultMethod": "vcard",
                "enabled": true,
                "header": "Payment Methods",
                "methods": {
                  "ach": true,
                  "check": true,
                  "vcard": true
                },
                "order": 0,
                "showPreviewVirtualCard": true
              },
              "review": {
                "enabled": true,
                "header": "Review Payment",
                "order": 0
              },
              "settings": {
                "color": "#000000",
                "language": "en"
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
                    .WithPath(
                        "/PaymentLink/updateOut/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234"
                    )
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.UpdatePayLinkOutFromIdAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PaymentPageRequestBodyOut
            {
                ContactUs = new ContactElement
                {
                    EmailLabel = "Email",
                    Enabled = true,
                    Header = "Contact Us",
                    Order = 0,
                    PaymentIcons = true,
                    PhoneLabel = "Phone",
                },
                Logo = new Element { Enabled = true, Order = 0 },
                MessageBeforePaying = new LabelElement
                {
                    Enabled = true,
                    Label = "Please review your payment details",
                    Order = 0,
                },
                Notes = new NoteElement
                {
                    Enabled = true,
                    Header = "Additional Notes",
                    Order = 0,
                    Placeholder = "Enter any additional notes here",
                    Value = "",
                },
                Page = new PageElement
                {
                    Description = "Get paid securely",
                    Enabled = true,
                    Header = "Payment Page",
                    Order = 0,
                },
                PaymentButton = new LabelElement
                {
                    Enabled = true,
                    Label = "Pay Now",
                    Order = 0,
                },
                PaymentMethods = new MethodElementOut
                {
                    AllMethodsChecked = true,
                    AllowMultipleMethods = true,
                    DefaultMethod = "vcard",
                    Enabled = true,
                    Header = "Payment Methods",
                    Methods = new MethodsListOut
                    {
                        Ach = true,
                        Check = true,
                        Vcard = true,
                    },
                    Order = 0,
                    ShowPreviewVirtualCard = true,
                },
                Review = new HeaderElement
                {
                    Enabled = true,
                    Header = "Review Payment",
                    Order = 0,
                },
                Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "paymentMethods": {
                "allMethodsChecked": false,
                "allowMultipleMethods": true,
                "defaultMethod": "vcard",
                "enabled": true,
                "header": "Payment Methods",
                "methods": {
                  "ach": true,
                  "check": false,
                  "vcard": true
                },
                "order": 0,
                "showPreviewVirtualCard": true
              },
              "paymentButton": {
                "enabled": true,
                "label": "Choose Payment Method",
                "order": 0
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
                    .WithPath(
                        "/PaymentLink/updateOut/2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234"
                    )
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.PaymentLink.UpdatePayLinkOutFromIdAsync(
            "2325-XXXXXXX-90b1-4598-b6c7-44cdcbf495d7-1234",
            new PaymentPageRequestBodyOut
            {
                PaymentMethods = new MethodElementOut
                {
                    AllMethodsChecked = false,
                    AllowMultipleMethods = true,
                    DefaultMethod = "vcard",
                    Enabled = true,
                    Header = "Payment Methods",
                    Methods = new MethodsListOut
                    {
                        Ach = true,
                        Check = false,
                        Vcard = true,
                    },
                    Order = 0,
                    ShowPreviewVirtualCard = true,
                },
                PaymentButton = new LabelElement
                {
                    Enabled = true,
                    Label = "Choose Payment Method",
                    Order = 0,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
