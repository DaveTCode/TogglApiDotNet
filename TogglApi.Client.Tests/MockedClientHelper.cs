using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using NLog;
using TogglApi.Client.General;

namespace TogglApi.Client.Tests
{
    internal static class MockedClientHelper
    {
        internal static async Task<(TogglWorkspaceClient, Mock<HttpMessageHandler>)> CreateMockedClient(ILogger log, string responseFile)
        {
            var fileContents = await File.ReadAllTextAsync(Path.Combine("responses", responseFile));

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(fileContents)
                })
                .Verifiable();
 
            var httpClient = new HttpClient(handlerMock.Object);
 
            return (new TogglWorkspaceClient(httpClient, log), handlerMock);
        }

        internal static void ValidateUrlRequest(string url, Mock<HttpMessageHandler> handlerMock)
        {
            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri.AbsoluteUri.StartsWith(url)
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
