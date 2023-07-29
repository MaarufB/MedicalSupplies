using MedicalSuppliesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesServices.Services.Contracts
{
    public interface IManufacturerRepo
    {
        public List<Manufacturer> GetAllManufacturers();
    }
}
