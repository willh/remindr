package kainos.nhs.hackday.core

import kainos.nhs.hackday.model.{Kind, Reminder}
import java.util.Date


object Api {

  var data = List(
    Reminder(0, "Dr Foster", "02890 775317", Kind.Appointment, new Date),
    Reminder(1, "Dr Foster", "02890 775317", Kind.Medication, new Date),
    Reminder(2, "Dr Foster", "02890 775317", Kind.Prescription, new Date),
    Reminder(3, "Dr Finnius", "02890 221619", Kind.Appointment, new Date),
    Reminder(4, "Dr Newton", "02890 123456", Kind.Appointment, new Date)
  )

  def history : List[Reminder] = data

  def history(number: String) : List[Reminder] = data.filter(_.number.equals(number))

  def cancel(id: Int) {
    data = data.filterNot(_.id == id)
  }

  def get(id: Int) = data.find(_.id == id)
}
