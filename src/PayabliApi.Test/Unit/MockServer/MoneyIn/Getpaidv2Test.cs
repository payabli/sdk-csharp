using NUnit.Framework;
using PayabliApi;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class Getpaidv2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "cardcvv": "999",
                "cardexp": "02/27",
                "cardHolder": "John Cassian",
                "cardnumber": "4111111111111111",
                "cardzip": "12345",
                "initiator": "payor",
                "method": "card"
              }
            }
            """;

        const string mockResponse = """
            {
              "code": "A0000",
              "reason": "Approved",
              "explanation": "Transaction approved",
              "action": "No action required",
              "data": {
                "parentOrgName": "Mrinal's Pet Supplies",
                "paypointDbaname": "Mrinal's Pet Shop North",
                "paypointLegalname": "Mrinal's Pet Shop North",
                "paypointEntryname": "495147f647",
                "paymentTransId": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                "connectorName": "gp",
                "externalProcessorInformation": "",
                "gatewayTransId": "TRN_Ih68D6UZdip7OEQ2QFXat1yQSLF2nB",
                "method": "card",
                "batchNumber": "3040_combined_20251201_3a50747d-6b5c-40ef-9f69-93a9cc7fcb49",
                "batchAmount": 420,
                "payorId": 4440,
                "paymentData": {
                  "maskedAccount": "4XXXXXXXXXXX5439",
                  "accountType": "visa",
                  "accountExp": "12/25",
                  "holderName": "John Cassian",
                  "orderDescription": "",
                  "binData": {
                    "binMatchedLength": "6",
                    "binCardBrand": "VISA",
                    "binCardType": "CREDIT",
                    "binCardCategory": "CLASSIC",
                    "binCardIssuer": "",
                    "binCardIssuerCountry": "RUSSIAN FEDERATION",
                    "binCardIssuerCountryCodeA2": "RU",
                    "binCardIssuerCountryNumber": "643",
                    "binCardIsRegulated": "",
                    "binCardUseCategory": "",
                    "binCardIssuerCountryCodeA3": ""
                  },
                  "paymentDetails": {
                    "totalAmount": 105,
                    "serviceFee": 5,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
                },
                "transStatus": 1,
                "paypointId": 3040,
                "totalAmount": 105,
                "netAmount": 100,
                "feeAmount": 5,
                "settlementStatus": 0,
                "operation": "Sale",
                "responseData": {
                  "resultCode": "A0000",
                  "resultCodeText": "Approved",
                  "responsetext": "CAPTURED",
                  "authcode": "AXS425",
                  "transactionid": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                  "avsresponse": "N",
                  "avsresponse_text": "No Match, No address or ZIP match",
                  "cvvresponse": "M",
                  "cvvresponse_text": "CVV2/CVC2 match",
                  "response_code": "100",
                  "response_code_text": "Operation successful"
                },
                "source": "api",
                "scheduleReference": 0,
                "orgId": 123,
                "refundId": 0,
                "returnedId": 0,
                "chargebackId": 0,
                "retrievalId": 0,
                "invoiceData": {},
                "entrypageId": 0,
                "externalPaypointID": "",
                "isValidatedACH": false,
                "transactionTime": "2025-12-01T09:50:03.559",
                "customer": {
                  "firstName": "David",
                  "lastName": "Beckham",
                  "companyName": "Driving School LLC",
                  "billingAddress1": "Home Address",
                  "billingAddress2": "",
                  "billingCity": "",
                  "billingState": "",
                  "billingZip": "45157",
                  "billingCountry": "US",
                  "billingPhone": "+15555555555",
                  "billingEmail": "example@payabli.com",
                  "customerNumber": "C-90010",
                  "shippingAddress1": "Home Address",
                  "shippingAddress2": "",
                  "shippingCity": "",
                  "shippingState": "",
                  "shippingZip": "45157",
                  "shippingCountry": "US",
                  "customerId": 4440,
                  "customerStatus": 0
                },
                "cfeeTransactions": [
                  {
                    "cFeeTransid": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                    "transStatus": 1,
                    "feeAmount": 5,
                    "settlementStatus": 0,
                    "operation": "Sale",
                    "responseData": {},
                    "refundId": 0,
                    "transactionTime": "2025-12-01T09:50:03.559Z"
                  }
                ],
                "transactionEvents": [
                  {
                    "transEvent": "Created",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:02.558651"
                  },
                  {
                    "transEvent": "Approved",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:03.609111"
                  }
                ],
                "pendingFeeAmount": 0,
                "riskFlagged": false,
                "riskFlaggedOn": "2025-12-01T09:50:02.547Z",
                "riskStatus": "PASSED",
                "riskReason": "",
                "riskAction": "",
                "riskActionCode": 0,
                "deviceId": "",
                "achSecCode": "",
                "achHolderType": "personal",
                "ipAddress": "255.255.255.255",
                "isSameDayACH": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.Getpaidv2Async(
            new RequestPaymentV2
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCredit
                    {
                        Cardcvv = "999",
                        Cardexp = "02/27",
                        CardHolder = "John Cassian",
                        Cardnumber = "4111111111111111",
                        Cardzip = "12345",
                        Initiator = "payor",
                        Method = PayMethodCreditMethod.Card,
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
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "initiator": "payor",
                "method": "card",
                "storedMethodId": "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                "storedMethodUsageType": "unscheduled"
              }
            }
            """;

        const string mockResponse = """
            {
              "code": "A0000",
              "reason": "Approved",
              "explanation": "Transaction approved",
              "action": "No action required",
              "data": {
                "parentOrgName": "Mrinal's Pet Supplies",
                "paypointDbaname": "Mrinal's Pet Shop North",
                "paypointLegalname": "Mrinal's Pet Shop North",
                "paypointEntryname": "495147f647",
                "paymentTransId": "3040-9708542b00354726ad8a6b0c65bc7a54",
                "connectorName": "gp",
                "externalProcessorInformation": "",
                "gatewayTransId": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                "method": "card",
                "batchNumber": "3040_combined_20251201_3a50747d-6b5c-40ef-9f69-93a9cc7fcb49",
                "batchAmount": 630,
                "payorId": 4440,
                "paymentData": {
                  "maskedAccount": "3XXXXXXXXXX0227",
                  "accountType": "amex",
                  "accountExp": "12/25",
                  "holderName": "Alexa Amazon",
                  "storedId": "fb1f5ec2-1ba4-4ba6-9839-20c2cc4baf5a-4440",
                  "initiator": "merchant",
                  "storedMethodUsageType": "unscheduled",
                  "sequence": "subsequent",
                  "orderDescription": "",
                  "binData": {
                    "binMatchedLength": "",
                    "binCardBrand": "",
                    "binCardType": "",
                    "binCardCategory": "",
                    "binCardIssuer": "",
                    "binCardIssuerCountry": "",
                    "binCardIssuerCountryCodeA2": "",
                    "binCardIssuerCountryNumber": "",
                    "binCardIsRegulated": "",
                    "binCardUseCategory": "",
                    "binCardIssuerCountryCodeA3": ""
                  },
                  "paymentDetails": {
                    "totalAmount": 105,
                    "serviceFee": 5,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
                },
                "transStatus": 1,
                "paypointId": 3040,
                "totalAmount": 105,
                "netAmount": 100,
                "feeAmount": 5,
                "settlementStatus": 0,
                "operation": "Sale",
                "responseData": {
                  "resultCode": "A0000",
                  "resultCodeText": "Approved",
                  "responsetext": "CAPTURED",
                  "authcode": "AXS425",
                  "transactionid": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                  "avsresponse": "N",
                  "avsresponse_text": "No Match, No address or ZIP match",
                  "cvvresponse": "M",
                  "cvvresponse_text": "CVV2/CVC2 match",
                  "response_code": "100",
                  "response_code_text": "Operation successful"
                },
                "source": "api",
                "scheduleReference": 0,
                "orgId": 123,
                "refundId": 0,
                "returnedId": 0,
                "chargebackId": 0,
                "retrievalId": 0,
                "invoiceData": {},
                "entrypageId": 0,
                "externalPaypointID": "",
                "isValidatedACH": false,
                "transactionTime": "2025-12-01T09:56:33.967",
                "customer": {
                  "firstName": "David",
                  "lastName": "Beckham",
                  "companyName": "Driving School LLC",
                  "billingAddress1": "Home Address",
                  "billingAddress2": "",
                  "billingCity": "",
                  "billingState": "",
                  "billingZip": "45157",
                  "billingCountry": "US",
                  "billingPhone": "+15555555555",
                  "billingEmail": "example@payabli.com",
                  "customerNumber": "C-90010",
                  "shippingAddress1": "Home Address",
                  "shippingAddress2": "",
                  "shippingCity": "",
                  "shippingState": "",
                  "shippingZip": "45157",
                  "shippingCountry": "US",
                  "customerId": 4440,
                  "customerStatus": 0
                },
                "cfeeTransactions": [
                  {
                    "cFeeTransid": "3040-9708542b00354726ad8a6b0c65bc7a54",
                    "transStatus": 1,
                    "feeAmount": 5,
                    "settlementStatus": 0,
                    "operation": "Sale",
                    "responseData": {},
                    "refundId": 0,
                    "transactionTime": "2025-12-01T09:56:33.967Z"
                  }
                ],
                "transactionEvents": [
                  {
                    "transEvent": "Created",
                    "eventData": "0HNHD68HATSUR:00000004",
                    "eventTime": "2025-12-01T09:56:32.662988"
                  },
                  {
                    "transEvent": "Approved",
                    "eventData": "0HNHD68HATSUR:00000004",
                    "eventTime": "2025-12-01T09:56:34.027504"
                  }
                ],
                "pendingFeeAmount": 0,
                "riskFlagged": false,
                "riskFlaggedOn": "2025-12-01T09:56:32.652Z",
                "riskStatus": "PASSED",
                "riskReason": "",
                "riskAction": "",
                "riskActionCode": 0,
                "deviceId": "",
                "achSecCode": "",
                "achHolderType": "personal",
                "ipAddress": "255.255.255.255",
                "isSameDayACH": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.Getpaidv2Async(
            new RequestPaymentV2
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodStoredMethod
                    {
                        Initiator = "payor",
                        Method = PayMethodStoredMethodMethod.Card,
                        StoredMethodId = "1ec55af9-7b5a-4ff0-81ed-c12d2f95e135-4440",
                        StoredMethodUsageType = "unscheduled",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "achAccount": "123123123",
                "achAccountType": "Checking",
                "achCode": "WEB",
                "achHolder": "John Cassian",
                "achHolderType": "personal",
                "achRouting": "123123123",
                "method": "ach"
              }
            }
            """;

        const string mockResponse = """
            {
              "code": "A0000",
              "reason": "Approved",
              "explanation": "Transaction approved",
              "action": "No action required",
              "data": {
                "parentOrgName": "Mountain View Services",
                "paypointDbaname": "Mountain View Auto",
                "paypointLegalname": "Mountain View Automotive Services LLC",
                "paypointEntryname": "31ae451b89",
                "paymentTransId": "2145-7b8fa3c9d5e64f73b2ee5a6b14bd39cd",
                "connectorName": "checkcommerce",
                "externalProcessorInformation": "",
                "gatewayTransId": "ACH_TRN_8K92D7VZexp8PFR3RGYbu2zRTMG3oC",
                "method": "ach",
                "batchNumber": "checkcommerce_2145_ach_12-01-2025",
                "batchAmount": 525,
                "payorId": 38267,
                "paymentData": {
                  "maskedAccount": "XXXXX4532",
                  "accountType": "Checking",
                  "holderName": "Sarah Martinez",
                  "orderDescription": "",
                  "paymentDetails": {
                    "totalAmount": 105,
                    "serviceFee": 5,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
                },
                "transStatus": 1,
                "paypointId": 3040,
                "totalAmount": 105,
                "netAmount": 100,
                "feeAmount": 5,
                "settlementStatus": 0,
                "operation": "Sale",
                "responseData": {
                  "resultCode": "A0000",
                  "resultCodeText": "Approved",
                  "responsetext": "CAPTURED",
                  "authcode": "AXS425",
                  "transactionid": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                  "avsresponse": "N",
                  "avsresponse_text": "No Match, No address or ZIP match",
                  "cvvresponse": "M",
                  "cvvresponse_text": "CVV2/CVC2 match",
                  "response_code": "100",
                  "response_code_text": "Operation successful"
                },
                "source": "api",
                "scheduleReference": 0,
                "orgId": 123,
                "refundId": 0,
                "returnedId": 0,
                "chargebackId": 0,
                "retrievalId": 0,
                "invoiceData": {},
                "entrypageId": 0,
                "externalPaypointID": "",
                "isValidatedACH": true,
                "transactionTime": "2025-12-01T10:15:28.742",
                "customer": {
                  "firstName": "Sarah",
                  "lastName": "Martinez",
                  "companyName": "Martinez Consulting",
                  "billingAddress1": "456 Oak Avenue",
                  "billingAddress2": "Suite 201",
                  "billingCity": "Portland",
                  "billingState": "OR",
                  "billingZip": "97201",
                  "billingCountry": "US",
                  "billingPhone": "+15035551234",
                  "billingEmail": "sarah.martinez@example.com",
                  "customerNumber": "C-90010",
                  "shippingAddress1": "456 Oak Avenue",
                  "shippingAddress2": "Suite 201",
                  "shippingCity": "Portland",
                  "shippingState": "OR",
                  "shippingZip": "97201",
                  "shippingCountry": "US",
                  "customerId": 4440,
                  "customerStatus": 0
                },
                "cfeeTransactions": [
                  {
                    "cFeeTransid": "2145-7b8fa3c9d5e64f73b2ee5a6b14bd39cd",
                    "transStatus": 1,
                    "feeAmount": 5,
                    "settlementStatus": 0,
                    "operation": "Sale",
                    "responseData": {},
                    "refundId": 0,
                    "transactionTime": "2025-12-01T10:15:28.742Z"
                  }
                ],
                "transactionEvents": [
                  {
                    "transEvent": "Created",
                    "eventData": "0HNHD69JBVWXP:00000001",
                    "eventTime": "2025-12-01T10:15:27.682442"
                  },
                  {
                    "transEvent": "Approved",
                    "eventData": "0HNHD69JBVWXP:00000001",
                    "eventTime": "2025-12-01T10:15:28.751283"
                  }
                ],
                "pendingFeeAmount": 0,
                "riskFlagged": false,
                "riskFlaggedOn": "2025-12-01T10:15:27.671Z",
                "riskStatus": "PASSED",
                "riskReason": "",
                "riskAction": "",
                "riskActionCode": 0,
                "deviceId": "",
                "achSecCode": "WEB",
                "achHolderType": "personal",
                "ipAddress": "255.255.255.255",
                "isSameDayACH": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.Getpaidv2Async(
            new RequestPaymentV2
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodAch
                    {
                        AchAccount = "123123123",
                        AchAccountType = Achaccounttype.Checking,
                        AchCode = "WEB",
                        AchHolder = "John Cassian",
                        AchHolderType = AchHolderType.Personal,
                        AchRouting = "123123123",
                        Method = PayMethodAchMethod.Ach,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "customerData": {
                "customerId": 4440
              },
              "entryPoint": "8cfec329267",
              "ipaddress": "255.255.255.255",
              "paymentDetails": {
                "serviceFee": 0,
                "totalAmount": 100
              },
              "paymentMethod": {
                "device": "6c361c7d-674c-44cc-b790-382b75d1xxx",
                "method": "cloud",
                "saveIfSuccess": true
              }
            }
            """;

        const string mockResponse = """
            {
              "code": "A0000",
              "reason": "Approved",
              "explanation": "Transaction approved",
              "action": "No action required",
              "data": {
                "parentOrgName": "Mrinal's Pet Supplies",
                "paypointDbaname": "Mrinal's Pet Shop North",
                "paypointLegalname": "Mrinal's Pet Shop North",
                "paypointEntryname": "495147f647",
                "paymentTransId": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                "connectorName": "gp",
                "externalProcessorInformation": "",
                "gatewayTransId": "TRN_Ih68D6UZdip7OEQ2QFXat1yQSLF2nB",
                "method": "card",
                "batchNumber": "3040_combined_20251201_3a50747d-6b5c-40ef-9f69-93a9cc7fcb49",
                "batchAmount": 420,
                "payorId": 4440,
                "paymentData": {
                  "maskedAccount": "4XXXXXXXXXXX5439",
                  "accountType": "visa",
                  "accountExp": "12/25",
                  "holderName": "John Cassian",
                  "orderDescription": "",
                  "binData": {
                    "binMatchedLength": "6",
                    "binCardBrand": "VISA",
                    "binCardType": "CREDIT",
                    "binCardCategory": "CLASSIC",
                    "binCardIssuer": "",
                    "binCardIssuerCountry": "RUSSIAN FEDERATION",
                    "binCardIssuerCountryCodeA2": "RU",
                    "binCardIssuerCountryNumber": "643",
                    "binCardIsRegulated": "",
                    "binCardUseCategory": "",
                    "binCardIssuerCountryCodeA3": ""
                  },
                  "paymentDetails": {
                    "totalAmount": 105,
                    "serviceFee": 5,
                    "checkUniqueId": "",
                    "currency": "USD",
                    "categories": [],
                    "splitFunding": []
                  }
                },
                "transStatus": 1,
                "paypointId": 3040,
                "totalAmount": 105,
                "netAmount": 100,
                "feeAmount": 5,
                "settlementStatus": 0,
                "operation": "Sale",
                "responseData": {
                  "resultCode": "A0000",
                  "resultCodeText": "Approved",
                  "responsetext": "CAPTURED",
                  "authcode": "AXS425",
                  "transactionid": "TRN_Xo4dpKfmx3OxSc9svd2ccI6OOnyB2I",
                  "avsresponse": "N",
                  "avsresponse_text": "No Match, No address or ZIP match",
                  "cvvresponse": "M",
                  "cvvresponse_text": "CVV2/CVC2 match",
                  "response_code": "100",
                  "response_code_text": "Operation successful"
                },
                "source": "api",
                "scheduleReference": 0,
                "orgId": 123,
                "refundId": 0,
                "returnedId": 0,
                "chargebackId": 0,
                "retrievalId": 0,
                "invoiceData": {},
                "entrypageId": 0,
                "externalPaypointID": "",
                "isValidatedACH": false,
                "transactionTime": "2025-12-01T09:50:03.559",
                "customer": {
                  "firstName": "David",
                  "lastName": "Beckham",
                  "companyName": "Driving School LLC",
                  "billingAddress1": "Home Address",
                  "billingAddress2": "",
                  "billingCity": "",
                  "billingState": "",
                  "billingZip": "45157",
                  "billingCountry": "US",
                  "billingPhone": "+15555555555",
                  "billingEmail": "example@payabli.com",
                  "customerNumber": "C-90010",
                  "shippingAddress1": "Home Address",
                  "shippingAddress2": "",
                  "shippingCity": "",
                  "shippingState": "",
                  "shippingZip": "45157",
                  "shippingCountry": "US",
                  "customerId": 4440,
                  "customerStatus": 0
                },
                "cfeeTransactions": [
                  {
                    "cFeeTransid": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
                    "transStatus": 1,
                    "feeAmount": 5,
                    "settlementStatus": 0,
                    "operation": "Sale",
                    "responseData": {},
                    "refundId": 0,
                    "transactionTime": "2025-12-01T09:50:03.559Z"
                  }
                ],
                "transactionEvents": [
                  {
                    "transEvent": "Created",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:02.558651"
                  },
                  {
                    "transEvent": "Approved",
                    "eventData": "0HNHD68HATSUC:00000001",
                    "eventTime": "2025-12-01T09:50:03.609111"
                  }
                ],
                "pendingFeeAmount": 0,
                "riskFlagged": false,
                "riskFlaggedOn": "2025-12-01T09:50:02.547Z",
                "riskStatus": "PASSED",
                "riskReason": "",
                "riskAction": "",
                "riskActionCode": 0,
                "deviceId": "",
                "achSecCode": "",
                "achHolderType": "personal",
                "ipAddress": "255.255.255.255",
                "isSameDayACH": false
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/MoneyIn/getpaid")
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

        var response = await Client.MoneyIn.Getpaidv2Async(
            new RequestPaymentV2
            {
                Body = new TransRequestBody
                {
                    CustomerData = new PayorDataRequest { CustomerId = 4440 },
                    EntryPoint = "8cfec329267",
                    Ipaddress = "255.255.255.255",
                    PaymentDetails = new PaymentDetail { ServiceFee = 0, TotalAmount = 100 },
                    PaymentMethod = new PayMethodCloud
                    {
                        Device = "6c361c7d-674c-44cc-b790-382b75d1xxx",
                        Method = PayMethodCloudMethod.Cloud,
                        SaveIfSuccess = true,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
