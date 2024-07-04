using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicDAO
{
    public class CageDAO
    {
        private readonly PetClinicContext context;

        private static CageDAO instance;

        public CageDAO()
        {
            context = new PetClinicContext();
        }

        public static CageDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CageDAO();
                }
                return instance;
            }
        }

        public List<Cage> GetAll()
        {
            return context.Cages.ToList();
        }

        public Cage? GetCageById(int id)
        {
            return context.Cages.Find(id);
        }

        public void Add(Cage cage)
        {
            if (GetCageById(cage.CageId) != null)
            {
                return;
            }

            context.Cages.Add(cage);
            context.SaveChanges();
        }

        public void Update(Cage cage)
        {
            if (GetCageById(cage.CageId) == null)
            {
                return;
            }

            context.Cages.Update(cage);
            context.SaveChanges();
        }
    }
}
