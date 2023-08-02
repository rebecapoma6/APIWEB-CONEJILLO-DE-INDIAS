using Data;
using Entitites.Entities;
using WebApplication1.IServices;


namespace WebApplication1.Services
{
    public class ProductService : BaseContextService, IProductService
    {
        public ProductService(ServiceContext serviceContext) : base(serviceContext) { }

        public int InsertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.IdProducto;
        }

        public void UpdateProduct(ProductItem product)
        {
            _serviceContext.Products.Update(product);
            _serviceContext.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _serviceContext.Products.Find(productId);
            if (product != null)
            {
                _serviceContext.Products.Remove(product);
                _serviceContext.SaveChanges();
            }
        }
    }
}

