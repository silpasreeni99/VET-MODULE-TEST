using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DoctorDto
    {
        public string imgUrl { get; set; }
        public string name { get; set; }
        public long npiNo { get; set; }
        public string mobileNo { get; set; }
        public string email { get; set; }
        public string speciality { get; set; }
        public string clinicAddress { get; set; }
    }
}
