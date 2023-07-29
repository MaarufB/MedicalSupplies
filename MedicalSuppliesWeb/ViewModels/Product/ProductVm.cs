using MedicalSuppliesModels;
using MedicalSuppliesWeb.ViewModels.Inventory;
using MedicalSuppliesWeb.ViewModels.Location;

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

        public string LocationName { get; set; }


        // Selected IDs for Manufacturer, Supplier, Colour, and Category
        public int ManufacturerId { get; set; }
        public int SupplierId { get; set; }
        public int ColourId { get; set; }
        public int CategoryId { get; set; }

        public int LocationId { get; set; }


        // Lists of available options for dropdown lists in the view
        public List<Manufacturer> AvailableManufacturers { get; set; }
        public List<MedicalSuppliesModels.Supplier> AvailableSuppliers { get; set; }
        public List<Colour> AvailableColours { get; set; }
        public List<Category> AvailableCategories { get; set; }

        public List<MedicalSuppliesModels.Location> AvailableLocations { get; set; }


        public InventoryVm Inventory { get; set; }



    }
}
