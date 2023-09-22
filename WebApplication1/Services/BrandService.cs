using Data;
using Entitites.Entities;
using Microsoft.EntityFrameworkCore;
using WebApplication1.IServices;

namespace WebApplication1.Services
{
    public class BrandService : BaseContextService, IBrandService
    {
        public BrandService(ServiceContext serviceContext) : base(serviceContext) { }

        public Brand GetBrandById(int brandId)
        {
            return _serviceContext.Brands.Find(brandId);
        }

        public List<Brand> GetAllBrands()
        {
            return _serviceContext.Brands.ToList();
        }

        public int InsertBrand(Brand brand)
        {
            _serviceContext.Brands.Add(brand);
            _serviceContext.SaveChanges();
            return brand.BrandId;
        }

        public void UpdateBrand(Brand brand)
        {
            _serviceContext.Entry(brand).State = EntityState.Modified;
            _serviceContext.SaveChanges();
        }

        public void DeleteBrand(int brandId)
        {
            var brand = _serviceContext.Brands.Find(brandId);
            if (brand != null)
            {
                _serviceContext.Brands.Remove(brand);
                _serviceContext.SaveChanges();
            }
        }
    }
}
