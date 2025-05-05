using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsi
{
    public class Patient
    {
        public string fullName { get; set; }
        public string idPatient { get; set; }

    }

    public class MedicalCard
    {
        public string fullName { get; set; }

        public string idMedicaCard { get; set; }
    }

    public class Department
    {
        public string nameDepartment { get; set; }

        public string idDepartment { get; set; }
    }

    public class Doctor
    {
        public string fullName { get; set; }
        public string idDoctor { get; set; }

    }

    public class Episode
    {
        public string diagnosis { get; set; }
        public string idEpisode { get; set; }

        public string idMedicalCard { get; set; }
    }

    public class Procedure
    {
        public string idProcedure { get; set; }

        public string nameProcedure { get; set; }
    }

    public class Medication
    {
        public string idMedication { get; set; }
        public string nameMedication { get; set; }


    }
}
