using System.Text.Json;
using NUnit.Framework;
using PayabliApi;
using PayabliApi.Core;

namespace PayabliApi.Test;

[TestFixture]
public class SignerDataTest
{
    [NUnit.Framework.Test]
    public void TestDeserialization()
    {
        var json = """
            {
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
            }
            """;
        var expectedObject = new SignerData
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
        };
        var deserializedObject = JsonUtils.Deserialize<SignerData>(json);
        Assert.That(deserializedObject, Is.EqualTo(expectedObject).UsingDefaults());
    }

    [NUnit.Framework.Test]
    public void TestSerialization()
    {
        var expectedJson = """
            {
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
            }
            """;
        var actualObj = new SignerData
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
        };
        var actualElement = JsonUtils.SerializeToElement(actualObj);
        var expectedElement = JsonUtils.Deserialize<JsonElement>(expectedJson);
        Assert.That(actualElement, Is.EqualTo(expectedElement).UsingJsonElementComparer());
    }
}
