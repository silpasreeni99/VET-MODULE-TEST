using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public interface IDoctorRepo
    {
        Feedback getFeedbacks(int doctorId,int appointmentId);
        Task<Feedback> getFeedbacksAsync(int doctorId,int appointmentId);
        bool postFeedback(int doctorId, Feedback feedback);
        Task<bool> postFeedbackAsync(int doctorId, Feedback feedback);
        bool AddAppointment(int doctorId, DoctorAppointment appointmentId);
        Task<bool> AddAppointmentAsync(int doctorId, DoctorAppointment appointmentId);
        List<Doctor> GetDoctors();
        Task<List<Doctor>> GetDoctorsAsync();
        bool EditDoctor(Doctor doctor, int id);
        Task<bool> EditDoctorasync(Doctor doctor, int id);
        Doctor SaveDoctor(Doctor doctor);
        Task SaveDoctorAsync(Doctor doctor);
    }
}
