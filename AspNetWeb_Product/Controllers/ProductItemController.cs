using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.Common;

namespace AspNetWeb_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductService productServ;
        private readonly ILogger<ProductItemController> logger;

        public ProductItemController(IProductService productServ, ILogger<ProductItemController> logger)
        {
            this.productServ = productServ;
            this.logger = logger;
        }

        [HttpGet("all-productitems-dto", Name = "GetAllItemsDto")]
        public ActionResult<IEnumerable<ProductItemDto>> getAllItemsDto()
        {
            return Ok(productServ.getAllProductsDto());
        }

        [HttpGet("all-productitems", Name = "GetAllItems")]
        public ActionResult<IEnumerable<ProductItem>> getAllItems() 
        {
            return Ok(productServ.db.productItems.getAllItems());
        }

        [HttpGet("productitem", Name = "GetProductItem")]
        public ActionResult<ProductItem> getProductItem([FromQuery] string name)
        {
            return Ok(productServ.getProductItem(name));
        }

        [HttpGet("productorder", Name = "GetProductOrder")]
        public ActionResult<ProductItemOrder> getProductrder([FromQuery] string name, [FromBody] ClientProperty clientProps)
        {
            try
            {
                return Ok(productServ.getProductOrder(name, clientProps.cltTimeProps, clientProps.cltPayProps));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex);
            }
            catch (ProductItemException ex) 
            {
                return BadRequest(new ProductItemException(ex));
            }
        }
    }
}
