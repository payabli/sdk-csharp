using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AuthorizeOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "entryPoint": "48acde49",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Window Painting",
              "paymentDetails": {
                "totalAmount": 47,
                "unbundled": false
              },
              "paymentMethod": {
                "method": "managed"
              },
              "vendorData": {
                "vendorNumber": "7895433"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": null,
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/authorize")
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

        var response = await Client.MoneyOut.AuthorizeOutAsync(
            new MoneyOutTypesRequestOutAuthorize
            {
                Body = new AuthorizePayoutBody
                {
                    EntryPoint = "48acde49",
                    InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                    {
                        new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                    },
                    OrderDescription = "Window Painting",
                    PaymentDetails = new RequestOutAuthorizePaymentDetails
                    {
                        TotalAmount = 47,
                        Unbundled = false,
                    },
                    PaymentMethod = new AuthorizePaymentMethod { Method = "managed" },
                    VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AuthCapturePayoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "entryPoint": "48acde49",
              "invoiceData": [
                {
                  "billId": 123,
                  "attachments": [
                    {
                      "filename": "bill.pdf",
                      "ftype": "pdf",
                      "furl": "https://example.com/bill.pdf"
                    }
                  ]
                }
              ],
              "orderDescription": "Window Painting",
              "paymentDetails": {
                "totalAmount": 47
              },
              "paymentMethod": {
                "method": "managed"
              },
              "vendorData": {
                "vendorNumber": "7895433"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": null,
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/authorize")
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

        var response = await Client.MoneyOut.AuthorizeOutAsync(
            new MoneyOutTypesRequestOutAuthorize
            {
                Body = new AuthorizePayoutBody
                {
                    EntryPoint = "48acde49",
                    InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                    {
                        new RequestOutAuthorizeInvoiceData
                        {
                            BillId = 123,
                            Attachments = new List<FileContent>()
                            {
                                new FileContent
                                {
                                    Filename = "bill.pdf",
                                    Ftype = FileContentFtype.Pdf,
                                    Furl = "https://example.com/bill.pdf",
                                },
                            },
                        },
                    },
                    OrderDescription = "Window Painting",
                    PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 47 },
                    PaymentMethod = new AuthorizePaymentMethod { Method = "managed" },
                    VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AuthCapturePayoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "entryPoint": "48acde49",
              "source": "api",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Window Painting",
              "paymentMethod": {
                "method": "ach",
                "storedMethodId": "4c6a4b78-72de-4bdd-9455-b9d30f991001-XXXX"
              },
              "paymentDetails": {
                "totalAmount": 47
              },
              "vendorData": {
                "vendorNumber": "7895433"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": null,
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/authorize")
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

        var response = await Client.MoneyOut.AuthorizeOutAsync(
            new MoneyOutTypesRequestOutAuthorize
            {
                Body = new AuthorizePayoutBody
                {
                    EntryPoint = "48acde49",
                    Source = "api",
                    InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                    {
                        new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                    },
                    OrderDescription = "Window Painting",
                    PaymentMethod = new AuthorizePaymentMethod
                    {
                        Method = "ach",
                        StoredMethodId = "4c6a4b78-72de-4bdd-9455-b9d30f991001-XXXX",
                    },
                    PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 47 },
                    VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AuthCapturePayoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "entryPoint": "47ced57b",
              "paymentMethod": {
                "method": "ach",
                "achHolder": "John Doe",
                "achRouting": "011401533",
                "achAccount": "123456789",
                "achAccountType": "checking",
                "achHolderType": "business"
              },
              "paymentDetails": {
                "totalAmount": 978.32
              },
              "vendorData": {
                "vendorNumber": "Vendor3800638299609471",
                "name1": "Heritage Pro Company",
                "name2": "",
                "ein": "473771889",
                "phone": "7868342364",
                "email": "contact570@heritagepro.com",
                "address1": "478 Mittie Roads",
                "city": "Jakubowskifield",
                "state": "WI",
                "zip": "45993",
                "country": "US",
                "mcc": "0763",
                "locationCode": "tpa",
                "contacts": [
                  {
                    "contactName": "Dax",
                    "contactEmail": "Mandy65@heritagepro.com",
                    "contactPhone": "996-325-5420 x31028"
                  }
                ],
                "vendorStatus": 1,
                "remitAddress1": "727 Terrell Streets",
                "remitAddress2": "Apt. 773",
                "remitCity": "South Nicholeside",
                "remitState": "ID",
                "remitZip": "72951-9790",
                "remitCountry": "US"
              },
              "invoiceData": [
                {
                  "invoiceNumber": "VI3BvwTG",
                  "netAmount": "1",
                  "invoiceDate": "2026-09-03",
                  "dueDate": "2026-11-04",
                  "comments": "Building Repairs - Community event setup (System updates)"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "pageIdentifier": null,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "authCode": null,
                "referenceId": "129-220",
                "resultCode": 1,
                "resultText": "Authorized",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 12345,
                "methodReferenceId": "12dea40cba9130s93s-12345"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyOut/authorize")
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

        var response = await Client.MoneyOut.AuthorizeOutAsync(
            new MoneyOutTypesRequestOutAuthorize
            {
                Body = new AuthorizePayoutBody
                {
                    EntryPoint = "47ced57b",
                    PaymentMethod = new AuthorizePaymentMethod
                    {
                        Method = "ach",
                        AchHolder = "John Doe",
                        AchRouting = "011401533",
                        AchAccount = "123456789",
                        AchAccountType = "checking",
                        AchHolderType = AchHolderType.Business,
                    },
                    PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 978.32 },
                    VendorData = new RequestOutAuthorizeVendorData
                    {
                        VendorNumber = "Vendor3800638299609471",
                        Name1 = "Heritage Pro Company",
                        Name2 = "",
                        Ein = "473771889",
                        Phone = "7868342364",
                        Email = "contact570@heritagepro.com",
                        Address1 = "478 Mittie Roads",
                        City = "Jakubowskifield",
                        State = "WI",
                        Zip = "45993",
                        Country = "US",
                        Mcc = "0763",
                        LocationCode = "tpa",
                        Contacts = new List<Contacts>()
                        {
                            new Contacts
                            {
                                ContactName = "Dax",
                                ContactEmail = "Mandy65@heritagepro.com",
                                ContactPhone = "996-325-5420 x31028",
                            },
                        },
                        VendorStatus = 1,
                        RemitAddress1 = "727 Terrell Streets",
                        RemitAddress2 = "Apt. 773",
                        RemitCity = "South Nicholeside",
                        RemitState = "ID",
                        RemitZip = "72951-9790",
                        RemitCountry = "US",
                    },
                    InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                    {
                        new RequestOutAuthorizeInvoiceData
                        {
                            InvoiceNumber = "VI3BvwTG",
                            NetAmount = "1",
                            InvoiceDate = new DateOnly(2026, 9, 3),
                            DueDate = new DateOnly(2026, 11, 4),
                            Comments = "Building Repairs - Community event setup (System updates)",
                        },
                    },
                },
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<AuthCapturePayoutResponse>(mockResponse))
                .UsingDefaults()
        );
    }
}
