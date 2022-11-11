using ApiLayerVet.Controllers;
using BussinessLayerVet;
using Entities;
using Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Put_Doctor_Valid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            IHttpActionResult actionResult = Controller.PutDoctor(d, 4);
            //Assert.IsNotNull(actionResult);
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));
        }
        [TestMethod]
        public void Put_Doctor_async_Valid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Doctor d = new Doctor();
            Task<IHttpActionResult> actionResult = Controller.PutDoctorAsync(d, 4);
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void GetAll_Doctors_Valid()
        {
            Doctor doctor = new Doctor();
            var list = new  List<Doctor>();
            list.Add(doctor);
            //var result = list.AsQueryable();
            var MockRepo= new Mock<IDoctorDataProcessor>();
            MockRepo.Setup(x => x.GetDoctors()).Returns(list);
            var Controller = new DoctorsController(MockRepo.Object);
             

            var d= (Controller.GetDoctors());
            Assert.AreNotEqual(d.Count(), 0);
        }

        [TestMethod]
        public void GetAll_DoctorsAsync_Valid()
        {
            Doctor doctor1=new Doctor();
            Doctor doctor2=new Doctor();    
            var list= new List<Doctor>();
            list.Add(doctor1);
            list.Add(doctor2);
            
            var MockRepo=new Mock<IDoctorDataProcessor>();
            MockRepo.Setup(x=> x.GetDoctorsAsync()).ReturnsAsync(list);
            var controller = new DoctorsController(MockRepo.Object);    
            var d=controller.GetDoctorsAsync();
            Assert.IsNotNull(d);
        }




        [TestMethod]
        public void Post_Feedback_InValid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Feedback feedback=new Feedback();
            Doctor doctor = new Doctor();
            IHttpActionResult actionResult = Controller.POST_FEEDBACK(doctor.doctorId, feedback);
            
            Assert.IsInstanceOfType(actionResult, typeof(BadRequestErrorMessageResult));

        }

        [TestMethod]
        public void Post_FeedbackAsync_InValid()
        {
            var MockRepo = new Mock<IDoctorDataProcessor>();
            var Controller = new DoctorsController(MockRepo.Object);
            Feedback feedback = new Feedback();
            Doctor doctor = new Doctor();
            Task<IHttpActionResult> actionResult = Controller.POST_FEEDBACK_ASYNC(doctor.doctorId, feedback);
            Assert.IsNotNull(actionResult);


        }


        [TestMethod]
        
        public void Post_Feedback_InValidWhenDoneIsFalse()
        {
            Feedback feedback = new Feedback();
            Doctor doctor=new Doctor();
            var MockRepo = new Mock<IDoctorDataProcessor>();
            MockRepo.Setup(x=>x.postFeedback(doctor.doctorId,feedback)).Returns(false);
            var Controller = new DoctorsController(MockRepo.Object);
            var res = Controller.POST_FEEDBACK(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));

        }

        [TestMethod]

        public void Post_Feedback_InValidAsyncWhenDoneIsFalse()
        {
            Feedback feedback = new Feedback();
            Doctor doctor = new Doctor();
            var MockRepo = new Mock<IDoctorDataProcessor>();
            MockRepo.Setup(x => x.postFeedbackAsync(doctor.doctorId, feedback)).ReturnsAsync(false);
            var Controller = new DoctorsController(MockRepo.Object);
            var res = Controller.POST_FEEDBACK(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));

        }

        [TestMethod]

        public void Post_Feedback_InValidModelState()
        {
            Feedback feedback = new Feedback()
            {
                doctorCompetence =  5,
                referOthers= 5,
                additionalComment= "frerffr",
                appointmentId=6
            };
            Doctor doctor = new Doctor();
            var MockRepo = new Mock<IDoctorDataProcessor>();
            //MockRepo.Setup(x => x.postFeedback(doctor.doctorId, feedback)).Returns(false);
            var Controller = new DoctorsController(MockRepo.Object);
            var res = Controller.POST_FEEDBACK(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]

        public void Post_Feedback_InValid1AsyncModelState()
        {
            Feedback feedback = new Feedback()
            {
                doctorCompetence = 5,
                referOthers = 5,
                additionalComment = "frerffr",
                appointmentId = 6
            };
            Doctor doctor = new Doctor();
            var MockRepo = new Mock<IDoctorDataProcessor>();
            //MockRepo.Setup(x => x.postFeedback(doctor.doctorId, feedback)).Returns(false);
            var Controller = new DoctorsController(MockRepo.Object);
            var res = Controller.POST_FEEDBACK_ASYNC(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(Task<IHttpActionResult>));
        }

        [TestMethod]

        public void Post_Feedback_ExceptionWhenDoneIsTrue()
        {
            Feedback feedback = new Feedback();
            Doctor doctor = new Doctor();
            var mock= new Mock<IDoctorDataProcessor>();
            mock.Setup(x => x.postFeedback(doctor.doctorId, feedback)).Returns(true);
            var Controller= new DoctorsController(mock.Object);
            var res = Controller.POST_FEEDBACK(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(IHttpActionResult));

        }

        [TestMethod]

        public void Post_Feedback_ExceptionAsyncWhenDoneIsTrue()
        {
            Feedback feedback = new Feedback();
            Doctor doctor = new Doctor();
            var mock = new Mock<IDoctorDataProcessor>();
            mock.Setup(x => x.postFeedbackAsync(doctor.doctorId, feedback)).ReturnsAsync(true);
            var Controller = new DoctorsController(mock.Object);
            var res = Controller.POST_FEEDBACK_ASYNC(doctor.doctorId, feedback);
            Assert.IsInstanceOfType(res, typeof(Task<IHttpActionResult>));

        }



    }
}
