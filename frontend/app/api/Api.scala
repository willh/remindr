package api

import java.util.Date
import play.api.libs.ws.WS
import model.{Prescription, Medication, Kind, Reminder}


object Api {

  var data = List(
    Reminder(0, "Dr Foster", "02890 775317", Kind.Appointment, new Date),
    Reminder(1, "Dr Foster", "02890 775317", Kind.Medication, new Date),
    Reminder(2, "Dr Foster", "02890 775317", Kind.Prescription, new Date),
    Reminder(3, "Dr Finnius", "02890 221619", Kind.Appointment, new Date),
    Reminder(4, "Dr Newton", "02890 123456", Kind.Appointment, new Date)
  )

  def history: List[Reminder] = data

  def history(number: String): List[Reminder] = data.filter(_.number.equals(number))

  def cancel(id: Int) {
    data = data.filterNot(_.id == id)
  }

  def get(id: Int) = data.find(_.id == id)

  def medicationReminder(med: Medication) {
    WS.url("http://nhs-hackday-backend.apphb.com/Remindr/Appointment").post(Map(
      "mobileNumber" -> Seq(med.mobile),
      "reminderStartDate" -> Seq(med.start.toString),
      "reminderEndDate" -> Seq(med.end.toString),
      "schedule" -> Seq(med.schedule),
      "message" -> Seq(med.message)
    ))
  }

  def prescriptionReminder(ps: Prescription) {
    WS.url("http://nhs-hackday-backend.apphb.com/Remindr/Appointment").post(Map(
      "mobileNumber" -> Seq(ps.mobile),
      "reminderDate" -> Seq(ps.reminderdate),
      "message" -> Seq(ps.message)
    ))
  }

  def appointment(app: Appointment) = {
    WS.url("http://nhs-hackday-backend.apphb.com/Remindr/Appointment").post(Map(
      "message"             -> Seq(app.message),
      "mobile"              -> Seq(app.mobile),
      "oneDayNotification"  -> Seq(app.oneDayNotification.toString),
      "oneWeekNotification" -> Seq(app.oneWeekNotification.toString),
      "reminderDate"        -> Seq(formatDate(app.reminderDate))
    ))
  }

  private def formatDate(date: Date) = new java.text.SimpleDateFormat("dd/MM/yyyy").format(date)
}
