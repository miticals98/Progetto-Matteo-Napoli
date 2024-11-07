using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_Matteo_Napoli.Models;
using Progetto_Matteo_Napoli.Services;
using Progetto_Matteo_Napoli.Services.Interfaces;
using Progetto_Matteo_Napoli.Utils;

namespace Progetto_Matteo_Napoli.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
	{

        private ICrudServiceBase<Product, ProductDTO> _productService;
        public ProductController(ICrudServiceBase<Product, ProductDTO> productService)
        {
            _productService = productService;
        }

        
        /// <summary>
        /// Get a specific Product.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Response Read(int id)
		{
            try
            {
                var product = _productService.Read(id);
                if (product is { })
                {
                    return new Response()
                    {
                        Code = 200,
                        Data = Translate.ProductToDTO(product),
                        Message = "OK"
                    };
                }
                else
                {
                    return new Response()
                    {
                        Code = 404,
                        Message = "User not found",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {

                return new Response()
                {
                    Code = 400,
                    Data = null,
                    Message = ex.Message
                };
            }

        }

       
        /// <summary>
        /// Create a specific Product.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Product
        ///     {
        ///        "id": 0,
        ///        "name": "Marco Rossi",
        ///        "email": "marco.rossi@email.it"
        ///     }
        ///
        /// </remarks>
        [HttpPost("")]
		
		public Response Create([FromBody] ProductDTO productDTO)
		{
            try
            {
                Product prod = Translate.DTOToProduct(productDTO);
                var res = _productService.Create(prod);
                return new Response()
                {
                    Code = 201,
                    Data = res,
                    Message = "OK"
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Code = 400,
                    Data = null,
                    Message = ex.Message
                };
            }
        }



             
        /// <summary>
        /// Modify a specific Product.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Product
        ///     {
        ///        "id": 5,
        ///        "name": "Marco Rossi",
        ///        "email": "marco.rossi@email.it"
        ///     }
        ///
        /// </remarks>
        [HttpPut("")]
		
		public Response Update([FromBody] ProductDTO productDTO)
		{
            try
            {
                var prod = Translate.DTOToProduct(productDTO);
                bool res = _productService.Update(prod);
                if (res)
                {
                    return new Response()
                    {
                        Code = 200,
                        Data = true,
                        Message = "OK"
                    };
                }
                else
                {
                    return new Response()
                    {
                        Code = 404,
                        Message = "User not found",
                        Data = false
                    };
                }
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Code = 400,
                    Data = null,
                    Message = ex.Message
                };
            }
        }



        
        
        /// <summary>
        /// Delete a specific Product.
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        /// /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Product
        ///     {
        ///        "id": 7,
        ///        "name": "Marco Rossi",
        ///        "email": "marco.rossi@email.it"
        ///     }
        ///
        /// </remarks>
        [HttpDelete("")]
		
		public Response Delete([FromBody] ProductDTO productDTO)
		{
            try
            {
                Product prod = Translate.DTOToProduct(productDTO);
                bool res = _productService.Delete(prod);
                return new()
                {
                    Code = res ? 200 : 404,
                    Data = res,
                    Message = res ? "OK" : "User not found"
                };
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Code = 400,
                    Data = null,
                    Message = ex.Message
                };
            }
        }
	}
}
