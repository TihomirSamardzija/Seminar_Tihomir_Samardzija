using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Seminar_Tihomir_Samardzija.Data;
using Seminar_Tihomir_Samardzija.Services.Interface;
using Seminar_Tihomir_Samardzija.Models.ViewModel;

namespace Seminar_Tihomir_Samardzija.Services.Implementation
{
    public class ValidationService : IValidationService
    {
        private readonly ApplicationDbContext db;

        public ValidationService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> UsersIdValid(string id)
        {
            return await db.Users.FindAsync(id) != null;
        }

        public async Task<bool> ProductIdValid(int id)
        {
            return await db.Product.FindAsync(id) != null;
        }

        public async Task<bool> EmailExists(string email)
        {
            return await db.Users.FirstOrDefaultAsync(x => x.NormalizedEmail == email.ToUpper()) != null;
        }

        public async Task<bool> ProductCategoryIdValid(int id)
        {
            return await db.ProductCategory.FindAsync(id) != null;
        }

    }
}