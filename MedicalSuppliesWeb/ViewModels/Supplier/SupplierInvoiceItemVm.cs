﻿namespace MedicalSuppliesWeb.ViewModels.Supplier
{
    public class SupplierInvoiceItemVm
    {
        public int SupplierInvoiceItemId { get; set; }
        public int SupplierInvoiceId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // Additional properties from related entities if needed
        public string ProductName { get; set; }
    }
}
