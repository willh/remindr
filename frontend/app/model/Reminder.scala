package model

import java.util.Date

case class Reminder(id: Int, user: String, number: String, kind: String, date: Date)
case class Appointment(reminderDate: Date,message: String, mobile: String, oneWeekNotification: Boolean, oneDayNotification: Boolean)
case class Medication (mobile: String, start: Date, end: Date, schedule: String, message: String)
case class Prescription(mobile: String, reminderdate: Date, message: String)

object Schedule {
  val Daily = "Daily"
  val Weekly = "Weekly"
}

object Kind {
  val Appointment = "Appointment"
  val Prescription = "Prescription"
  val Medication = "Medication"
}
