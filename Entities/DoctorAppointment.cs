using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DoctorAppointment
    {
        [Key]
        public int appointmentId { get; set; }
        public int appointmentIdByAppointmentModule { get; set; }
    }
}
