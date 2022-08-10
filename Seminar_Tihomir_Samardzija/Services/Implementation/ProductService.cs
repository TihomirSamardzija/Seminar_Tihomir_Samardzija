using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Seminar_Tihomir_Samardzija.Data;
using Seminar_Tihomir_Samardzija.Models.Binding;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Models.Dto;
using Seminar_Tihomir_Samardzija.Models.ViewModel;
using Seminar_Tihomir_Samardzija.Services.Interface;

namespace Seminar_Tihomir_Samardzija.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IFileStorageService fileStorageService;
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly AppConfig appConfig;

        public ProductService(ApplicationDbContext db,
            IMapper mapper, IOptions<AppConfig> appConfig,
            IFileStorageService fileStorageService)
        {
            this.appConfig = appConfig.Value;
            this.db = db;
            this.mapper = mapper;
            this.fileStorageService = fileStorageService;
        }

        /// <summary>
        /// Dodavanje proizvoda
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> AddProductAsync(ProductBinding model)
        {
            var dbo = mapper.Map<Product>(model);
            var productCategory = await db.ProductCategory.FindAsync(model.ProductCategoryId);
            if (productCategory == null)
            {
                return null;
            }
            dbo.ProductCategory = productCategory;
            db.Product.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductViewModel>(dbo);
        }
        /// <summary>
        /// Dohvati proizvod putem id-1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> GetProductAsync(int id)
        {
            var dbo = await db.Product.FindAsync(id);
            return mapper.Map<ProductViewModel>(dbo);

        }

        /// <summary>
        /// Dohvati sve proizvode
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            var dbo = await db.Product.ToListAsync();
            return dbo.Select(x => mapper.Map<ProductViewModel>(x)).ToList();

        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductViewModel> UpdateProductAsync(ProductUpdateBinding model)
        {
            var category = await db.ProductCategory.FirstOrDefaultAsync(x => x.Id == model.ProductCategoryId);
            var dbo = await db.Product.FindAsync(model.Id);
            mapper.Map(model, dbo);
            dbo.ProductCategory = category;
            await db.SaveChangesAsync();
            return mapper.Map<ProductViewModel>(dbo);
        }

        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(Product model)
        {
            var product = await db.Product.FirstOrDefaultAsync(x => x.Id == model.Id);
            db.Product.Remove(product);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Dodaj kategoriju proizvoda
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> AddProductCategoryAsync(ProductCategoryBinding model)
        {
            var dbo = mapper.Map<ProductCategory>(model);
            db.ProductCategory.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }
        /// <summary>
        /// Dohvati kategoriju proizvoda
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> GetProductCategoryAsync(int id)
        {
            var dbo = await db.ProductCategory.FindAsync(id);
            return mapper.Map<ProductCategoryViewModel>(dbo);

        }

        /// <summary>
        /// Dohvati sve kategorije proizvoda
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductCategoryViewModel>> GetProductCategorysAsync()
        {
            var dbo = await db.ProductCategory.ToListAsync();
            return dbo.Select(x => mapper.Map<ProductCategoryViewModel>(x)).ToList();

        }

        /// <summary>
        /// Product category update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ProductCategoryViewModel> UpdateProductCategoryAsync(ProductCategoryUpdateBinding model)
        {
            var dbo = await db.ProductCategory.FindAsync(model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<ProductCategoryViewModel>(dbo);
        }


    }
}
