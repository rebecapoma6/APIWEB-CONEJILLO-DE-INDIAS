using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IBrandService
    {
        Brand GetBrandById(int brandId);
        List<Brand> GetAllBrands();
        int InsertBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(int brandId);
    }
}
