using Microsoft.AspNetCore.Mvc;
using UserRolesNew.Services;
using UserRolesNew.ViewModels.Dashboard;

namespace UserRolesNew.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ICustomerInvoiceRepo _customerInvoiceRepo;
        private readonly ICustomerOrderRepo _customerOrderRepo;
        private readonly ISupplierInvoiceRepo _supplierInvoiceRepo;
        private readonly ISupplierOrderRepo _supplierOrderRepo;

        public AdminDashboardController(ICustomerInvoiceRepo customerInvoiceRepo,
                                        ICustomerOrderRepo customerOrderRepo,
                                        ISupplierInvoiceRepo supplierInvoiceRepo,
                                        ISupplierOrderRepo supplierOrderRepo)
        {
            _customerInvoiceRepo = customerInvoiceRepo;
            _customerOrderRepo = customerOrderRepo;
            _supplierInvoiceRepo = supplierInvoiceRepo;
            _supplierOrderRepo = supplierOrderRepo;
        }
        public IActionResult Index()
        {
            var dashBoardViewModel = new DashboardVm
            {
                CustomerOrders = _customerOrderRepo.GetAllCustomerOrders()

                                                 .Select(c => new CustomerOrderVm
                                                 {
                                                     CustomerOrderId = c.CustomerOrderId,
                                                     Date = c.Date,
                                                     CustomerOrderTotal = c.CustomerOrderTotal,
                                                     CustomerName = c.Customer.FirstName,
                                                     TicketStatus = c.TicketStatus.Status
                                                 }
                                                        ).ToList(),



                CustomerInvoices = _customerInvoiceRepo.GetAllCustomerInvoices()

                                                .Select(i => new CustomerInvoiceVm
                                                {
                                                    CustomerInvoiceId = i.CustomerInvoiceId,
                                                    InvoiceDate = i.InvoiceDate,
                                                    TotalAmount = i.TotalAmount,
                                                    CustomerInvoiceNo = i.CustomerInvoiceNo,
                                                    CustomerName = i.CustomerOrder.Customer.FirstName,
                                                    TicketStatus = i.TicketStatus.Status
                                                }
                                                        ).ToList(),


                SupplierOrders = _supplierOrderRepo.GetAllSupplierOrders()

                                                .Select(o => new SupplierOrderVm
                                                {
                                                    SupplierOrderId = o.SupplierOrderId,
                                                    Date = o.Date,
                                                    SupplierOrderTotal = o.SupplierOrderTotal,
                                                    SupplierName = o.Supplier.SupplierName,
                                                    TicketStatus = o.TicketStatus.Status
                                                }
                                                        ).ToList(),

                SupplierInvoices = _supplierInvoiceRepo.GetAllSupplierInvoices()

                                                .Select(i => new SupplierInvoiceVm
                                                {
                                                    SupplierInvoiceId = i.SupplierInvoiceId,
                                                    InvoiceDate = i.InvoiceDate,
                                                    TotalAmount = i.TotalAmount,
                                                    SupplierInvoiceNumber = i.SupplierInvoiceNumber,
                                                    SupplierName = i.SupplierOrder.Supplier.SupplierName,
                                                    TicketStatus= i.TicketStatus.Status
                                                }
                                                        ).ToList()
            };

            return View(dashBoardViewModel);
        }
    }
}
