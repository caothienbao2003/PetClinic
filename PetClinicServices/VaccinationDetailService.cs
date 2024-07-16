using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicBussinessObject;
using PetClinicRepository;
using PetClinicRepository.Interface;
using PetClinicServices.Interface;

namespace PetClinicServices
{
    public class VaccinationDetailService : IVaccinationDetailService
    {
        private readonly IVaccinationDetailRepository vaccinationDetailRepository;

        public VaccinationDetailService()
        {
            if (vaccinationDetailRepository == null)
            {
                vaccinationDetailRepository = new VaccinationDetailRepository();
            }
        }

        public List<VaccinationDetail> GetVaccinationDetailsList()
        {
            return vaccinationDetailRepository.GetVaccinationDetailsList();
        }

        public VaccinationDetail GetVaccinationDetailById(int id)
        {
            return vaccinationDetailRepository.GetVaccinationDetailById(id);
        }

        public void UpdateVaccinationDetail(VaccinationDetail vaccinationDetail)
        {
            vaccinationDetailRepository.UpdateVaccinationDetail(vaccinationDetail);
        }
    }
}
