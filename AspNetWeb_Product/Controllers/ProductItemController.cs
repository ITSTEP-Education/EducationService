using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_Product.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data.Common;

namespace AspNetWeb_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductService productServ;
        private readonly IOrderService orderServ;
        private readonly ILogger<ProductItemController> logger;

        public ProductItemController(IProductService productServ, IOrderService orderService, ILogger<ProductItemController> logger)
        {
            this.productServ = productServ;
            this.orderServ = orderService;
            this.logger = logger;
        }

        [HttpGet("all-productitems-dto", Name = "GetAllItemsDto")]
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

        [HttpGet("product-item", Name = "GetProductItem")]
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

        [HttpPost("product-order-dto", Name = "GetProductOrder")]
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

        [HttpGet("check", Name = "GetReponce")]
        public ActionResult<string> getResponce()
        {
            return Ok("ProductItem");
        }

        [HttpPost("product-order", Name = "AddProductOrder")]
        public IActionResult AddProductOrder([FromBody] ProductOrder productOrder)
        {
            try
            {
                orderServ.addProductOrerGuidDate(productOrder);
                return Ok(productOrder.guid);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
