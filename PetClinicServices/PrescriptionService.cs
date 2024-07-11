using PetClinicRepository.Interface;
using PetClinicRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetClinicServices.Interface;
using PetClinicBussinessObject;

namespace PetClinicServices
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionService prescriptionService;

        public PrescriptionService()
        {
            if (prescriptionService == null)
            {
                prescriptionService = new PrescriptionService();
            }
        }

        public List<Prescription> GetAllPrescription()
        {
            return prescriptionService.GetAllPrescription();
        }
    }
}
