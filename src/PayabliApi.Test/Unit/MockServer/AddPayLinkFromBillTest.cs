using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddPayLinkFromBillTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
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
                "enabled": true,
                "header": "Payment Methods",
                "methods": {
                  "amex": true,
                  "applePay": true,
                  "discover": true,
                  "eCheck": true,
                  "mastercard": true,
                  "visa": true
                },
                "order": 0
              },
              "payor": {
                "enabled": true,
                "fields": [
                  {
                    "display": true,
                    "fixed": true,
                    "identifier": true,
                    "label": "Full Name",
                    "name": "fullName",
                    "order": 0,
                    "required": true,
                    "validation": "^[a-zA-Z ]+$",
                    "value": "",
                    "width": 0
                  }
                ],
                "header": "Payor Information",
                "order": 0
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
                    .WithPath("/PaymentLink/bill/23548884")
                    .WithParam("mail2", "jo@example.com; ceo@example.com")
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

        var response = await Client.PaymentLink.AddPayLinkFromBillAsync(
            23548884,
            new PayLinkDataBill
            {
                Mail2 = "jo@example.com; ceo@example.com",
                Body = new PaymentPageRequestBody
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
                    PaymentMethods = new MethodElement
                    {
                        AllMethodsChecked = true,
                        Enabled = true,
                        Header = "Payment Methods",
                        Methods = new MethodsList
                        {
                            Amex = true,
                            ApplePay = true,
                            Discover = true,
                            ECheck = true,
                            Mastercard = true,
                            Visa = true,
                        },
                        Order = 0,
                    },
                    Payor = new PayorElement
                    {
                        Enabled = true,
                        Fields = new List<PayorFields>()
                        {
                            new PayorFields
                            {
                                Display = true,
                                Fixed = true,
                                Identifier = true,
                                Label = "Full Name",
                                Name = "fullName",
                                Order = 0,
                                Required = true,
                                Validation = "^[a-zA-Z ]+$",
                                Value = "",
                                Width = 0,
                            },
                        },
                        Header = "Payor Information",
                        Order = 0,
                    },
                    Review = new HeaderElement
                    {
                        Enabled = true,
                        Header = "Review Payment",
                        Order = 0,
                    },
                    Settings = new PagelinkSetting { Color = "#000000", Language = "en" },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponsePaymentLinks>(mockResponse))
                .UsingDefaults()
        );
    }
}
