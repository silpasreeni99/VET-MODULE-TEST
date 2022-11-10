using DTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayerVet
{
    public interface IDoctorDataProcessor
    {
        Feedback getFeedbacks(int doctorId,int appointmentId);
        Task<Feedback> getFeedbacksAsync(int doctorId,int appointmentId);
        bool postFeedback(int doctorId, Feedback feedback);
        Task<bool> postFeedbackAsync(int doctorId, Feedback feedback);
        bool AddAppointment(int doctorId, DoctorAppointment appointmentId);
        Task<bool> AddAppointmentAsync(int doctorId, DoctorAppointment appointmentId);
        List<Doctor> GetDoctors();
        Task<List<Doctor>> GetDoctorsAsync();
        bool editDoctor(Doctor d, int id);
        Task<bool> editDoctorAsync(Doctor d, int id);
        Doctor AddDoctor(DoctorDto dto);
        Task<Doctor> AddDoctorAsync(DoctorDto dto);
    }
}
