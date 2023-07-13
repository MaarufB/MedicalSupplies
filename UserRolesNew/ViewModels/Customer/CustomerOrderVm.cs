namespace UserRolesNew.ViewModels.Customer
{
    public class CustomerOrderVm
    {

        public CustomerOrderVm()
        {
            CustomerOrderItems = new List<CustomerOrderItemVm>();
        }

        public int CustomerOrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal CustomerOrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerName { get; set; }

        public string TicketStatus { get; set; }

        public int CustomerId { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public int PaymentMethodId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public int TicketStatusId { get; set; }

        // Additional properties from related entities if needed

        public string PaymentMethodName { get; set; }
        public string TicketStatusName { get; set; }
        public List<CustomerOrderItemVm> CustomerOrderItems { get; set; }





    }
}
