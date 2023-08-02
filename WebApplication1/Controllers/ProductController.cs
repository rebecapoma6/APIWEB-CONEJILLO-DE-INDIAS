using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ServiceContext _serviceContext;
        public ProductController(IProductService productService, ServiceContext serviceContext)
        {
            _productService = productService;
            _serviceContext = serviceContext;
        }
        [HttpPost(Name = "InsertProduct")]
       
        public int Post([FromQuery] string userUser_Name, [FromQuery] string userPassword, [FromBody] ProductItem productItem)
        {
            var seletedUser = _serviceContext.Set<UserItem>()
                               .Where(u => u.User_Name == userUser_Name
                                    && u.Password == userPassword
                                    && u.IdRoll == 1)
                                .FirstOrDefault();


            if (seletedUser != null)
            {
                return _productService.InsertProduct(productItem);

            }
            else
            {
                throw new InvalidCredentialException("El producto no Existe");
            }


        }



    }


}


