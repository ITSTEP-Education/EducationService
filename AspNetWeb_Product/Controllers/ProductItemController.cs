using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AspNetWeb_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<ProductItemController> logger;

        public ProductItemController(IUnitOfWork unitOfWork, ILogger<ProductItemController> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        [HttpGet("productitems", Name = "GetAllItems")]
        public ActionResult<IEnumerable<ProductItem>> getAllItems()
        {
            try
            {
                return Ok(unitOfWork.productItems.getAllItems());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}", Name = "GetItem")]
        public ActionResult<ProductItem> getItem([Required] string name)
        {
            try
            {
                return Ok(unitOfWork.productItems.getItem(name));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
