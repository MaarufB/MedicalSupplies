using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.ViewModels.Product
{
    public class ProductVm
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public string ColourName { get; set; }
        public string SupplierName { get; set; }


        // Selected IDs for Manufacturer, Supplier, Colour, and Category
        public int ManufacturerId { get; set; }
        public int SupplierId { get; set; }
        public int ColourId { get; set; }
        public int CategoryId { get; set; }

        // Lists of available options for dropdown lists in the view
        public List<Manufacturer> AvailableManufacturers { get; set; }
        public List<MedicalSuppliesModels.Supplier> AvailableSuppliers { get; set; }
        public List<Colour> AvailableColours { get; set; }
        public List<Category> AvailableCategories { get; set; }



    }
}
