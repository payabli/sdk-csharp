using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.Businesses;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class LinkBusinessPersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
              "personType": "Owner",
              "ownershipPercentage": 100,
              "isPrimaryController": true,
              "isSigner": true,
              "title": "CEO",
              "primaryEmail": "contact@example.com",
              "secondaryEmail": "contact.alt@example.net",
              "primaryPhoneNumber": "3055551212",
              "secondaryPhoneNumber": "3055559876",
              "billingAddress": {
                "addressLine1": "123 Main Street",
                "cityLocality": "Miami",
                "stateProvince": "FL",
                "postalCode": "33101",
                "country": "US",
                "type": "billing"
              },
              "mailingAddress": {
                "addressLine1": "456 Oak Avenue",
                "cityLocality": "Miami",
                "stateProvince": "FL",
                "postalCode": "33102",
                "country": "US",
                "type": "mailing"
              }
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Person linked to business successfully",
              "traceId": "0HNOIMDG0IS4U:00000147",
              "data": {
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "personType": "owner",
                "ownershipPercentage": 100,
                "beneficialOwner": true,
                "isPrimaryController": true,
                "isSigner": true,
                "title": "CEO",
                "primaryEmail": "contact@example.com",
                "secondaryEmail": "contact.alt@example.net",
                "primaryPhoneNumber": "3055551212",
                "secondaryPhoneNumber": "3055559876",
                "billingAddressUuid": "019fed1a-6e41-7194-84c8-98ae0219799a",
                "mailingAddressUuid": "019fed1a-6e43-7768-b3b4-607c374f7730",
                "createdAt": "2026-08-14T17:24:31.387Z",
                "updatedAt": "2026-08-14T17:24:31.387Z",
                "_links": {
                  "self": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/people/01a0014d-ce1a-7110-9bac-c4c59647a88d",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                  "person": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55/people")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
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

        var response = await Client.Businesses.LinkBusinessPersonAsync(
            "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
            new LinkBusinessPersonRequest
            {
                PersonReference = "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                PersonType = PersonType.Owner,
                OwnershipPercentage = 100,
                IsPrimaryController = true,
                IsSigner = true,
                Title = "CEO",
                PrimaryEmail = "contact@example.com",
                SecondaryEmail = "contact.alt@example.net",
                PrimaryPhoneNumber = "3055551212",
                SecondaryPhoneNumber = "3055559876",
                BillingAddress = new PersonAddressRequest
                {
                    AddressLine1 = "123 Main Street",
                    CityLocality = "Miami",
                    StateProvince = "FL",
                    PostalCode = "33101",
                    Country = "US",
                    Type = PersonAddressType.Billing,
                },
                MailingAddress = new PersonAddressRequest
                {
                    AddressLine1 = "456 Oak Avenue",
                    CityLocality = "Miami",
                    StateProvince = "FL",
                    PostalCode = "33102",
                    Country = "US",
                    Type = PersonAddressType.Mailing,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
