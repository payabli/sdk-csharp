using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddVendorTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "vendorNumber": "1234",
              "name1": "Herman's Coatings and Masonry",
              "name2": "<string>",
              "ein": "12-3456789",
              "phone": "5555555555",
              "email": "example@email.com",
              "address1": "123 Ocean Drive",
              "address2": "Suite 400",
              "city": "Miami",
              "state": "FL",
              "zip": "33139",
              "country": "US",
              "mcc": "7777",
              "locationCode": "MIA123",
              "contacts": [
                {
                  "contactName": "Herman Martinez",
                  "contactEmail": "example@email.com",
                  "contactTitle": "Owner",
                  "contactPhone": "3055550000"
                }
              ],
              "billingData": {
                "id": 123,
                "bankName": "Country Bank",
                "routingAccount": "123123123",
                "accountNumber": "123123123",
                "typeAccount": "Checking",
                "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                "bankAccountHolderType": "Business",
                "bankAccountFunction": 0
              },
              "paymentMethod": "managed",
              "vendorStatus": 1,
              "remitAddress1": "123 Walnut Street",
              "remitAddress2": "Suite 900",
              "remitCity": "Miami",
              "remitState": "FL",
              "remitZip": "31113",
              "remitCountry": "US",
              "payeeName1": "<string>",
              "payeeName2": "<string>",
              "customerVendorAccount": "A-37622",
              "internalReferenceId": 123
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3890,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Vendor/single/8cfec329267")
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

        var response = await Client.Vendor.AddVendorAsync(
            "8cfec329267",
            new VendorData
            {
                VendorNumber = "1234",
                Name1 = "Herman's Coatings and Masonry",
                Name2 = "<string>",
                Ein = "12-3456789",
                Phone = "5555555555",
                Email = "example@email.com",
                Address1 = "123 Ocean Drive",
                Address2 = "Suite 400",
                City = "Miami",
                State = "FL",
                Zip = "33139",
                Country = "US",
                Mcc = "7777",
                LocationCode = "MIA123",
                Contacts = new List<Contacts>()
                {
                    new Contacts
                    {
                        ContactName = "Herman Martinez",
                        ContactEmail = "example@email.com",
                        ContactTitle = "Owner",
                        ContactPhone = "3055550000",
                    },
                },
                BillingData = new BillingData
                {
                    Id = 123,
                    BankName = "Country Bank",
                    RoutingAccount = "123123123",
                    AccountNumber = "123123123",
                    TypeAccount = TypeAccount.Checking,
                    BankAccountHolderName = "Gruzya Adventure Outfitters LLC",
                    BankAccountHolderType = BankAccountHolderType.Business,
                    BankAccountFunction = 0,
                },
                PaymentMethod = "managed",
                VendorStatus = 1,
                RemitAddress1 = "123 Walnut Street",
                RemitAddress2 = "Suite 900",
                RemitCity = "Miami",
                RemitState = "FL",
                RemitZip = "31113",
                RemitCountry = "US",
                PayeeName1 = "<string>",
                PayeeName2 = "<string>",
                CustomerVendorAccount = "A-37622",
                InternalReferenceId = 123,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<PayabliApiResponseVendors>(mockResponse))
                .UsingDefaults()
        );
    }
}
