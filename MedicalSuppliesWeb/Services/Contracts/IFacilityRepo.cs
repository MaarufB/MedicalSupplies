﻿using MedicalSuppliesModels;

namespace MedicalSuppliesWeb.Services.Contracts
{
    public interface IFacilityRepo
    {
        public List<Facility> GetAllFacilities();
    }
}
