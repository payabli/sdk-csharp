using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class ListPaypointsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "Records": [
                {
                  "AverageMonthlyVolume": 1000,
                  "AverageTicketAmount": 1000,
                  "BAddress1": "123 Walnut Street",
                  "BAddress2": "Suite 103",
                  "BankData": [
                    {
                      "bankAccountFunction": 0,
                      "bankAccountHolderName": "Gruzya Adventure Outfitters LLC",
                      "nickname": "Business Checking 1234"
                    }
                  ],
                  "BCity": "New Vegas",
                  "BCountry": "US",
                  "BFax": "5551234567",
                  "BinPerson": 60,
                  "BinPhone": 20,
                  "BinWeb": 20,
                  "BoardingId": 340,
                  "BPhone": "5551234567",
                  "BStartdate": "01/01/1990",
                  "BState": "FL",
                  "BSummary": "Brick and mortar store that sells office supplies",
                  "BTimeZone": -5,
                  "BZip": "33000",
                  "ContactData": [
                    {}
                  ],
                  "CreatedAt": "2022-07-01T15:00:01.000Z",
                  "DbaName": "Sunshine Gutters",
                  "DocumentsRef": "DocumentsRef",
                  "Ein": "123456789",
                  "EntryPoints": [
                    {}
                  ],
                  "externalPaypointID": "Paypoint-100",
                  "ExternalProcessorInformation": "[MER_xxxxxxxxxxxxxx]/[NNNNNNNNN]",
                  "HighTicketAmount": 1000,
                  "IdPaypoint": 1000000,
                  "LastModified": "2022-07-01T15:00:01.000Z",
                  "LegalName": "Sunshine Services, LLC",
                  "License": "2222222FFG",
                  "LicenseState": "CA",
                  "MAddress1": "123 Walnut Street",
                  "MAddress2": "STE 900",
                  "Mccid": "Mccid",
                  "MCity": "Johnson City",
                  "MCountry": "US",
                  "MState": "TN",
                  "MZip": "37615",
                  "OrgId": 123,
                  "OrgParentName": "PropertyManager Pro",
                  "OwnerData": [
                    {}
                  ],
                  "OwnType": "Limited Liability Company",
                  "PaypointStatus": 1,
                  "SalesCode": "SalesCode",
                  "Taxfillname": "Sunshine LLC",
                  "TemplateId": 22,
                  "WebsiteAddress": "www.example.com",
                  "Whencharged": "When Service Provided",
                  "Whendelivered": "0-7 Days",
                  "Whenprovided": "30 Days or Less",
                  "Whenrefund": "Exchange Only"
                }
              ],
              "Summary": {
                "pageIdentifier": "null",
                "pageSize": 20,
                "totalAmount": 77.22,
                "totalNetAmount": 77.22,
                "totalPages": 2,
                "totalRecords": 2
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Query/paypoints/123")
                    .WithParam("fromRecord", "251")
                    .WithParam("limitRecord", "0")
                    .WithParam("sortBy", "desc(field_name)")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Query.ListPaypointsAsync(
            123,
            new ListPaypointsRequest
            {
                FromRecord = 251,
                LimitRecord = 0,
                SortBy = "desc(field_name)",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(JsonUtils.Deserialize<QueryEntrypointResponse>(mockResponse)).UsingDefaults()
        );
    }
}
