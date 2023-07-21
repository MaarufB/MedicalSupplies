﻿using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
{
    public class Productrepo : IProductRepo
    {
        private readonly MSDBContext _context;

        public Productrepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(s => s.Supplier)
                .Include(m => m.Manufacturer)
                .Include(c => c.Colour).ToList();
            return products;
        }
    }
}