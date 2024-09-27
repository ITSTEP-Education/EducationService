using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_Product.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace AspNetWeb_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IProductService productServ;
        private readonly IOrderService orderServ;
        private readonly ILogger<EducationController> logger;

        public EducationController(IProductService productServ, IOrderService orderService, ILogger<EducationController> logger)
        {
            this.productServ = productServ;
            this.orderServ = orderService;
            this.logger = logger;
        }

        //HttpRequest for intaraction with ProductItems
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
        public ActionResult<ProductItem> getProductItem([FromQuery][Required] string name)
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
                return NotFound(new ProductItemException(ex));
            }
        }

        //HttpRequest for intaraction with ProductOrder
        [HttpPost("product-order-dto", Name = "GetProductOrderDto")]
        public ActionResult<ProductOrderDto> getProductrderDto([FromQuery][Required] string name, 
            [FromBody] ClientProperty clientProps)
        {
            try
            {
                return Ok(productServ.getProductOrderDto(name, clientProps.cltTimeProps, clientProps.cltPayProps));
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

        [HttpPost("product-order", Name = "AddProductOrder")]
        public IActionResult AddProductOrder([FromBody] ProductOrder productOrder)
        {
            if (!ModelState.IsValid) return BadRequest("model is not valid");

            try
            {
                orderServ.addProductOrderGuidDate(productOrder);
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

        [HttpGet("product-orders", Name = "GetProductOrders")]
        public ActionResult<IEnumerable<ProductOrder>> getAllProductOrders()
        {
            try
            {
                return Ok(orderServ.getAllOrders());
            }
            catch (ProductItemException ex)
            {
                return NotFound(new { msg = ex.Message, prop = ex.property });
            }
            catch (DbException ex)
            {
                return BadRequest(new { msg = ex.Message, prop = ex.SqlState });
            }
        }

        [HttpGet("product-order", Name = "GetProductOrder")]
        public ActionResult<ProductOrder> getProductOrder([FromQuery][Required] string guid)
        {
            try
            {
                return Ok(orderServ.getOrder(guid));
            }
            catch (ProductItemException ex)
            {
                return NotFound(new { msg = ex.Message, prop = ex.property });
            }
        }
    }
}
