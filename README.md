# VET-MODULE
Layer of Our Project:
*  ApiLayerVet
*  BussinessLayerVet
*  DalLayerVet



EndPoints :

DoctorsController:
  --> getDoctor:Doctor
  --> postDoctor(Doctor)
  --> putDoctor(Doctor)
  --> postAppointmentId(doctorId:int,appointmentId:int)

-------------------------------------------------------------------------------------------

FeedbacksController:
  --> postFeedback(Feedback)
  --> getFeedback():Feedback
