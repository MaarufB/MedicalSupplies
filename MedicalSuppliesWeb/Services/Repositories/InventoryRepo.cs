﻿using Microsoft.EntityFrameworkCore;
using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesWeb.Services.Contracts;

namespace MedicalSuppliesWeb.Services.Repositories
{
    public class InventoryRepo : IInventoryRepo
    {
        private readonly MSDBContext _context;
        public InventoryRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Inventory> GetInventories()
        {
            var inventories = _context.Inventories
                .Include(p=>p.Product)
                .Include(s=>s.Supplier)
                .Include(l=>l.Location)
                .ToList();
            return inventories;
        }
    }
}
