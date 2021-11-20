using System;

namespace GymModels
{
    public class Applicant
    {
        public string Name { get; set; }
        public string FahterName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }



        public DateTime AdmissionDate { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }

        public string PhotoPath { get; set; }
        public int Package { get; set; }
        public DateTime ExpiryDate { get; set; }

        public bool Active { get; set; }
    }
}
