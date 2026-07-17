using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.TokenStorage;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetMethodTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "aba": "",
                "achHolderType": "personal",
                "achSecCode": "achSecCode",
                "bin": "401288",
                "binData": {
                  "binMatchedLength": "6",
                  "binCardBrand": "Visa",
                  "binCardType": "Credit",
                  "binCardCategory": "PLATINUM",
                  "binCardIssuer": "Bank of Example",
                  "binCardIssuerCountry": "United States",
                  "binCardIssuerCountryCodeA2": "US",
                  "binCardIssuerCountryNumber": "840",
                  "binCardIsRegulated": "false",
                  "binCardUseCategory": "Consumer",
                  "binCardIssuerCountryCodeA3": "USA"
                },
                "customers": [
                  {
                    "additionalData": {
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
                    "balance": 250,
                    "billingPhone": "1234567890",
                    "company": "Bluesky Tech Inc",
                    "created": "2023-06-01T14:30:00.000Z",
                    "customerId": 4440,
                    "customerNumber": "C-90010",
                    "customerStatus": 1,
                    "customerUsername": "Marcus",
                    "identifierFields": [
                      "firstname",
                      "email"
                    ],
                    "lastUpdated": "2024-12-15T09:45:32.000Z",
                    "mfa": true,
                    "mfaMode": 1,
                    "parentOrgId": 5,
                    "parentOrgName": "TechCorp",
                    "paypointDbaname": "Bluesky Tech",
                    "paypointEntryname": "45782932fcc",
                    "paypointLegalname": "Bluesky Technologies LLC",
                    "shippingAddress1": "Suite 500",
                    "shippingCity": "San Francisco",
                    "shippingCountry": "US",
                    "shippingState": "CA",
                    "shippingZip": "94105",
                    "timeZone": -8
                  }
                ],
                "descriptor": "visa",
                "expDate": "0926",
                "holderName": "Marcus Chen",
                "idPmethod": "81f7fde1-dd8b-4892-b2e1-cd60dd91f6b4-XXXC",
                "lastUpdated": "2025-01-15T16:30:22.000Z",
                "maskedAccount": "4XXXXXXX2345",
                "method": "card",
                "methodType": "Single Merchant",
                "postalCode": "94105"
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithParam("cardExpirationFormat", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.GetMethodAsync(
            "32-8877drt00045632-678",
            new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "aba": "021000021",
                "achHolderType": "personal",
                "achSecCode": "PPD",
                "bin": "",
                "customers": [
                  {
                    "additionalData": {
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
                    "balance": 250,
                    "billingPhone": "1234567890",
                    "company": "Bluesky Tech Inc",
                    "created": "2023-06-01T14:30:00.000Z",
                    "customerId": 4440,
                    "customerNumber": "C-90010",
                    "customerStatus": 1,
                    "customerUsername": "Marcus",
                    "identifierFields": [
                      "firstname",
                      "email"
                    ],
                    "lastUpdated": "2024-12-15T09:45:32.000Z",
                    "mfa": true,
                    "mfaMode": 1,
                    "parentOrgId": 5,
                    "parentOrgName": "TechCorp",
                    "paypointDbaname": "Bluesky Tech",
                    "paypointEntryname": "45782932fcc",
                    "paypointLegalname": "Bluesky Technologies LLC",
                    "shippingAddress1": "Suite 500",
                    "shippingCity": "San Francisco",
                    "shippingCountry": "US",
                    "shippingState": "CA",
                    "shippingZip": "94105",
                    "snIdentifier": "null",
                    "snProvider": "google",
                    "timeZone": -8
                  }
                ],
                "descriptor": "Checking",
                "expDate": "",
                "holderName": "Marcus Chen",
                "idPmethod": "81f7fde1-dd8b-4892-b2e1-cd60dd91f6b4-XXXX",
                "lastUpdated": "2025-01-15T16:30:22.000Z",
                "maskedAccount": "8XXXXXX8654",
                "method": "ach",
                "methodType": "Single Merchant",
                "postalCode": ""
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithParam("cardExpirationFormat", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.GetMethodAsync(
            "32-8877drt00045632-678",
            new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "isSuccess": true,
              "responseData": {
                "aba": "122105278",
                "achHolderType": "business",
                "achSecCode": "PPD",
                "bin": "",
                "customers": [],
                "descriptor": "checking",
                "expDate": "",
                "holderName": "John Doe",
                "idPmethod": "749e236c-59a3-49c7-ab47-73e06f9e94aa-123xxx",
                "isValidatedACH": false,
                "lastUpdated": "2026-01-02T19:11:27.634Z",
                "maskedAccount": "0XXXXXX0022",
                "method": "ach",
                "methodType": "Multiple Universal",
                "postalCode": "",
                "vendors": [
                  {
                    "vendorNumber": "VEN-123",
                    "name1": "Connie's Concrete",
                    "name2": "",
                    "ein": "XXXXX4789",
                    "phone": "(123) 456-7890",
                    "email": "conniesconcrete@payabli.com",
                    "address1": "Suite 500",
                    "address2": "",
                    "city": "San Francisco",
                    "state": "CA",
                    "zip": "94021",
                    "country": "US",
                    "mcc": "",
                    "locationCode": "WEST",
                    "contacts": [
                      {
                        "contactName": "John Doe",
                        "contactEmail": "johndoe@payabli.com",
                        "contactTitle": "Finance Manager",
                        "contactPhone": "5555551234"
                      }
                    ],
                    "paymentMethod": "ach",
                    "vendorStatus": 1,
                    "vendorId": 456,
                    "paypointLegalname": "Gruzya Adventure Outfitters LLC",
                    "paypointId": "3040",
                    "paypointDbaname": "Gruzya Adventure Outfitters LLC",
                    "paypointEntryname": "47ac12de2",
                    "parentOrgName": "Payabli",
                    "parentOrgId": 3,
                    "createdDate": "2025-09-17T00:13:40.174Z",
                    "lastUpdated": "2025-09-18T15:40:55.181Z",
                    "remitAddress1": "Suite 500",
                    "remitAddress2": "",
                    "remitCity": "San Francisco",
                    "remitState": "CA",
                    "remitZip": "94021",
                    "remitCountry": "US",
                    "internalReferenceId": 30986,
                    "externalPaypointID": "3037"
                  }
                ]
              },
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/TokenStorage/32-8877drt00045632-678")
                    .WithParam("cardExpirationFormat", "1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TokenStorage.GetMethodAsync(
            "32-8877drt00045632-678",
            new GetMethodRequest { CardExpirationFormat = 1, IncludeTemporary = false }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
