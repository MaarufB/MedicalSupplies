using MedicalSuppliesModels;
using MedicalSuppliesModels.Context;
using MedicalSuppliesServices.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSuppliesServices.Services.Repositories
{
    public class ColourRepo : IColourRepo
    {
        private readonly MSDBContext _context;

        public ColourRepo(MSDBContext context)
        {
            _context = context;
        }
        public List<Colour> GetAllColours()
        {
            return(_context.Colours.ToList());
        }
    }
}
