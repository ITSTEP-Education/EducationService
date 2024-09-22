using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_Product.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Net;
using System.Runtime.CompilerServices;

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

        /// <summary>
        /// request to get entities ProductItemDto
        /// </summary>
        /// <value>on of the <see cref="ProductItemDto"> inherited from <see cref="ProductItem"></value>
        /// <returns>Ok(...) or BadRequest(...)</returns>
        /// <example>
        /// content of ProductItemExceptio
        /// <code>
        /// new ProductItemException("absent table", "products")
        /// </code>
        /// </example>
        /// <responce code="200">Successful fullfilment</responce>
        /// <exception cref="ProductItemException">appear if in db records is absent for ProductItem</exception>
        [HttpGet("all-productitems-dto", Name = "GetAllItemsDto")]
        [ProducesResponseType(typeof(IEnumerable<ProductItemDto>), 200)]
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
