using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class AuthCapturePayoutResponseTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization_1()
    {
        var json = """
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
        var expectedObject = new AuthCapturePayoutResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new AuthCapturePayoutResponseData
            {
                AuthCode = null,
                ReferenceId = "129-219",
                ResultCode = 1,
                ResultText = "Authorized",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = 0,
                MethodReferenceId = null,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<AuthCapturePayoutResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_1()
    {
        var expectedJson = """
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
        var actualObj = new AuthCapturePayoutResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new AuthCapturePayoutResponseData
            {
                AuthCode = null,
                ReferenceId = "129-219",
                ResultCode = 1,
                ResultText = "Authorized",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = 0,
                MethodReferenceId = null,
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }

    [NUnit.Framework.Test]
    public void TestDeserialization_2()
    {
        var json = """
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
                "resultText": "Captured",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;
        var expectedObject = new AuthCapturePayoutResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new AuthCapturePayoutResponseData
            {
                AuthCode = null,
                ReferenceId = "129-219",
                ResultCode = 1,
                ResultText = "Captured",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = 0,
                MethodReferenceId = null,
            },
        };
        var deserializedObject = JsonUtils.Deserialize<AuthCapturePayoutResponse>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization_2()
    {
        var expectedJson = """
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
                "resultText": "Captured",
                "avsResponseText": null,
                "cvvResponseText": null,
                "customerId": 0,
                "methodReferenceId": null
              }
            }
            """;
        var actualObj = new AuthCapturePayoutResponse
        {
            ResponseCode = 1,
            PageIdentifier = null,
            RoomId = 0,
            IsSuccess = true,
            ResponseText = "Success",
            ResponseData = new AuthCapturePayoutResponseData
            {
                AuthCode = null,
                ReferenceId = "129-219",
                ResultCode = 1,
                ResultText = "Captured",
                AvsResponseText = null,
                CvvResponseText = null,
                CustomerId = 0,
                MethodReferenceId = null,
            },
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
