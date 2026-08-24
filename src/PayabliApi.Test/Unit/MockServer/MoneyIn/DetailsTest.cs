using NUnit.Framework;
using PayabliApi.Test.Unit.MockServer;
using PayabliApi.Test.Utils;

namespace PayabliApi.Test.Unit.MockServer.MoneyIn;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "BatchAmount": 10050.75,
              "BatchNumber": "BN987654321",
              "CfeeTransactions": [
                {
                  "cFeeTransid": "cFeeTransid",
                  "feeAmount": 1.1,
                  "operation": "operation",
                  "refundId": 4440,
                  "responseData": {
                    "key": "value"
                  },
                  "settlementStatus": 1,
                  "transactionTime": "2024-01-15T09:30:00.000Z",
                  "transStatus": 1
                }
              ],
              "Customer": {
                "AdditionalData": {
                  "key1": "value1",
                  "key2": "value2",
                  "key3": "value3"
                },
                "BillingAddress1": "123 Willow Lane",
                "BillingAddress2": "Unit 101",
                "BillingCity": "Greenfield",
                "BillingCountry": "USA",
                "BillingEmail": "elizabeta.marion@email.com",
                "BillingPhone": "831-555-0123",
                "BillingState": "CA",
                "BillingZip": "93927",
                "customerId": 4440,
                "CustomerNumber": "C-90010",
                "customerStatus": 1,
                "FirstName": "Elizabeta",
                "Identifiers": [
                  "\\\"firstname\\\"",
                  "\\\"lastname\\\"",
                  "\\\"email\\\"",
                  "\\\"customId\\\""
                ],
                "LastName": "Marion",
                "ShippingAddress1": "123 Willow Lane",
                "ShippingAddress2": "Unit 101",
                "ShippingCity": "Greenfield",
                "ShippingCountry": "USA",
                "ShippingState": "CA",
                "ShippingZip": "93927"
              },
              "EntrypageId": 0,
              "ExternalProcessorInformation": "[MER_xxxxxxxxxxxxxx]/[NNNNNNNNN]",
              "FeeAmount": 5,
              "GatewayTransId": "GT12345678",
              "invoiceData": {
                "company": "Wind in the Willows Neighborhood Association, LLC",
                "discount": 0,
                "dutyAmount": 0,
                "firstName": "Elizabeta",
                "freightAmount": 0,
                "frequency": "onetime",
                "invoiceAmount": 1000.5,
                "invoiceDate": "2025-02-15",
                "invoiceDueDate": "2025-03-15",
                "invoiceEndDate": "2025-04-15",
                "invoiceNumber": "INV-2345",
                "invoiceStatus": 1,
                "invoiceType": 1,
                "items": [
                  {
                    "itemCategories": [
                      "HOA Dues",
                      "Annual Service"
                    ],
                    "itemCommodityCode": "200300",
                    "itemCost": 1000.5,
                    "itemDescription": "Annual dues for Wind in the Willows HOA.",
                    "itemMode": 1,
                    "itemProductCode": "HOADUES2024",
                    "itemProductName": "HOA Annual Dues",
                    "itemQty": 1,
                    "itemTaxAmount": 0,
                    "itemTaxRate": 0,
                    "itemTotalAmount": 1000.5,
                    "itemUnitOfMeasure": "service"
                  }
                ],
                "lastName": "Marion",
                "notes": "Annual HOA dues for Wind in the Willows Neighborhood.",
                "paymentTerms": "NET30",
                "purchaseOrder": "PO-4321ABC",
                "shippingAddress1": "123 Willow Lane",
                "shippingAddress2": "Unit 101",
                "shippingCity": "Greenfield",
                "shippingCountry": "USA",
                "shippingEmail": "elizabeta.marion@email.com",
                "shippingFromZip": "93926",
                "shippingPhone": "831-555-0123",
                "shippingState": "CA",
                "shippingZip": "93927",
                "summaryCommodityCode": "HOA2024",
                "tax": 0,
                "termsConditions": "Full payment of HOA dues required within 30 days."
              },
              "Method": "online",
              "NetAmount": 995.5,
              "Operation": "Sale",
              "OrderId": "DUES-123",
              "OrgId": 123,
              "ParentOrgName": "HOAManager Pro",
              "PaymentData": {
                "AccountExp": "11/29",
                "AccountType": "visa",
                "AccountZip": "90210",
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
                "HolderName": "Elizabeta Marion",
                "Initiator": "merchant",
                "MaskedAccount": "5xxxxxxxxxxx4321",
                "orderDescription": "Annual HOA Dues for Wind in the Willows",
                "paymentDetails": {
                  "categories": [
                    {
                      "amount": 1000,
                      "label": "Deposit"
                    },
                    {
                      "amount": 1000,
                      "label": "Deposit"
                    }
                  ],
                  "currency": "USD",
                  "serviceFee": 5,
                  "splitFunding": [
                    {}
                  ],
                  "totalAmount": 1000.5
                },
                "Sequence": "first",
                "SignatureData": "image/png;base64,",
                "StoredMethodUsageType": "unscheduled"
              },
              "PaymentTransId": "12345-67890abcd",
              "PayorId": 98765,
              "PaypointDbaname": "Wind in the Willows",
              "PaypointEntryname": "72aeon12",
              "PaypointId": 3040,
              "PaypointLegalname": "Wind in the Willows Neighborhood Association, LLC",
              "PendingFeeAmount": 0,
              "RefundId": 0,
              "ResponseData": {
                "authcode": "123456",
                "avsresponse": "N",
                "avsresponse_text": "No address or ZIP match only",
                "cvvresponse": "M",
                "cvvresponse_text": "CVV2/CVC2 match",
                "orderid": "10-bfcd5a17861d4a8690ca53c00000X",
                "response": "Success",
                "response_code": "100",
                "response_code_text": "Transaction was approved.",
                "responsetext": "SUCCESS",
                "resultCode": "A0000",
                "resultCodeText": "Approved",
                "transactionid": "8082800000"
              },
              "ReturnedId": 0,
              "ScheduleReference": 0,
              "SettlementStatus": 1,
              "Source": "web",
              "splitCount": 0,
              "TotalAmount": 1000.5,
              "TransactionEvents": [
                {
                  "EventTime": "2024-01-23T00:46:05.000Z",
                  "TransEvent": "Created"
                },
                {
                  "EventData": "response=1&responsetext=Approved&authcode=123456&transactionid=9144440&avsresponse=&cvvresponse=&orderid=434-38aXXXX8ae4cd496db737200000000&type=sale&response_code=100&verification_method=&emv_application_id=A0000000031000&emv_application_label=VISA&emv_application_preferred_name=&emv_application_pan_sequence_number=00&transaction_status_information=&masked_merchant_number=xxxxxxxx9100&masked_terminal_number=xx01",
                  "EventTime": "2024-01-23T00:46:17.000Z",
                  "TransEvent": "Approved"
                },
                {
                  "EventData": {
                    "action_type": "settle",
                    "amount": 1000.5,
                    "api_method": "",
                    "batch_id": "68031555",
                    "date": "20240123013414",
                    "device_license_number": "",
                    "device_nickname": "",
                    "ip_address": "100.100.100.100",
                    "processor_batch_id": "680317555",
                    "processor_response_code": "",
                    "processor_response_text": "",
                    "requested_amountSpecified": false,
                    "response_code": "100",
                    "response_text": "SUCCESS",
                    "source": "internal",
                    "success": 1,
                    "username": " "
                  },
                  "EventTime": "2024-01-23T01:34:14.000Z",
                  "TransEvent": "Settled"
                }
              ],
              "TransactionTime": "2024-02-15T10:30:00.000Z",
              "TransStatus": 2
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/details/45-as456777hhhhhhhhhh77777777-324")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.DetailsAsync("45-as456777hhhhhhhhhh77777777-324");
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "ParentOrgName": "Riverside Pet Supply",
              "PaypointDbaname": "Riverside Pet Store",
              "PaypointLegalname": "Riverside Pet Store",
              "PaypointEntryname": "495147f647",
              "PaypointId": 3040,
              "PaymentTransId": "3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae",
              "ConnectorName": "FV",
              "GatewayTransId": "020080b14c2541444bc985621033c1b7ccda",
              "Method": "device",
              "DeviceId": "499585-389fj484-3jcj8hj3",
              "OrderId": "",
              "Operation": "Sale",
              "Source": "api",
              "PayorId": 4440,
              "TotalAmount": 100,
              "NetAmount": 100,
              "FeeAmount": 0,
              "PendingFeeAmount": 0,
              "BatchAmount": 100,
              "BatchNumber": "3040_device_20260401_1a2b3c4d",
              "SettlementStatus": 0,
              "TransStatus": 1,
              "ScheduleReference": 0,
              "RefundId": 0,
              "ReturnedId": 0,
              "splitCount": 0,
              "PaymentData": {
                "MaskedAccount": "4xxxxxxxxxxx1111",
                "AccountType": "visa",
                "AccountExp": "07/28",
                "HolderName": "",
                "paymentDetails": {
                  "totalAmount": 100,
                  "serviceFee": 0,
                  "currency": "USD",
                  "categories": [],
                  "splitFunding": []
                }
              },
              "ResponseData": {
                "resultCode": "A0000",
                "resultCodeText": "Approved",
                "responsetext": "Approved",
                "authcode": "OK2576",
                "transactionid": "020080b14c2541444bc985621033c1b7ccda",
                "response_code": "100",
                "response_code_text": "Operation successful"
              },
              "Customer": {
                "customerId": 4440,
                "CustomerNumber": "C-90010",
                "FirstName": "Elizabeta",
                "LastName": "Marion",
                "BillingEmail": "elizabeta.marion@email.com",
                "customerStatus": 1
              },
              "TransactionEvents": [
                {
                  "TransEvent": "Created",
                  "EventTime": "2026-04-09T14:49:39.000Z"
                },
                {
                  "TransEvent": "Initiated",
                  "EventTime": "2026-04-09T14:49:39.000Z"
                },
                {
                  "TransEvent": "Approved",
                  "EventTime": "2026-04-09T14:49:44.000Z"
                }
              ],
              "TransactionTime": "2026-04-09T14:49:44.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/MoneyIn/details/3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae")
                    .WithHeader("Authorization", "*")
                    .WithHeader("requestToken", "*", WireMock.Matchers.MatchBehaviour.RejectOnMatch)
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyIn.DetailsAsync("3040-96dfa9a7c4ed4f82a3dd4a4a12ad28ae");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
