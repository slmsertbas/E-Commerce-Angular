using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include( p => p.ProductBrand)
                .Include( p => p.ProductType)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductParams productParams)
        {
            //var products = _context.Products.OrderByDescending();

            return await _context.Products.Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .Skip((productParams.PageNumber - 1) * productParams.PageSize)
                .Take(productParams.PageSize)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetProductsOrderByPrice()
        {
             var productList = _context.Products.Include( p => p.ProductBrand)
                .Include( p => p.ProductType)
                .AsNoTracking()
                .OrderBy(x => x.Price)
                .ToList();

            return await Task.FromResult(productList);
        }

        public async Task<IReadOnlyList<Product>> GetProductsOrderByPriceDesc()
        {
             var productList = _context.Products.Include( p => p.ProductBrand)
                .Include( p => p.ProductType)
                .AsNoTracking()
                .OrderByDescending(x => x.Price)
                .ToList();

            return await Task.FromResult(productList);
        }

        public async Task<IReadOnlyList<Product>> GetProductsByTypeId(int productTypeId) 
        {
            var productList = _context.Products.Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .AsNoTracking()
            .Where(p => p.ProductTypeId == productTypeId)
            .OrderBy(p => p.Name)
            .ToList();

            return await Task.FromResult(productList);
            
        }

        public async Task<IReadOnlyList<Product>> GetProductsByBrandId(int brandId) 
        {
            var productList = _context.Products.Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .AsNoTracking()
            .Where(p => p.ProductBrandId == brandId)
            .OrderBy(p => p.Name)
            .ToList();

            return await Task.FromResult(productList);
            
        }

        public async Task<List<Product>> GetProductsByName(string searchText)
        {
            searchText = searchText.Trim().ToLower();

            var retVal = _context.Products.Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .AsNoTracking()
                .Where(p => p.Name.ToLower().Contains(searchText))
                .OrderBy(p => p.Name)
                .ToList();

            return await Task.FromResult(retVal);
        }
    }
}