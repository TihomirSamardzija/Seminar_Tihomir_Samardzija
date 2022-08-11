using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seminar_Tihomir_Samardzija.Models;
using Seminar_Tihomir_Samardzija.Models.Binding;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Services.Interface;

namespace Seminar_Tihomir_Samardzija.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AdminController(IProductService productService, IMapper mapper, IUserService userSevice)
        {
            this.productService = productService;
            this.mapper = mapper;
            this.userService = userSevice;
        }

        [HttpGet]
        public async Task<IActionResult> ProductAdministration()
        {
            var products = await productService.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductBinding model)
        {
            await productService.AddProductAsync(model);
            return RedirectToAction("ProductAdministration");
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await productService.GetProductAsync(id);
            return View(product);
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var product = await productService.GetProductAsync(id);
            var model = mapper.Map<ProductUpdateBinding>(product);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateBinding model)
        {
            var product = await productService.UpdateProductAsync(model);
            return RedirectToAction("ProductAdministration");
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await productService.GetProductAsync(id);
            var model = mapper.Map<Product>(product);
            return View(model);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public async Task<IActionResult> DeleteProductConfirmed(int id)
        {
            var product = await productService.GetProductAsync(id);
            var model = mapper.Map<Product>(product);

            await productService.DeleteProductAsync(model);

            return RedirectToAction("ProductAdministration");
        }



        [HttpGet]
        public async Task<IActionResult> AddProductCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductCategory(ProductCategoryBinding model)
        {
            await productService.AddProductCategoryAsync(model);
            return RedirectToAction("ProductAdministration");
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await userService.GetUsers();
            return View(users);

        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userService.GetUser(id);
            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserAdminUpdateBinding model)
        {
            await userService.UpdateUser(model);
            return RedirectToAction("Users");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userService.DeleteUserAsync(id);
            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> CreateNewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser(UserAdminBinding model)
        {
            await userService.CreateUserAsync(model);
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var users = await userService.GetUser(id);
            return View(users);
        }

    }
}
