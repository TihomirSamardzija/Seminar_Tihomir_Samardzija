using Seminar_Tihomir_Samardzija.Models.Binding;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Models.ViewModel;

namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface IProductService
    {
        Task<ProductViewModel> AddProductAsync(ProductBinding model);
        Task<ProductViewModel> GetProductAsync(int id);
        Task<List<ProductViewModel>> GetProductsAsync();
        Task<ProductViewModel> UpdateProductAsync(ProductUpdateBinding model);
        Task DeleteProductAsync(Product model);
        Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model);
        Task<List<ProductCategoryViewModel>> GetProductCategorysAsync();
        Task<ProductCategoryViewModel> GetProductCategoryAsync(int id);
        Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model);
    }
}