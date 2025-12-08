using NUnit.Framework;
using PayabliApi.Core;

namespace PayabliApi.Test.Unit.MockServer;

[TestFixture]
public class GetCheckImageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            "%PDF-1.7\n%����\n123 0 obj\n<</Linearized 1/L 123456/O 125/E 78901/N 1/T 123450/H [ 800 200]>>\nendobj\n\n124 0 obj\n<</DecodeParms<</Columns 4/Predictor 12>>/Filter/FlateDecode/ID[<AB123C4567EF890123456789ABCDEF01><12345678ABCDEF9876543210FEDCBA98>]/Index[123 100]/Info 122 0 R/Length 128/Prev 123450/Root 125 0 R/Size 223/Type/XRef/W[1 3 1]>>stream\nh�bbd```b``�\n\"x�a7�r�H~�����A�D���2����m�f��L`v6�H����D���J[@����H8�I��)0��q� XD��`��a���P�`�`��\"�A$������r���p�$�Ip������a� �"
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath(
                        "/MoneyOut/checkimage/check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf"
                    )
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.MoneyOut.GetCheckImageAsync(
            "check133832686289732320_01JKBNZ5P32JPTZY8XXXX000000.pdf"
        );
        Assert.That(response, Is.EqualTo(JsonUtils.Deserialize<string>(mockResponse)));
    }
}
