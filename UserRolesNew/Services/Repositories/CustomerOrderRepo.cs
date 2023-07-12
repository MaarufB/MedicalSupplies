﻿using Microsoft.EntityFrameworkCore;
using UserRolesData.Context;
using UserRolesModels;
using UserRolesNew.Services.Contracts;

namespace UserRolesNew.Services.Repositories
{
    public class CustomerOrderRepo : ICustomerOrderRepo
    {
        private readonly MSDBContext _context;

        public CustomerOrderRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<CustomerOrder> GetAllCustomerOrders()
        {
            var customerOrders = _context.CustomerOrders
                .Include(t => t.TicketStatus)
                .Include(t => t.Customer)
                .Include(t => t.PaymentMethod)
                .Include(i => i.CustomerOrderItems)
                .ToList();
            return customerOrders;
        }
    }
}