using FrontEndApi.Controllers;
using FrontEndApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace ApiEndPointTests
{
    public class FrontEndApiTest
    {
        private readonly FrontEndController _frontEndController;

        public FrontEndApiTest()
        {

            var httpClientRepoMock = new Mock<IHttpClientRepository>();
            httpClientRepoMock.Setup(x => x.GetAsync("http://localhost:5001/api/backend1")).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpClientRepoMock.Setup(x => x.GetAsync("http://localhost:5002/api/backend2")).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpClientRepoMock.Setup(x => x.PostAsync("http://localhost:5001/api/backend1", "test")).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));
            httpClientRepoMock.Setup(x => x.PostAsync("http://localhost:5002/api/backend2", "test")).ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK));

            _frontEndController = new FrontEndController(httpClientRepoMock.Object);

        }

        [Fact]
        public async Task FrontEndController_GetRequest_ReturnOKOnSuccess()
        {
            var result = await _frontEndController.Get();
            var okResult = (OkObjectResult)result;

            Assert.NotNull(result);
            Assert.True(okResult.StatusCode == (int?)HttpStatusCode.OK);


        }


        [Fact]
        public async Task FrontEndController_PostRequest_ReturnOKOnSuccess()
        {

            var result = await _frontEndController.Post("test");
            var okResult = (OkObjectResult)result;
            Assert.NotNull(result);
            Assert.True(okResult.StatusCode == (int?)HttpStatusCode.OK);


        }
    }
}