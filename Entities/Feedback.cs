using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Feedback
    {
        [Key]
        public int feedbackId { get; set; }
        [Required]
        public int doctorCompetence { get; set; }
        [Required]
        public int referOthers { get; set; }
        [Required]
        public int satisfactionInBooking { get; set; }
        [Required]
        public string additionalComment { get; set; }
        [Required]
        public int appointmentId { get; set; }
    }
}
