using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //IEnumerable<Product> 
        Task <Product> GetProductByIdAsync (int id);

        Task <IReadOnlyList<Product>> GetProductsAsync(ProductParams productParams);

        Task <IReadOnlyList<Product>> GetProductsOrderByPriceDesc();

        Task <IReadOnlyList<Product>> GetProductsOrderByPrice();

        Task <IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task <IReadOnlyList<ProductType>> GetProductTypesAsync();

        Task<IReadOnlyList<Product>> GetProductsByTypeId(int productTypeId);

        Task<IReadOnlyList<Product>> GetProductsByBrandId(int brandId);

        Task<List<Product>> GetProductsByName(string searchText);
    }
}