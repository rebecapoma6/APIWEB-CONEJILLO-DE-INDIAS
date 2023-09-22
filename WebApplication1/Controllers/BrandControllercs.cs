using Data;
using Entitites.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;
using WebApplication1.IServices;
using WebApplication1.Services;




namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly ServiceContext _serviceContext;

        public BrandController(IBrandService brandService, ServiceContext serviceContext)
        {
            _brandService = brandService;
            _serviceContext = serviceContext;
        }

        [HttpGet(Name = "GetAllBrands")]
        public IActionResult GetAllBrands()
        {
            var brands = _serviceContext.Brands.ToList();
            return Ok(brands);
        }

        [HttpGet("{brandId}", Name = "GetBrandById")]
        public IActionResult GetBrandById(int brandId)
        {
            var brand = _serviceContext.Brands.FirstOrDefault(b => b.BrandId == brandId);
            if (brand != null)
            {
                return Ok(brand);
            }
            return NotFound("Marca no encontrada");
        }

        [HttpPost(Name = "InsertBrand")]
        public IActionResult InsertBrand([FromBody] Brand brand)
        {
            _serviceContext.Brands.Add(brand);
            _serviceContext.SaveChanges();
            return CreatedAtRoute("GetBrandById", new { brandId = brand.BrandId }, brand);
        }

        [HttpPut("{brandId}", Name = "UpdateBrand")]
        public IActionResult UpdateBrand(int brandId, [FromBody] Brand updatedBrand)
        {
            var brand = _serviceContext.Brands.FirstOrDefault(b => b.BrandId == brandId);
            if (brand != null)
            {
                brand.Name = updatedBrand.Name;

                _serviceContext.SaveChanges();

                return Ok("La marca se ha modificado correctamente");
            }
            else
            {
                return NotFound("No se ha encontrado la marca");
            }
        }

        [HttpDelete("{brandId}", Name = "DeleteBrand")]
        public IActionResult DeleteBrand(int brandId)
        {
            var brand = _serviceContext.Brands.Find(brandId);
            if (brand != null)
            {
                _serviceContext.Brands.Remove(brand);
                _serviceContext.SaveChanges();
                return Ok("La marca se ha eliminado");
            }
            else
            {
                return NotFound("No se ha encontrado la marca");
            }
        }
    }
}
