package kainos.nhs.hackday.core.model

import java.util.Date

case class Medication (mobile: String, start: Date, end: Date, schedule: String, message: String)

object Schedule {
  val Daily = "Daily"
  val Weekly = "Weekly"
}
