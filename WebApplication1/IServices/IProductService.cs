using Entitites.Entities;

namespace WebApplication1.IServices
{
    public interface IProductService
    {
        int insertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem Products);
        void DeleteProduct(int ProductsId);



        //void UpdateProduct(ProductItem existingProductItem);

    }
}