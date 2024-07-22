using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class PetHealthDAO
    {
        private readonly PetClinicContext context;

        private static PetHealthDAO? instance;

        public PetHealthDAO()
        {
            context = new PetClinicContext();
        }

        public static PetHealthDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PetHealthDAO();
                }
                return instance;
            }
        }

        public List<PetHealth> GetAllPetHealths()
        {
            return context.PetHealths.ToList();
        }

        public PetHealth GetPetHealthByPetId(int petId)
        {
            return context.PetHealths.FirstOrDefault(p => p.PetId == petId)!;
        }

        public PetHealth GetPetHealthById(int petHealthId)
        {
            return context.PetHealths.FirstOrDefault(p => p.PetHealthId == petHealthId)!;
        }
        
        public void AddPetHealth(PetHealth petHealth)
        {
            context.PetHealths.Add(petHealth);
            context.SaveChanges();
        }

        public void UpdatePetHealth(PetHealth petHealth)
        {
            context.PetHealths.Update(petHealth);
            context.SaveChanges();
        }
    }
}
