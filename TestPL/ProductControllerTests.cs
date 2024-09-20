using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace AspNetWeb_Product.Tests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<AspNetWeb_Product.Program>>
    {
        private readonly HttpClient client;

        public ProductControllerTests(WebApplicationFactory<AspNetWeb_Product.Program> factory)
        {
            client = factory.CreateClient();
        }

        [Fact(DisplayName = "1 get response Ok(\"ProductItem\") for testing launch")]
        public async Task GetResponce_ResponceOkString()
        {
            //Arrange
            var responce = await client.GetAsync("/api/ProductItem/check");

            //Act
            responce.EnsureSuccessStatusCode();
            var content = await responce.Content.ReadAsStringAsync();

            //Assert
            Assert.NotNull(content);
            Assert.Equal("productitem", content.ToLower());
        }
    }

}
