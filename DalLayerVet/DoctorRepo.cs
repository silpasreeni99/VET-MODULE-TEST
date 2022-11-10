using Entities;
using Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DalLayerVet
{
    public class DoctorRepo : IDoctorRepo
    {
        VetDbContext db = new VetDbContext();
        public Feedback getFeedbacks(int doctorId, int appointmentId)
        {
            var data = db.Doctors.Find(doctorId);
            if (data == null)
            {
                throw new DoctorNotFoundException("doctor id not present");
            }
            else
            {
                if ((from s in data.appointmentIds where s.appointmentId == appointmentId select s).ToList().Count == 0)
                {
                    throw new AppointmentIdNotFoundException("the given appointment id is not present");
                }
                else
                {
                    List<Feedback> f = (from i in data.feedbacks where i.appointmentId == appointmentId select i).ToList();
                    if (f.Count == 0)
                    {
                        throw new FeedbackNotPresentException("Feedback not present");
                    }
                    else
                    {
                        return f[0];
                    }
                }
            }
        }
        public async Task<Feedback> getFeedbacksAsync(int doctorId, int appointmentId)
        {

            var data = await db.Doctors.FindAsync(doctorId);
            if (data == null)
            {
                throw new DoctorNotFoundException("doctor id not present");

            }
            else
            {
                if ((from s in data.appointmentIds where s.appointmentId == appointmentId select s).ToList().Count == 0)
                {
                    throw new AppointmentIdNotFoundException("the given appointment id is not present");
                }

                else
                {
                    List<Feedback> f = (from i in data.feedbacks where i.appointmentId == appointmentId select i).ToList();
                    if (f.Count == 0)
                    {
                        throw new FeedbackNotPresentException("Feedback not present");
                    }
                    else
                    {
                        return f[0];
                    }
                }
            }
        }
        public bool postFeedback(int doctorId, Feedback feedback)
        {
            var data = db.Doctors.Find(doctorId);
            if (data == null)
            {
                return false;
            }
            else
            {

                if (((from a in data.appointmentIds where a.appointmentIdByAppointmentModule == feedback.appointmentId select a).ToList()).Count == 0)
                {
                    throw new AppointmentIdNotFoundException("given appointment id not present in our database");
                }
                else
                {
                    if ((from f in data.feedbacks where f.appointmentId == feedback.appointmentId select f).ToList().Count == 0)
                    {
                        data.feedbacks.Add(feedback);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        throw new FeedbackExitsException("feedback exits in our database");
                    }
                }

            }
        }
        public async Task<bool> postFeedbackAsync(int doctorId, Feedback feedback)
        {
            var data = await db.Doctors.FindAsync(doctorId);
            if (data == null)
            {
                return false;
            }
            else
            {

                if ((from s in data.appointmentIds where s.appointmentIdByAppointmentModule == feedback.appointmentId select s).ToList().Count == 0)
                {
                    throw new AppointmentIdNotFoundException("given appointment id not present in our database");
                }
                else
                {
                    if ((from f in data.feedbacks where f.appointmentId == feedback.appointmentId select f).ToList().Count == 0)
                    {
                        data.feedbacks.Add(feedback);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new FeedbackExitsException("feedback exits in our database");
                    }
                }

            }
        }
        public bool AddAppointment(int doctorId, DoctorAppointment appointmentId)
        {
            if (db.Doctors.Find(doctorId) != null)
            {
                Doctor d = db.Doctors.Find(doctorId);
                d.appointmentIds.Add(appointmentId);
                db.SaveChanges();
                return true;
            }
            else
                return false;

        }
        public async Task<bool> AddAppointmentAsync(int doctorId, DoctorAppointment appointmentId)
        {
            if (db.Doctors.Find(doctorId) != null)
            {
                Doctor d = db.Doctors.Find(doctorId);
                d.appointmentIds.Add(appointmentId);
                await db.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
        public List<Doctor> GetDoctors()
        {
            return db.Doctors.ToList();
        }

        public async Task<List<Doctor>> GetDoctorsAsync()
        {
            var list = await db.Doctors.ToListAsync();
            return list;
        }
        public bool EditDoctor(Doctor doctor, int id)
        {
            var data = db.Doctors.Find(id);
            if (data == null)
                return false;
            else
            {
                data.name = doctor.name;
                data.mobileNo = doctor.mobileNo;
                data.email = doctor.email;
                data.clinicAddress = doctor.clinicAddress;
                data.imgUrl = doctor.imgUrl;
                data.speciality = doctor.speciality;
                data.npiNo = doctor.npiNo;
                db.SaveChanges();
                return true;
            }
        }

        public async Task<bool> EditDoctorasync(Doctor doctor, int id)
        {
            var data = await db.Doctors.FindAsync(id);
            if (data == null) return false;
            else
            {
                data.name = doctor.name;
                data.mobileNo = doctor.mobileNo;
                data.email = doctor.email;
                data.clinicAddress = doctor.clinicAddress;
                data.imgUrl = doctor.imgUrl;
                data.speciality = doctor.speciality;
                data.npiNo = doctor.npiNo;
                await db.SaveChangesAsync();
                return true;
            }

        }
        public Doctor SaveDoctor(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            db.SaveChanges();
            return doctor;
        }

        public async Task SaveDoctorAsync(Doctor doctor)
        {
            db.Doctors.Add(doctor);
            await db.SaveChangesAsync();
        }


    }
}
