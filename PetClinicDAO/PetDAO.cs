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

        private static PetDAO? instance;

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

        public List<Pet> GetPetListByUserId(int userId)
        {
            return context.Pets.Include(p => p.Customer).Where(p => p.CustomerId == userId).ToList();
        }

        public Pet GetPetById(int petId)
        {
            return context.Pets.Include(p => p.Customer).FirstOrDefault(p => p.PetId == petId);
        }

        public List<PetHealth> GetPetHealthsList()
        {
            return context.PetHealths.ToList();
        }

        public PetHealth GetPetHealthByPetId(int? petId)
        {
            return context.PetHealths.FirstOrDefault(p => p.PetId == petId)!;
        }

        public void AddPet(Pet pet)
        {
            context.Pets.Add(pet);
            context.SaveChanges();
        }

        public void RemovePet(int petId)
        {
            var pet = context.Pets.FirstOrDefault(p => p.PetId == petId);
            if (pet != null)
            {
                //pet.ActiveStatus = 0;
                pet.ActiveStatus = (int)ActiveStatus.UnActive;
                context.SaveChanges();
            }
        }

        public void UpdatePet(Pet pet)
        {
            if (GetPetById(pet.PetId) == null)
            {
                return;
            }
            context.Pets.Update(pet);
            context.SaveChanges();
        }

        public List<string> GetAllPetTypes()
        {
            return context.Pets.Select(p => p.PetType).Distinct().ToList();
        }

        public List<Pet> SearchPets(string? petName, string? customer, string? petType)
        {
            var query = context.Pets.Include(p => p.Customer).AsQueryable();

            if (!string.IsNullOrEmpty(petName))
            {
                query = query.Where(p => p.PetName.Contains(petName));
            }

            if (!string.IsNullOrEmpty(customer))
            {
                query = query.Where(p => p.Customer.FirstName.Contains(customer));
            }

            if (!string.IsNullOrEmpty(petType))
            {
                query = query.Where(p => p.PetType == petType);
            }

            return query.ToList();
        }

    }
}
