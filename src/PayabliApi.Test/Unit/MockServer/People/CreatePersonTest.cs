using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.People;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePersonTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "firstName": "Marcus",
              "middleName": "James",
              "lastName": "Delgado",
              "primaryEmail": "marcus.delgado@example.com",
              "secondaryEmail": "m.delgado@example.net",
              "primaryPhoneNumber": "3055551212",
              "secondaryPhoneNumber": "3055559876",
              "dateOfBirth": "1985-03-14",
              "ssn": "412-55-9021",
              "nationality": "US",
              "driversLicenseNumber": "D1234567",
              "driversLicenseState": "FL",
              "externalId": "person-001",
              "customData": {
                "department": "finance"
              },
              "addresses": [
                {
                  "addressLine1": "123 Main Street",
                  "addressLine2": "Suite 400",
                  "cityLocality": "Miami",
                  "stateProvince": "FL",
                  "postalCode": "33101",
                  "country": "US",
                  "type": "legal"
                }
              ],
              "identificationDocuments": [
                {
                  "type": "passport",
                  "number": "X1234567",
                  "issuingCountry": "US",
                  "expirationDate": "2030-06-30"
                }
              ],
              "businessRelationship": {
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
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
            }
            """;

        const string mockResponse = """
            {
              "success": true,
              "message": "Person created successfully",
              "traceId": "0HNNQ4R2OT26Q:0000001D",
              "data": {
                "personReference": "01a0014d-ce1a-7110-9bac-c4c59647a88d",
                "externalId": "person-001",
                "firstName": "Marcus",
                "middleName": "James",
                "lastName": "Delgado",
                "primaryEmail": "marcus.delgado@example.com",
                "secondaryEmail": "m.delgado@example.net",
                "primaryPhoneNumber": "3055551212",
                "secondaryPhoneNumber": "3055559876",
                "dateOfBirth": "****-**-14",
                "ssn": "***-**-9021",
                "nationality": "US",
                "driversLicenseNumber": "D1***567",
                "driversLicenseState": "FL",
                "customData": {
                  "department": "finance"
                },
                "verificationStatus": "not_started",
                "businessRelationship": {
                  "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
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
                  "billingAddressUuid": "01a0014d-ce1a-7110-9bac-c4c59647a891",
                  "mailingAddressUuid": "01a0014d-ce1a-7110-9bac-c4c59647a892"
                },
                "createdAt": "2026-08-14T17:24:31.387Z",
                "lastUpdated": "2026-08-14T17:24:31.387Z",
                "_links": {
                  "self": "/v2/people/01a0014d-ce1a-7110-9bac-c4c59647a88d",
                  "business": "/v2/businesses/019fed1a-3d6e-75d3-a81e-cba3874b0a55"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people")
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

        var response = await Client.People.CreatePersonAsync(
            new CreatePersonRequest
            {
                FirstName = "Marcus",
                MiddleName = "James",
                LastName = "Delgado",
                PrimaryEmail = "marcus.delgado@example.com",
                SecondaryEmail = "m.delgado@example.net",
                PrimaryPhoneNumber = "3055551212",
                SecondaryPhoneNumber = "3055559876",
                DateOfBirth = "1985-03-14",
                Ssn = "412-55-9021",
                Nationality = "US",
                DriversLicenseNumber = "D1234567",
                DriversLicenseState = "FL",
                ExternalId = "person-001",
                CustomData = new Dictionary<string, object?>() { { "department", "finance" } },
                Addresses = new List<PersonAddressRequest>()
                {
                    new PersonAddressRequest
                    {
                        AddressLine1 = "123 Main Street",
                        AddressLine2 = "Suite 400",
                        CityLocality = "Miami",
                        StateProvince = "FL",
                        PostalCode = "33101",
                        Country = "US",
                        Type = PersonAddressType.Legal,
                    },
                },
                IdentificationDocuments = new List<IdentificationDocumentRequest>()
                {
                    new IdentificationDocumentRequest
                    {
                        Type = "passport",
                        Number = "X1234567",
                        IssuingCountry = "US",
                        ExpirationDate = "2030-06-30",
                    },
                },
                BusinessRelationship = new BusinessRelationshipRequest
                {
                    BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
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
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "firstName": "Grace",
              "lastName": "Delgado",
              "nationality": "US",
              "businessRelationship": {
                "businessReference": "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                "personType": "Owner",
                "ownershipPercentage": 50
              }
            }
            """;

        const string mockResponse = """
            {
              "success": false,
              "message": "Person created, but the business link did not complete. See warnings for details.",
              "traceId": "0HNONVRI1SQDV:0000001F",
              "data": {
                "personReference": "01a0d492-62c6-7151-9411-86ed90094a97",
                "firstName": "Grace",
                "lastName": "Delgado",
                "nationality": "US",
                "verificationStatus": "not_started",
                "createdAt": "2026-09-24T17:59:18.470Z",
                "lastUpdated": "2026-09-24T17:59:18.470Z",
                "_links": {
                  "self": "/v2/people/01a0d492-62c6-7151-9411-86ed90094a97"
                }
              },
              "warnings": [
                {
                  "code": "LINK_OWNERSHIP_EXCEEDED",
                  "message": "Combined ownership would exceed 100% (existing 100.00%, attempted 50%)."
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/people")
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

        var response = await Client.People.CreatePersonAsync(
            new CreatePersonRequest
            {
                FirstName = "Grace",
                LastName = "Delgado",
                Nationality = "US",
                BusinessRelationship = new BusinessRelationshipRequest
                {
                    BusinessReference = "019fed1a-3d6e-75d3-a81e-cba3874b0a55",
                    PersonType = PersonType.Owner,
                    OwnershipPercentage = 50,
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
