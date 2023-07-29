using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly MSDBContext _context;

        public CategoryRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Category> GetAllCategories()
        {
            return(_context.Categories.ToList());
        }
    }
}
