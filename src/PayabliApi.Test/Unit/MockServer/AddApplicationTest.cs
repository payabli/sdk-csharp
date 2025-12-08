using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class AddApplicationTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "services": {
                "ach": {},
                "card": {
                  "acceptAmex": true,
                  "acceptDiscover": true,
                  "acceptMastercard": true,
                  "acceptVisa": true
                }
              },
              "annualRevenue": 1000,
              "averageBillSize": "500",
              "averageMonthlyBill": "5650",
              "avgmonthly": 1000,
              "baddress": "123 Walnut Street",
              "baddress1": "Suite 103",
              "bankData": {},
              "bcity": "New Vegas",
              "bcountry": "US",
              "binperson": 60,
              "binphone": 20,
              "binweb": 20,
              "bstate": "FL",
              "bsummary": "Brick and mortar store that sells office supplies",
              "btype": "Limited Liability Company",
              "bzip": "33000",
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "creditLimit": "creditLimit",
              "dbaName": "Sunshine Gutters",
              "ein": "123456789",
              "faxnumber": "1234567890",
              "highticketamt": 1000,
              "legalName": "Sunshine Services, LLC",
              "license": "2222222FFG",
              "licstate": "CA",
              "maddress": "123 Walnut Street",
              "maddress1": "STE 900",
              "mcc": "7777",
              "mcity": "Johnson City",
              "mcountry": "US",
              "mstate": "TN",
              "mzip": "37615",
              "orgId": 123,
              "ownership": [
                {
                  "oaddress": "33 North St",
                  "ocity": "Any City",
                  "ocountry": "US",
                  "odriverstate": "CA",
                  "ostate": "CA",
                  "ownerdob": "01/01/1990",
                  "ownerdriver": "CA6677778",
                  "owneremail": "test@email.com",
                  "ownername": "John Smith",
                  "ownerpercent": 100,
                  "ownerphone1": "555888111",
                  "ownerphone2": "555888111",
                  "ownerssn": "123456789",
                  "ownertitle": "CEO",
                  "ozip": "55555"
                }
              ],
              "phonenumber": "1234567890",
              "processingRegion": "US",
              "recipientEmail": "josephray@example.com",
              "recipientEmailNotification": true,
              "resumable": true,
              "signer": {
                "address": "33 North St",
                "address1": "STE 900",
                "city": "Bristol",
                "country": "US",
                "dob": "01/01/1976",
                "email": "test@email.com",
                "name": "John Smith",
                "phone": "555888111",
                "ssn": "123456789",
                "state": "TN",
                "zip": "55555",
                "pciAttestation": true,
                "signedDocumentReference": "https://example.com/signed-document.pdf",
                "attestationDate": "04/20/2025",
                "signDate": "04/20/2025",
                "additionalData": "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}"
              },
              "startdate": "01/01/1990",
              "taxFillName": "Sunshine LLC",
              "templateId": 22,
              "ticketamt": 1000,
              "website": "www.example.com",
              "whenCharged": "When Service Provided",
              "whenDelivered": "Over 30 Days",
              "whenProvided": "30 Days or Less",
              "whenRefunded": "30 Days or Less"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/app")
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

        var response = await Client.Boarding.AddApplicationAsync(
            new ApplicationDataPayIn
            {
                Services = new ApplicationDataPayInServices
                {
                    Ach = new ApplicationDataPayInServicesAch(),
                    Card = new ApplicationDataPayInServicesCard
                    {
                        AcceptAmex = true,
                        AcceptDiscover = true,
                        AcceptMastercard = true,
                        AcceptVisa = true,
                    },
                },
                AnnualRevenue = 1000,
                AverageBillSize = "500",
                AverageMonthlyBill = "5650",
                Avgmonthly = 1000,
                Baddress = "123 Walnut Street",
                Baddress1 = "Suite 103",
                BankData = new ApplicationDataPayInBankData(),
                Bcity = "New Vegas",
                Bcountry = "US",
                Binperson = 60,
                Binphone = 20,
                Binweb = 20,
                Bstate = "FL",
                Bsummary = "Brick and mortar store that sells office supplies",
                Btype = OwnType.LimitedLiabilityCompany,
                Bzip = "33000",
                Contacts = new List<ApplicationDataPayInContactsItem>()
                {
                    new ApplicationDataPayInContactsItem
                    {
                        ContactEmail = "herman@hermanscoatings.com",
                        ContactName = "Herman Martinez",
                        ContactPhone = "3055550000",
                        ContactTitle = "Owner",
                    },
                },
                CreditLimit = "creditLimit",
                DbaName = "Sunshine Gutters",
                Ein = "123456789",
                Faxnumber = "1234567890",
                Highticketamt = 1000,
                LegalName = "Sunshine Services, LLC",
                License = "2222222FFG",
                Licstate = "CA",
                Maddress = "123 Walnut Street",
                Maddress1 = "STE 900",
                Mcc = "7777",
                Mcity = "Johnson City",
                Mcountry = "US",
                Mstate = "TN",
                Mzip = "37615",
                OrgId = 123,
                Ownership = new List<ApplicationDataPayInOwnershipItem>()
                {
                    new ApplicationDataPayInOwnershipItem
                    {
                        Oaddress = "33 North St",
                        Ocity = "Any City",
                        Ocountry = "US",
                        Odriverstate = "CA",
                        Ostate = "CA",
                        Ownerdob = "01/01/1990",
                        Ownerdriver = "CA6677778",
                        Owneremail = "test@email.com",
                        Ownername = "John Smith",
                        Ownerpercent = 100,
                        Ownerphone1 = "555888111",
                        Ownerphone2 = "555888111",
                        Ownerssn = "123456789",
                        Ownertitle = "CEO",
                        Ozip = "55555",
                    },
                },
                Phonenumber = "1234567890",
                ProcessingRegion = "US",
                RecipientEmail = "josephray@example.com",
                RecipientEmailNotification = true,
                Resumable = true,
                Signer = new SignerDataRequest
                {
                    Address = "33 North St",
                    Address1 = "STE 900",
                    City = "Bristol",
                    Country = "US",
                    Dob = "01/01/1976",
                    Email = "test@email.com",
                    Name = "John Smith",
                    Phone = "555888111",
                    Ssn = "123456789",
                    State = "TN",
                    Zip = "55555",
                    PciAttestation = true,
                    SignedDocumentReference = "https://example.com/signed-document.pdf",
                    AttestationDate = "04/20/2025",
                    SignDate = "04/20/2025",
                    AdditionalData =
                        "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
                },
                Startdate = "01/01/1990",
                TaxFillName = "Sunshine LLC",
                TemplateId = 22,
                Ticketamt = 1000,
                Website = "www.example.com",
                WhenCharged = Whencharged.WhenServiceProvided,
                WhenDelivered = Whendelivered.Over30Days,
                WhenProvided = Whenprovided.ThirtyDaysOrLess,
                WhenRefunded = Whenrefunded.ThirtyDaysOrLess,
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "annualRevenue": 750000,
              "baddress": "789 Industrial Parkway",
              "baddress1": "Unit 12",
              "bankData": [
                {
                  "accountNumber": "1XXXXXX3100",
                  "bankAccountFunction": 1,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Withdrawal Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-456"
                },
                {
                  "accountNumber": "1XXXXXX3200",
                  "bankAccountFunction": 0,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Deposit Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-789"
                },
                {
                  "accountNumber": "1XXXXXX3123",
                  "bankAccountFunction": 3,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Remittance Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-100"
                }
              ],
              "bcity": "Miami",
              "bcountry": "US",
              "bstate": "FL",
              "bsummary": "Commercial and industrial coating services, including protective and decorative coatings",
              "btype": "Limited Liability Company",
              "bzip": "33101",
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "dbaname": "Herman's Coatings",
              "ein": "123456789",
              "faxnumber": "3055550001",
              "legalname": "Herman's Coatings LLC",
              "license": "FL123456",
              "licstate": "FL",
              "maddress": "789 Industrial Parkway",
              "maddress1": "Unit 12",
              "mcc": "1799",
              "mcity": "Miami",
              "mcountry": "US",
              "mstate": "FL",
              "mzip": "33101",
              "orgId": 123,
              "ownership": [
                {
                  "oaddress": "123 Palm Avenue",
                  "ocity": "Miami",
                  "ocountry": "US",
                  "odriverstate": "FL",
                  "ostate": "FL",
                  "ownerdob": "05/15/1980",
                  "ownerdriver": "FL789456",
                  "owneremail": "herman@hermanscoatings.com",
                  "ownername": "Herman Martinez",
                  "ownerpercent": 100,
                  "ownerphone1": "3055550000",
                  "ownerphone2": "3055550002",
                  "ownerssn": "123456789",
                  "ownertitle": "Owner",
                  "ozip": "33102"
                }
              ],
              "phonenumber": "3055550000",
              "recipientEmail": "herman@hermanscoatings.com",
              "recipientEmailNotification": true,
              "resumable": true,
              "signer": {
                "address": "33 North St",
                "address1": "STE 900",
                "city": "Bristol",
                "country": "US",
                "dob": "01/01/1976",
                "email": "test@email.com",
                "name": "John Smith",
                "phone": "555888111",
                "ssn": "123456789",
                "state": "TN",
                "zip": "55555",
                "pciAttestation": true,
                "signedDocumentReference": "https://example.com/signed-document.pdf",
                "attestationDate": "04/20/2025",
                "signDate": "04/20/2025",
                "additionalData": "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}"
              },
              "startdate": "01/01/2015",
              "taxfillname": "Herman's Coatings LLC",
              "templateId": 22,
              "website": "www.hermanscoatings.com"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/app")
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

        var response = await Client.Boarding.AddApplicationAsync(
            new ApplicationDataManaged
            {
                AnnualRevenue = 750000,
                Baddress = "789 Industrial Parkway",
                Baddress1 = "Unit 12",
                BankData = new List<Bank>()
                {
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3100",
                        BankAccountFunction = 1,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Withdrawal Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-456",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3200",
                        BankAccountFunction = 0,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Deposit Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-789",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3123",
                        BankAccountFunction = 3,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Remittance Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-100",
                    },
                },
                Bcity = "Miami",
                Bcountry = "US",
                Bstate = "FL",
                Bsummary =
                    "Commercial and industrial coating services, including protective and decorative coatings",
                Btype = OwnType.LimitedLiabilityCompany,
                Bzip = "33101",
                Contacts = new List<ApplicationDataManagedContactsItem>()
                {
                    new ApplicationDataManagedContactsItem
                    {
                        ContactEmail = "herman@hermanscoatings.com",
                        ContactName = "Herman Martinez",
                        ContactPhone = "3055550000",
                        ContactTitle = "Owner",
                    },
                },
                Dbaname = "Herman's Coatings",
                Ein = "123456789",
                Faxnumber = "3055550001",
                Legalname = "Herman's Coatings LLC",
                License = "FL123456",
                Licstate = "FL",
                Maddress = "789 Industrial Parkway",
                Maddress1 = "Unit 12",
                Mcc = "1799",
                Mcity = "Miami",
                Mcountry = "US",
                Mstate = "FL",
                Mzip = "33101",
                OrgId = 123,
                Ownership = new List<ApplicationDataManagedOwnershipItem>()
                {
                    new ApplicationDataManagedOwnershipItem
                    {
                        Oaddress = "123 Palm Avenue",
                        Ocity = "Miami",
                        Ocountry = "US",
                        Odriverstate = "FL",
                        Ostate = "FL",
                        Ownerdob = "05/15/1980",
                        Ownerdriver = "FL789456",
                        Owneremail = "herman@hermanscoatings.com",
                        Ownername = "Herman Martinez",
                        Ownerpercent = 100,
                        Ownerphone1 = "3055550000",
                        Ownerphone2 = "3055550002",
                        Ownerssn = "123456789",
                        Ownertitle = "Owner",
                        Ozip = "33102",
                    },
                },
                Phonenumber = "3055550000",
                RecipientEmail = "herman@hermanscoatings.com",
                RecipientEmailNotification = true,
                Resumable = true,
                Signer = new SignerDataRequest
                {
                    Address = "33 North St",
                    Address1 = "STE 900",
                    City = "Bristol",
                    Country = "US",
                    Dob = "01/01/1976",
                    Email = "test@email.com",
                    Name = "John Smith",
                    Phone = "555888111",
                    Ssn = "123456789",
                    State = "TN",
                    Zip = "55555",
                    PciAttestation = true,
                    SignedDocumentReference = "https://example.com/signed-document.pdf",
                    AttestationDate = "04/20/2025",
                    SignDate = "04/20/2025",
                    AdditionalData =
                        "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
                },
                Startdate = "01/01/2015",
                Taxfillname = "Herman's Coatings LLC",
                TemplateId = 22,
                Website = "www.hermanscoatings.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "services": {
                "ach": {
                  "acceptCCD": true,
                  "acceptPPD": true,
                  "acceptWeb": true
                },
                "card": {
                  "acceptAmex": true,
                  "acceptDiscover": true,
                  "acceptMastercard": true,
                  "acceptVisa": true
                },
                "odp": {
                  "allowAch": true,
                  "allowChecks": true,
                  "allowVCard": true,
                  "processing_region": "US",
                  "processor": "tsys",
                  "issuerNetworkSettingsId": "12345678901234"
                }
              },
              "annualRevenue": 750000,
              "baddress": "789 Industrial Parkway",
              "baddress1": "Unit 12",
              "bankData": [
                {
                  "accountNumber": "1XXXXXX3100",
                  "bankAccountFunction": 1,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Withdrawal Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "333-789"
                },
                {
                  "accountNumber": "1XXXXXX3200",
                  "bankAccountFunction": 0,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Deposit Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "333-234"
                },
                {
                  "accountNumber": "1XXXXXX3123",
                  "bankAccountFunction": 3,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "nickname": "Remittance Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "333-567"
                }
              ],
              "bcity": "Miami",
              "bcountry": "US",
              "bstate": "FL",
              "bsummary": "Commercial and industrial coating services, including protective and decorative coatings",
              "btype": "Limited Liability Company",
              "bzip": "33101",
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "dbaname": "Herman's Coatings",
              "ein": "123456789",
              "faxnumber": "3055550001",
              "highticketamt": 15000,
              "legalname": "Herman's Coatings LLC",
              "license": "FL123456",
              "licstate": "FL",
              "maddress": "789 Industrial Parkway",
              "maddress1": "Unit 12",
              "mcc": "1799",
              "mcity": "Miami",
              "mcountry": "US",
              "mstate": "FL",
              "mzip": "33101",
              "orgId": 123,
              "ownership": [
                {
                  "oaddress": "123 Palm Avenue",
                  "ocity": "Miami",
                  "ocountry": "US",
                  "odriverstate": "FL",
                  "ostate": "FL",
                  "ownerdob": "05/15/1980",
                  "ownerdriver": "FL789456",
                  "owneremail": "herman@hermanscoatings.com",
                  "ownername": "Herman Martinez",
                  "ownerpercent": 100,
                  "ownerphone1": "3055550000",
                  "ownerphone2": "3055550002",
                  "ownerssn": "123456789",
                  "ownertitle": "Owner",
                  "ozip": "33102"
                }
              ],
              "payoutAverageMonthlyVolume": 50000,
              "payoutAverageTicketAmount": 3500,
              "payoutCreditLimit": 25000,
              "payoutHighTicketAmount": 15000,
              "phonenumber": "3055550000",
              "recipientEmail": "herman@hermanscoatings.com",
              "recipientEmailNotification": true,
              "resumable": true,
              "signer": {
                "address": "33 North St",
                "address1": "STE 900",
                "city": "Bristol",
                "country": "US",
                "dob": "01/01/1976",
                "email": "test@email.com",
                "name": "John Smith",
                "phone": "555888111",
                "ssn": "123456789",
                "state": "TN",
                "zip": "55555",
                "pciAttestation": true,
                "signedDocumentReference": "https://example.com/signed-document.pdf",
                "attestationDate": "04/20/2025",
                "signDate": "04/20/2025",
                "additionalData": "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}"
              },
              "startdate": "01/01/2015",
              "taxfillname": "Herman's Coatings LLC",
              "templateId": 22,
              "website": "www.hermanscoatings.com"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/app")
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

        var response = await Client.Boarding.AddApplicationAsync(
            new ApplicationDataOdp
            {
                Services = new Services
                {
                    Ach = new AchSetup
                    {
                        AcceptCcd = true,
                        AcceptPpd = true,
                        AcceptWeb = true,
                    },
                    Card = new CardSetup
                    {
                        AcceptAmex = true,
                        AcceptDiscover = true,
                        AcceptMastercard = true,
                        AcceptVisa = true,
                    },
                    Odp = new OdpSetup
                    {
                        AllowAch = true,
                        AllowChecks = true,
                        AllowVCard = true,
                        ProcessingRegion = OdpSetupProcessingRegion.Us,
                        Processor = "tsys",
                        IssuerNetworkSettingsId = "12345678901234",
                    },
                },
                AnnualRevenue = 750000,
                Baddress = "789 Industrial Parkway",
                Baddress1 = "Unit 12",
                BankData = new List<Bank>()
                {
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3100",
                        BankAccountFunction = 1,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Withdrawal Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "333-789",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3200",
                        BankAccountFunction = 0,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Deposit Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "333-234",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3123",
                        BankAccountFunction = 3,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Nickname = "Remittance Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "333-567",
                    },
                },
                Bcity = "Miami",
                Bcountry = "US",
                Bstate = "FL",
                Bsummary =
                    "Commercial and industrial coating services, including protective and decorative coatings",
                Btype = OwnType.LimitedLiabilityCompany,
                Bzip = "33101",
                Contacts = new List<ApplicationDataOdpContactsItem>()
                {
                    new ApplicationDataOdpContactsItem
                    {
                        ContactEmail = "herman@hermanscoatings.com",
                        ContactName = "Herman Martinez",
                        ContactPhone = "3055550000",
                        ContactTitle = "Owner",
                    },
                },
                Dbaname = "Herman's Coatings",
                Ein = "123456789",
                Faxnumber = "3055550001",
                Highticketamt = 15000,
                Legalname = "Herman's Coatings LLC",
                License = "FL123456",
                Licstate = "FL",
                Maddress = "789 Industrial Parkway",
                Maddress1 = "Unit 12",
                Mcc = "1799",
                Mcity = "Miami",
                Mcountry = "US",
                Mstate = "FL",
                Mzip = "33101",
                OrgId = 123,
                Ownership = new List<ApplicationDataOdpOwnershipItem>()
                {
                    new ApplicationDataOdpOwnershipItem
                    {
                        Oaddress = "123 Palm Avenue",
                        Ocity = "Miami",
                        Ocountry = "US",
                        Odriverstate = "FL",
                        Ostate = "FL",
                        Ownerdob = "05/15/1980",
                        Ownerdriver = "FL789456",
                        Owneremail = "herman@hermanscoatings.com",
                        Ownername = "Herman Martinez",
                        Ownerpercent = 100,
                        Ownerphone1 = "3055550000",
                        Ownerphone2 = "3055550002",
                        Ownerssn = "123456789",
                        Ownertitle = "Owner",
                        Ozip = "33102",
                    },
                },
                PayoutAverageMonthlyVolume = 50000,
                PayoutAverageTicketAmount = 3500,
                PayoutCreditLimit = 25000,
                PayoutHighTicketAmount = 15000,
                Phonenumber = "3055550000",
                RecipientEmail = "herman@hermanscoatings.com",
                RecipientEmailNotification = true,
                Resumable = true,
                Signer = new SignerDataRequest
                {
                    Address = "33 North St",
                    Address1 = "STE 900",
                    City = "Bristol",
                    Country = "US",
                    Dob = "01/01/1976",
                    Email = "test@email.com",
                    Name = "John Smith",
                    Phone = "555888111",
                    Ssn = "123456789",
                    State = "TN",
                    Zip = "55555",
                    PciAttestation = true,
                    SignedDocumentReference = "https://example.com/signed-document.pdf",
                    AttestationDate = "04/20/2025",
                    SignDate = "04/20/2025",
                    AdditionalData =
                        "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
                },
                Startdate = "01/01/2015",
                Taxfillname = "Herman's Coatings LLC",
                TemplateId = 22,
                Website = "www.hermanscoatings.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "services": {
                "ach": {
                  "acceptCCD": true,
                  "acceptPPD": true,
                  "acceptWeb": true
                },
                "card": {
                  "acceptAmex": true,
                  "acceptDiscover": true,
                  "acceptMastercard": true,
                  "acceptVisa": true
                },
                "odp": {
                  "allowAch": false,
                  "allowChecks": false,
                  "allowVCard": false
                }
              },
              "annualRevenue": 750000,
              "attachments": [
                {},
                {}
              ],
              "baddress": "789 Industrial Parkway",
              "baddress1": "Unit 12",
              "bankData": [
                {
                  "accountNumber": "1XXXXXX3100",
                  "bankAccountFunction": 1,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "id": 123,
                  "nickname": "Withdrawal Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-789"
                },
                {
                  "accountNumber": "1XXXXXX3200",
                  "bankAccountFunction": 0,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "id": 456,
                  "nickname": "Deposit Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-456"
                },
                {
                  "accountNumber": "1XXXXXX3123",
                  "bankAccountFunction": 3,
                  "bankAccountHolderName": "Herman's Coatings LLC",
                  "bankAccountHolderType": "Business",
                  "bankName": "First Miami Bank",
                  "id": 987,
                  "nickname": "Remittance Account",
                  "routingAccount": "123123123",
                  "typeAccount": "Checking",
                  "accountId": "123-100"
                }
              ],
              "bcity": "Miami",
              "bcountry": "US",
              "boardingLinkId": "bl_123456",
              "bstate": "FL",
              "bsummary": "Commercial and industrial coating services, including protective and decorative coatings",
              "btype": "Limited Liability Company",
              "bzip": "33101",
              "contacts": [
                {
                  "contactEmail": "herman@hermanscoatings.com",
                  "contactName": "Herman Martinez",
                  "contactPhone": "3055550000",
                  "contactTitle": "Owner"
                }
              ],
              "dbaname": "Herman's Coatings",
              "ein": "123456789",
              "faxnumber": "3055550001",
              "highticketamt": 15000,
              "legalname": "Herman's Coatings LLC",
              "license": "FL123456",
              "licstate": "FL",
              "maddress": "789 Industrial Parkway",
              "maddress1": "Unit 12",
              "mcc": "1799",
              "mcity": "Miami",
              "mcountry": "US",
              "mstate": "FL",
              "mzip": "33101",
              "orgId": 123,
              "ownership": [
                {
                  "oaddress": "123 Palm Avenue",
                  "ocity": "Miami",
                  "ocountry": "US",
                  "odriverstate": "FL",
                  "ostate": "FL",
                  "ownerdob": "05/15/1980",
                  "ownerdriver": "FL789456",
                  "owneremail": "herman@hermanscoatings.com",
                  "ownername": "Herman Martinez",
                  "ownerpercent": 100,
                  "ownerphone1": "3055550000",
                  "ownerphone2": "3055550002",
                  "ownerssn": "123456789",
                  "ownertitle": "Owner",
                  "ozip": "33102"
                }
              ],
              "payoutAverageMonthlyVolume": 50000,
              "payoutAverageTicketAmount": 500,
              "payoutCreditLimit": 25000,
              "payoutHighTicketAmount": 15000,
              "phonenumber": "3055550000",
              "recipientEmail": "herman@hermanscoatings.com",
              "recipientEmailNotification": true,
              "resumable": true,
              "signer": {
                "address": "33 North St",
                "address1": "STE 900",
                "city": "Bristol",
                "country": "US",
                "dob": "01/01/1976",
                "email": "test@email.com",
                "name": "John Smith",
                "phone": "555888111",
                "ssn": "123456789",
                "state": "TN",
                "zip": "55555",
                "pciAttestation": true,
                "signedDocumentReference": "https://example.com/signed-document.pdf",
                "attestationDate": "04/20/2025",
                "signDate": "04/20/2025",
                "additionalData": "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}"
              },
              "startdate": "01/01/2015",
              "taxfillname": "Herman's Coatings LLC",
              "templateId": 22,
              "website": "www.hermanscoatings.com"
            }
            """;

        const string mockResponse = """
            {
              "isSuccess": true,
              "responseCode": 1,
              "responseData": 3625,
              "responseText": "Success"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/Boarding/app")
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

        var response = await Client.Boarding.AddApplicationAsync(
            new ApplicationDataOdp
            {
                Services = new Services
                {
                    Ach = new AchSetup
                    {
                        AcceptCcd = true,
                        AcceptPpd = true,
                        AcceptWeb = true,
                    },
                    Card = new CardSetup
                    {
                        AcceptAmex = true,
                        AcceptDiscover = true,
                        AcceptMastercard = true,
                        AcceptVisa = true,
                    },
                    Odp = new OdpSetup
                    {
                        AllowAch = false,
                        AllowChecks = false,
                        AllowVCard = false,
                    },
                },
                AnnualRevenue = 750000,
                Attachments = new List<FileContent>() { new FileContent(), new FileContent() },
                Baddress = "789 Industrial Parkway",
                Baddress1 = "Unit 12",
                BankData = new List<Bank>()
                {
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3100",
                        BankAccountFunction = 1,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Id = 123,
                        Nickname = "Withdrawal Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-789",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3200",
                        BankAccountFunction = 0,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Id = 456,
                        Nickname = "Deposit Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-456",
                    },
                    new Bank
                    {
                        AccountNumber = "1XXXXXX3123",
                        BankAccountFunction = 3,
                        BankAccountHolderName = "Herman's Coatings LLC",
                        BankAccountHolderType = BankAccountHolderType.Business,
                        BankName = "First Miami Bank",
                        Id = 987,
                        Nickname = "Remittance Account",
                        RoutingAccount = "123123123",
                        TypeAccount = TypeAccount.Checking,
                        AccountId = "123-100",
                    },
                },
                Bcity = "Miami",
                Bcountry = "US",
                BoardingLinkId = "bl_123456",
                Bstate = "FL",
                Bsummary =
                    "Commercial and industrial coating services, including protective and decorative coatings",
                Btype = OwnType.LimitedLiabilityCompany,
                Bzip = "33101",
                Contacts = new List<ApplicationDataOdpContactsItem>()
                {
                    new ApplicationDataOdpContactsItem
                    {
                        ContactEmail = "herman@hermanscoatings.com",
                        ContactName = "Herman Martinez",
                        ContactPhone = "3055550000",
                        ContactTitle = "Owner",
                    },
                },
                Dbaname = "Herman's Coatings",
                Ein = "123456789",
                Faxnumber = "3055550001",
                Highticketamt = 15000,
                Legalname = "Herman's Coatings LLC",
                License = "FL123456",
                Licstate = "FL",
                Maddress = "789 Industrial Parkway",
                Maddress1 = "Unit 12",
                Mcc = "1799",
                Mcity = "Miami",
                Mcountry = "US",
                Mstate = "FL",
                Mzip = "33101",
                OrgId = 123,
                Ownership = new List<ApplicationDataOdpOwnershipItem>()
                {
                    new ApplicationDataOdpOwnershipItem
                    {
                        Oaddress = "123 Palm Avenue",
                        Ocity = "Miami",
                        Ocountry = "US",
                        Odriverstate = "FL",
                        Ostate = "FL",
                        Ownerdob = "05/15/1980",
                        Ownerdriver = "FL789456",
                        Owneremail = "herman@hermanscoatings.com",
                        Ownername = "Herman Martinez",
                        Ownerpercent = 100,
                        Ownerphone1 = "3055550000",
                        Ownerphone2 = "3055550002",
                        Ownerssn = "123456789",
                        Ownertitle = "Owner",
                        Ozip = "33102",
                    },
                },
                PayoutAverageMonthlyVolume = 50000,
                PayoutAverageTicketAmount = 500,
                PayoutCreditLimit = 25000,
                PayoutHighTicketAmount = 15000,
                Phonenumber = "3055550000",
                RecipientEmail = "herman@hermanscoatings.com",
                RecipientEmailNotification = true,
                Resumable = true,
                Signer = new SignerDataRequest
                {
                    Address = "33 North St",
                    Address1 = "STE 900",
                    City = "Bristol",
                    Country = "US",
                    Dob = "01/01/1976",
                    Email = "test@email.com",
                    Name = "John Smith",
                    Phone = "555888111",
                    Ssn = "123456789",
                    State = "TN",
                    Zip = "55555",
                    PciAttestation = true,
                    SignedDocumentReference = "https://example.com/signed-document.pdf",
                    AttestationDate = "04/20/2025",
                    SignDate = "04/20/2025",
                    AdditionalData =
                        "{\"deviceId\":\"499585-389fj484-3jcj8hj3\",\"session\":\"fifji4-fiu443-fn4843\",\"timeWithCompany\":\"6 Years\"}",
                },
                Startdate = "01/01/2015",
                Taxfillname = "Herman's Coatings LLC",
                TemplateId = 22,
                Website = "www.hermanscoatings.com",
            }
        );
        Assert.That(
            response,
            Is.EqualTo(
                    JsonUtils.Deserialize<PayabliApiResponse00Responsedatanonobject>(mockResponse)
                )
                .UsingDefaults()
        );
    }
}
