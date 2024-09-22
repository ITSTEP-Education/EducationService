using Asp.Versioning;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Net;

namespace AspNetWeb_Product.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductService productServ;
        private readonly ILogger<ProductItemController> logger;

        public ProductItemController(IProductService productServ, ILogger<ProductItemController> logger)
        {
            this.productServ = productServ;
            this.logger = logger;
        }

        ///<include file='../DocXML/ProductItemDocumentation.xml' path='docs/members[@name="controller"]/GetAllItemsDto/*'/>
        [MapToApiVersion("1.0")]
        [HttpGet("all-productitems-dto", Name = "GetAllItemsDto")]
        [ProducesResponseType(typeof(IEnumerable<ProductItemDto>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<ProductItemDto>> getAllItemsDto()
        {
            try
            {
                return Ok(productServ.getAllProductsDto());
            }
            catch (ProductItemException ex)
            {
                return BadRequest(new { msg = ex.Message, prop = ex.property });
            }
        }

        
        [MapToApiVersion("2.0")]
        [HttpGet("all-productitems", Name = "GetAllItems")]
        public ActionResult<IEnumerable<ProductItem>> getAllItems() 
        {
            try
            {
                return Ok(productServ.db.productItems.getAllItems());
            }
            catch ( DbException ex)
            {
                return BadRequest(new {msg = ex.Message, prop = ex.SqlState});
            }
        }

        [MapToApiVersion("1.0")]
        [HttpGet("productitem", Name = "GetProductItem")]
        public ActionResult<ProductItem> getProductItem([FromQuery] string name)
        {
            try
            {
                return Ok(productServ.getProductItem(name));
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

        [MapToApiVersion("3.0")]
        [HttpGet("productorder", Name = "GetProductOrder")]
        public ActionResult<ProductItemOrder> getProductrder([FromQuery] string name, 
            [FromBody] ClientProperty clientProps)
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
