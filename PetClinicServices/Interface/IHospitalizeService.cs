using PetClinicBussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetClinicServices.Interface
{
    public interface IHospitalizeService
    {
        public List<Hospitalize> GetAllHospitalize();
        public Hospitalize? GetHospitalizeById(int id);
        public void AddHospitalize(Hospitalize hospitalize);
        public void UpdateHospitalize(Hospitalize hospitalize);
    }
}
