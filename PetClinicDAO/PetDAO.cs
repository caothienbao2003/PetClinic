using Microsoft.EntityFrameworkCore;
using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class PetDAO
    {
        private readonly PetClinicContext context;

        private static PetDAO instance;

        public PetDAO()
        {
            context = new PetClinicContext();
        }

        public static PetDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PetDAO();
                }
                return instance;
            }
        }

        public List<Pet> GetAll()
        {
            return context.Pets.Include(p => p.Customer).ToList();
        }
    }
}
