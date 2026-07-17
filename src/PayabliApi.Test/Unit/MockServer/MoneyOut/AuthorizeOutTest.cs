using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyOut;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AuthorizeOutTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "autoCapture": true,
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
                "vendorNumber": "VEN-123"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "8cfec329267",
                AutoCapture = true,
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
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "VEN-123" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "autoCapture": true,
              "invoiceData": [
                {
                  "billId": 54323,
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
                "vendorNumber": "VEN-123"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "8cfec329267",
                AutoCapture = true,
                InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                {
                    new RequestOutAuthorizeInvoiceData
                    {
                        BillId = 54323,
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
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "VEN-123" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "autoCapture": true,
              "source": "api",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Window Painting",
              "paymentMethod": {
                "method": "ach",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-456"
              },
              "paymentDetails": {
                "totalAmount": 47
              },
              "vendorData": {
                "vendorNumber": "VEN-123"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "8cfec329267",
                AutoCapture = true,
                Source = "api",
                InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                {
                    new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                },
                OrderDescription = "Window Painting",
                PaymentMethod = new AuthorizePaymentMethod
                {
                    Method = "ach",
                    StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-456",
                },
                PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 47 },
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "VEN-123" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Office Supplies",
              "paymentDetails": {
                "totalAmount": 1500,
                "checkNumber": "10001"
              },
              "paymentMethod": {
                "method": "check"
              },
              "vendorData": {
                "vendorNumber": "VEN-123"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "8cfec329267",
                InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                {
                    new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                },
                OrderDescription = "Office Supplies",
                PaymentDetails = new RequestOutAuthorizePaymentDetails
                {
                    TotalAmount = 1500,
                    CheckNumber = "10001",
                },
                PaymentMethod = new AuthorizePaymentMethod { Method = "check" },
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "VEN-123" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "entryPoint": "48acde49",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Contractor Payment",
              "paymentDetails": {
                "totalAmount": 2500
              },
              "paymentMethod": {
                "method": "wire",
                "achHolder": "Jane Smith",
                "achRouting": "011401533",
                "achAccount": "987654321",
                "achAccountType": "checking"
              },
              "vendorData": {
                "vendorNumber": "7895433"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "48acde49",
                InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                {
                    new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                },
                OrderDescription = "Contractor Payment",
                PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 2500 },
                PaymentMethod = new AuthorizePaymentMethod
                {
                    Method = "wire",
                    AchHolder = "Jane Smith",
                    AchRouting = "011401533",
                    AchAccount = "987654321",
                    AchAccountType = "checking",
                },
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_6()
    {
        const string requestJson = """
            {
              "entryPoint": "48acde49",
              "invoiceData": [
                {
                  "billId": 54323
                }
              ],
              "orderDescription": "Urgent Vendor Payment",
              "paymentDetails": {
                "totalAmount": 1200
              },
              "paymentMethod": {
                "method": "rtp",
                "achHolder": "Jane Smith",
                "achRouting": "011401533",
                "achAccount": "987654321",
                "achAccountType": "checking"
              },
              "vendorData": {
                "vendorNumber": "7895433"
              }
            }
            """;

        const string mockResponse = """
            {
              "responseCode": 1,
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456
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
            new RequestOutAuthorize
            {
                EntryPoint = "48acde49",
                InvoiceData = new List<RequestOutAuthorizeInvoiceData>()
                {
                    new RequestOutAuthorizeInvoiceData { BillId = 54323 },
                },
                OrderDescription = "Urgent Vendor Payment",
                PaymentDetails = new RequestOutAuthorizePaymentDetails { TotalAmount = 1200 },
                PaymentMethod = new AuthorizePaymentMethod
                {
                    Method = "rtp",
                    AchHolder = "Jane Smith",
                    AchRouting = "011401533",
                    AchAccount = "987654321",
                    AchAccountType = "checking",
                },
                VendorData = new RequestOutAuthorizeVendorData { VendorNumber = "7895433" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_7()
    {
        const string requestJson = """
            {
              "entryPoint": "8cfec329267",
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
                "vendorNumber": "VEN-123",
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
                  "invoiceNumber": "INV-2345",
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
              "roomId": 0,
              "isSuccess": true,
              "responseText": "Success",
              "responseData": {
                "referenceId": "129-219",
                "resultCode": 1,
                "resultText": "Authorized",
                "customerId": 456,
                "vendorId": 456,
                "methodReferenceId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-456"
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
            new RequestOutAuthorize
            {
                EntryPoint = "8cfec329267",
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
                    VendorNumber = "VEN-123",
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
                        InvoiceNumber = "INV-2345",
                        NetAmount = "1",
                        InvoiceDate = new DateOnly(2026, 9, 3),
                        DueDate = new DateOnly(2026, 11, 4),
                        Comments = "Building Repairs - Community event setup (System updates)",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
