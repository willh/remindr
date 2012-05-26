package kainos.nhs.hackday.model

import java.util.Date

case class History(id: Int, user: String, number: String, kind: String, date: Date)

object Kind {
  val Appointment  = "Appointment"
  val Prescription = "Prescription"
  val Medication   = "Medication"
}
